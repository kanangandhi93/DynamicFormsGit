using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Dynamic
{
    public partial class frmCreateForm : Form
    {
        #region Attribute
        //////////////////////////////////
        /// <summary>
        /// Attributes
        /// </summary>
        /// <returns></returns>
        const int DRAG_HANDLE_SIZE = 7;
        int mouseX, mouseY;
        Control SelectedControl;
        Control copiedControl;
        Direction direction;
        Point newLocation;
        Size newSize;
        string[] gParam = null;
        Bitmap MemoryImage;
        String xmlFileName = "";
        bool cutCheck = false;
        bool copyCheck = false;
        // Adding a private font (Win2000 and later)
        [DllImport("gdi32.dll", ExactSpelling = true)]
        private static extern IntPtr AddFontMemResourceEx(byte[] pbFont, int cbFont, IntPtr pdv, out uint pcFonts);

        // Cleanup of a private font (Win2000 and later)
        [DllImport("gdi32.dll", ExactSpelling = true)]
        internal static extern bool RemoveFontMemResourceEx(IntPtr fh);

        // Some private holders of font information we are loading
        static private IntPtr m_fh = IntPtr.Zero;
        static private PrivateFontCollection m_pfc = null;


        enum Direction
        {
            NW,
            N,
            NE,
            W,
            E,
            SW,
            S,
            SE,
            None
        }

        #endregion

        public frmCreateForm()
        {
            InitializeComponent();
        }

        private void addNewFOrmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolNewAdd_Click(object sender, EventArgs e)
        {
            ComboControlNames.Items.Clear();
            pnControls.Controls.Clear();
            propertyGrid1.SelectedObject = null;
            pnControls.Invalidate();
        }

        private void lblTool1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String LableName = "Lbl_" + randNumber;

            Label ctrl = new Label();
            ctrl.Location = new Point(30, 130);
            ctrl.Name = LableName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = LableName;
            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            pnControls.Controls.Add(ctrl);
            ComboControlNames.Items.Add(LableName);
        }

        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Cursor.Clip = System.Drawing.Rectangle.Empty;
                control.Invalidate();
                DrawControlBorder(control);
            }
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                Point nextPosition = new Point();
                nextPosition = pnControls.PointToClient(MousePosition);
                nextPosition.Offset(mouseX, mouseY);
                control.Location = nextPosition;
                Invalidate();
            }
        }

        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pnControls.Invalidate();  //unselect other control
                SelectedControl = (Control)sender;
                Control control = (Control)sender;
                mouseX = -e.X;
                mouseY = -e.Y;
                control.Invalidate();
                DrawControlBorder(sender);
                propertyGrid1.SelectedObject = SelectedControl;
            }
        }

        private void control_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Start();
        }

        private void control_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            Cursor = Cursors.SizeAll;
        }

        private void toolSaves_Click(object sender, EventArgs e)
        {
            if (pnControls.Controls.Count > 0)
            {
                SavetoXML();
            }
        }

        private byte[] imageToByteArray(Bitmap bmp)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(Bitmap));
            return (byte[])converter.ConvertTo(bmp, typeof(byte[]));
        }

        private string FontToString(Font font)
        {
            return font.FontFamily.Name + ":" + font.Size + ":" + (int)font.Style;
        }

        private void SavetoXML()
        {
            XmlDocument xmlDoc = new XmlDocument();

            // Write down the XML declaration
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);

            // Create the root element
            XmlElement rootNode = xmlDoc.CreateElement("ShanuFormSave");
            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
            xmlDoc.AppendChild(rootNode);


            foreach (Control p in pnControls.Controls)
            {
                string ControlNames = p.Name;
                string types = p.GetType().ToString();
                string locX = p.Location.X.ToString();
                string locY = p.Location.Y.ToString();
                string sizeWidth = p.Width.ToString();
                string sizeHegiht = p.Height.ToString();
                string Texts = p.Text.ToString();

                var backColors = p.BackColor.Name;
                var forecolors = p.ForeColor.Name;

                PictureBox pic = p as PictureBox; //cast control into PictureBox
                byte[] bytes = null;
                string PicBitMapImages = "";
                if (pic != null) //if it is pictureBox, then it will not be null.
                {
                    if (pic.Image != null)
                    {
                        Bitmap img = new Bitmap(pic.Image);
                        bytes = imageToByteArray(img);
                        PicBitMapImages = Convert.ToBase64String(bytes);
                    }
                }

                //Font f = p.Font;

                string fonts = FontToString(p.Font);


                // Create a new <Category> element and add it to the root node
                XmlElement parentNode = xmlDoc.CreateElement("Controls");

                // Set attribute name and value!
                parentNode.SetAttribute("ID", p.GetType().ToString());

                xmlDoc.DocumentElement.PrependChild(parentNode);

                // Create the required nodes
                XmlElement CntrlType = xmlDoc.CreateElement("ControlsType");
                XmlElement locNodeX = xmlDoc.CreateElement("LocationX");
                XmlElement locNodeY = xmlDoc.CreateElement("LocationY");
                XmlElement SizeWidth = xmlDoc.CreateElement("SizeWidth");
                XmlElement SizeHegith = xmlDoc.CreateElement("SizeHeight");
                XmlElement cntText = xmlDoc.CreateElement("Text");
                XmlElement cntFonts = xmlDoc.CreateElement("Fonts");
                XmlElement CntrlPictureImage = xmlDoc.CreateElement("picImage");
                XmlElement CntrlBackColor = xmlDoc.CreateElement("BackColor");
                XmlElement CntrlForeColor = xmlDoc.CreateElement("ForeColor");
                XmlElement nodeCntrlName = xmlDoc.CreateElement("CntrlsName");

                //XmlElement nodePanelWidth = xmlDoc.CreateElement("panelWidth");
                //XmlElement nodePanelHeight = xmlDoc.CreateElement("panelHeight");
                // retrieve the text 
                XmlText cntrlKind = xmlDoc.CreateTextNode(p.GetType().ToString());

                XmlText cntrlLocX = xmlDoc.CreateTextNode(locX);
                XmlText cntrlLocY = xmlDoc.CreateTextNode(locY);

                XmlText cntrlWidth = xmlDoc.CreateTextNode(sizeWidth);
                XmlText cntrlHeight = xmlDoc.CreateTextNode(sizeHegiht);

                XmlText cntrlText = xmlDoc.CreateTextNode(Texts);
                XmlText cntrlFont = xmlDoc.CreateTextNode(fonts);
                XmlText cntrlPicImg = xmlDoc.CreateTextNode(PicBitMapImages);
                XmlText cntrlBckColor = xmlDoc.CreateTextNode(backColors);
                XmlText cntrlFrColor = xmlDoc.CreateTextNode(forecolors);
                XmlText txtCntrlsNames = xmlDoc.CreateTextNode(ControlNames);


                XmlText txtPanelWidth = xmlDoc.CreateTextNode(pnControls.Width.ToString());
                XmlText txtPanelHeight = xmlDoc.CreateTextNode(pnControls.Height.ToString());
                // append the nodes to the parentNode without the value
                parentNode.AppendChild(CntrlType);
                parentNode.AppendChild(locNodeX);
                parentNode.AppendChild(locNodeY);
                parentNode.AppendChild(SizeWidth);
                parentNode.AppendChild(SizeHegith);
                parentNode.AppendChild(cntText);
                parentNode.AppendChild(cntFonts);
                parentNode.AppendChild(CntrlPictureImage);
                parentNode.AppendChild(CntrlBackColor);
                parentNode.AppendChild(CntrlForeColor);
                parentNode.AppendChild(nodeCntrlName);
                //parentNode.AppendChild(nodePanelWidth);
                //parentNode.AppendChild(nodePanelHeight);

                // save the value of the fields into the nodes
                CntrlType.AppendChild(cntrlKind);
                locNodeX.AppendChild(cntrlLocX);
                locNodeY.AppendChild(cntrlLocY);

                SizeWidth.AppendChild(cntrlWidth);
                SizeHegith.AppendChild(cntrlHeight);

                cntText.AppendChild(cntrlText);
                cntFonts.AppendChild(cntrlFont);
                CntrlPictureImage.AppendChild(cntrlPicImg);
                CntrlBackColor.AppendChild(cntrlBckColor);
                CntrlForeColor.AppendChild(cntrlFrColor);
                nodeCntrlName.AppendChild(txtCntrlsNames);
                //nodePanelWidth.AppendChild(txtPanelWidth);
                //nodePanelHeight.AppendChild(txtPanelHeight);
            }


            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XML Files (*.xml)|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                xmlDoc.Save(dlg.FileName);
                MessageBox.Show("Form Saved.");
            }


        }

        private void toolOpens_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
                OpenFileDialog1.Filter = " XML Files|*.xml";

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xmlFileName = OpenFileDialog1.FileName.ToString();
                    pnControls.Controls.Clear();
                    loadXMLFILE();
                    // MessageBox.Show();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void loadXMLFILE()
        {
            if (xmlFileName == "")
            {
                return;
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFileName);
            XmlNode xnList = xml.SelectSingleNode("ShanuFormSave");

            int i = 0;

            foreach (XmlNode xn in xnList)
            {
                string CntrlType = xn["ControlsType"].InnerText;
                string LOCX = xn["LocationX"].InnerText;
                string LOCY = xn["LocationY"].InnerText;

                string CNTLWidth = xn["SizeWidth"].InnerText;
                string CNTLHeight = xn["SizeHeight"].InnerText;

                string CntrlText = xn["Text"].InnerText;

                string fonts = xn["Fonts"].InnerText;
                string PictuerImg = xn["picImage"].InnerText;

                string bckColor = xn["BackColor"].InnerText;
                string foreColor = xn["ForeColor"].InnerText;
                string CntrlsName = xn["CntrlsName"].InnerText;

                gParam = new string[] { CntrlType,
                                                LOCX,
                                                LOCY,
                                                CNTLWidth,
                                                CNTLHeight,
                                                CntrlText,
                                                fonts,
                                                PictuerImg,
                                                 bckColor,
                                                foreColor,
                                                CntrlsName
                                              };
                loadShanuLabelDesign();
            }

        }

        private void loadShanuLabelDesign()
        {
            try
            {



                switch (gParam[0])
                {


                    case "System.Windows.Forms.PictureBox": //현재화면 사용가능여부 조회
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            PictureBox ctrl = new PictureBox();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.SizeMode = PictureBoxSizeMode.StretchImage;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));

                            if (gParam[7] != "")
                            {
                                Bitmap bmp1 = new Bitmap(new MemoryStream(Convert.FromBase64String(gParam[7])));
                                ctrl.Image = bmp1;
                            }
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.DataGridView": //현재화면 사용가능여부 조회
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            DataGridView ctrl = new DataGridView();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.Label": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);
                            Label ctrl = new Label();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            //   ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.Button":
                        {
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);


                            Button ctrl = new Button();
                            //ctrl.Image = global::DragObject.Properties.Resources.Sunset;
                            ctrl.BackColor = myBackColor;
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));

                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            ctrl.Click += new EventHandler(control_Click);
                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.ComboBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            ComboBox ctrl = new ComboBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            //  ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.ListBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            ListBox ctrl = new ListBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            //     ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.ListView": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            ListView ctrl = new ListView();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            //   ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.NumericUpDown": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            NumericUpDown ctrl = new NumericUpDown();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            //  ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.TreeView": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            TreeView ctrl = new TreeView();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            //  ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.DateTimePicker": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            DateTimePicker ctrl = new DateTimePicker();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            // ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.TextBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            TextBox ctrl = new TextBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            //    ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.RadioButton": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            RadioButton ctrl = new RadioButton();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            //    ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                    case "System.Windows.Forms.CheckBox": //현재화면 사용가능여부 조회
                        {
                            var cvt = new FontConverter();
                            //string s = cvt.ConvertToString(this.Font);
                            Font f = StringToFont(gParam[6]);// cvt.ConvertFromString(gParam[6]) as Font;
                            System.Drawing.Color myBackColor = new System.Drawing.Color();
                            myBackColor = System.Drawing.ColorTranslator.FromHtml(gParam[8]);
                            System.Drawing.Color myForeColorColor = new System.Drawing.Color();
                            myForeColorColor = System.Drawing.ColorTranslator.FromHtml(gParam[9]);

                            CheckBox ctrl = new CheckBox();
                            ctrl.Name = gParam[10];
                            ctrl.Location = new Point(System.Convert.ToInt32(gParam[1]), System.Convert.ToInt32(gParam[2]));
                            ctrl.Text = gParam[5];
                            ctrl.Font = f;
                            ctrl.BackColor = myBackColor;
                            ctrl.ForeColor = myForeColorColor;
                            ctrl.Size = new System.Drawing.Size(System.Convert.ToInt32(gParam[3]), System.Convert.ToInt32(gParam[4]));
                            ctrl.MouseEnter += new EventHandler(control_MouseEnter);
                            ctrl.MouseLeave += new EventHandler(control_MouseLeave);
                            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                            // ctrl.Click += new EventHandler(control_Click);

                            pnControls.Controls.Add(ctrl);
                            ComboControlNames.Items.Add(gParam[10]);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void control_Click(object sender, EventArgs e)
        {
            //if (rdoMessage.Checked == true)
            //{
            RunTimeCodeGenerate("Hi".Trim());
            //}
            //else if (rdoDataTable.Checked == true)
            //{
            //    RunTimeCodeGenerate_ReturnTypeDataTable(txtCode.Text.Trim());
            //}
            //else if (rdoXML.Checked == true)
            //{
            //    RunTimeCodeGenerate_ReturnTypeDataTable(txtCode.Text.Trim());
            //}
            //else if (rdoDatabase.Checked == true)
            //{
            //    RunTimeCodeGenerate_ReturnTypeDataTable(txtCode.Text.Trim());
            //}
        }

        #region Runtime Method Generation Function
        //////////////////////////////////
        /// <summary>
        ///This function will create a Runtime Class and add all our runtime code to display the Message box .
        /// </summary>
        public void RunTimeCodeGenerate(String yourCodeHere)
        {
            try
            {
                string code = @"
                
                     using System;
                     using System.Xml;
                     using System.Data;
               namespace proj
                {
                    public class Program
                    {
                        public static void Main()
                        {
                        YourCodeHere
                        }
                    }
                }
            ";
                string finalCode = code.Replace("YourCodeHere", yourCodeHere);

                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters();
                // Reference to System.Drawing library
                parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                parameters.ReferencedAssemblies.Add("System.Drawing.dll");
                parameters.ReferencedAssemblies.Add("System.Data.dll");
                parameters.ReferencedAssemblies.Add("System.Xml.dll");
                parameters.ReferencedAssemblies.Add("System.dll");
                // parameters.ReferencedAssemblies.Add("System.Data.SqlClient.dll");
                parameters.GenerateInMemory = true;
                // True - exe file generation, false - dll file generation
                parameters.GenerateExecutable = true;

                CompilerResults results = provider.CompileAssemblyFromSource(parameters, finalCode);

                if (results.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (CompilerError error in results.Errors)
                    {
                        sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                    }

                    throw new InvalidOperationException(sb.ToString());
                }

                Assembly assembly = results.CompiledAssembly;
                Type program = assembly.GetType("proj.Program");
                MethodInfo main = program.GetMethod("Main");

                main.Invoke(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


        //////////////////////////////////
        /// <summary>
        ///This function will create at Runtime  and this class has a method with return type as DataTable.user can write there own code in textbox to return the data Table here now Initially i have worked for the .
        /// </summary>

        public void RunTimeCodeGenerate_ReturnTypeDataTable(String yourCodeHere)
        {
            try
            {
                string code = @"
                
                   using System;
                    using System.Collections.Generic;
                    using System.ComponentModel;
                    using System.Data;
                    using System.Drawing;
                    using System.Text;
                    using System.Windows.Forms;
                    using Microsoft.CSharp;
                    using System.CodeDom.Compiler;
                    using System.Reflection;
                    using System.Data.SqlClient;
                    using System.IO;
               namespace proj
                {
                    public class Program
                    {
                        public static void Main()
                        {
                        }
                        public static DataTable returnDTS()
                        {
                        YourCodeHere;
                        }
                    }
                }
            ";
                string finalCode = code.Replace("YourCodeHere", yourCodeHere);

                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters();
                // Reference to System.Drawing library
                parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                parameters.ReferencedAssemblies.Add("System.Drawing.dll");
                parameters.ReferencedAssemblies.Add("System.Data.dll");
                parameters.ReferencedAssemblies.Add("System.Xml.dll");
                parameters.ReferencedAssemblies.Add("System.dll");
                // parameters.ReferencedAssemblies.Add("System.Data.SqlClient.dll");
                parameters.GenerateInMemory = true;
                // True - exe file generation, false - dll file generation
                parameters.GenerateExecutable = true;

                CompilerResults results = provider.CompileAssemblyFromSource(parameters, finalCode);

                if (results.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (CompilerError error in results.Errors)
                    {
                        sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                    }

                    throw new InvalidOperationException(sb.ToString());
                }

                Assembly assembly = results.CompiledAssembly;
                Type program = assembly.GetType("Proj.Program");
                MethodInfo main = program.GetMethod("returnDTS");


                object ds = main.Invoke(null, null);
                DataTable dt = (DataTable)ds;
                foreach (Control pnlCntl in pnControls.Controls)
                {
                    // DataGridView Data Bind from Data Table and from XML Data Source.
                    if (pnlCntl is DataGridView)
                    {
                        if (pnlCntl.Name == ComboControlNames.SelectedItem.ToString())
                        {
                            DataGridView grid = (DataGridView)pnlCntl;
                            grid.DataSource = dt;
                        }

                    }
                    else if (pnlCntl is ListView)  // ListView Data Bind from Data Table and from XML Data Source.
                    {
                        if (pnlCntl.Name == ComboControlNames.SelectedItem.ToString())
                        {
                            ListView lstView = (ListView)pnlCntl;
                            lstView.View = View.Details;

                            foreach (DataColumn column in dt.Columns)
                            {
                                lstView.Columns.Add(column.ColumnName);
                            }
                            foreach (DataRow row in dt.Rows)
                            {
                                ListViewItem item = new ListViewItem(row[0].ToString());
                                for (int i = 1; i < dt.Columns.Count; i++)
                                {
                                    item.SubItems.Add(row[i].ToString());
                                }
                                lstView.Items.Add(item);
                            }


                        }
                    }
                    else if (pnlCntl is ComboBox)  // ComboBox Data Bind from Data Table and from XML Data Source.
                    {
                        if (pnlCntl.Name == ComboControlNames.SelectedItem.ToString())
                        {
                            ComboBox cmbo = (ComboBox)pnlCntl;
                            cmbo.DataSource = dt;
                            if (dt.Columns.Count > 1)
                            {
                                cmbo.DisplayMember = dt.Columns[1].ColumnName.ToString();// "ItemName";
                                cmbo.ValueMember = dt.Columns[0].ColumnName.ToString(); //"itemCode";
                            }

                        }
                    }
                    else if (pnlCntl is ListBox)  // ListBox Data Bind from Data Table and from XML Data Source.
                    {
                        if (pnlCntl.Name == ComboControlNames.SelectedItem.ToString())
                        {
                            ListBox lstBox = (ListBox)pnlCntl;
                            lstBox.DataSource = dt;

                            if (dt.Columns.Count > 1)
                            {
                                lstBox.DisplayMember = dt.Columns[1].ColumnName.ToString();// "ItemName";
                                lstBox.ValueMember = dt.Columns[0].ColumnName.ToString(); //"itemCode";
                            }
                            //lstBox.DisplayMember = "ItemName";
                            //lstBox.ValueMember = "itemCode";

                        }
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        #endregion


        private Font StringToFont(string font)
        {
            string[] parts = font.Split(':');
            if (parts.Length != 3)
                throw new ArgumentException("Not a valid font string", "font");

            Font loadedFont = new Font(parts[0], float.Parse(parts[1]), (FontStyle)int.Parse(parts[2]));
            return loadedFont;
        }

        private void DeleteATool_Click(object sender, EventArgs e)
        {
            ComboControlNames.Items.Clear();
            pnControls.Controls.Clear();
            propertyGrid1.SelectedObject = null;
            pnControls.Invalidate();
        }

        private void DeleteSTool_Click(object sender, EventArgs e)
        {
            if (SelectedControl != null)
            {
                ComboControlNames.Items.Remove(SelectedControl.Name);
                pnControls.Controls.Remove(SelectedControl);
                propertyGrid1.SelectedObject = null;
                pnControls.Invalidate();
            }
        }

        private void DrawControlBorder(object sender)
        {
            Control control = (Control)sender;
            //define the border to be drawn, it will be offset by DRAG_HANDLE_SIZE / 2
            //around the control, so when the drag handles are drawn they will be seem
            //connected in the middle.
            Rectangle Border = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE / 2),
                new Size(control.Size.Width + DRAG_HANDLE_SIZE,
                    control.Size.Height + DRAG_HANDLE_SIZE));
            //define the 8 drag handles, that has the size of DRAG_HANDLE_SIZE
            Rectangle NW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle N = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle NE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y - DRAG_HANDLE_SIZE),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle W = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle E = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SW = new Rectangle(
                new Point(control.Location.X - DRAG_HANDLE_SIZE,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle S = new Rectangle(
                new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
            Rectangle SE = new Rectangle(
                new Point(control.Location.X + control.Width,
                    control.Location.Y + control.Height),
                new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));

            //get the form graphic
            Graphics g = pnControls.CreateGraphics();
            //draw the border and drag handles
            ControlPaint.DrawBorder(g, Border, Color.Gray, ButtonBorderStyle.Dotted);
            ControlPaint.DrawGrabHandle(g, NW, true, true);
            ControlPaint.DrawGrabHandle(g, N, true, true);
            ControlPaint.DrawGrabHandle(g, NE, true, true);
            ControlPaint.DrawGrabHandle(g, W, true, true);
            ControlPaint.DrawGrabHandle(g, E, true, true);
            ControlPaint.DrawGrabHandle(g, SW, true, true);
            ControlPaint.DrawGrabHandle(g, S, true, true);
            ControlPaint.DrawGrabHandle(g, SE, true, true);
            g.Dispose();
        }
    }
}
