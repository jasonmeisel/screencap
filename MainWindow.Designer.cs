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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_imagePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.m_recordButton = new System.Windows.Forms.Button();
            this.m_showExplorerCheckbox = new System.Windows.Forms.CheckBox();
            this.m_closeAfterCheckbox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.m_fpsBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_statusLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_imagePanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(710, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_imagePanel
            // 
            this.m_imagePanel.BackColor = System.Drawing.Color.Magenta;
            this.m_imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_imagePanel.Location = new System.Drawing.Point(3, 3);
            this.m_imagePanel.Name = "m_imagePanel";
            this.m_imagePanel.Size = new System.Drawing.Size(704, 375);
            this.m_imagePanel.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.m_recordButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_showExplorerCheckbox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.m_closeAfterCheckbox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.m_statusLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 384);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(704, 74);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // m_recordButton
            // 
            this.m_recordButton.AutoSize = true;
            this.m_recordButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_recordButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_recordButton.Location = new System.Drawing.Point(370, 3);
            this.m_recordButton.Name = "m_recordButton";
            this.tableLayoutPanel2.SetRowSpan(this.m_recordButton, 2);
            this.m_recordButton.Size = new System.Drawing.Size(331, 68);
            this.m_recordButton.TabIndex = 5;
            this.m_recordButton.Text = "Record";
            this.m_recordButton.UseVisualStyleBackColor = true;
            // 
            // m_showExplorerCheckbox
            // 
            this.m_showExplorerCheckbox.AutoSize = true;
            this.m_showExplorerCheckbox.Checked = true;
            this.m_showExplorerCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_showExplorerCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_showExplorerCheckbox.Location = new System.Drawing.Point(209, 3);
            this.m_showExplorerCheckbox.Name = "m_showExplorerCheckbox";
            this.m_showExplorerCheckbox.Size = new System.Drawing.Size(155, 31);
            this.m_showExplorerCheckbox.TabIndex = 6;
            this.m_showExplorerCheckbox.Text = "Show In Explorer";
            this.m_showExplorerCheckbox.UseVisualStyleBackColor = true;
            // 
            // m_closeAfterCheckbox
            // 
            this.m_closeAfterCheckbox.AutoSize = true;
            this.m_closeAfterCheckbox.Checked = true;
            this.m_closeAfterCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_closeAfterCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_closeAfterCheckbox.Location = new System.Drawing.Point(209, 40);
            this.m_closeAfterCheckbox.Name = "m_closeAfterCheckbox";
            this.m_closeAfterCheckbox.Size = new System.Drawing.Size(155, 31);
            this.m_closeAfterCheckbox.TabIndex = 7;
            this.m_closeAfterCheckbox.Text = "Exit Program";
            this.m_closeAfterCheckbox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.m_fpsBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 40);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 31);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // m_fpsBox
            // 
            this.m_fpsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_fpsBox.Location = new System.Drawing.Point(49, 3);
            this.m_fpsBox.Name = "m_fpsBox";
            this.m_fpsBox.Size = new System.Drawing.Size(148, 26);
            this.m_fpsBox.TabIndex = 0;
            this.m_fpsBox.Text = "30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "FPS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_statusLabel
            // 
            this.m_statusLabel.AutoSize = true;
            this.m_statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_statusLabel.Location = new System.Drawing.Point(3, 0);
            this.m_statusLabel.Name = "m_statusLabel";
            this.m_statusLabel.Size = new System.Drawing.Size(200, 37);
            this.m_statusLabel.TabIndex = 9;
            this.m_statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Opacity = 0.99D;
            this.Text = "screencap";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button m_recordButton;
        public System.Windows.Forms.CheckBox m_showExplorerCheckbox;
        public System.Windows.Forms.CheckBox m_closeAfterCheckbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.TextBox m_fpsBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Panel m_imagePanel;
        public System.Windows.Forms.Label m_statusLabel;
    }
}

