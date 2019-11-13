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
    public partial class frmReStock : Form
    {
        public frmReStock()
        {
            InitializeComponent();
        }

        BusinessLayer.blInventory blInventory = new BusinessLayer.blInventory();
        BusinessLayer.blUserAdmin blUserAdmin = new BusinessLayer.blUserAdmin();

        DataTable dt;

        private void frmReStock_Load(object sender, EventArgs e)
        {

        }

        public void populateData(string ItemCode, string ItemName)
        {
            txtItemCode.Text = ItemCode;
            txtItemName.Text = ItemName;

            dt = blInventory.getOrNoDetails(ItemCode);
            dgMain.Columns.Clear();
            dgMain.DataSource = dt;
            dgMain.Columns[0].Width = 50;
            dgMain.Columns[4].Width = 120;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult msg;
            msg = MessageBox.Show("Are you sure you want to Restock this item?", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                blInventory.UpdateStocks(txtItemCode.Text, txtOrNo.Text, Int32.Parse(txtRestock.Text));
                populateData(txtItemCode.Text, txtItemName.Text);
                blUserAdmin.UpdateAuditTrail(userConfiguration.User, "ReStock Form", "Restock", "", txtRestock.Text);
                blUserAdmin.UpdateAuditTrail(userConfiguration.User, "ReStock Form", "OrNo", "", txtOrNo.Text);

                txtRestock.Text = "";
                txtOrNo.Text = "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void txtRestock_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
