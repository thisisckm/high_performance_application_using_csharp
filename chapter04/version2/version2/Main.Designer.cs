namespace Chapter04Version2
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            groupBoxToolbox = new GroupBox();
            buttonGo = new Button();
            comboBoxConvert = new ComboBox();
            pictureBoxCanvas = new PictureBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openImageToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            groupBoxToolbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCanvas).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxToolbox
            // 
            groupBoxToolbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxToolbox.AutoSize = true;
            groupBoxToolbox.Controls.Add(buttonGo);
            groupBoxToolbox.Controls.Add(comboBoxConvert);
            groupBoxToolbox.Enabled = false;
            groupBoxToolbox.Location = new Point(12, 27);
            groupBoxToolbox.Name = "groupBoxToolbox";
            groupBoxToolbox.Size = new Size(776, 81);
            groupBoxToolbox.TabIndex = 0;
            groupBoxToolbox.TabStop = false;
            groupBoxToolbox.Text = "Toolbox";
            // 
            // buttonGo
            // 
            buttonGo.Enabled = false;
            buttonGo.Image = (Image)resources.GetObject("buttonGo.Image");
            buttonGo.Location = new Point(258, 36);
            buttonGo.Name = "buttonGo";
            buttonGo.Size = new Size(51, 23);
            buttonGo.TabIndex = 1;
            buttonGo.UseVisualStyleBackColor = true;
            buttonGo.Click += buttonGo_Click;
            // 
            // comboBoxConvert
            // 
            comboBoxConvert.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxConvert.FormattingEnabled = true;
            comboBoxConvert.Items.AddRange(new object[] { "Greyscale", "Pencil Sketch" });
            comboBoxConvert.Location = new Point(17, 36);
            comboBoxConvert.Name = "comboBoxConvert";
            comboBoxConvert.Size = new Size(235, 23);
            comboBoxConvert.TabIndex = 0;
            comboBoxConvert.SelectedIndexChanged += comboBoxConvert_SelectedIndexChanged;
            // 
            // pictureBoxCanvas
            // 
            pictureBoxCanvas.Location = new Point(12, 114);
            pictureBoxCanvas.Name = "pictureBoxCanvas";
            pictureBoxCanvas.Size = new Size(776, 339);
            pictureBoxCanvas.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxCanvas.TabIndex = 1;
            pictureBoxCanvas.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openImageToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openImageToolStripMenuItem
            // 
            openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            openImageToolStripMenuItem.Size = new Size(151, 22);
            openImageToolStripMenuItem.Text = "&Open Image ...";
            openImageToolStripMenuItem.Click += openImageToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(148, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(151, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxCanvas);
            Controls.Add(groupBoxToolbox);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "PixelPro Plus";
            groupBoxToolbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxCanvas).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxToolbox;
        private ComboBox comboBoxConvert;
        private Button buttonGo;
        private PictureBox pictureBoxCanvas;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openImageToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}