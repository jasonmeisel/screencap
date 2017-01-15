namespace screencap
{
    partial class MainWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_recordButton = new System.Windows.Forms.Button();
            this.m_imagePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.m_imagePanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.m_recordButton);
            this.splitContainer1.Size = new System.Drawing.Size(710, 461);
            this.splitContainer1.SplitterDistance = 423;
            this.splitContainer1.TabIndex = 2;
            // 
            // m_recordButton
            // 
            this.m_recordButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_recordButton.Location = new System.Drawing.Point(0, 0);
            this.m_recordButton.Name = "m_recordButton";
            this.m_recordButton.Size = new System.Drawing.Size(710, 34);
            this.m_recordButton.TabIndex = 2;
            this.m_recordButton.Text = "Record";
            this.m_recordButton.UseVisualStyleBackColor = true;
            // 
            // m_imagePanel
            // 
            this.m_imagePanel.BackColor = System.Drawing.Color.Magenta;
            this.m_imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_imagePanel.Location = new System.Drawing.Point(0, 0);
            this.m_imagePanel.Name = "m_imagePanel";
            this.m_imagePanel.Size = new System.Drawing.Size(710, 423);
            this.m_imagePanel.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 461);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainWindow";
            this.Opacity = 0.99D;
            this.Text = "screencap";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Button m_recordButton;
        public System.Windows.Forms.Panel m_imagePanel;
    }
}

