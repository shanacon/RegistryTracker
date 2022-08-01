namespace RegistryTracker
{
    partial class ResultForm
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
            this.ResultListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // ResultListView
            // 
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(12, 12);
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(675, 426);
            this.ResultListView.TabIndex = 0;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            this.ResultListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ResultListView_ColumnClick);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultListView);
            this.Name = "ResultForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ResultListView;
    }
}