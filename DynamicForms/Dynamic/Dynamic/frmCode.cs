using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dynamic
{
    public partial class frmCode : Form
    {
        public frmCode()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            frmCreateForm frm = new Dynamic.frmCreateForm();
            frm.Code = txtCode.Text;
            this.Close();
        }
    }
}
