using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace Inventory
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        BusinessLayer.blUserAdmin blAdmin = new blUserAdmin();
        string oldpassowrd = "";

        private void btnChange_Click(object sender, EventArgs e)
        {
            BusinessLayer.blUserAdmin blAdmin = new blUserAdmin();

            if (oldpassowrd == txtOld.Text)
            {
                if (txtNew.Text == txtNewtry.Text)
                {
                    DialogResult msg;
                    msg = MessageBox.Show("Are you sure you want to change your password?", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (msg == DialogResult.Yes)
                    {

                        blAdmin.changePassword(lblUsername.Text, txtNew.Text);
                        MessageBox.Show("Successfully change password", "new password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        blAdmin.UpdateAuditTrail(lblUsername.Text, "Change Password", "Change Password","","");

                        frmChangePassword frm = new frmChangePassword();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("mismatch password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("invalid old password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void populateData()
        {
            lblUsername.Text = userConfiguration.User;
            oldpassowrd = userConfiguration.UserPassword;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            populateData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
