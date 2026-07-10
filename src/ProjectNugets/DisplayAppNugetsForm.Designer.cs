namespace ProjectNugets
{
    partial class DisplayAppNugetsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblResults = new System.Windows.Forms.Label();
            this.txtBxResults = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbBxQuery = new System.Windows.Forms.ComboBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.lblParams = new System.Windows.Forms.Label();
            this.txtBxParams = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.rdBtnSolution = new System.Windows.Forms.RadioButton();
            this.rdbtnNuget = new System.Windows.Forms.RadioButton();
            this.rdBtnAny = new System.Windows.Forms.RadioButton();
            this.lblElement = new System.Windows.Forms.Label();
            this.cmbBxElement = new System.Windows.Forms.ComboBox();
            this.pnlQuery = new System.Windows.Forms.Panel();
            this.btnOpenLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxCurrentItems = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxTotalItems = new System.Windows.Forms.TextBox();
            this.grpBxSqlType = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnUpgrade = new System.Windows.Forms.RadioButton();
            this.rdBtnMain = new System.Windows.Forms.RadioButton();
            this.btnCSV = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtBxFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSrch = new System.Windows.Forms.Button();
            this.pnlQuery.SuspendLayout();
            this.grpBxSqlType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Location = new System.Drawing.Point(27, 229);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(42, 13);
            this.lblResults.TabIndex = 0;
            this.lblResults.Text = "Results";
            // 
            // txtBxResults
            // 
            this.txtBxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxResults.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBxResults.Location = new System.Drawing.Point(75, 226);
            this.txtBxResults.Multiline = true;
            this.txtBxResults.Name = "txtBxResults";
            this.txtBxResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBxResults.Size = new System.Drawing.Size(866, 357);
            this.txtBxResults.TabIndex = 1;
            this.txtBxResults.WordWrap = false;
            this.txtBxResults.TextChanged += new System.EventHandler(this.txtBxResults_TextChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(435, 170);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(947, 597);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbBxQuery
            // 
            this.cmbBxQuery.FormattingEnabled = true;
            this.cmbBxQuery.Items.AddRange(new object[] {
            "",
            "getAllSolutions()",
            "getSolutionById (int iId)",
            "getSolutionByName(string sSolutionName)",
            "getAllProjects()",
            "getProjectById(int iId)",
            "getProjectByProjectName(string sProjectName)",
            "getProjectBySolutionAndProjectName(string sSolutionName, string sProjectName)",
            "getAllNugets",
            "getNugetById(int iNugetId)",
            "getNugetByProjectId(int iProjectId)",
            "getNugetBySolutionName(string SolutionName)",
            "getSolutionByNugetName(string NugetName)"});
            this.cmbBxQuery.Location = new System.Drawing.Point(72, 3);
            this.cmbBxQuery.Name = "cmbBxQuery";
            this.cmbBxQuery.Size = new System.Drawing.Size(435, 21);
            this.cmbBxQuery.TabIndex = 4;
            this.cmbBxQuery.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblQuery
            // 
            this.lblQuery.AutoSize = true;
            this.lblQuery.Location = new System.Drawing.Point(31, 6);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(35, 13);
            this.lblQuery.TabIndex = 5;
            this.lblQuery.Text = "Query";
            // 
            // lblParams
            // 
            this.lblParams.AutoSize = true;
            this.lblParams.Location = new System.Drawing.Point(6, 41);
            this.lblParams.Name = "lblParams";
            this.lblParams.Size = new System.Drawing.Size(60, 13);
            this.lblParams.TabIndex = 6;
            this.lblParams.Text = "Parameters";
            // 
            // txtBxParams
            // 
            this.txtBxParams.Location = new System.Drawing.Point(72, 38);
            this.txtBxParams.Name = "txtBxParams";
            this.txtBxParams.Size = new System.Drawing.Size(435, 20);
            this.txtBxParams.TabIndex = 7;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(72, 59);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(91, 13);
            this.lblComment.TabIndex = 8;
            this.lblComment.Text = "(comma delimited)";
            // 
            // rdBtnSolution
            // 
            this.rdBtnSolution.AutoSize = true;
            this.rdBtnSolution.Location = new System.Drawing.Point(20, 19);
            this.rdBtnSolution.Name = "rdBtnSolution";
            this.rdBtnSolution.Size = new System.Drawing.Size(63, 17);
            this.rdBtnSolution.TabIndex = 9;
            this.rdBtnSolution.Text = "Solution";
            this.rdBtnSolution.UseVisualStyleBackColor = true;
            this.rdBtnSolution.CheckedChanged += new System.EventHandler(this.rdBtnSolution_CheckedChanged);
            // 
            // rdbtnNuget
            // 
            this.rdbtnNuget.AutoSize = true;
            this.rdbtnNuget.Location = new System.Drawing.Point(89, 19);
            this.rdbtnNuget.Name = "rdbtnNuget";
            this.rdbtnNuget.Size = new System.Drawing.Size(54, 17);
            this.rdbtnNuget.TabIndex = 10;
            this.rdbtnNuget.Text = "Nuget";
            this.rdbtnNuget.UseVisualStyleBackColor = true;
            this.rdbtnNuget.CheckedChanged += new System.EventHandler(this.rdbtnNuget_CheckedChanged);
            // 
            // rdBtnAny
            // 
            this.rdBtnAny.AutoSize = true;
            this.rdBtnAny.Checked = true;
            this.rdBtnAny.Location = new System.Drawing.Point(161, 19);
            this.rdBtnAny.Name = "rdBtnAny";
            this.rdBtnAny.Size = new System.Drawing.Size(43, 17);
            this.rdBtnAny.TabIndex = 11;
            this.rdBtnAny.TabStop = true;
            this.rdBtnAny.Text = "Any";
            this.rdBtnAny.UseVisualStyleBackColor = true;
            this.rdBtnAny.CheckedChanged += new System.EventHandler(this.rdBtnAny_CheckedChanged);
            // 
            // lblElement
            // 
            this.lblElement.AutoSize = true;
            this.lblElement.Location = new System.Drawing.Point(24, 59);
            this.lblElement.Name = "lblElement";
            this.lblElement.Size = new System.Drawing.Size(45, 13);
            this.lblElement.TabIndex = 13;
            this.lblElement.Text = "Solution";
            this.lblElement.Click += new System.EventHandler(this.label5_Click);
            // 
            // cmbBxElement
            // 
            this.cmbBxElement.FormattingEnabled = true;
            this.cmbBxElement.Items.AddRange(new object[] {
            "",
            "getAllProject()",
            "getProjectById(int iId)",
            "getProjectByProjectName(string sProjectName)",
            "getProjectBySolutionAndProjectName(string sSolutionName, string sProjectName)",
            "getAllNugets",
            "getNugetById(int iNugetId)",
            "getNugetByProjectId(int iProjectId)"});
            this.cmbBxElement.Location = new System.Drawing.Point(75, 59);
            this.cmbBxElement.Name = "cmbBxElement";
            this.cmbBxElement.Size = new System.Drawing.Size(435, 21);
            this.cmbBxElement.TabIndex = 12;
            this.cmbBxElement.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // pnlQuery
            // 
            this.pnlQuery.Controls.Add(this.cmbBxQuery);
            this.pnlQuery.Controls.Add(this.lblQuery);
            this.pnlQuery.Controls.Add(this.lblParams);
            this.pnlQuery.Controls.Add(this.txtBxParams);
            this.pnlQuery.Controls.Add(this.lblComment);
            this.pnlQuery.Location = new System.Drawing.Point(3, 86);
            this.pnlQuery.Name = "pnlQuery";
            this.pnlQuery.Size = new System.Drawing.Size(516, 78);
            this.pnlQuery.TabIndex = 14;
            // 
            // btnOpenLoad
            // 
            this.btnOpenLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenLoad.Location = new System.Drawing.Point(830, 597);
            this.btnOpenLoad.Name = "btnOpenLoad";
            this.btnOpenLoad.Size = new System.Drawing.Size(84, 23);
            this.btnOpenLoad.TabIndex = 15;
            this.btnOpenLoad.Text = "Load";
            this.btnOpenLoad.UseVisualStyleBackColor = true;
            this.btnOpenLoad.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Item Index";
            // 
            // txtBxCurrentItems
            // 
            this.txtBxCurrentItems.Location = new System.Drawing.Point(224, 170);
            this.txtBxCurrentItems.Name = "txtBxCurrentItems";
            this.txtBxCurrentItems.Size = new System.Drawing.Size(65, 20);
            this.txtBxCurrentItems.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Total Items";
            // 
            // txtBxTotalItems
            // 
            this.txtBxTotalItems.Location = new System.Drawing.Point(75, 170);
            this.txtBxTotalItems.Name = "txtBxTotalItems";
            this.txtBxTotalItems.Size = new System.Drawing.Size(65, 20);
            this.txtBxTotalItems.TabIndex = 17;
            // 
            // grpBxSqlType
            // 
            this.grpBxSqlType.Controls.Add(this.rdbtnNuget);
            this.grpBxSqlType.Controls.Add(this.rdBtnSolution);
            this.grpBxSqlType.Controls.Add(this.rdBtnAny);
            this.grpBxSqlType.Location = new System.Drawing.Point(291, 12);
            this.grpBxSqlType.Name = "grpBxSqlType";
            this.grpBxSqlType.Size = new System.Drawing.Size(228, 42);
            this.grpBxSqlType.TabIndex = 18;
            this.grpBxSqlType.TabStop = false;
            this.grpBxSqlType.Text = "SQL Lookup";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtnUpgrade);
            this.groupBox1.Controls.Add(this.rdBtnMain);
            this.groupBox1.Location = new System.Drawing.Point(75, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 42);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repo Branch";
            // 
            // rdBtnUpgrade
            // 
            this.rdBtnUpgrade.AutoSize = true;
            this.rdBtnUpgrade.Location = new System.Drawing.Point(129, 19);
            this.rdBtnUpgrade.Name = "rdBtnUpgrade";
            this.rdBtnUpgrade.Size = new System.Drawing.Size(66, 17);
            this.rdBtnUpgrade.TabIndex = 13;
            this.rdBtnUpgrade.Text = "Upgrade";
            this.rdBtnUpgrade.UseVisualStyleBackColor = true;
            this.rdBtnUpgrade.CheckedChanged += new System.EventHandler(this.rdBtnUpgrade_CheckedChanged);
            // 
            // rdBtnMain
            // 
            this.rdBtnMain.AutoSize = true;
            this.rdBtnMain.Checked = true;
            this.rdBtnMain.Location = new System.Drawing.Point(6, 19);
            this.rdBtnMain.Name = "rdBtnMain";
            this.rdBtnMain.Size = new System.Drawing.Size(85, 17);
            this.rdBtnMain.TabIndex = 12;
            this.rdBtnMain.TabStop = true;
            this.rdBtnMain.Text = "Main/Master";
            this.rdBtnMain.UseVisualStyleBackColor = true;
            this.rdBtnMain.CheckedChanged += new System.EventHandler(this.rdBtnMain_CheckedChanged);
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(672, 199);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(75, 23);
            this.btnCSV.TabIndex = 20;
            this.btnCSV.Text = "Export CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(9, 203);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(51, 13);
            this.lblFilePath.TabIndex = 9;
            this.lblFilePath.Text = "File Path:";
            // 
            // txtBxFilePath
            // 
            this.txtBxFilePath.Location = new System.Drawing.Point(75, 200);
            this.txtBxFilePath.Name = "txtBxFilePath";
            this.txtBxFilePath.Size = new System.Drawing.Size(487, 20);
            this.txtBxFilePath.TabIndex = 10;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(577, 199);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 21;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnSrch
            // 
            this.btnSrch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSrch.Location = new System.Drawing.Point(728, 597);
            this.btnSrch.Name = "btnSrch";
            this.btnSrch.Size = new System.Drawing.Size(84, 23);
            this.btnSrch.TabIndex = 22;
            this.btnSrch.Text = "Search";
            this.btnSrch.UseVisualStyleBackColor = true;
            this.btnSrch.Click += new System.EventHandler(this.btnSrch_Click);
            // 
            // DisplayAppNugetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 632);
            this.Controls.Add(this.btnSrch);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.btnCSV);
            this.Controls.Add(this.txtBxFilePath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBxSqlType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBxTotalItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenLoad);
            this.Controls.Add(this.txtBxCurrentItems);
            this.Controls.Add(this.pnlQuery);
            this.Controls.Add(this.lblElement);
            this.Controls.Add(this.cmbBxElement);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtBxResults);
            this.Controls.Add(this.lblResults);
            this.Name = "DisplayAppNugetsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisplayAppNugetsForm";
            this.pnlQuery.ResumeLayout(false);
            this.pnlQuery.PerformLayout();
            this.grpBxSqlType.ResumeLayout(false);
            this.grpBxSqlType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.TextBox txtBxResults;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbBxQuery;
        private System.Windows.Forms.Label lblQuery;
        private System.Windows.Forms.Label lblParams;
        private System.Windows.Forms.TextBox txtBxParams;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.RadioButton rdBtnSolution;
        private System.Windows.Forms.RadioButton rdbtnNuget;
        private System.Windows.Forms.RadioButton rdBtnAny;
        private System.Windows.Forms.Label lblElement;
        private System.Windows.Forms.ComboBox cmbBxElement;
        private System.Windows.Forms.Panel pnlQuery;
        private System.Windows.Forms.Button btnOpenLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxCurrentItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxTotalItems;
        private System.Windows.Forms.GroupBox grpBxSqlType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBtnUpgrade;
        private System.Windows.Forms.RadioButton rdBtnMain;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtBxFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSrch;
    }
}