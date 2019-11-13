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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
            populateTable();
        }
        BusinessLayer.blInventory blInventory = new BusinessLayer.blInventory();
        BusinessLayer.blUserAdmin blUserAdmin = new BusinessLayer.blUserAdmin();
        //string username = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            // errorNotify.SetError(txtName, "Please fillup");

            DialogResult msg;
            msg = MessageBox.Show("Are you sure you want to Save this Record", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msg == DialogResult.Yes)
            {
                blInventory.UpdateInventory(txtItemCode.Text, txtName.Text, Int16.Parse(txtStock.Text), decimal.Parse(txtPrice.Text), "", userConfiguration.User);              
                blUserAdmin.UpdateAuditTrail(userConfiguration.User, "Inventory Form", "Saving Record", "", txtName.Text);

                populateTable();
                enabledTestbuttons("load");
                clearfields();
                MessageBox.Show("Record Successfully Saved.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            populateTable();
            enabledTestbuttons("load");

            populateDatagridviewDesign();
        }


        public void populateTable()
        {
            DataTable dt;
            dt = blInventory.getData();
            dgMain.Columns.Clear();
            dgMain.DataSource = dt;
            dgMain.Columns[2].Width = 80;
            dgMain.Columns[3].Width = 100;
            dgMain.Columns[5].Width = 120;
        }

        //public void populateUsername(string user)
        //{
        //    username = user;
        //}
        private void dgMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clearfields();

                DataGridViewRow dr = dgMain.SelectedRows[0];
                txtItemCode.Text = dr.Cells[0].Value.ToString();
                txtName.Text = dr.Cells[1].Value.ToString();
                txtStock.Text = dr.Cells[2].Value.ToString();
                txtPrice.Text = dr.Cells[3].Value.ToString();


                enabledTestbuttons("grid");
            }

            finally { }
        }
        private void dgMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            enabledTestbuttons("add");

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            enabledTestbuttons("edit");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult msg;
            msg = MessageBox.Show("Are you sure you want to Delete Selected item?", "Inventory", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {

                blInventory.DeleteItem(txtItemCode.Text);
                blUserAdmin.UpdateAuditTrail(userConfiguration.User, "Inventory Form", "Deleting Record", "", txtItemCode.Text);

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

        private void txtStock_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

                txtName.Enabled =
               txtStock.Enabled =
               txtPrice.Enabled =
                                false;
            }

            else if (val == "add")
            {
                clearfields();

                btnAdd.Enabled =
             btnCancel.Enabled =

               txtName.Enabled =
              txtStock.Enabled =
               txtPrice.Enabled =
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

                txtName.Enabled =
               txtStock.Enabled =
                txtPrice.Enabled =
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

                txtName.Enabled =
               txtStock.Enabled =
               txtPrice.Enabled =
                                 false;
            }

            else if (val == "cancel")
            {

            }

        }



        void clearfields()
        {

            txtItemCode.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";
            txtPrice.Text = string.Empty;
        }

        private void dgMain_CellContentClick(object sender, EventArgs e)
        {

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text != "")
            {
                frmReStock frm = new frmReStock();
                frm.populateData(txtItemCode.Text, txtName.Text);
                frm.Show();
                frm.MdiParent = this.MdiParent;
            }
            else
            {
                MessageBox.Show("Please select item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            populateTable();
        }

        void populateDatagridviewDesign()
        {
            dgMain.BorderStyle = BorderStyle.None;
            dgMain.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgMain.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgMain.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgMain.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgMain.BackgroundColor = Color.White;

            dgMain.EnableHeadersVisualStyles = false;
            dgMain.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgMain.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgMain.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;       
        }

    }
}
