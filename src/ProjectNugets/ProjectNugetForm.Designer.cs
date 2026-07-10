namespace ProjectNugets
{
    partial class ProjectNugetForm
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
            this.lblProjectRepo = new System.Windows.Forms.Label();
            this.txtBxProjectRepo = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBxSolutions = new System.Windows.Forms.TextBox();
            this.lblSolutionss = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.txtBxProject = new System.Windows.Forms.TextBox();
            this.txtBxReference = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.btnUpdateNugets = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBxDLLName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDllSearch = new System.Windows.Forms.Button();
            this.btnCreateTables = new System.Windows.Forms.Button();
            this.btnGetRepo = new System.Windows.Forms.Button();
            this.panelGetRepo = new System.Windows.Forms.Panel();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxScript = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxStatus = new System.Windows.Forms.TextBox();
            this.btnPullRepos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBxPS = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnUpgrade = new System.Windows.Forms.RadioButton();
            this.rdBtnMain = new System.Windows.Forms.RadioButton();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.panelGetRepo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProjectRepo
            // 
            this.lblProjectRepo.AutoSize = true;
            this.lblProjectRepo.Location = new System.Drawing.Point(14, 9);
            this.lblProjectRepo.Name = "lblProjectRepo";
            this.lblProjectRepo.Size = new System.Drawing.Size(69, 13);
            this.lblProjectRepo.TabIndex = 0;
            this.lblProjectRepo.Text = "Project Repo";
            // 
            // txtBxProjectRepo
            // 
            this.txtBxProjectRepo.Location = new System.Drawing.Point(89, 6);
            this.txtBxProjectRepo.Name = "txtBxProjectRepo";
            this.txtBxProjectRepo.Size = new System.Drawing.Size(822, 20);
            this.txtBxProjectRepo.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(926, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(926, 492);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtBxSolutions
            // 
            this.txtBxSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxSolutions.Location = new System.Drawing.Point(107, 14);
            this.txtBxSolutions.Multiline = true;
            this.txtBxSolutions.Name = "txtBxSolutions";
            this.txtBxSolutions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBxSolutions.Size = new System.Drawing.Size(894, 135);
            this.txtBxSolutions.TabIndex = 6;
            this.txtBxSolutions.WordWrap = false;
            // 
            // lblSolutionss
            // 
            this.lblSolutionss.AutoSize = true;
            this.lblSolutionss.Location = new System.Drawing.Point(32, 17);
            this.lblSolutionss.Name = "lblSolutionss";
            this.lblSolutionss.Size = new System.Drawing.Size(50, 13);
            this.lblSolutionss.TabIndex = 5;
            this.lblSolutionss.Text = "Solutions";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(42, 158);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(40, 13);
            this.lblProject.TabIndex = 7;
            this.lblProject.Text = "Project";
            // 
            // txtBxProject
            // 
            this.txtBxProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxProject.Location = new System.Drawing.Point(106, 158);
            this.txtBxProject.Multiline = true;
            this.txtBxProject.Name = "txtBxProject";
            this.txtBxProject.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBxProject.Size = new System.Drawing.Size(895, 162);
            this.txtBxProject.TabIndex = 8;
            this.txtBxProject.WordWrap = false;
            // 
            // txtBxReference
            // 
            this.txtBxReference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxReference.Location = new System.Drawing.Point(106, 328);
            this.txtBxReference.Multiline = true;
            this.txtBxReference.Name = "txtBxReference";
            this.txtBxReference.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBxReference.Size = new System.Drawing.Size(895, 158);
            this.txtBxReference.TabIndex = 10;
            this.txtBxReference.WordWrap = false;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(25, 323);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(57, 13);
            this.lblReference.TabIndex = 9;
            this.lblReference.Text = "Reference";
            // 
            // btnUpdateNugets
            // 
            this.btnUpdateNugets.Location = new System.Drawing.Point(436, 60);
            this.btnUpdateNugets.Name = "btnUpdateNugets";
            this.btnUpdateNugets.Size = new System.Drawing.Size(84, 23);
            this.btnUpdateNugets.TabIndex = 11;
            this.btnUpdateNugets.Text = "Update Nuget";
            this.btnUpdateNugets.UseVisualStyleBackColor = true;
            this.btnUpdateNugets.Click += new System.EventHandler(this.btnUpdateNugets_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(526, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBxDLLName
            // 
            this.txtBxDLLName.Location = new System.Drawing.Point(89, 32);
            this.txtBxDLLName.Name = "txtBxDLLName";
            this.txtBxDLLName.Size = new System.Drawing.Size(250, 20);
            this.txtBxDLLName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "DLL Search";
            // 
            // btnDllSearch
            // 
            this.btnDllSearch.Location = new System.Drawing.Point(360, 30);
            this.btnDllSearch.Name = "btnDllSearch";
            this.btnDllSearch.Size = new System.Drawing.Size(106, 23);
            this.btnDllSearch.TabIndex = 15;
            this.btnDllSearch.Text = "Search For DLL";
            this.btnDllSearch.UseVisualStyleBackColor = true;
            this.btnDllSearch.Click += new System.EventHandler(this.btnDllSearch_Click);
            // 
            // btnCreateTables
            // 
            this.btnCreateTables.Location = new System.Drawing.Point(104, 60);
            this.btnCreateTables.Name = "btnCreateTables";
            this.btnCreateTables.Size = new System.Drawing.Size(106, 23);
            this.btnCreateTables.TabIndex = 16;
            this.btnCreateTables.Text = "Create Tables";
            this.btnCreateTables.UseVisualStyleBackColor = true;
            this.btnCreateTables.Click += new System.EventHandler(this.btnCreateTables_Click);
            // 
            // btnGetRepo
            // 
            this.btnGetRepo.Location = new System.Drawing.Point(268, 60);
            this.btnGetRepo.Name = "btnGetRepo";
            this.btnGetRepo.Size = new System.Drawing.Size(106, 23);
            this.btnGetRepo.TabIndex = 17;
            this.btnGetRepo.Text = "Get Repo";
            this.btnGetRepo.UseVisualStyleBackColor = true;
            this.btnGetRepo.Click += new System.EventHandler(this.btnGetRepo_Click);
            // 
            // panelGetRepo
            // 
            this.panelGetRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGetRepo.Controls.Add(this.btnExecute);
            this.panelGetRepo.Controls.Add(this.label4);
            this.panelGetRepo.Controls.Add(this.txtBxScript);
            this.panelGetRepo.Controls.Add(this.label3);
            this.panelGetRepo.Controls.Add(this.txtBxStatus);
            this.panelGetRepo.Controls.Add(this.btnPullRepos);
            this.panelGetRepo.Controls.Add(this.label2);
            this.panelGetRepo.Controls.Add(this.cmbBxPS);
            this.panelGetRepo.Location = new System.Drawing.Point(26, 159);
            this.panelGetRepo.Name = "panelGetRepo";
            this.panelGetRepo.Size = new System.Drawing.Size(1017, 487);
            this.panelGetRepo.TabIndex = 18;
            this.panelGetRepo.Visible = false;
            this.panelGetRepo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGetRepo_Paint);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(895, 202);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(106, 23);
            this.btnExecute.TabIndex = 23;
            this.btnExecute.Text = "Execute Script";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Script";
            // 
            // txtBxScript
            // 
            this.txtBxScript.Location = new System.Drawing.Point(123, 45);
            this.txtBxScript.Multiline = true;
            this.txtBxScript.Name = "txtBxScript";
            this.txtBxScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBxScript.Size = new System.Drawing.Size(878, 151);
            this.txtBxScript.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Status";
            // 
            // txtBxStatus
            // 
            this.txtBxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxStatus.Location = new System.Drawing.Point(123, 245);
            this.txtBxStatus.Multiline = true;
            this.txtBxStatus.Name = "txtBxStatus";
            this.txtBxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBxStatus.Size = new System.Drawing.Size(878, 228);
            this.txtBxStatus.TabIndex = 19;
            // 
            // btnPullRepos
            // 
            this.btnPullRepos.Enabled = false;
            this.btnPullRepos.Location = new System.Drawing.Point(895, 16);
            this.btnPullRepos.Name = "btnPullRepos";
            this.btnPullRepos.Size = new System.Drawing.Size(106, 23);
            this.btnPullRepos.TabIndex = 18;
            this.btnPullRepos.Text = "Load Script";
            this.btnPullRepos.UseVisualStyleBackColor = true;
            this.btnPullRepos.Click += new System.EventHandler(this.btnPullRepos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PowerShell Scripts";
            // 
            // cmbBxPS
            // 
            this.cmbBxPS.FormattingEnabled = true;
            this.cmbBxPS.Location = new System.Drawing.Point(123, 18);
            this.cmbBxPS.Name = "cmbBxPS";
            this.cmbBxPS.Size = new System.Drawing.Size(729, 21);
            this.cmbBxPS.TabIndex = 0;
            this.cmbBxPS.SelectedIndexChanged += new System.EventHandler(this.cmbBxPS_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtnUpgrade);
            this.groupBox1.Controls.Add(this.rdBtnMain);
            this.groupBox1.Location = new System.Drawing.Point(108, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 42);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repo Branch";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblProjectRepo);
            this.pnlSearch.Controls.Add(this.txtBxProjectRepo);
            this.pnlSearch.Controls.Add(this.btnBrowse);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.btnDllSearch);
            this.pnlSearch.Controls.Add(this.txtBxDLLName);
            this.pnlSearch.Location = new System.Drawing.Point(26, 89);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1017, 64);
            this.pnlSearch.TabIndex = 21;
            // 
            // pnlLoad
            // 
            this.pnlLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLoad.Controls.Add(this.lblSolutionss);
            this.pnlLoad.Controls.Add(this.txtBxSolutions);
            this.pnlLoad.Controls.Add(this.txtBxProject);
            this.pnlLoad.Controls.Add(this.lblProject);
            this.pnlLoad.Controls.Add(this.txtBxReference);
            this.pnlLoad.Controls.Add(this.btnClose);
            this.pnlLoad.Controls.Add(this.lblReference);
            this.pnlLoad.Location = new System.Drawing.Point(26, 159);
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(1017, 521);
            this.pnlLoad.TabIndex = 22;
            // 
            // ProjectNugetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 717);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGetRepo);
            this.Controls.Add(this.btnCreateTables);
            this.Controls.Add(this.btnUpdateNugets);
            this.Controls.Add(this.panelGetRepo);
            this.Controls.Add(this.pnlLoad);
            this.Name = "ProjectNugetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Nuget Extractor";
            this.panelGetRepo.ResumeLayout(false);
            this.panelGetRepo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlLoad.ResumeLayout(false);
            this.pnlLoad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProjectRepo;
        private System.Windows.Forms.TextBox txtBxProjectRepo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBxSolutions;
        private System.Windows.Forms.Label lblSolutionss;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TextBox txtBxProject;
        private System.Windows.Forms.TextBox txtBxReference;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.Button btnUpdateNugets;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBxDLLName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDllSearch;
        private System.Windows.Forms.Button btnCreateTables;
        private System.Windows.Forms.Button btnGetRepo;
        private System.Windows.Forms.Panel panelGetRepo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBxPS;
        private System.Windows.Forms.Button btnPullRepos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxStatus;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxScript;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBtnUpgrade;
        private System.Windows.Forms.RadioButton rdBtnMain;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlLoad;
    }
}

