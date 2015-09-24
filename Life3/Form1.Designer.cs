namespace Life
{
    partial class Form1
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
            this.myPanel = new System.Windows.Forms.Panel();
            this.initButton = new System.Windows.Forms.Button();
            this.nextGenButton = new System.Windows.Forms.Button();
            this.next10GenButton = new System.Windows.Forms.Button();
            this.next100GenButton = new System.Windows.Forms.Button();
            this.next1000GenButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RandomSeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Density = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GenerationCounter = new System.Windows.Forms.TextBox();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.AutoRefresh = new System.Windows.Forms.CheckBox();
            this.clearGrid = new System.Windows.Forms.Button();
            this.PopulationCounter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // myPanel
            // 
            this.myPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel.BackColor = System.Drawing.Color.Transparent;
            this.myPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myPanel.CausesValidation = false;
            this.myPanel.Location = new System.Drawing.Point(0, 0);
            this.myPanel.Name = "myPanel";
            this.myPanel.Size = new System.Drawing.Size(472, 456);
            this.myPanel.TabIndex = 0;
            this.myPanel.SizeChanged += new System.EventHandler(this.myPanel_Resize);
            this.myPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RePaint);
            this.myPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.myPanel_MouseMove);
            this.myPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.myPanel_MouseDown);
            // 
            // initButton
            // 
            this.initButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initButton.Location = new System.Drawing.Point(64, 54);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(72, 24);
            this.initButton.TabIndex = 1;
            this.initButton.Text = "Randomize";
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // nextGenButton
            // 
            this.nextGenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextGenButton.Location = new System.Drawing.Point(146, 53);
            this.nextGenButton.Name = "nextGenButton";
            this.nextGenButton.Size = new System.Drawing.Size(80, 24);
            this.nextGenButton.TabIndex = 2;
            this.nextGenButton.Text = "+ 1 Gen.";
            this.nextGenButton.Click += new System.EventHandler(this.nextGenButton_Click);
            // 
            // next10GenButton
            // 
            this.next10GenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next10GenButton.Location = new System.Drawing.Point(226, 53);
            this.next10GenButton.Name = "next10GenButton";
            this.next10GenButton.Size = new System.Drawing.Size(80, 24);
            this.next10GenButton.TabIndex = 3;
            this.next10GenButton.Text = "+ 10 Gen.";
            this.next10GenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // next100GenButton
            // 
            this.next100GenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next100GenButton.Location = new System.Drawing.Point(306, 53);
            this.next100GenButton.Name = "next100GenButton";
            this.next100GenButton.Size = new System.Drawing.Size(80, 24);
            this.next100GenButton.TabIndex = 4;
            this.next100GenButton.Text = "+ 100 Gen.";
            this.next100GenButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // next1000GenButton
            // 
            this.next1000GenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next1000GenButton.Location = new System.Drawing.Point(386, 53);
            this.next1000GenButton.Name = "next1000GenButton";
            this.next1000GenButton.Size = new System.Drawing.Size(80, 24);
            this.next1000GenButton.TabIndex = 5;
            this.next1000GenButton.Text = "+ 1000 Gen.";
            this.next1000GenButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Seed (0-32000):";
            // 
            // RandomSeed
            // 
            this.RandomSeed.Location = new System.Drawing.Point(112, 4);
            this.RandomSeed.MaxLength = 5;
            this.RandomSeed.Name = "RandomSeed";
            this.RandomSeed.Size = new System.Drawing.Size(48, 20);
            this.RandomSeed.TabIndex = 7;
            this.RandomSeed.Text = "0";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Density (0.1-0.9):";
            // 
            // Density
            // 
            this.Density.Location = new System.Drawing.Point(112, 28);
            this.Density.Name = "Density";
            this.Density.Size = new System.Drawing.Size(48, 20);
            this.Density.TabIndex = 9;
            this.Density.Text = "0.2";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Generation # ";
            // 
            // GenerationCounter
            // 
            this.GenerationCounter.Location = new System.Drawing.Point(200, 22);
            this.GenerationCounter.Name = "GenerationCounter";
            this.GenerationCounter.Size = new System.Drawing.Size(56, 20);
            this.GenerationCounter.TabIndex = 12;
            this.GenerationCounter.Text = "0";
            // 
            // statsPanel
            // 
            this.statsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.statsPanel.Controls.Add(this.AutoRefresh);
            this.statsPanel.Controls.Add(this.clearGrid);
            this.statsPanel.Controls.Add(this.PopulationCounter);
            this.statsPanel.Controls.Add(this.label4);
            this.statsPanel.Controls.Add(this.initButton);
            this.statsPanel.Controls.Add(this.Density);
            this.statsPanel.Controls.Add(this.label2);
            this.statsPanel.Controls.Add(this.RandomSeed);
            this.statsPanel.Controls.Add(this.label1);
            this.statsPanel.Controls.Add(this.next1000GenButton);
            this.statsPanel.Controls.Add(this.next100GenButton);
            this.statsPanel.Controls.Add(this.next10GenButton);
            this.statsPanel.Controls.Add(this.nextGenButton);
            this.statsPanel.Controls.Add(this.label3);
            this.statsPanel.Controls.Add(this.GenerationCounter);
            this.statsPanel.Location = new System.Drawing.Point(0, 456);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(528, 80);
            this.statsPanel.TabIndex = 13;
            // 
            // AutoRefresh
            // 
            this.AutoRefresh.Checked = true;
            this.AutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoRefresh.Location = new System.Drawing.Point(376, 22);
            this.AutoRefresh.Name = "AutoRefresh";
            this.AutoRefresh.Size = new System.Drawing.Size(96, 16);
            this.AutoRefresh.TabIndex = 16;
            this.AutoRefresh.Text = "Auto Refresh";
            // 
            // clearGrid
            // 
            this.clearGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearGrid.Location = new System.Drawing.Point(8, 54);
            this.clearGrid.Name = "clearGrid";
            this.clearGrid.Size = new System.Drawing.Size(48, 24);
            this.clearGrid.TabIndex = 15;
            this.clearGrid.Text = "Clear";
            this.clearGrid.Click += new System.EventHandler(this.clearGrid_Click);
            // 
            // PopulationCounter
            // 
            this.PopulationCounter.Location = new System.Drawing.Point(288, 22);
            this.PopulationCounter.Name = "PopulationCounter";
            this.PopulationCounter.Size = new System.Drawing.Size(56, 20);
            this.PopulationCounter.TabIndex = 14;
            this.PopulationCounter.Text = "0";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(288, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Population";
            // 
            // WinForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(472, 533);
            this.Controls.Add(this.myPanel);
            this.Controls.Add(this.statsPanel);
            this.MinimumSize = new System.Drawing.Size(480, 300);
            this.Name = "WinForm";
            this.Text = "Life1";
            this.statsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion


    }
}

