namespace mat_290_framework
{
    partial class MAT290
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Polyline = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Points = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Shell = new System.Windows.Forms.ToolStripMenuItem();
            this.methodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_DeCast = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Bern = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Midpoint = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Inter = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Inter_Poly = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Inter_Splines = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_DeBoor = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Project1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Project2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Project3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Project4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Project5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Project6 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Project7 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Project8 = new System.Windows.Forms.ToolStripMenuItem();
            this.Txt_knot = new System.Windows.Forms.TextBox();
            this.Lbl_degree = new System.Windows.Forms.Label();
            this.Lbl_knot = new System.Windows.Forms.Label();
            this.NUD_degree = new System.Windows.Forms.NumericUpDown();
            this.CB_cont = new System.Windows.Forms.CheckBox();
            this.PolynomialDegreeValue = new System.Windows.Forms.NumericUpDown();
            this.PolynomialDegreeLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_degree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PolynomialDegreeValue)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.methodToolStripMenuItem,
            this.projectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Clear,
            this.Menu_Exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // Menu_Clear
            // 
            this.Menu_Clear.Name = "Menu_Clear";
            this.Menu_Clear.Size = new System.Drawing.Size(101, 22);
            this.Menu_Clear.Text = "&Clear";
            this.Menu_Clear.Click += new System.EventHandler(this.Menu_Clear_Click);
            // 
            // Menu_Exit
            // 
            this.Menu_Exit.Name = "Menu_Exit";
            this.Menu_Exit.Size = new System.Drawing.Size(101, 22);
            this.Menu_Exit.Text = "E&xit";
            this.Menu_Exit.Click += new System.EventHandler(this.Menu_Exit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Polyline,
            this.Menu_Points,
            this.Menu_Shell});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // Menu_Polyline
            // 
            this.Menu_Polyline.Checked = true;
            this.Menu_Polyline.CheckOnClick = true;
            this.Menu_Polyline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_Polyline.Name = "Menu_Polyline";
            this.Menu_Polyline.Size = new System.Drawing.Size(116, 22);
            this.Menu_Polyline.Text = "&Polyline";
            this.Menu_Polyline.Click += new System.EventHandler(this.Menu_Polyline_Click);
            // 
            // Menu_Points
            // 
            this.Menu_Points.Checked = true;
            this.Menu_Points.CheckOnClick = true;
            this.Menu_Points.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_Points.Name = "Menu_Points";
            this.Menu_Points.Size = new System.Drawing.Size(116, 22);
            this.Menu_Points.Text = "P&oints";
            this.Menu_Points.Click += new System.EventHandler(this.Menu_Points_Click);
            // 
            // Menu_Shell
            // 
            this.Menu_Shell.Checked = true;
            this.Menu_Shell.CheckOnClick = true;
            this.Menu_Shell.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_Shell.Name = "Menu_Shell";
            this.Menu_Shell.Size = new System.Drawing.Size(116, 22);
            this.Menu_Shell.Text = "&Shell";
            this.Menu_Shell.Click += new System.EventHandler(this.Menu_Shell_Click);
            // 
            // methodToolStripMenuItem
            // 
            this.methodToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_DeCast,
            this.Menu_Bern,
            this.Menu_Midpoint,
            this.Menu_Inter,
            this.Menu_DeBoor});
            this.methodToolStripMenuItem.Name = "methodToolStripMenuItem";
            this.methodToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.methodToolStripMenuItem.Text = "&Method";
            // 
            // Menu_DeCast
            // 
            this.Menu_DeCast.Name = "Menu_DeCast";
            this.Menu_DeCast.Size = new System.Drawing.Size(136, 22);
            this.Menu_DeCast.Text = "&DeCastlejau";
            this.Menu_DeCast.Click += new System.EventHandler(this.Menu_DeCast_Click);
            // 
            // Menu_Bern
            // 
            this.Menu_Bern.Name = "Menu_Bern";
            this.Menu_Bern.Size = new System.Drawing.Size(136, 22);
            this.Menu_Bern.Text = "&Bernstein";
            this.Menu_Bern.Click += new System.EventHandler(this.Menu_Bern_Click);
            // 
            // Menu_Midpoint
            // 
            this.Menu_Midpoint.Name = "Menu_Midpoint";
            this.Menu_Midpoint.Size = new System.Drawing.Size(136, 22);
            this.Menu_Midpoint.Text = "&Midpoint";
            this.Menu_Midpoint.Click += new System.EventHandler(this.Menu_Midpoint_Click);
            // 
            // Menu_Inter
            // 
            this.Menu_Inter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Inter_Poly,
            this.Menu_Inter_Splines});
            this.Menu_Inter.Name = "Menu_Inter";
            this.Menu_Inter.Size = new System.Drawing.Size(136, 22);
            this.Menu_Inter.Text = "&Interpolate";
            // 
            // Menu_Inter_Poly
            // 
            this.Menu_Inter_Poly.Name = "Menu_Inter_Poly";
            this.Menu_Inter_Poly.Size = new System.Drawing.Size(134, 22);
            this.Menu_Inter_Poly.Text = "&Polynomial";
            this.Menu_Inter_Poly.Click += new System.EventHandler(this.Menu_Inter_Poly_Click);
            // 
            // Menu_Inter_Splines
            // 
            this.Menu_Inter_Splines.Name = "Menu_Inter_Splines";
            this.Menu_Inter_Splines.Size = new System.Drawing.Size(134, 22);
            this.Menu_Inter_Splines.Text = "&Splines";
            this.Menu_Inter_Splines.Click += new System.EventHandler(this.Menu_Inter_Splines_Click);
            // 
            // Menu_DeBoor
            // 
            this.Menu_DeBoor.Name = "Menu_DeBoor";
            this.Menu_DeBoor.Size = new System.Drawing.Size(136, 22);
            this.Menu_DeBoor.Text = "DeBoo&r";
            this.Menu_DeBoor.Click += new System.EventHandler(this.Menu_DeBoor_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Project1,
            this.Menu_Project2,
            this.Menu_Project3,
            this.Menu_Project4,
            this.Menu_Project5,
            this.Menu_Project6,
            this.Menu_Project7,
            this.Menu_Project8});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // Menu_Project1
            // 
            this.Menu_Project1.Name = "Menu_Project1";
            this.Menu_Project1.Size = new System.Drawing.Size(120, 22);
            this.Menu_Project1.Text = "Project 1";
            this.Menu_Project1.Click += new System.EventHandler(this.Menu_Project1_Click);
            // 
            // Menu_Project2
            // 
            this.Menu_Project2.Name = "Menu_Project2";
            this.Menu_Project2.Size = new System.Drawing.Size(120, 22);
            this.Menu_Project2.Text = "Project 2";
            this.Menu_Project2.Click += new System.EventHandler(this.Menu_Project2_Click);
            // 
            // Menu_Project3
            // 
            this.Menu_Project3.Name = "Menu_Project3";
            this.Menu_Project3.Size = new System.Drawing.Size(120, 22);
            this.Menu_Project3.Text = "Project 3";
            this.Menu_Project3.Click += new System.EventHandler(this.Menu_Project3_Click);
            // 
            // Menu_Project4
            // 
            this.Menu_Project4.Name = "Menu_Project4";
            this.Menu_Project4.Size = new System.Drawing.Size(120, 22);
            this.Menu_Project4.Text = "Project 4";
            this.Menu_Project4.Click += new System.EventHandler(this.Menu_Project4_Click);
            // 
            // Menu_Project5
            // 
            this.Menu_Project5.Name = "Menu_Project5";
            this.Menu_Project5.Size = new System.Drawing.Size(120, 22);
            this.Menu_Project5.Text = "Project 5";
            this.Menu_Project5.Click += new System.EventHandler(this.Menu_Project5_Click);
            // 
            // Menu_Project6
            // 
            this.Menu_Project6.Name = "Menu_Project6";
            this.Menu_Project6.Size = new System.Drawing.Size(120, 22);
            this.Menu_Project6.Text = "Project 6";
            this.Menu_Project6.Click += new System.EventHandler(this.Menu_Project6_Click);
            // 
            // Menu_Project7
            // 
            this.Menu_Project7.Name = "Menu_Project7";
            this.Menu_Project7.Size = new System.Drawing.Size(120, 22);
            this.Menu_Project7.Text = "Project 7";
            this.Menu_Project7.Click += new System.EventHandler(this.Menu_Project7_Click);
            // 
            // Menu_Project8
            // 
            this.Menu_Project8.Name = "Menu_Project8";
            this.Menu_Project8.Size = new System.Drawing.Size(120, 22);
            this.Menu_Project8.Text = "Project 8";
            this.Menu_Project8.Click += new System.EventHandler(this.Menu_Project8_Click);
            // 
            // Txt_knot
            // 
            this.Txt_knot.Location = new System.Drawing.Point(12, 541);
            this.Txt_knot.Name = "Txt_knot";
            this.Txt_knot.Size = new System.Drawing.Size(768, 20);
            this.Txt_knot.TabIndex = 1;
            this.Txt_knot.Visible = false;
            this.Txt_knot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_knot_KeyPress);
            // 
            // Lbl_degree
            // 
            this.Lbl_degree.AutoSize = true;
            this.Lbl_degree.Location = new System.Drawing.Point(693, 517);
            this.Lbl_degree.Name = "Lbl_degree";
            this.Lbl_degree.Size = new System.Drawing.Size(42, 13);
            this.Lbl_degree.TabIndex = 3;
            this.Lbl_degree.Text = "Degree";
            this.Lbl_degree.Visible = false;
            // 
            // Lbl_knot
            // 
            this.Lbl_knot.AutoSize = true;
            this.Lbl_knot.Location = new System.Drawing.Point(12, 525);
            this.Lbl_knot.Name = "Lbl_knot";
            this.Lbl_knot.Size = new System.Drawing.Size(54, 13);
            this.Lbl_knot.TabIndex = 4;
            this.Lbl_knot.Text = "Knot Seq.";
            this.Lbl_knot.Visible = false;
            // 
            // NUD_degree
            // 
            this.NUD_degree.InterceptArrowKeys = false;
            this.NUD_degree.Location = new System.Drawing.Point(741, 515);
            this.NUD_degree.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_degree.Name = "NUD_degree";
            this.NUD_degree.ReadOnly = true;
            this.NUD_degree.Size = new System.Drawing.Size(39, 20);
            this.NUD_degree.TabIndex = 5;
            this.NUD_degree.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_degree.Visible = false;
            this.NUD_degree.ValueChanged += new System.EventHandler(this.NUD_degree_ValueChanged);
            // 
            // CB_cont
            // 
            this.CB_cont.AutoSize = true;
            this.CB_cont.Checked = true;
            this.CB_cont.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_cont.Location = new System.Drawing.Point(72, 524);
            this.CB_cont.Name = "CB_cont";
            this.CB_cont.Size = new System.Drawing.Size(72, 17);
            this.CB_cont.TabIndex = 7;
            this.CB_cont.Text = "Continuity";
            this.CB_cont.UseVisualStyleBackColor = true;
            this.CB_cont.Visible = false;
            this.CB_cont.CheckedChanged += new System.EventHandler(this.CB_cont_CheckedChanged);
            // 
            // PolynomialDegreeValue
            // 
            this.PolynomialDegreeValue.InterceptArrowKeys = false;
            this.PolynomialDegreeValue.Location = new System.Drawing.Point(741, 467);
            this.PolynomialDegreeValue.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.PolynomialDegreeValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PolynomialDegreeValue.Name = "PolynomialDegreeValue";
            this.PolynomialDegreeValue.ReadOnly = true;
            this.PolynomialDegreeValue.Size = new System.Drawing.Size(39, 20);
            this.PolynomialDegreeValue.TabIndex = 8;
            this.PolynomialDegreeValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PolynomialDegreeValue.ValueChanged += new System.EventHandler(this.PolyValueUpdated);
            // 
            // PolynomialDegreeLabel
            // 
            this.PolynomialDegreeLabel.AutoSize = true;
            this.PolynomialDegreeLabel.Location = new System.Drawing.Point(640, 469);
            this.PolynomialDegreeLabel.Name = "PolynomialDegreeLabel";
            this.PolynomialDegreeLabel.Size = new System.Drawing.Size(95, 13);
            this.PolynomialDegreeLabel.TabIndex = 9;
            this.PolynomialDegreeLabel.Text = "Polynomial Degree";
            this.PolynomialDegreeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // MAT290
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.PolynomialDegreeLabel);
            this.Controls.Add(this.PolynomialDegreeValue);
            this.Controls.Add(this.CB_cont);
            this.Controls.Add(this.NUD_degree);
            this.Controls.Add(this.Lbl_knot);
            this.Controls.Add(this.Lbl_degree);
            this.Controls.Add(this.Txt_knot);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MAT290";
            this.Text = "MAT290Framework";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MAT290_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MAT290_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MAT290_MouseMove);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MAT290_MouseWheel);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_degree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PolynomialDegreeValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Exit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Polyline;
        private System.Windows.Forms.ToolStripMenuItem Menu_Points;
        private System.Windows.Forms.ToolStripMenuItem methodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Shell;
        private System.Windows.Forms.ToolStripMenuItem Menu_DeCast;
        private System.Windows.Forms.ToolStripMenuItem Menu_Bern;
        private System.Windows.Forms.ToolStripMenuItem Menu_Midpoint;
        private System.Windows.Forms.ToolStripMenuItem Menu_Clear;
        private System.Windows.Forms.ToolStripMenuItem Menu_Inter;
        private System.Windows.Forms.ToolStripMenuItem Menu_DeBoor;
        private System.Windows.Forms.ToolStripMenuItem Menu_Inter_Poly;
        private System.Windows.Forms.ToolStripMenuItem Menu_Inter_Splines;
        private System.Windows.Forms.TextBox Txt_knot;
        private System.Windows.Forms.Label Lbl_degree;
        private System.Windows.Forms.Label Lbl_knot;
        private System.Windows.Forms.NumericUpDown NUD_degree;
        private System.Windows.Forms.CheckBox CB_cont;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Menu_Project1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Project2;
        private System.Windows.Forms.ToolStripMenuItem Menu_Project3;
        private System.Windows.Forms.ToolStripMenuItem Menu_Project4;
        private System.Windows.Forms.ToolStripMenuItem Menu_Project5;
        private System.Windows.Forms.ToolStripMenuItem Menu_Project6;
        private System.Windows.Forms.ToolStripMenuItem Menu_Project7;
        private System.Windows.Forms.ToolStripMenuItem Menu_Project8;
        private System.Windows.Forms.NumericUpDown PolynomialDegreeValue;
        private System.Windows.Forms.Label PolynomialDegreeLabel;
    }
}

