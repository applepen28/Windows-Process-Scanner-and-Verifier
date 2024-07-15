using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Management;//wmi 
using System.Runtime.InteropServices;
using System.Threading.Tasks;// asynchronous operation

namespace windows_process_scanner
{
    // Main form class for the Windows Process Scanner application
    public partial class Form1 : Form
    {
        #region Constants
        // Text constants used for UI elements and messages
        private const string TerminateText = "Terminate";
        private const string CheckMark = "✔️";
        private const string CrossMark = "❌";
        private const string NotAvailable = "N/A";
        #endregion

        #region Fields
        // ProcessManager instance to manage and interact with system processes
        private ProcessManager processManager;
        // Flag to enable or disable highlighting of processes in the ListView based on their legitimacy
        public static bool isHighlightingEnabled = false;
        // Custom sorter for the ListView to enable sorting by column
        private ListViewColumnSorter lvwColumnSorter;
        #endregion

        #region Constructor
        public  Form1()
        {
            InitializeComponent();
            this.listView1.FullRowSelect = true; // Enable full row selection in the ListView
            SetupUI(); // Setup additional UI elements
            processManager = new ProcessManager(); // Initialize the ProcessManager
            // Load all running processes asynchronously when the form is shown
            this.Shown += async (sender, e) => await GetAllRunningProcessesAsync();
        }
        #endregion

        #region  UI setup methods
        // P/Invoke declaration for SendMessage, used to optimize ListView updates
        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        private const uint WM_SETREDRAW = 0x000B; // Message ID for setting the redraw state

        // Setup UI elements that are not part of the default form components
        private void SetupUI()
        {
            SetupFilterTextBox(); // Setup the filter text box for process filtering
            SetupContextMenu(); // Setup the context menu for the ListView
            SetupListViewSorter(); // Setup the ListView column sorter
        }

        // Setup the filter text box to respond to changes and key presses
        private void SetupFilterTextBox()
        {
            this.textBox_filter.TextChanged += textBox_filter_Click;
            this.textBox_filter.KeyDown += textBox_filter_KeyDown;
        }

        // Setup the context menu for the ListView, adding a "Terminate" option
        private void SetupContextMenu()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem terminateMenuItem = new ToolStripMenuItem("Terminate");
            terminateMenuItem.Click += Terminate_button_Click_1;
            contextMenuStrip.Items.Add(terminateMenuItem);
            listView1.ContextMenuStrip = contextMenuStrip;
        }

        // Initialize the ListViewColumnSorter and attach it to the ListView
        private void SetupListViewSorter()
        {
            this.lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = this.lvwColumnSorter;
            this.listView1.ColumnClick += ListView1_ColumnClick;
        }


        #endregion

        #region Process Management Methods
        // Refresh the legitimacy data for processes
        public void RefreshLegitProcessData()
        {
            processManager.RefreshLegitProcessData();
        }

        // Asynchronously load and display all running processes in the ListView
        public async Task GetAllRunningProcessesAsync()
        {
            try
            {
                // Temporarily disable ListView redraw to improve performance during bulk update
                SendMessage(listView1.Handle, WM_SETREDRAW, 0, 0);
                // Clear existing items to prepare for new process list
                listView1.Items.Clear();
                // Retrieve the current filter text from the UI
                var filter = textBox_filter.Text;
                // Asynchronously get all running processes from the system
                var processes = await processManager.GetAllRunningProcesses();
                // Apply the user-defined filter to the process list
                var filteredProcesses = processManager.FilterProcesses(processes, filter);
                // Prepare a list to hold ListViewItems for display
                var items = new List<ListViewItem>();
                // Convert each filtered process into a ListViewItem
                foreach (var process in filteredProcesses)
                {
                    var item = CreateListViewItem(process);
                    items.Add(item);
                }
                // Add all created ListViewItems to the ListView
                listView1.Items.AddRange(items.ToArray());

                // Re-enable ListView redraw now that updates are complete
                SendMessage(listView1.Handle, WM_SETREDRAW, 1, 0);
                // Force the ListView to repaint itself to reflect the new items
                listView1.Invalidate();
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong during the process retrieval or update
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Apply the current filter to the process list
        private async void ApplyFilter()
        {
            await GetAllRunningProcessesAsync(); ;
        }

        // Check if any items are selected in the ListView
        private bool AreItemsSelected()
        {
            return listView1.SelectedItems.Count > 0;
        }

        // Terminate all selected processes 
        private void TerminateSelectedProcesses()
        {
            // Check if any processes are selected in the ListView
            if (AreItemsSelected())
            {
                // Iterate through each selected item in the ListView
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    // Confirm with the user before terminating the process
                    if (ConfirmProcessTermination(item))
                    {
                        // Terminate the selected process
                        TerminateProcess(item);
                        // Remove the terminated process from the ListView
                        RemoveItemFromListView(item);


                    }
                }
            }
        }

        // Terminate a specific process based on the ListViewItem
        private void TerminateProcess(ListViewItem item)
        {
            int processId = int.Parse(item.SubItems[1].Text);
            processManager.TerminateProcess(processId);
        }

        // Confirm with the user before terminating a process
        private bool ConfirmProcessTermination(ListViewItem item)
        {
            // Extract the process ID from the ListViewItem's sub-item
            var processId = int.Parse(item.SubItems[1].Text);
            // Extract the process name from the ListViewItem's sub-item
            var processName = item.SubItems[0].Text;
            // Display a confirmation dialog to the user with the process name and termination action
            DialogResult result = MessageBox.Show($"Are you sure you want to {TerminateText} the process {processName}?", $"{TerminateText} Process", MessageBoxButtons.YesNo);
            // Return true if the user confirms the termination, false otherwise
            return result == DialogResult.Yes;
        }
        #endregion

        #region Listview item creation and manipulation
        // Create a ListViewItem for a process
        private ListViewItem CreateListViewItem(ManagementObject process)
        {
            ListViewItem item = new ListViewItem(process["Name"].ToString());

            string processPath = process["ExecutablePath"]?.ToString();
            bool isLegitProcess = processManager.IsLegitProcess(process["Name"].ToString());
            bool isLegitProcessPath = processManager.IsLegitProcessPath(processPath);
            bool isLegitSignature = processManager.IsLegitSignature(processPath);

            AddSubItemsToItem(item, process, isLegitProcess, isLegitProcessPath, isLegitSignature);
            SetItemColor(item, isLegitProcess, isLegitProcessPath, isLegitSignature);

            return item;
        }

        // Add sub-items to a ListViewItem for detailed process information
        private void AddSubItemsToItem(ListViewItem item, ManagementObject process, bool isLegitProcess, bool isLegitProcessPath, bool isLegitSignature)
        {
            item.SubItems.Add(process["ProcessId"].ToString());

            string processPath = process["ExecutablePath"]?.ToString();
            if (!string.IsNullOrEmpty(processPath))
            {
                item.SubItems.Add(processPath);
            }
            else
            {
                item.SubItems.Add(NotAvailable);
            }

            // Convert WorkingSetSize to KB and format it with thousands separator
            if (process["WorkingSetSize"] != null && long.TryParse(process["WorkingSetSize"].ToString(), out long workingSetSizeBytes))
            {
                long workingSetSizeKB = workingSetSizeBytes / 1024;
                string formattedMemoryUsage = $"{workingSetSizeKB:N0} KB"; // N0 format specifier adds thousands separators
                item.SubItems.Add(formattedMemoryUsage);
            }
            else
            {
                item.SubItems.Add(NotAvailable);
            }

            item.SubItems.Add(isLegitProcess ? CheckMark : CrossMark);
            item.SubItems.Add(isLegitProcessPath ? CheckMark : CrossMark);
            item.SubItems.Add(isLegitSignature ? CheckMark : CrossMark);
        }


        // Set the background color of a ListViewItem based on the legitimacy of the process
        private void SetItemColor(ListViewItem item, bool isLegitProcess, bool isLegitProcessPath, bool isLegitSignature)
        {
            int tickCount = (isLegitProcess ? 1 : 0)
                         + (isLegitProcessPath ? 1 : 0)
                         + (isLegitSignature ? 1 : 0);

            if (isHighlightingEnabled)
            {
                switch (tickCount)
                {
                    case 0:
                        item.BackColor = Color.LightPink;
                        break;
                    case 1:
                        item.BackColor = Color.LightSalmon;
                        break;
                    case 2:
                        item.BackColor = Color.LightYellow;
                        break;
                    case 3:
                        item.BackColor = Color.LightGreen;
                        break;
                }
            }
        }

        // Remove a ListViewItem from the ListView
        private void RemoveItemFromListView(ListViewItem item)
        {
            listView1.Items.Remove(item);
        }
        #endregion

        #region Event Handlers

        // Event handler for column click, sorts the ListView based on the clicked column
        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Toggle the sorting order if the same column is clicked again
                lvwColumnSorter.Order = lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                // Set the column to be sorted; default to ascending order
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.listView1.Sort();
        }
        // Event handlers for refreshing the process list
        private async void button_refresh_Click(object sender, EventArgs e)
        {
            await GetAllRunningProcessesAsync();
        }
        private async void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await GetAllRunningProcessesAsync();
        }
        // Event handler for toggling process highlighting
        private async void Highlight_checkbox_Click(object sender, EventArgs e)
        {
            isHighlightingEnabled = Highlight_checkbox.CheckState == CheckState.Checked;
            await GetAllRunningProcessesAsync();
        }
        // Event handlers for terminating selected processes
        private void Terminate_button_Click_1(object sender, EventArgs e)
        {
            TerminateSelectedProcesses();
        }
        
        private void endTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TerminateSelectedProcesses();
        }
        private void TerminateMenuItem_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TerminateSelectedProcesses();
        }


        // Event handlers for filtering processes
        private async void textBox_filter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_filter.Text))
            {
                await GetAllRunningProcessesAsync();
            }
        }
        private void textBox_filter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_applyFilter_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
        private void button_applyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // Event handler for opening the settings dialog
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new setting().ShowDialog();
        }
        // Event handler to restart the application with administrative privileges
        private void runAsAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(exeName) { Verb = "runas" });
                Application.Exit();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("Operation canceled or failed. Administrative privileges are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for exiting the application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        #endregion
    }
}
