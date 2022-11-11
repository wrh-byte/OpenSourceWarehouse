
namespace SolutionComponentSplit
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRetrieve = new System.Windows.Forms.ToolStripButton();
            this.SolutionNameText = new System.Windows.Forms.TextBox();
            this.SolutionUniqueName = new System.Windows.Forms.Label();
            this.TotalCount = new System.Windows.Forms.Label();
            this.Solution1Text = new System.Windows.Forms.TextBox();
            this.S1ComponentList = new System.Windows.Forms.ListBox();
            this.Solution2Text = new System.Windows.Forms.TextBox();
            this.S2ComponentList = new System.Windows.Forms.ListBox();
            this.SplitBtn = new System.Windows.Forms.Button();
            this.ComponentGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComponentGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbRetrieve});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1175, 27);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(117, 24);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbRetrieve
            // 
            this.tsbRetrieve.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRetrieve.Name = "tsbRetrieve";
            this.tsbRetrieve.Size = new System.Drawing.Size(165, 24);
            this.tsbRetrieve.Text = "Retrieve Component";
            this.tsbRetrieve.Click += new System.EventHandler(this.tsbRetrieve_Click);
            // 
            // SolutionNameText
            // 
            this.SolutionNameText.Location = new System.Drawing.Point(191, 69);
            this.SolutionNameText.Name = "SolutionNameText";
            this.SolutionNameText.Size = new System.Drawing.Size(286, 25);
            this.SolutionNameText.TabIndex = 5;
            // 
            // SolutionUniqueName
            // 
            this.SolutionUniqueName.AutoSize = true;
            this.SolutionUniqueName.Location = new System.Drawing.Point(18, 72);
            this.SolutionUniqueName.Name = "SolutionUniqueName";
            this.SolutionUniqueName.Size = new System.Drawing.Size(167, 15);
            this.SolutionUniqueName.TabIndex = 6;
            this.SolutionUniqueName.Text = "Solution UniqueName:";
            // 
            // TotalCount
            // 
            this.TotalCount.AutoSize = true;
            this.TotalCount.Location = new System.Drawing.Point(18, 691);
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.Size = new System.Drawing.Size(87, 15);
            this.TotalCount.TabIndex = 8;
            this.TotalCount.Text = "TotalCount";
            // 
            // Solution1Text
            // 
            this.Solution1Text.Location = new System.Drawing.Point(661, 98);
            this.Solution1Text.Name = "Solution1Text";
            this.Solution1Text.Size = new System.Drawing.Size(336, 25);
            this.Solution1Text.TabIndex = 9;
            // 
            // S1ComponentList
            // 
            this.S1ComponentList.FormattingEnabled = true;
            this.S1ComponentList.ItemHeight = 15;
            this.S1ComponentList.Location = new System.Drawing.Point(661, 129);
            this.S1ComponentList.Name = "S1ComponentList";
            this.S1ComponentList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.S1ComponentList.Size = new System.Drawing.Size(336, 169);
            this.S1ComponentList.TabIndex = 10;
            // 
            // Solution2Text
            // 
            this.Solution2Text.Location = new System.Drawing.Point(661, 398);
            this.Solution2Text.Name = "Solution2Text";
            this.Solution2Text.Size = new System.Drawing.Size(336, 25);
            this.Solution2Text.TabIndex = 11;
            // 
            // S2ComponentList
            // 
            this.S2ComponentList.FormattingEnabled = true;
            this.S2ComponentList.ItemHeight = 15;
            this.S2ComponentList.Location = new System.Drawing.Point(661, 439);
            this.S2ComponentList.Name = "S2ComponentList";
            this.S2ComponentList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.S2ComponentList.Size = new System.Drawing.Size(336, 199);
            this.S2ComponentList.TabIndex = 12;
            // 
            // SplitBtn
            // 
            this.SplitBtn.Location = new System.Drawing.Point(661, 683);
            this.SplitBtn.Name = "SplitBtn";
            this.SplitBtn.Size = new System.Drawing.Size(336, 23);
            this.SplitBtn.TabIndex = 13;
            this.SplitBtn.Text = "Split";
            this.SplitBtn.UseVisualStyleBackColor = true;
            this.SplitBtn.Click += new System.EventHandler(this.SplitBtn_Click);
            // 
            // ComponentGridView
            // 
            this.ComponentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ComponentGridView.Location = new System.Drawing.Point(21, 129);
            this.ComponentGridView.Name = "ComponentGridView";
            this.ComponentGridView.RowHeadersWidth = 51;
            this.ComponentGridView.RowTemplate.Height = 27;
            this.ComponentGridView.Size = new System.Drawing.Size(577, 533);
            this.ComponentGridView.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Target Solution1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(658, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Target Solution2";
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComponentGridView);
            this.Controls.Add(this.SplitBtn);
            this.Controls.Add(this.S2ComponentList);
            this.Controls.Add(this.Solution2Text);
            this.Controls.Add(this.S1ComponentList);
            this.Controls.Add(this.Solution1Text);
            this.Controls.Add(this.TotalCount);
            this.Controls.Add(this.SolutionUniqueName);
            this.Controls.Add(this.SolutionNameText);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1175, 773);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComponentGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbRetrieve;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TextBox SolutionNameText;
        private System.Windows.Forms.Label SolutionUniqueName;
        private System.Windows.Forms.Label TotalCount;
        private System.Windows.Forms.TextBox Solution1Text;
        private System.Windows.Forms.ListBox S1ComponentList;
        private System.Windows.Forms.TextBox Solution2Text;
        private System.Windows.Forms.ListBox S2ComponentList;
        private System.Windows.Forms.Button SplitBtn;
        private System.Windows.Forms.DataGridView ComponentGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
