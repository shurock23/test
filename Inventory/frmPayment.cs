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
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }
        BusinessLayer.blBilling blBilling = new BusinessLayer.blBilling();
        BusinessLayer.blUserAdmin blUserAdmin = new BusinessLayer.blUserAdmin();

        DataTable dt;
        decimal _iTotal;
        string _ORno;
        decimal _discount;
        string _customerCode;



        private void btnProcess_Click(object sender, EventArgs e)
        {
            DialogResult msg;
            msg = MessageBox.Show("Are you sure you want to pay this transaction?", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                DataTable dtTransCode = blBilling.getTransactionCode();
                DataTable dtGetTransId = blBilling.UpdateTransactionHeader(dtTransCode.Rows[0]["TransactionCode"].ToString(), _customerCode, _ORno, _discount, _iTotal, "");
                blBilling.UpdateTransactionDetails(dt, Convert.ToInt32(dtGetTransId.Rows[0]["TransactionId"]));
                blBilling.UpdateCustomerPayment(Convert.ToInt32(dtGetTransId.Rows[0]["TransactionId"]), _customerCode, decimal.Parse(txtAmountPaid.Text), userConfiguration.User, cmbPayment.Text, txtCheque.Text);

                blUserAdmin.UpdateAuditTrail(userConfiguration.User, "Payment Form", "Payment", "", dtTransCode.Rows[0]["TransactionCode"].ToString());

                MessageBox.Show("Transaction Successfully Saved.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void populateData(DataTable dtOrder, decimal iTotal, string ORNo, decimal discount, string customerCode)
        {
            dt = dtOrder;
            _iTotal = iTotal;
            _ORno = ORNo;
            _discount = discount;
            _customerCode = customerCode;
            txtTotal.Text = iTotal.ToString("0.00");
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {

        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayment.Text == "Cheque")
            {
                lbCheque.Visible = true;
                txtCheque.Visible = true;
            }
            else
            {
                lbCheque.Visible = false;
                txtCheque.Visible = false;
            }
        }

        private void txtAmountPaid_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}
