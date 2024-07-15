using System;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;


namespace windows_process_scanner
{
    public partial class setting : Form
    {
        // FileHandler instance to handle file operations
        private FileHandler fileHandler;

        public setting()
        {
            InitializeComponent();
            // Initialize FileHandler
            fileHandler = new FileHandler();
            // Load items from file
            LoadItemsFromFile();
        }

        // Method to load items from file
        private void LoadItemsFromFile()
        {
            listBoxPath.Items.AddRange(fileHandler.ReadFromFile("legitProcessPaths.txt"));
            listboxname.Items.AddRange(fileHandler.ReadFromFile("legitProcessNames.txt"));
        }

        // Event handler for add name button click
        private void addname_Click(object sender, EventArgs e)
        {
            AddItem("Please enter a name", "Add Name", listboxname);
        }

        // Event handler for remove name button click
        private void remove_name_Click(object sender, EventArgs e)
        {
            RemoveItem("Please select a name to remove.", "Remove Name", listboxname);
        }

        // Event handler for add path button click
        private void addPath_Click(object sender, EventArgs e)
        {
            AddItem("Please enter a path", "Add Path", listBoxPath, true);
        }

        // Event handler for remove path button click
        private void removePath_Click(object sender, EventArgs e)
        {
            RemoveItem("Please select a path to remove.", "Remove Path", listBoxPath);
        }

        private bool IsUserAdministrator()
        {
            bool isAdmin;
            try
            {
                // Get the currently logged in user
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
            {
                isAdmin = false;
            }
            return isAdmin;
        }


        // Method to add item to list box
        private void AddItem(string prompt, string title, ListBox listBox, bool isPath = false)
        {
            if (!IsUserAdministrator())
            {
                MessageBox.Show("You need administrative privileges to add items.", "Administrative Access Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, "", -1, -1);
            if (isPath ? string.IsNullOrWhiteSpace(input) || !System.IO.Path.IsPathRooted(input) : string.IsNullOrWhiteSpace(input) || input.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show($"Please enter a valid {title.ToLower()}");
                return;
            }

            listBox.Items.Add(input);
            SaveChanges();
        }


        // Method to remove item from list box
        private void RemoveItem(string prompt, string title, ListBox listBox)
        {
            if (!IsUserAdministrator())
            {
                MessageBox.Show("You need administrative privileges to remove items.", "Administrative Access Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBox.SelectedItem == null)
            {
                MessageBox.Show(prompt);
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to remove this {title.ToLower()}?", title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                listBox.Items.Remove(listBox.SelectedItem);
                SaveChanges();
            }
        }


        // Method to save changes to file
        // Method to save changes to file
        private void SaveChanges()
        {
            fileHandler.SaveToFile("legitProcessPaths.txt", listBoxPath.Items.Cast<string>());
            fileHandler.SaveToFile("legitProcessNames.txt", listboxname.Items.Cast<string>());
            RefreshMainForm();
        }


        // Method to refresh main form
        private async void RefreshMainForm()
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.RefreshLegitProcessData();
                // In the setting.cs file
                await mainForm.GetAllRunningProcessesAsync();

            }
        }

       
    }
}
