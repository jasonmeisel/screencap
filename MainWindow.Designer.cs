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
            this.m_imagePanel = new System.Windows.Forms.Panel();
            this.m_recordButton = new System.Windows.Forms.Button();
            this.m_imagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_imagePanel
            // 
            this.m_imagePanel.AutoSize = true;
            this.m_imagePanel.BackColor = System.Drawing.Color.Magenta;
            this.m_imagePanel.Controls.Add(this.m_recordButton);
            this.m_imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_imagePanel.Location = new System.Drawing.Point(0, 0);
            this.m_imagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.m_imagePanel.Name = "m_imagePanel";
            this.m_imagePanel.Size = new System.Drawing.Size(710, 461);
            this.m_imagePanel.TabIndex = 0;
            // 
            // m_recordButton
            // 
            this.m_recordButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_recordButton.Location = new System.Drawing.Point(0, 426);
            this.m_recordButton.Name = "m_recordButton";
            this.m_recordButton.Size = new System.Drawing.Size(710, 35);
            this.m_recordButton.TabIndex = 0;
            this.m_recordButton.Text = "Record";
            this.m_recordButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 461);
            this.Controls.Add(this.m_imagePanel);
            this.Name = "MainWindow";
            this.Opacity = 0.99D;
            this.Text = "screencap";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.m_imagePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel m_imagePanel;
        public System.Windows.Forms.Button m_recordButton;
    }
}

