
namespace ProjectNugets
{
    partial class SearchTextForm
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblProjectRepo = new System.Windows.Forms.Label();
            this.txtBxProjectRepo = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxText = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxStatus = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxFileCount = new System.Windows.Forms.TextBox();
            this.txtBxSolution = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.txtBxFileCount);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.lblProjectRepo);
            this.pnlSearch.Controls.Add(this.txtBxProjectRepo);
            this.pnlSearch.Controls.Add(this.btnBrowse);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.txtBxText);
            this.pnlSearch.Location = new System.Drawing.Point(12, 29);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1017, 64);
            this.pnlSearch.TabIndex = 22;
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
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(680, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Text Search";
            // 
            // txtBxText
            // 
            this.txtBxText.Location = new System.Drawing.Point(89, 35);
            this.txtBxText.Name = "txtBxText";
            this.txtBxText.Size = new System.Drawing.Size(570, 20);
            this.txtBxText.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Status";
            // 
            // txtBxStatus
            // 
            this.txtBxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBxStatus.Location = new System.Drawing.Point(118, 134);
            this.txtBxStatus.Multiline = true;
            this.txtBxStatus.Name = "txtBxStatus";
            this.txtBxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBxStatus.Size = new System.Drawing.Size(878, 541);
            this.txtBxStatus.TabIndex = 23;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(954, 682);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(784, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "File Count:";
            // 
            // txtBxFileCount
            // 
            this.txtBxFileCount.Location = new System.Drawing.Point(869, 35);
            this.txtBxFileCount.Name = "txtBxFileCount";
            this.txtBxFileCount.Size = new System.Drawing.Size(115, 20);
            this.txtBxFileCount.TabIndex = 27;
            // 
            // txtBxSolution
            // 
            this.txtBxSolution.Location = new System.Drawing.Point(118, 99);
            this.txtBxSolution.Name = "txtBxSolution";
            this.txtBxSolution.Size = new System.Drawing.Size(878, 20);
            this.txtBxSolution.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Solution";
            // 
            // SearchTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 717);
            this.Controls.Add(this.txtBxSolution);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBxStatus);
            this.Controls.Add(this.pnlSearch);
            this.Name = "SearchTextForm";
            this.Text = "SearchTextForm";
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblProjectRepo;
        private System.Windows.Forms.TextBox txtBxProjectRepo;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxText;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBxFileCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxSolution;
        private System.Windows.Forms.Label label4;
    }
}