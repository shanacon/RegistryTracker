namespace RegistryTracker
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mylabel = new System.Windows.Forms.Label();
            this.AddPathBtn = new System.Windows.Forms.Button();
            this.TrackedPathBox = new System.Windows.Forms.CheckedListBox();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.DeletePathBtn = new System.Windows.Forms.Button();
            this.SelectAllBtn = new System.Windows.Forms.Button();
            this.StartResetTrackBtn = new System.Windows.Forms.Button();
            this.StopTrackBtn = new System.Windows.Forms.Button();
            this.ShowResultBtn = new System.Windows.Forms.Button();
            this.ShowNoAccessBtn = new System.Windows.Forms.Button();
            this.NoAccessLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mylabel
            // 
            this.mylabel.AutoSize = true;
            this.mylabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mylabel.Location = new System.Drawing.Point(672, 253);
            this.mylabel.Name = "mylabel";
            this.mylabel.Size = new System.Drawing.Size(0, 20);
            this.mylabel.TabIndex = 1;
            // 
            // AddPathBtn
            // 
            this.AddPathBtn.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.AddPathBtn.Location = new System.Drawing.Point(505, 72);
            this.AddPathBtn.Name = "AddPathBtn";
            this.AddPathBtn.Size = new System.Drawing.Size(200, 34);
            this.AddPathBtn.TabIndex = 4;
            this.AddPathBtn.Text = "Add path to track";
            this.AddPathBtn.UseVisualStyleBackColor = true;
            this.AddPathBtn.Click += new System.EventHandler(this.AddPathBtn_Click);
            // 
            // TrackedPathBox
            // 
            this.TrackedPathBox.BackColor = System.Drawing.SystemColors.Window;
            this.TrackedPathBox.CheckOnClick = true;
            this.TrackedPathBox.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.TrackedPathBox.FormattingEnabled = true;
            this.TrackedPathBox.Location = new System.Drawing.Point(34, 164);
            this.TrackedPathBox.Name = "TrackedPathBox";
            this.TrackedPathBox.Size = new System.Drawing.Size(465, 184);
            this.TrackedPathBox.TabIndex = 5;
            // 
            // PathBox
            // 
            this.PathBox.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.PathBox.Location = new System.Drawing.Point(34, 76);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(465, 25);
            this.PathBox.TabIndex = 6;
            this.PathBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PathBox_KeyDown);
            // 
            // DeletePathBtn
            // 
            this.DeletePathBtn.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.DeletePathBtn.Location = new System.Drawing.Point(505, 164);
            this.DeletePathBtn.Name = "DeletePathBtn";
            this.DeletePathBtn.Size = new System.Drawing.Size(230, 34);
            this.DeletePathBtn.TabIndex = 7;
            this.DeletePathBtn.Text = "Delete selected path";
            this.DeletePathBtn.UseVisualStyleBackColor = true;
            this.DeletePathBtn.Click += new System.EventHandler(this.DeletePathBtn_Click);
            // 
            // SelectAllBtn
            // 
            this.SelectAllBtn.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.SelectAllBtn.Location = new System.Drawing.Point(34, 370);
            this.SelectAllBtn.Name = "SelectAllBtn";
            this.SelectAllBtn.Size = new System.Drawing.Size(112, 34);
            this.SelectAllBtn.TabIndex = 8;
            this.SelectAllBtn.Text = "select all";
            this.SelectAllBtn.UseVisualStyleBackColor = true;
            this.SelectAllBtn.Click += new System.EventHandler(this.SelectAllBtn_Click);
            // 
            // StartResetTrackBtn
            // 
            this.StartResetTrackBtn.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.StartResetTrackBtn.Location = new System.Drawing.Point(505, 204);
            this.StartResetTrackBtn.Name = "StartResetTrackBtn";
            this.StartResetTrackBtn.Size = new System.Drawing.Size(161, 34);
            this.StartResetTrackBtn.TabIndex = 9;
            this.StartResetTrackBtn.Text = "Start Track";
            this.StartResetTrackBtn.UseVisualStyleBackColor = true;
            this.StartResetTrackBtn.Click += new System.EventHandler(this.StartTrackBtn_Click);
            // 
            // StopTrackBtn
            // 
            this.StopTrackBtn.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.StopTrackBtn.Location = new System.Drawing.Point(505, 244);
            this.StopTrackBtn.Name = "StopTrackBtn";
            this.StopTrackBtn.Size = new System.Drawing.Size(161, 60);
            this.StopTrackBtn.TabIndex = 10;
            this.StopTrackBtn.Text = "Stop track and show result";
            this.StopTrackBtn.UseVisualStyleBackColor = true;
            this.StopTrackBtn.Click += new System.EventHandler(this.StopTrackBtn_Click);
            // 
            // ShowResultBtn
            // 
            this.ShowResultBtn.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.ShowResultBtn.Location = new System.Drawing.Point(505, 310);
            this.ShowResultBtn.Name = "ShowResultBtn";
            this.ShowResultBtn.Size = new System.Drawing.Size(161, 34);
            this.ShowResultBtn.TabIndex = 11;
            this.ShowResultBtn.Text = "Show result";
            this.ShowResultBtn.UseVisualStyleBackColor = true;
            this.ShowResultBtn.Click += new System.EventHandler(this.ShowResultBtn_Click);
            // 
            // ShowNoAccessBtn
            // 
            this.ShowNoAccessBtn.Font = new System.Drawing.Font("微軟正黑體", 15F);
            this.ShowNoAccessBtn.Location = new System.Drawing.Point(152, 354);
            this.ShowNoAccessBtn.Name = "ShowNoAccessBtn";
            this.ShowNoAccessBtn.Size = new System.Drawing.Size(237, 68);
            this.ShowNoAccessBtn.TabIndex = 12;
            this.ShowNoAccessBtn.Text = "Show list of path which don\'t have access";
            this.ShowNoAccessBtn.UseVisualStyleBackColor = true;
            this.ShowNoAccessBtn.Click += new System.EventHandler(this.ShowNoAccessBtn_Click);
            // 
            // NoAccessLabel
            // 
            this.NoAccessLabel.AutoSize = true;
            this.NoAccessLabel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.NoAccessLabel.Location = new System.Drawing.Point(410, 379);
            this.NoAccessLabel.Name = "NoAccessLabel";
            this.NoAccessLabel.Size = new System.Drawing.Size(0, 20);
            this.NoAccessLabel.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NoAccessLabel);
            this.Controls.Add(this.ShowNoAccessBtn);
            this.Controls.Add(this.ShowResultBtn);
            this.Controls.Add(this.StopTrackBtn);
            this.Controls.Add(this.StartResetTrackBtn);
            this.Controls.Add(this.SelectAllBtn);
            this.Controls.Add(this.DeletePathBtn);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.TrackedPathBox);
            this.Controls.Add(this.AddPathBtn);
            this.Controls.Add(this.mylabel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mylabel;
        private System.Windows.Forms.Button AddPathBtn;
        private System.Windows.Forms.CheckedListBox TrackedPathBox;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button DeletePathBtn;
        private System.Windows.Forms.Button SelectAllBtn;
        private System.Windows.Forms.Button StartResetTrackBtn;
        private System.Windows.Forms.Button StopTrackBtn;
        private System.Windows.Forms.Button ShowResultBtn;
        private System.Windows.Forms.Button ShowNoAccessBtn;
        private System.Windows.Forms.Label NoAccessLabel;
    }
}

