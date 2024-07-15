using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace windows_process_scanner
{
    // Class to evaluate processes
    public class ProcessEvaluator
    {
        // Set of legitimate process names
        private readonly HashSet<string> legitProcessNames;
        // Set of legitimate process paths
        private readonly HashSet<string> legitProcessPaths;

        // Constructor initializes legitimate process names and paths
        public ProcessEvaluator(HashSet<string> legitProcessNames, HashSet<string> legitProcessPaths)
        {
            // Throw ArgumentNullException if the provided sets are null
            this.legitProcessNames = legitProcessNames ?? throw new ArgumentNullException(nameof(legitProcessNames));
            this.legitProcessPaths = legitProcessPaths ?? throw new ArgumentNullException(nameof(legitProcessPaths));
        }

        // Method to check if a process is legitimate based on its name
        public bool IsLegitProcess(string processName)
        {
            // Check if the process name is null or empty
            if (string.IsNullOrWhiteSpace(processName))
            {
                return false;
            }

            // Check if the process name exists in the set of legitimate process names
            return legitProcessNames.Contains(processName);
        }


        // Method to check if a process is legitimate based on its path
        public bool IsLegitProcessPath(string processPath)
        {
            if (string.IsNullOrWhiteSpace(processPath))
            {
                return false;
            }

            foreach (var legitPath in legitProcessPaths)
            {
                if (processPath.StartsWith(legitPath, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }


        // Method to check if a process has a legitimate signature based on its path
        public bool IsLegitSignature(string processPath)
        {
            // Return false if the process path is null or empty
            if (string.IsNullOrEmpty(processPath))
            {
                return false;
            }

            try
            {
                // Validate the digital signature of the process
                return ValidateCertificate(processPath);
            }
            catch (CryptographicException)
            {
                // Handle the case where the file does not contain a digital signature
                Console.WriteLine($"The file {processPath} does not contain a digital signature.");
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions and log the error message
                Console.WriteLine($"An error occurred while checking the digital signature of the file {processPath}. Error: {ex.Message}");
                return false;
            }
        }

        // Validates the digital certificate of a process
        private bool ValidateCertificate(string processPath)
        {
            // Load the certificate from the process path and set up the certificate chain
            using (X509Certificate2 cert = new X509Certificate2(processPath))
            using (X509Chain chain = new X509Chain())
            {
                // Configure the chain policy
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;

                // Build the certificate chain and check its validity
                bool isChainValid = chain.Build(cert);

                // Check if the certificate is valid and issued by a trusted authority
                if (!isChainValid || cert.NotAfter < DateTime.Now || !IsCertificateIssuedByTrustedAuthority(chain))
                {
                    Console.WriteLine($"The file {processPath} does not contain a valid digital signature.");
                    return false;
                }

                return true;
            }
        }

        // Method to check if a certificate is issued by a trusted authority
        private bool IsCertificateIssuedByTrustedAuthority(X509Chain chain)
        {
            // Iterate through the chain elements to verify each certificate
            foreach (X509ChainElement chainElement in chain.ChainElements)
            {
                if (!chainElement.Certificate.Verify())
                {
                    // Verify the certificate and check if it's issued by a trusted authority
                    Console.WriteLine($"The certificate is not issued by a trusted authority.");
                    return false;
                }
            }

            return true;
        }
    }
}
