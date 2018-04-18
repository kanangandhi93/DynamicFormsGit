namespace Dynamic
{
    partial class frmCreateForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewFOrmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNewAdd = new System.Windows.Forms.ToolStripButton();
            this.toolSaves = new System.Windows.Forms.ToolStripButton();
            this.toolOpens = new System.Windows.Forms.ToolStripButton();
            this.toolCuts = new System.Windows.Forms.ToolStripButton();
            this.toolCopys = new System.Windows.Forms.ToolStripButton();
            this.toolPastes = new System.Windows.Forms.ToolStripButton();
            this.DeleteATool = new System.Windows.Forms.ToolStripButton();
            this.DeleteSTool = new System.Windows.Forms.ToolStripButton();
            this.frmbackColor = new System.Windows.Forms.ToolStripButton();
            this.frmBackGround = new System.Windows.Forms.ToolStripButton();
            this.lblTool1 = new System.Windows.Forms.ToolStripButton();
            this.CheckboxTool = new System.Windows.Forms.ToolStripButton();
            this.btnTool = new System.Windows.Forms.ToolStripButton();
            this.ComboBoxTool = new System.Windows.Forms.ToolStripButton();
            this.GridTool = new System.Windows.Forms.ToolStripButton();
            this.DateTimeTool = new System.Windows.Forms.ToolStripButton();
            this.ListBoxTool = new System.Windows.Forms.ToolStripButton();
            this.ListViewTool = new System.Windows.Forms.ToolStripButton();
            this.NumeriUpTool = new System.Windows.Forms.ToolStripButton();
            this.PicTool = new System.Windows.Forms.ToolStripButton();
            this.RadioTool = new System.Windows.Forms.ToolStripButton();
            this.txtTool = new System.Windows.Forms.ToolStripButton();
            this.treeviewTool = new System.Windows.Forms.ToolStripButton();
            this.pnControls = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ComboControlNames = new System.Windows.Forms.ComboBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1339, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewFOrmToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addNewFOrmToolStripMenuItem
            // 
            this.addNewFOrmToolStripMenuItem.Name = "addNewFOrmToolStripMenuItem";
            this.addNewFOrmToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.addNewFOrmToolStripMenuItem.Text = "Add New Form";
            this.addNewFOrmToolStripMenuItem.Click += new System.EventHandler(this.addNewFOrmToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNewAdd,
            this.toolSaves,
            this.toolOpens,
            this.toolCuts,
            this.toolCopys,
            this.toolPastes,
            this.DeleteATool,
            this.DeleteSTool,
            this.frmbackColor,
            this.frmBackGround,
            this.lblTool1,
            this.CheckboxTool,
            this.btnTool,
            this.ComboBoxTool,
            this.GridTool,
            this.DateTimeTool,
            this.ListBoxTool,
            this.ListViewTool,
            this.NumeriUpTool,
            this.PicTool,
            this.RadioTool,
            this.txtTool,
            this.treeviewTool});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(144, 945);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolNewAdd
            // 
            this.toolNewAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolNewAdd.Image")));
            this.toolNewAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolNewAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolNewAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNewAdd.Name = "toolNewAdd";
            this.toolNewAdd.Size = new System.Drawing.Size(141, 28);
            this.toolNewAdd.Text = "New";
            this.toolNewAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolNewAdd.ToolTipText = "New";
            this.toolNewAdd.Click += new System.EventHandler(this.toolNewAdd_Click);
            // 
            // toolSaves
            // 
            this.toolSaves.Image = ((System.Drawing.Image)(resources.GetObject("toolSaves.Image")));
            this.toolSaves.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolSaves.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolSaves.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSaves.Name = "toolSaves";
            this.toolSaves.Size = new System.Drawing.Size(141, 28);
            this.toolSaves.Text = "Save";
            this.toolSaves.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolSaves.ToolTipText = "Save";
            this.toolSaves.Click += new System.EventHandler(this.toolSaves_Click);
            // 
            // toolOpens
            // 
            this.toolOpens.Image = ((System.Drawing.Image)(resources.GetObject("toolOpens.Image")));
            this.toolOpens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolOpens.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolOpens.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpens.Name = "toolOpens";
            this.toolOpens.Size = new System.Drawing.Size(141, 28);
            this.toolOpens.Text = "Open";
            this.toolOpens.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolOpens.ToolTipText = "Open";
            this.toolOpens.Click += new System.EventHandler(this.toolOpens_Click);
            // 
            // toolCuts
            // 
            this.toolCuts.Image = ((System.Drawing.Image)(resources.GetObject("toolCuts.Image")));
            this.toolCuts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolCuts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCuts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCuts.Name = "toolCuts";
            this.toolCuts.Size = new System.Drawing.Size(141, 28);
            this.toolCuts.Text = "Cut";
            this.toolCuts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolCuts.ToolTipText = "Cut";
            // 
            // toolCopys
            // 
            this.toolCopys.Image = ((System.Drawing.Image)(resources.GetObject("toolCopys.Image")));
            this.toolCopys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolCopys.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolCopys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCopys.Name = "toolCopys";
            this.toolCopys.Size = new System.Drawing.Size(141, 28);
            this.toolCopys.Text = "Copy";
            this.toolCopys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolCopys.ToolTipText = "Copy";
            // 
            // toolPastes
            // 
            this.toolPastes.Enabled = false;
            this.toolPastes.Image = ((System.Drawing.Image)(resources.GetObject("toolPastes.Image")));
            this.toolPastes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolPastes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolPastes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPastes.Name = "toolPastes";
            this.toolPastes.Size = new System.Drawing.Size(141, 26);
            this.toolPastes.Text = "Paste";
            this.toolPastes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolPastes.ToolTipText = "Paste";
            // 
            // DeleteATool
            // 
            this.DeleteATool.Image = ((System.Drawing.Image)(resources.GetObject("DeleteATool.Image")));
            this.DeleteATool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteATool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteATool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteATool.Name = "DeleteATool";
            this.DeleteATool.Size = new System.Drawing.Size(141, 36);
            this.DeleteATool.Text = "Delete All";
            this.DeleteATool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteATool.ToolTipText = "Add your TextBox";
            this.DeleteATool.Click += new System.EventHandler(this.DeleteATool_Click);
            // 
            // DeleteSTool
            // 
            this.DeleteSTool.Image = ((System.Drawing.Image)(resources.GetObject("DeleteSTool.Image")));
            this.DeleteSTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteSTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteSTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteSTool.Name = "DeleteSTool";
            this.DeleteSTool.Size = new System.Drawing.Size(141, 24);
            this.DeleteSTool.Text = "Delete Selected";
            this.DeleteSTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteSTool.ToolTipText = "Add your TextBox";
            this.DeleteSTool.Click += new System.EventHandler(this.DeleteSTool_Click);
            // 
            // frmbackColor
            // 
            this.frmbackColor.Image = ((System.Drawing.Image)(resources.GetObject("frmbackColor.Image")));
            this.frmbackColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmbackColor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.frmbackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.frmbackColor.Name = "frmbackColor";
            this.frmbackColor.Size = new System.Drawing.Size(141, 24);
            this.frmbackColor.Text = "FormColor";
            this.frmbackColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmbackColor.ToolTipText = "About Me";
            // 
            // frmBackGround
            // 
            this.frmBackGround.Image = ((System.Drawing.Image)(resources.GetObject("frmBackGround.Image")));
            this.frmBackGround.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmBackGround.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.frmBackGround.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.frmBackGround.Name = "frmBackGround";
            this.frmBackGround.Size = new System.Drawing.Size(141, 24);
            this.frmBackGround.Text = "FormImage";
            this.frmBackGround.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.frmBackGround.ToolTipText = "About Me";
            // 
            // lblTool1
            // 
            this.lblTool1.Image = ((System.Drawing.Image)(resources.GetObject("lblTool1.Image")));
            this.lblTool1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTool1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lblTool1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblTool1.Name = "lblTool1";
            this.lblTool1.Size = new System.Drawing.Size(141, 24);
            this.lblTool1.Text = "label";
            this.lblTool1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTool1.ToolTipText = "About Me";
            this.lblTool1.Click += new System.EventHandler(this.lblTool1_Click);
            // 
            // CheckboxTool
            // 
            this.CheckboxTool.Image = ((System.Drawing.Image)(resources.GetObject("CheckboxTool.Image")));
            this.CheckboxTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckboxTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CheckboxTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheckboxTool.Name = "CheckboxTool";
            this.CheckboxTool.Size = new System.Drawing.Size(141, 24);
            this.CheckboxTool.Text = "CheckBox";
            this.CheckboxTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckboxTool.ToolTipText = "Add your Button";
            // 
            // btnTool
            // 
            this.btnTool.Image = ((System.Drawing.Image)(resources.GetObject("btnTool.Image")));
            this.btnTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTool.Name = "btnTool";
            this.btnTool.Size = new System.Drawing.Size(141, 24);
            this.btnTool.Text = "Button";
            this.btnTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTool.ToolTipText = "Add your Button";
            this.btnTool.Click += new System.EventHandler(this.btnTool_Click);
            // 
            // ComboBoxTool
            // 
            this.ComboBoxTool.Image = ((System.Drawing.Image)(resources.GetObject("ComboBoxTool.Image")));
            this.ComboBoxTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ComboBoxTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ComboBoxTool.Name = "ComboBoxTool";
            this.ComboBoxTool.Size = new System.Drawing.Size(141, 24);
            this.ComboBoxTool.Text = "ComboBox";
            this.ComboBoxTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComboBoxTool.ToolTipText = "Add your Button";
            // 
            // GridTool
            // 
            this.GridTool.Image = ((System.Drawing.Image)(resources.GetObject("GridTool.Image")));
            this.GridTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GridTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GridTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GridTool.Name = "GridTool";
            this.GridTool.Size = new System.Drawing.Size(141, 24);
            this.GridTool.Text = "DatagridView";
            this.GridTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GridTool.ToolTipText = "Add your Button";
            // 
            // DateTimeTool
            // 
            this.DateTimeTool.Image = ((System.Drawing.Image)(resources.GetObject("DateTimeTool.Image")));
            this.DateTimeTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DateTimeTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DateTimeTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DateTimeTool.Name = "DateTimeTool";
            this.DateTimeTool.Size = new System.Drawing.Size(141, 24);
            this.DateTimeTool.Text = "DateTimePicker";
            this.DateTimeTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DateTimeTool.ToolTipText = "Add your Button";
            // 
            // ListBoxTool
            // 
            this.ListBoxTool.Image = ((System.Drawing.Image)(resources.GetObject("ListBoxTool.Image")));
            this.ListBoxTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListBoxTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ListBoxTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ListBoxTool.Name = "ListBoxTool";
            this.ListBoxTool.Size = new System.Drawing.Size(141, 24);
            this.ListBoxTool.Text = "ListBox";
            this.ListBoxTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListBoxTool.ToolTipText = "Add your Button";
            // 
            // ListViewTool
            // 
            this.ListViewTool.Image = ((System.Drawing.Image)(resources.GetObject("ListViewTool.Image")));
            this.ListViewTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListViewTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ListViewTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ListViewTool.Name = "ListViewTool";
            this.ListViewTool.Size = new System.Drawing.Size(141, 24);
            this.ListViewTool.Text = "ListView";
            this.ListViewTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ListViewTool.ToolTipText = "Add your Button";
            // 
            // NumeriUpTool
            // 
            this.NumeriUpTool.Image = ((System.Drawing.Image)(resources.GetObject("NumeriUpTool.Image")));
            this.NumeriUpTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NumeriUpTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NumeriUpTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NumeriUpTool.Name = "NumeriUpTool";
            this.NumeriUpTool.Size = new System.Drawing.Size(141, 24);
            this.NumeriUpTool.Text = "NumericUpDown";
            this.NumeriUpTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NumeriUpTool.ToolTipText = "Add your Button";
            // 
            // PicTool
            // 
            this.PicTool.Image = ((System.Drawing.Image)(resources.GetObject("PicTool.Image")));
            this.PicTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PicTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PicTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PicTool.Name = "PicTool";
            this.PicTool.Size = new System.Drawing.Size(141, 24);
            this.PicTool.Text = "PictureBox";
            this.PicTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PicTool.ToolTipText = "Add your Button";
            // 
            // RadioTool
            // 
            this.RadioTool.Image = ((System.Drawing.Image)(resources.GetObject("RadioTool.Image")));
            this.RadioTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RadioTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RadioTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RadioTool.Name = "RadioTool";
            this.RadioTool.Size = new System.Drawing.Size(141, 24);
            this.RadioTool.Text = "Radio";
            this.RadioTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RadioTool.ToolTipText = "Add your Button";
            // 
            // txtTool
            // 
            this.txtTool.Image = ((System.Drawing.Image)(resources.GetObject("txtTool.Image")));
            this.txtTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.txtTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtTool.Name = "txtTool";
            this.txtTool.Size = new System.Drawing.Size(141, 24);
            this.txtTool.Text = "TextBox";
            this.txtTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtTool.ToolTipText = "Add your TextBox";
            // 
            // treeviewTool
            // 
            this.treeviewTool.Image = ((System.Drawing.Image)(resources.GetObject("treeviewTool.Image")));
            this.treeviewTool.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.treeviewTool.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.treeviewTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.treeviewTool.Name = "treeviewTool";
            this.treeviewTool.Size = new System.Drawing.Size(141, 24);
            this.treeviewTool.Text = "TreeView";
            this.treeviewTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.treeviewTool.ToolTipText = "Add your TextBox";
            // 
            // pnControls
            // 
            this.pnControls.BackColor = System.Drawing.Color.White;
            this.pnControls.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnControls.Location = new System.Drawing.Point(144, 28);
            this.pnControls.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnControls.Name = "pnControls";
            this.pnControls.Size = new System.Drawing.Size(1195, 945);
            this.pnControls.TabIndex = 19;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ComboControlNames, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1071, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.809524F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.19048F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 945);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // ComboControlNames
            // 
            this.ComboControlNames.FormattingEnabled = true;
            this.ComboControlNames.Location = new System.Drawing.Point(3, 4);
            this.ComboControlNames.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ComboControlNames.Name = "ComboControlNames";
            this.ComboControlNames.Size = new System.Drawing.Size(262, 28);
            this.ComboControlNames.TabIndex = 21;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 40);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(262, 901);
            this.propertyGrid1.TabIndex = 22;
            this.propertyGrid1.UseCompatibleTextRendering = true;
            this.propertyGrid1.ViewForeColor = System.Drawing.Color.Black;
            // 
            // frmCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1339, 973);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pnControls);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create  Form";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewFOrmToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolNewAdd;
        private System.Windows.Forms.ToolStripButton toolSaves;
        private System.Windows.Forms.ToolStripButton toolOpens;
        private System.Windows.Forms.ToolStripButton toolCuts;
        private System.Windows.Forms.ToolStripButton toolCopys;
        private System.Windows.Forms.ToolStripButton toolPastes;
        private System.Windows.Forms.ToolStripButton DeleteATool;
        private System.Windows.Forms.ToolStripButton DeleteSTool;
        private System.Windows.Forms.ToolStripButton frmbackColor;
        private System.Windows.Forms.ToolStripButton frmBackGround;
        private System.Windows.Forms.ToolStripButton lblTool1;
        private System.Windows.Forms.ToolStripButton CheckboxTool;
        private System.Windows.Forms.ToolStripButton btnTool;
        private System.Windows.Forms.ToolStripButton ComboBoxTool;
        private System.Windows.Forms.ToolStripButton GridTool;
        private System.Windows.Forms.ToolStripButton DateTimeTool;
        private System.Windows.Forms.ToolStripButton ListBoxTool;
        private System.Windows.Forms.ToolStripButton ListViewTool;
        private System.Windows.Forms.ToolStripButton NumeriUpTool;
        private System.Windows.Forms.ToolStripButton PicTool;
        private System.Windows.Forms.ToolStripButton RadioTool;
        private System.Windows.Forms.ToolStripButton txtTool;
        private System.Windows.Forms.ToolStripButton treeviewTool;
        private System.Windows.Forms.Panel pnControls;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ComboBox ComboControlNames;
    }
}

