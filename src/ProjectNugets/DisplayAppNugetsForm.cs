using ProjectNugets.Support.Dtos;
using ProjectNugets.Support.Repos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectNugets
{
    public partial class DisplayAppNugetsForm : Form
    {
        private int selectedIdx = -1;

        private string SqlProcedures = "";
        private string[] sqlProceduresAry = new string[0];
        private int iId = 8;
        private int iName = 55;
        private int iVersion = 20;
        private int iNuget = 8;
        private int itemlenAdj = 0;

        private string csvFileName = "";
        private string csvFilePath = "";
        private string csvFilePartname = "export_";
        private string csvFilePartRepo = "Main";
        private string csvFilePartLookup = "Any";
        private string csvFilePartSolution = "Solution";
        private string csvFilePartExtention = ".csv";

        public DisplayAppNugetsForm()
        {
            InitializeComponent();
            loadAppConfig();
            LoadCmbBox();
        }

        private void loadAppConfig()
        {
            SqlProcedures = ConfigurationManager.AppSettings["SqlProcedures"];
            loadSizesAppConfig();
        }
        private void loadSizesAppConfig()
        {
            iId = int.Parse(ConfigurationManager.AppSettings["iId"]);
            iName = int.Parse(ConfigurationManager.AppSettings["iName"]);
            iVersion = int.Parse(ConfigurationManager.AppSettings["iVersion"]);
            iNuget = int.Parse(ConfigurationManager.AppSettings["iNuget"]);
            itemlenAdj = 0;

        }

        private void buildcsvFileName()
        {
            if (String.IsNullOrWhiteSpace(csvFilePath))
            {
                csvFilePath = @"c:\temp";
                if (!Directory.Exists(csvFilePath))
                {
                    Directory.CreateDirectory(csvFilePath);
                }
            }
            csvFileName = Path.Combine(csvFilePath, csvFilePartname + csvFilePartRepo + csvFilePartLookup + csvFilePartSolution + csvFilePartExtention);
            txtBxFilePath.Text = csvFileName;
        }

        private void LoadCmbBox()
        {
            var SqlProceduresAry = SqlProcedures.Split(',');
            cmbBxQuery.Items.Clear();
            if (!string.IsNullOrWhiteSpace(SqlProceduresAry[0]))
                cmbBxQuery.Items.Add("");
            foreach (var SqlProc in SqlProceduresAry)
            {
               var sSqlProc = SqlProc.Replace("XxX", ",");
                cmbBxQuery.Items.Add(sSqlProc);
            }
            cmbBxQuery.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var rtnObj = new object();
            Cursor = Cursors.WaitCursor;
            try
            {
                switch (selectedIdx)
                {
                    case 1:
                        rtnObj = (List<SolutionDto>)SyncRepository.getAllSolutions();
                        displaySolutionResults((List<SolutionDto>)rtnObj);
                        break;
                    case 2:
                        rtnObj = (List<SolutionDto>)SyncRepository.getSolutionById(txtBxParams.Text);
                        displaySolutionResults((List<SolutionDto>)rtnObj);
                        break;
                    case 3:
                        rtnObj = (List<SolutionDto>)SyncRepository.getSolutionByName(txtBxParams.Text);
                        displaySolutionResults((List<SolutionDto>)rtnObj);
                        break;
                    case 4:
                        rtnObj = (List<SolutionProjectDto>)SyncRepository.getAllProjects();
                        displaySolutionProjectResults((List<SolutionProjectDto>)rtnObj);
                        break;
                    case 5:
                        rtnObj = (List<ProjectDto>)SyncRepository.getProjectById(txtBxParams.Text);
                        displayProjectResults((List<ProjectDto>)rtnObj);
                        break;
                    case 6:
                        rtnObj = (List<ProjectDto>)SyncRepository.getProjectByProjectName(txtBxParams.Text);
                        displayProjectResults((List<ProjectDto>)rtnObj);
                        break;
                    case 7:
                        var txtParam = txtBxParams.Text.Split(',');
                        rtnObj = (List<SolutionProjectDto>)SyncRepository.getProjectBySolutionAndProjectName(txtParam[0], txtParam[1]);
                        displaySolutionProjectResults((List<SolutionProjectDto>)rtnObj);
                        break;
                    case 8:
                        rtnObj = (List<NugetDto>)SyncRepository.getAllNugets();
                        displayNugetResults((List<NugetDto>)rtnObj);
                        break;
                    case 9:
                        rtnObj = (List<NugetDto>)SyncRepository.getNugetById(txtBxParams.Text);
                        displayNugetResults((List<NugetDto>)rtnObj);
                        break;
                    case 10:
                        rtnObj = (List<NugetDto>)SyncRepository.getNugetByProjectId(txtBxParams.Text);
                        displayNugetResults((List<NugetDto>)rtnObj);
                        break;
                    case 11:
                        rtnObj = (List<SolutionNugetDto>)SyncRepository.getNugetBySolutionName(txtBxParams.Text);
                        displayNugetSolutionResults((List<SolutionNugetDto>)rtnObj);
                        break;
                    case 12:
                        rtnObj = (List<SolutionNugetDto>)SyncRepository.getSolutionsByNugetName(txtBxParams.Text);
                        displayNugetSolutionResults((List<SolutionNugetDto>)rtnObj);
                        break;
                    default:
                        rtnObj = (List<NugetDto>)SyncRepository.getAllSolutions();
                        break;
                }
            }
            catch { }
            Cursor = Cursors.Default;
        }

        private int displayItemCount(int idx, int totalIdx)
        {
            var rtnidx = idx + 1;
            txtBxTotalItems.Text = totalIdx.ToString();
            txtBxCurrentItems.Text = idx.ToString();
            txtBxTotalItems.Refresh();
            txtBxCurrentItems.Refresh();
            return rtnidx;
        }

        private void resetItemCount()
        {
            txtBxResults.Text = "";
            txtBxTotalItems.Text = "0";
            txtBxCurrentItems.Text = "0";
            txtBxTotalItems.Refresh();
            txtBxCurrentItems.Refresh();
        }

        private string itemStringadj(string itemName, string item)
        {
            loadSizesAppConfig();
            if (itemName.ToLower().EndsWith("id"))
            {
                itemlenAdj = iId - item.Trim().Length;
            }
            if (itemName.ToLower().EndsWith("name"))
            {
                itemlenAdj = iName - item.Trim().Length;
            }
            if (itemName.ToLower().EndsWith("version"))
            {
                itemlenAdj = iVersion - item.Trim().Length;
            }
            if (itemName.ToLower() == "isnuget")
            {
                itemlenAdj = iNuget - item.Trim().Length;
            }
            var space = "";
            for (int i = 0; i < itemlenAdj; i++)
            {
                space += " ";
            }
            return item.Trim() + space;
        }


        private void displaySolutionResults(List<SolutionDto> list)
        {

            resetItemCount();
            int idx = 0;

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    idx = displayItemCount(idx, list.Count);

                    string dtoStr = "id = " + itemStringadj("Id", item.Id.ToString()) +
                        "SolutionName = " + itemStringadj("SolutionName", item.SolutionName) + 
                        Environment.NewLine;
                    txtBxResults.Text += dtoStr;
                }
                idx = displayItemCount(idx, list.Count);
            }
        }

        private void displayNugetSolutionResults(List<SolutionNugetDto> list)
        {
            resetItemCount();
            int idx = 0;

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    idx = displayItemCount(idx, list.Count);

                    string dtoStr = "SolutionName = " + itemStringadj("SolutionName", item.SolutionName) +
                        " ProjectName = " + itemStringadj("ProjectName", item.ProjectName)  +
                        " NetVersion = " + itemStringadj("NetVersion", item.NetVersion)  +
                        " IsNuget = " + itemStringadj("IsNuget", item.IsNuget.ToString())  +
                        " NugetName = " + itemStringadj("NugetName", item.NugetName)  +
                        " NugetVersion = " + itemStringadj("NugetVersion", item.NugetVersion)  +
                        Environment.NewLine;
                    txtBxResults.Text += dtoStr;
                }
                idx = displayItemCount(idx, list.Count);
            }
        }

        private void displayProjectResults(List<ProjectDto> list)
        {
            resetItemCount();
            int idx = 0;

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    idx = displayItemCount(idx, list.Count);

                    string dtoStr = "id = " + itemStringadj("Id", item.Id.ToString()) +
                        " SolutionId = " + itemStringadj("SolutionId", item.SolutionId.ToString()) +
                        " ProjectName = " + itemStringadj("ProjectName", item.ProjectName) +
                        " NetVersion = " + itemStringadj("NetVersion", item.NetVersion) +
                        " IsNuget = " + itemStringadj("IsNuget", item.IsNuget.ToString()) +
                        Environment.NewLine;
                    txtBxResults.Text += dtoStr;
                }
                idx = displayItemCount(idx, list.Count);
            }
        }

        private void displaySolutionProjectResults(List<SolutionProjectDto> list)
        {
            resetItemCount();
            int idx = 0;

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    idx = displayItemCount(idx, list.Count);

                    string dtoStr = "id = " + itemStringadj("Id", item.Id.ToString()) +
                        "SolutionName = " + itemStringadj("SolutionName", item.SolutionName) +
                        " ProjectId = " + itemStringadj("ProjectId", item.ProjectId.ToString()) +
                        " ProjectName = " + itemStringadj("ProjectName", item.ProjectName) +
                        " NetVersion = " + itemStringadj("NetVersion", item.NetVersion) +
                        " IsNuget = " + itemStringadj("IsNuget", item.IsNuget.ToString()) +
                        Environment.NewLine;
                    txtBxResults.Text += dtoStr;
                }
                idx = displayItemCount(idx, list.Count);
            }
        }

        private void displayNugetResults(List<NugetDto> list)
        {
            resetItemCount();
            int idx = 0;

            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    idx = displayItemCount(idx, list.Count);

                    string dtoStr = "id = " + itemStringadj("Id", item.Id.ToString()) +
                        " ProjectId = " + itemStringadj("ProjectId", item.ProjectId.ToString()) +
                        " NugetName = " + itemStringadj("NugetName", item.NugetName) +
                        " NugetVersion = " + itemStringadj("NugetVersion", item.NugetVersion) +
                        " ProjectName = " + item.ProjectId.ToString() +
                        " NugetVersion = " + item.NugetVersion +
                        Environment.NewLine;
                    txtBxResults.Text += dtoStr;
                }
                idx = displayItemCount(idx, list.Count);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIdx = cmbBxQuery.SelectedIndex;
            csvFilePartLookup = cmbBxQuery.SelectedItem.ToString();
            buildcsvFileName();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBxResults.Text = "";
            if (cmbBxElement.SelectedIndex > 0)
            {
                if (rdbtnNuget.Checked)
                {
                    var nugetList = SyncRepository.getSolutionsByNugetName(cmbBxElement.Text);
                    if (nugetList != null)
                        displayNugetSolutionResults((List<SolutionNugetDto>)nugetList.ToList());
                }
                if (rdBtnSolution.Checked)
                {
                    var nugetList = SyncRepository.getNugetBySolutionName(cmbBxElement.Text);
                    if (nugetList != null)
                        displayNugetSolutionResults((List<SolutionNugetDto>)nugetList.ToList());
                }
                csvFilePartLookup = cmbBxElement.Text;
                buildcsvFileName();
            }
        }

        private void rdBtnAny_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnAny.Checked)
            {
                lblElement.Enabled = false;
                cmbBxElement.Enabled = false;
                cmbBxElement.SelectedIndex = 0;
                pnlQuery.Enabled = true;
                csvFilePartLookup = "Any";
                buildcsvFileName();
            }
        }

        private void rdbtnNuget_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnNuget.Checked)
            {
                var nugetList = (List<NugetDto>)SyncRepository.getAllNugets();
                cmbBxElement.Items.Clear();
                cmbBxElement.Items.Add("");
                foreach (var nuget in nugetList)
                {
                    if (!cmbBxElement.Items.Contains(nuget.NugetName))
                        cmbBxElement.Items.Add(nuget.NugetName);
                }
                lblElement.Enabled = true;
                cmbBxElement.Enabled = true;
                cmbBxElement.SelectedIndex = 0;
                pnlQuery.Enabled = false;
                csvFilePartLookup = "Nuget";
                buildcsvFileName();
            }
        }

        private void rdBtnSolution_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtnSolution.Checked)
            {
                var solutionList = (List<SolutionDto>)SyncRepository.getAllSolutions();
                cmbBxElement.Items.Clear();
                cmbBxElement.Items.Add("");
                foreach (var solution in solutionList)
                {
                    if (!cmbBxElement.Items.Contains(solution.SolutionName))
                        cmbBxElement.Items.Add(solution.SolutionName);
                }
                lblElement.Enabled = true;
                cmbBxElement.Enabled = true;
                cmbBxElement.SelectedIndex = 0;
                pnlQuery.Enabled = false;
                csvFilePartLookup = "Solution";
                buildcsvFileName();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ProjectNugetForm pnf = new ProjectNugetForm();
            pnf.ShowDialog();
        }

        private void rdBtnMain_CheckedChanged(object sender, EventArgs e)
        {
            SyncRepository.nuget = "NugetsMain";
            SyncRepository.project = "ProjectsMain";
            SyncRepository.solution = "SolutionsMain";
            csvFilePartRepo = "Main";
            buildcsvFileName();
        }

        private void rdBtnUpgrade_CheckedChanged(object sender, EventArgs e)
        {
            SyncRepository.nuget = "NugetsUpgrade";
            SyncRepository.project = "ProjectsUpgrade";
            SyncRepository.solution = "SolutionsUpgrade";
            csvFilePartRepo = "Upgrade";
            buildcsvFileName();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                csvFilePath = dialog.SelectedPath;
                buildcsvFileName();
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtBxResults.Text))
            {
                var resultText = txtBxResults.Text;
                while (resultText.Contains("  "))
                {
                    resultText = resultText.Replace("  ", " ");
                }
                resultText = resultText.Replace(" ", ",");
                resultText = resultText.Replace(",=,", " = ");
                File.WriteAllText(csvFileName, resultText);
            }
        }

        private void txtBxResults_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSrch_Click(object sender, EventArgs e)
        {
            SearchTextForm srch = new SearchTextForm();
            srch.Show();
        }
    }
}
