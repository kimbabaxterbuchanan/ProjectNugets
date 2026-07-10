using ProjectNugets.Support.Dtos;
using ProjectNugets.Support.Repos;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;

using System.Diagnostics;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

using System.Windows;


namespace ProjectNugets
{
    public partial class ProjectNugetForm : Form
    {
        private String[] solutionList;

        private bool bSolutionInsert = true;

        private String solutionId = "0";
        private String solutionName = "";
        private string projectId = "0";
        private string projectName = "";
        private string projectPath = "";
        private string netVersion = "";
        private string isNuget = "0";

        private string nugetId = "0";
        private string nugetName = "";
        private string nugetPath = "";
        private string nugetVersion = "";

        private string versionGroupName = "";
        private string versionFrameworkName = "";
        private string generatePackageOnBuild = "";
        private string versionCoreName = "";
        private string nugetGroupName = "";
        private string nugetNetElementName = "";
        private string nugetNetElementNodeName = "";
        private string nugetCoreElementName = "";
        private string nugetCoreElementNodeName = "";
        private string nugetNodeName = "";
        private string nugetNodeVersion = "";

        private bool bSaveToDB = true;
        private string dllSearchTxt = "";

        private string repoSection = "Main";

        public ProjectNugetForm()
        {
            InitializeComponent();
            loadAppConfig();
        }

        private void loadAppConfig()
        {

            versionGroupName = ConfigurationManager.AppSettings["versionGroupName"];
            versionFrameworkName = ConfigurationManager.AppSettings["versionFrameworkName"];
            generatePackageOnBuild = ConfigurationManager.AppSettings["generatePackageOnBuild"];
            versionCoreName = ConfigurationManager.AppSettings["versionCoreName"];
            nugetGroupName = ConfigurationManager.AppSettings["nugetGroupName"];
            nugetNetElementName = ConfigurationManager.AppSettings["nugetNetElementName"];
            nugetNetElementNodeName = ConfigurationManager.AppSettings["nugetNetElementNodeName"];
            nugetCoreElementName = ConfigurationManager.AppSettings["nugetNetCoreElementName"];
            nugetCoreElementNodeName = ConfigurationManager.AppSettings["nugetCoreElementNodeName"];
            nugetNodeName = ConfigurationManager.AppSettings["nugetNodeName"];
            nugetNodeVersion = ConfigurationManager.AppSettings["nugetNodeVersion"];
            btnPullRepos.Enabled = false;
            pnlSearch.Enabled = true;
            SyncRepository.nuget = "NugetsMain";
            SyncRepository.project = "ProjectsMain";
            SyncRepository.solution = "SolutionsMain";
            repoSection = "Main";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            panelGetRepo.Visible = false;
            panelGetRepo.SendToBack();
            btnPullRepos.Enabled = false;
            bSaveToDB = true;
            dllSearchTxt = "";
            searchforNugets();
        }

        private void searchforNugets()
        { 
            txtBxProjectRepo.Text = "";
            txtBxSolutions.Text = "";
            txtBxReference.Text = "";
            Application.DoEvents();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBxProjectRepo.Text = folderBrowserDialog1.SelectedPath;
                txtBxProjectRepo.Refresh();
                getAllSolutions();
                if (solutionList != null && solutionList.Length > 0)
                {
                    foreach (String solution in solutionList)
                    {
                        projectId = "0";
                        solutionName = "";
                        projectName = "";
                        projectPath = "";
                        netVersion = "";
                        isNuget = "0";

                        nugetId = "0";
                        nugetName = "";
                        nugetPath = "";
                        nugetVersion = "";

                        solutionName = Path.GetFileName(solution);

                        if (!solutionName.StartsWith("."))
                        {
                            bSolutionInsert = true;
                            DirectoryInfo solutionDir = new DirectoryInfo(solution);
                            if (bSaveToDB)
                            {
                                txtBxProject.Text = "";
                                txtBxReference.Text = "";
                            }
                            txtBxSolutions.Text += solutionName + "\t" + solution + Environment.NewLine;
                            txtBxSolutions.SelectionStart = txtBxSolutions.Text.Length;
                            txtBxSolutions.ScrollToCaret();
                            txtBxSolutions.Refresh();

                            Application.DoEvents();
                            var projectList = getProjectList(solution);
                            var nuspecList = getNuSpecList(solution);
                            if (projectList != null && projectList.Length > 0)
                            {
                                foreach (String project in projectList)
                                {
                                    projectName = Path.GetFileName(project).Replace(".csproj", "");
                                    projectPath = project.Replace(txtBxProjectRepo.Text + "\\", "").Replace(".csproj", "");

                                    txtBxProject.Text += projectName + "\t" + projectPath + Environment.NewLine;
                                    txtBxProject.SelectionStart = txtBxProject.Text.Length;
                                    txtBxProject.ScrollToCaret();
                                    txtBxProject.Refresh();
                                    if (bSaveToDB)
                                    {
                                        var projectEnum = (List<SolutionProjectDto>)SyncRepository.getProjectBySolutionAndProjectName(solutionName, projectName);
                                        if (projectEnum != null)
                                        {
                                            int rtnId = getSolutionProjectFromEnum((List<SolutionProjectDto>)projectEnum);
                                            if (rtnId > 0)
                                            {
                                                projectId = rtnId.ToString();
                                            }
                                        }
                                    }
                                    if (!projectName.ToLower().Contains("test") || !bSaveToDB)
                                    {
                                        Read(project);
                                    }
                                }
                                foreach (string nuspec in nuspecList)
                                {
                                    var readLines = File.ReadAllLines(nuspec);
                                    foreach (string line in readLines)
                                    {
                                        if (line.Length > 0 && line.Trim().ToLower().StartsWith("<file "))
                                        {
                                            var targetList = line.Split('\\');
                                            var target = targetList[targetList.Length-1];
                                            target = target.Substring(0, target.LastIndexOf("."));
                                            SyncRepository.UpdateIsNugetNameVersion(target, solutionId);
                                        }
                                    }
                                }
                            }
                        }
                    }
//                    SyncRepository.UpdateIsNuget();
                }
                txtBxSolutions.Text += "Completed Load";
                txtBxSolutions.SelectionStart = txtBxSolutions.Text.Length;
                txtBxSolutions.ScrollToCaret();
                txtBxProject.SelectionStart = txtBxProject.Text.Length;
                txtBxProject.ScrollToCaret();
                txtBxReference.SelectionStart = txtBxReference.Text.Length;
                txtBxReference.ScrollToCaret();
            }
        }

        private int getSolutionProjectFromEnum(List<SolutionProjectDto> dtos)
        {
            if (dtos != null && dtos.Count > 0)
            {
                try
                {
                    return dtos[0].ProjectId;
                }
                catch { }
            }
            return -1;
        }

        private int getProjectFromEnum(List<ProjectDto> dtos)
        {
            if (dtos != null && dtos.Count > 0)
            {
                try
                {
                    return dtos[0].Id;
                }
                catch { }
            }
            return - 1;
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
        private String[] getProjectList(String sDir)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(sDir, "*.csproj", SearchOption.AllDirectories);
                return filePaths;
            }
            catch { }
            return new string[1] { "" };
        }

        private String[] getNuSpecList(String sDir)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(sDir, "*.nuspec", SearchOption.AllDirectories);
                return filePaths;
            }
            catch { }
            return new string[1] { "" };
        }

        public void Read(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);
            bool bVersionFound = false;
            netVersion = "";

            foreach (XElement el in doc.Root.Elements())
            {
                try
                {
                    if (el.Name.LocalName == versionGroupName && !bVersionFound && el.HasElements)
                    {
                        foreach (XElement el2 in el.Elements())
                        {
                            if (String.IsNullOrEmpty(netVersion) && (el2.Name.ToString().Contains(versionFrameworkName) || el2.Name.ToString().Contains(versionCoreName)))
                            {
                                bVersionFound = true;
                                netVersion = el2.FirstNode.ToString();
                                if (bSaveToDB)
                                {
                                    if (bSolutionInsert == true)
                                    {
                                        var iSolutionId = SyncRepository.UpSertSolution("0", solutionName);
                                        solutionId = iSolutionId.ToString();
                                        bSolutionInsert = false;
                                    }
                                    if (!netVersion.ToLower().StartsWith("net"))
                                    {
                                        var iProjectId = SyncRepository.UpSertProject("0", solutionId, projectName, projectPath, netVersion, isNuget);
                                        projectId = iProjectId.ToString();
                                        break;
                                    }
                                }
                               
                            }
                            else if (netVersion.ToLower().StartsWith("net"))
                            {
                                if (el2.Name.ToString().Contains(generatePackageOnBuild))
                                {
                                    var isNugetString = el2.FirstNode.ToString();
                                    isNuget = isNugetString.ToLower() == "true" ? "1" : "0";
                                }
                            }
                        }
                        if (netVersion.ToLower().StartsWith("net") && !String.IsNullOrWhiteSpace(netVersion)) 
                        {
                            var iProjectId = SyncRepository.UpSertProject("0", solutionId, projectName, projectPath, netVersion, isNuget);
                            projectId = iProjectId.ToString();
                        }
                    }
      
                    else if (el.Name.LocalName == nugetGroupName && bVersionFound && el.HasElements)
                    {
                        if (el.Elements().FirstOrDefault().ToString().Contains(nugetNetElementName) || el.Elements().FirstOrDefault().ToString().Contains(nugetCoreElementName))
                        {
                            foreach (XElement el2 in el.Elements())
                            {
                                nugetId = "0";
                                nugetName = "";
                                nugetPath = "";
                                nugetVersion = "";
                                if (el2.Name.LocalName == nugetNetElementName || el2.Name.LocalName == nugetCoreElementName)
                                {
                                    if (el2.HasAttributes)
                                    {
                                        foreach (XAttribute attr in el2.Attributes())
                                        {
                                            var attrSplit = attr.ToString().Split(' ');
                                            if (attrSplit.Length > 2)
                                            {
                                                foreach (string attr2 in attrSplit)
                                                {
                                                    getNodeValue(attr2);
                                                }
                                            }
                                            else
                                            {
                                                getNodeValue(attrSplit[0]);
                                            }
                                            if (el2.HasElements)
                                            {
                                                var el3 = (XElement)el2.FirstNode;
                                                nugetPath = el3.Value;
                                                if (String.IsNullOrEmpty(nugetPath) || nugetPath.Length < 20)
                                                {
                                                    el3 = (XElement)el2.NextNode;
                                                    if (el3 != null)
                                                    {
                                                        nugetPath = el3.Value;
                                                    }
                                                }
                                                if (String.IsNullOrWhiteSpace(dllSearchTxt) || nugetName.ToLower().Contains(dllSearchTxt))
                                                    txtBxReference.Text += string.Format("   Package: {0}", nugetPath) + Environment.NewLine;
                                            }
                                            if (!string.IsNullOrEmpty(nugetVersion) && bSaveToDB && nugetPath.ToLower().Contains("\\packages\\"))
                                            {
                                                SyncRepository.upSertNuget("0", projectId, nugetName.Replace(",", ""), nugetPath, nugetVersion);
                                            }
                                            else if (netVersion.ToLower().StartsWith("net"))
                                            {
                                                if (!string.IsNullOrEmpty(nugetVersion) && bSaveToDB)
                                                {
                                                    SyncRepository.upSertNuget("0", projectId, nugetName.Replace(",", ""), nugetPath, nugetVersion);
                                                }
                                            }
                                            txtBxReference.SelectionStart = txtBxReference.Text.Length;
                                            txtBxReference.ScrollToCaret();
                                            txtBxReference.Refresh();

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch { }
                txtBxReference.Refresh();
            }
        }

        private void getNodeValue(String attr2)
        {
            if (attr2.Contains("="))
            {
                var splitattr2 = attr2.Split('=');
                if (splitattr2[0] == nugetNodeName)
                {
                    nugetName = splitattr2[1].Replace("\"", "");
                    if (String.IsNullOrWhiteSpace(dllSearchTxt) || nugetName.ToLower().Contains(dllSearchTxt))
                        if (nugetName.ToLower().Contains(dllSearchTxt))
                        {
                            txtBxReference.Text += solutionName + " ";
                            txtBxReference.Text += projectName + " ";
                            txtBxReference.Text += string.Format("   Nuget: {0}", nugetName) + Environment.NewLine;
                        }
                    if (String.IsNullOrWhiteSpace(dllSearchTxt))
                        txtBxReference.Text += string.Format("   Nuget: {0}", nugetName) + Environment.NewLine;
                }
                if (splitattr2[0] == nugetNodeVersion)
                {
                    nugetVersion = splitattr2[1].Replace("\"", "");
                    if (String.IsNullOrWhiteSpace(dllSearchTxt) || nugetName.ToLower().Contains(dllSearchTxt))
                        txtBxReference.Text += string.Format("   Version: {0}", nugetVersion) + Environment.NewLine;
                }
            }
        }

        private void btnUpdateNugets_Click(object sender, EventArgs e)
        {
            panelGetRepo.Visible = false;
            panelGetRepo.SendToBack();
            pnlSearch.Enabled = true;
            SyncRepository.UpdateIsNuget();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayAppNugetsForm danf = new DisplayAppNugetsForm();
            danf.ShowDialog();
        }

        private void btnDllSearch_Click(object sender, EventArgs e)
        {
            bSaveToDB = false;
            dllSearchTxt = txtBxDLLName.Text.ToLower();
            searchforNugets();
        }

        private void btnCreateTables_Click(object sender, EventArgs e)
        {
            pnlSearch.Enabled = true;
            panelGetRepo.Visible = false;
            panelGetRepo.SendToBack();

            createrTables();
        }
        private void createrTables()
        {
            txtBxSolutions.Text = "Creating Nugets Table " + repoSection + Environment.NewLine;
            txtBxSolutions.Refresh();
            SyncRepository.createNugetsTable();
            txtBxSolutions.Text += "Creating Projects Table " + repoSection + Environment.NewLine;
            txtBxSolutions.Refresh();
            SyncRepository.createProjectsTable();
            txtBxSolutions.Text += "Creating Solutions Table " + repoSection + Environment.NewLine;
            txtBxSolutions.Refresh();
            SyncRepository.createSolutionsTable();
            txtBxSolutions.Text += "All tables created for " + repoSection + Environment.NewLine;
            txtBxSolutions.Refresh();
            txtBxSolutions.Text += "If you have not downloaded projects to scan for nugets" + Environment.NewLine;
            txtBxSolutions.Refresh();
            txtBxSolutions.Text += "Modify the PowerShellScripts CloneAllRepos.Config with required settings" + Environment.NewLine;
            txtBxSolutions.Refresh();
            txtBxSolutions.Text += "Open a powershell command window and execute the PowerShellScripts/getallRepos.ps1" + Environment.NewLine;
            txtBxSolutions.Refresh();
            txtBxSolutions.Text += "Use Browser Button and select the Project folder to start Project Nuget Scan" + Environment.NewLine;
            txtBxSolutions.Refresh();
        }

        private void btnGetRepo_Click(object sender, EventArgs e)
        {
            pnlSearch.Enabled = false;
            var ps1File = Application.StartupPath + @"\PowerShellScripts\";
            string[] psList = Directory.GetFiles(ps1File);
            cmbBxPS.Items.Clear();
            foreach (var ps in psList)
            {
                var psName = ps.Replace(ps1File, "");
                cmbBxPS.Items.Add(psName);
            }
            panelGetRepo.Visible = true;
            panelGetRepo.BringToFront();
        }
        internal async Task executePowerShell(TextBox text)
        {
            TextBoxStatusDispatcher("Starting Pulling Repos...." + Environment.NewLine);
            PowerShell ps = PowerShell.Create();
            ps.AddScript(txtBxScript.Text);
            ps.Streams.Progress.DataAdded += MyUpdateText;
//            PSDataCollection<string> input = null;
//            PSDataCollection<string> pSDataCollection = new PSDataCollection<string>();
//            PSDataCollection<string> output = pSDataCollection;

            ps.Invoke();
            TextBoxStatusDispatcher("Finished Pulling Repos...." + Environment.NewLine);
        }
        private void MyUpdateText(object sender, DataAddedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((Action<object, DataAddedEventArgs>)MyUpdateText, sender, e);
                return;
            }
            ProgressRecord newRecord = ((PSDataCollection<ProgressRecord>)sender)[e.Index];
            TextBoxStatusDispatcher(newRecord.Activity);
        }
        private void TextBoxStatusDispatcher(string text, bool append = true)
        {
            if (text.ToLower().StartsWith("reading "))
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke((Action<String,bool>)TextBoxStatusDispatcher, text, append);
                return;
            }
            if (append)
            {
                txtBxStatus.Text += text;
            }
            else
            {
                txtBxStatus.Text = text;
            }
            txtBxStatus.Text += Environment.NewLine;
            txtBxStatus.Refresh();
        }
        private void executePS()
        {
            try
            {
                txtBxStatus.Text = "Starting PS" + Environment.NewLine;

                // create Powershell runspace
                Runspace runspace = RunspaceFactory.CreateRunspace();

                // open it
                runspace.Open();

                // create a pipeline and feed it the script text
                Pipeline pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(txtBxScript.Text);

                // add an extra command to transform the script output objects into nicely formatted strings
                // remove this line to get the actual objects that the script returns. For example, the script
                // "Get-Process" returns a collection of System.Diagnostics.Process instances.
                pipeline.Commands.Add("Out-String");

                // execute the script
                Collection<PSObject> results = pipeline.Invoke();

                // close the runspace
                runspace.Close();

                // convert the script result into a single string
                StringBuilder stringBuilder = new StringBuilder();
                foreach (PSObject obj in results)
                {
                    txtBxStatus.Text += obj.ToString();
                }
            } catch (Exception ex)
            {
                txtBxStatus.Text = ex.Message;
            }
        }

        private void btnPullRepos_Click(object sender, EventArgs e)
        {
            var psScript = cmbBxPS.SelectedItem.ToString();
            var ps1File = Application.StartupPath + @"\PowerShellScripts\" + psScript;
            
            txtBxScript.Text = "";

            var lines = File.ReadAllLines(ps1File);
            foreach (var line in lines)
            {
                txtBxScript.Text += line + Environment.NewLine;
            }
            pnlSearch.Enabled = true;
        }

        private void panelGetRepo_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnExecute_Click(object sender, EventArgs e)
        {
            //           executePowerShell();
            txtBxStatus.Text = "";
            await Task.Run(() => executePowerShell(txtBxStatus));

        }

        private void cmbBxPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPullRepos.Enabled = cmbBxPS.SelectedIndex != -1;
        }

        private void rdBtnMain_CheckedChanged(object sender, EventArgs e)
        {
            pnlSearch.Enabled = true;
            SyncRepository.nuget = "NugetsMain";
            SyncRepository.project = "ProjectsMain";
            SyncRepository.solution = "SolutionsMain";
            repoSection = "Main";
        }

        private void rdBtnUpgrade_CheckedChanged(object sender, EventArgs e)
        {
            pnlSearch.Enabled = true;
            SyncRepository.nuget = "NugetsUpgrade";
            SyncRepository.project = "ProjectsUpgrade";
            SyncRepository.solution = "SolutionsUpgrade";
            repoSection = "Upgrade";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
