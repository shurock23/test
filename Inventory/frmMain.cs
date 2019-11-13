using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
           
            if(userConfiguration.Position == "Admin")
            {}
            else
            {
                customerToolStripMenuItem1.Visible = false;
                inventoruToolStripMenuItem.Visible = false;
                auditTrailToolStripMenuItem.Visible = false;
                reportsToolStripMenuItem.Visible = false;
            }
        }

        private void inventoruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory frm = new frmInventory();
            //frm.populateUsername(tssUsername.Text);
            frm.Show();
            frm.MdiParent = this;
        }

        public void populateData(string username, string name, string position, string usrpassword)
        {
            tssUsername.Text = username;
            tssName.Text = name;
            tssPosition.Text = position;
            userConfiguration.User = username;
            userConfiguration.UserPassword = usrpassword;
            userConfiguration.Position = position;
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.Show();
            frm.MdiParent = this;
        }

        private void cashierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCashier frm = new frmCashier();
            frm.Show();
            frm.MdiParent = this;
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.Show();
            frm.MdiParent = this;
        }

        private void auditTrailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAuditTrail frm = new frmAuditTrail();
            frm.Show();
            frm.MdiParent = this;
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.Show();
            frm.MdiParent = this;
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReports frm = new frmReports();
            frm.Show();
            frm.MdiParent = this;
        }

    }
}
