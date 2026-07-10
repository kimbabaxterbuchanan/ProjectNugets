using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNugets
{
    public partial class SearchTextForm : Form
    {
        private String[] solutionList;
        private List<String> searchExtensions = new List<string>();
        private List<String> omitFolders = new List<string>();

        private int fileCount = 0;

        public SearchTextForm()
        {
            InitializeComponent();
            loadDefaults();

        }

        private void loadDefaults()
        {
            searchExtensions.Add(".js");
            searchExtensions.Add(".cs");
            searchExtensions.Add(".aspx");
            searchExtensions.Add(".html");
            searchExtensions.Add(".xaml");
            searchExtensions.Add(".ts");
            searchExtensions.Add(".css");
            omitFolders.Add(".vs");
            omitFolders.Add(".git");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //            searchforNugets();
            //        }
            txtBxStatus.Text = "Start list" + Environment.NewLine;
            fileCount = 0;
            txtBxFileCount.Text = fileCount.ToString();
            txtBxStatus.Refresh();
            txtBxFileCount.Refresh();
            getAllSolutions();
            foreach (string path in solutionList)
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    ProcessFile(path);
                }
                else if (Directory.Exists(path) )
                {
                    txtBxSolution.Text = path;
                    txtBxSolution.Refresh();

                    // This path is a directory
                    ProcessDirectory(path);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
            }
            txtBxStatus.Text += "End list" + Environment.NewLine;
            txtBxStatus.Refresh();
        }

        // Process all files in the directory passed in, recurse on any directories
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                fileCount++;
                txtBxFileCount.Text = fileCount.ToString();
                txtBxFileCount.Refresh();
                FileInfo fileInf = new FileInfo(fileName);
                if (searchExtensions.Contains(fileInf.Extension))
                {
                    ProcessFile(fileName);
                }
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                DirectoryInfo dirinf = new DirectoryInfo(subdirectory);

                if (!omitFolders.Contains(dirinf.Name)){
                    ProcessDirectory(subdirectory);
                }
            }
        }

        // Insert logic for processing found files here.
        public void ProcessFile(string path)
        {
            var searchtext = File.ReadAllLines(path);
            foreach (var srchtxt in searchtext)
            {
                if (srchtxt.ToLower().Contains(txtBxText.Text.ToLower()))
                {
                    txtBxStatus.Text += String.Format("Processed file '{0}'.", path) + Environment.NewLine;
                    txtBxStatus.SelectionStart = txtBxStatus.TextLength;
                    txtBxStatus.ScrollToCaret();
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            txtBxText.Text = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBxProjectRepo.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void searchforNugets()
        {

            txtBxProjectRepo.Text = "";
            Application.DoEvents();
            txtBxProjectRepo.Text = folderBrowserDialog1.SelectedPath;
            txtBxProjectRepo.Refresh();
            getAllSolutions();
            if (solutionList != null && solutionList.Length > 0)
            {
                foreach (String solution in solutionList)
                {
                }
            }
        }

        private void getAllSolutions()
        {
            solutionList = getSolutioneList(txtBxProjectRepo.Text);
        }
        private String[] getSolutioneList(String sDir)
        {
            try
            {
                string[] filePaths = Directory.GetDirectories(sDir);
                return filePaths;
            }
            catch { }
            return new string[1] { "" };
        }
        
        private void getfiles(string sDir)
        {
            String[] fileList = Directory.GetFiles(sDir);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
