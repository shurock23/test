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
    public partial class frmCustomer : Form
    {
        BusinessLayer.blCustomer blCustomer = new BusinessLayer.blCustomer();
        BusinessLayer.blInventory blInventory = new BusinessLayer.blInventory();
        BusinessLayer.blBilling blBilling = new BusinessLayer.blBilling();
        BusinessLayer.blUserAdmin blUserAdmin = new BusinessLayer.blUserAdmin();

        int _transactionheaderId = 0;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            populateTable();
            gbPayment.Location = new Point(296, 105);
        }

        protected void populateTable()
        {
            DataTable dt;
            dt = blCustomer.getCustomer();
            dgMain.Columns.Clear();
            dgMain.DataSource = dt;

        }

        public void enabledTestbuttons(string val)
        {
            if (val == "load")
            {
                btnAdd.Enabled =
                               true;

                btnEdit.Enabled =
                btnSave.Enabled =
              btnDelete.Enabled =
              btnCancel.Enabled =

                   txtCustomerName.Enabled =
               txtMobileNo.Enabled =
                                false;
            }

            else if (val == "add")
            {
                clearfields();

                btnAdd.Enabled =
             btnCancel.Enabled =

                  txtCustomerName.Enabled =
               txtMobileNo.Enabled =
               btnSave.Enabled =
                                true;
                btnDelete.Enabled =
                  btnEdit.Enabled =
                                   false;
            }

            else if (val == "edit")
            {
                btnAdd.Enabled =
               btnEdit.Enabled =
             btnDelete.Enabled =
                                false;

                btnSave.Enabled =
              btnCancel.Enabled =

               txtCustomerName.Enabled =
               txtMobileNo.Enabled =
                                 true;
            }


            else if (val == "grid")
            {
                btnDelete.Enabled =
                  btnEdit.Enabled =
                   btnAdd.Enabled =
                                   true;

                btnSave.Enabled =
              btnCancel.Enabled =

                txtCustomerName.Enabled =
               txtMobileNo.Enabled =

                                 false;
            }

            else if (val == "cancel")
            {

            }

        }

        void clearfields()
        {

            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            txtMobileNo.Text = "";

        }

        private void dgMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clearfields();

                DataGridViewRow dr = dgMain.SelectedRows[0];
                txtCustomerCode.Text = dr.Cells[0].Value.ToString();
                txtCustomerName.Text = dr.Cells[1].Value.ToString();
                txtMobileNo.Text = dr.Cells[2].Value.ToString();

                dgCustomerPayment.DataSource = blCustomer.getCustomerPayment(txtCustomerCode.Text);
                dgCustomerPayment.Columns[0].Width = 120;
                enabledTestbuttons("grid");
            }

            finally { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult msg;
            msg = MessageBox.Show("Are you sure you want to Save this Record", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                blCustomer.UpdateCustomer(txtCustomerCode.Text, txtCustomerName.Text, txtMobileNo.Text);
                blUserAdmin.UpdateAuditTrail(userConfiguration.User, "Customer Form", "Customer", "", txtCustomerName.Text);

                populateTable();
                enabledTestbuttons("load");
                clearfields();
                MessageBox.Show("Record Successfully Saved.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enabledTestbuttons("add");

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enabledTestbuttons("edit");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            gbPayment.Visible = true;
            DataTable dtRemainingBalance = blBilling.getTransCodeBalance(txtCustomerCode.Text);
            cmbTransactionCode.DataSource = dtRemainingBalance;
            cmbTransactionCode.DisplayMember = "transactionCode";
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            gbPayment.Visible = false;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            DialogResult msg;
            msg = MessageBox.Show("Are you sure you want to pay this transaction?", "Invetory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                blBilling.UpdateCustomerPayment(_transactionheaderId, txtCustomerCode.Text, decimal.Parse(txtAmountPaid.Text), "john", cmbPayment.Text, txtCheque.Text);
                dgCustomerPayment.DataSource = blCustomer.getCustomerPayment(txtCustomerCode.Text);
                clearfieldsPayment();
            }
        }

        private void dgCustomerPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow dr = dgCustomerPayment.SelectedRows[0];
                string transcode = dr.Cells[0].Value.ToString();
                dgItemOrder.DataSource = blInventory.getItemOrder(transcode);
            }
            finally { }
        }

        private void cmbTransactionCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtRemainingBalance = blBilling.getRemainingBalance(txtCustomerCode.Text, cmbTransactionCode.Text);
                if (dtRemainingBalance.Rows.Count > 0)
                {
                    txtRemainingBalance.Text = dtRemainingBalance.Rows[0]["RemainingBalance"].ToString();
                    _transactionheaderId = Convert.ToInt32(dtRemainingBalance.Rows[0]["Transactionheaderid"]);
                }
            }
            catch { }
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayment.Text == "Cheque")
            {
                lbcheque.Visible = true;
                txtCheque.Visible = true;
            }
            else
            {
                lbcheque.Visible = false;
                txtCheque.Visible = false;
            }
        }

        void clearfieldsPayment()
        {
            txtCheque.Text = string.Empty;
            txtRemainingBalance.Text = string.Empty;
            txtOrNo.Text = string.Empty;
            txtAmountPaid.Text = "0.00";
        }

        private void txtAmountPaid_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult msg;
            msg = MessageBox.Show("Are you sure you want to Delete Selected customer?", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {

                blCustomer.DeleteCustomer(txtCustomerCode.Text);
                blUserAdmin.UpdateAuditTrail(userConfiguration.User, "Customer Form", "Deleting Record", "", txtCustomerCode.Text);

                populateTable();
                enabledTestbuttons("load");
                clearfields();
                MessageBox.Show("Record Successfully Deleted.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            enabledTestbuttons("load");
            clearfields();
        }

    }
}
