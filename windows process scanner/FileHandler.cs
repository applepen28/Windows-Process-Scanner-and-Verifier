using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace windows_process_scanner
{
    // Class to handle file operations
    public class FileHandler
    {
        // Method to initialize a HashSet from a file, or create the file with default values if it doesn't exist
        public HashSet<string> InitializeHashSet(string fileName, HashSet<string> defaultValues)
        {
            // Combine the application startup path with the file name to get the full file path
            var filePath = Path.Combine(Application.StartupPath, fileName);


            // If the file doesn't exist, create it and write the default values to it
            if (!File.Exists(filePath))
            {
                File.WriteAllLines(filePath, defaultValues);
                return defaultValues;
            }
            else
            {
                // If the file exists, try to read it and return a HashSet of its lines
                try
                {
                    return new HashSet<string>(File.ReadAllLines(filePath));
                }
                // If an error occurs while reading the file, show an error message and return the default values
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading {fileName}: " + ex.Message);
                    return defaultValues;
                }
            }
        }

        // Method to save data to a file
        public void SaveToFile(string fileName, IEnumerable<string> data)
        {
            File.WriteAllLines(fileName, data);
        }

        // Method to read data from a file
        public string[] ReadFromFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }
    }
}
