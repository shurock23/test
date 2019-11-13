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
    public partial class frmCashier : Form
    {
        public frmCashier()
        {
            InitializeComponent();
        }

        BusinessLayer.blCustomer blCustomer = new BusinessLayer.blCustomer();
        BusinessLayer.blInventory blInventory = new BusinessLayer.blInventory();
        BusinessLayer.blUserAdmin blUserAdmin = new BusinessLayer.blUserAdmin();

        DataTable dtCasheirInv;
        DataTable dtOrderList = new DataTable();
        double subTotal, Discount, TotaAmount;

        private void frmCashier_Load(object sender, EventArgs e)
        {
            populateCustomer(); populateInventory();

            txtDiscount.Text = "0.00";


            group1.Location = new Point(12, 47);


            dtOrderList.Columns.Add("ItemCode");
            dtOrderList.Columns.Add("ItemName");
            dtOrderList.Columns.Add("Price");
            dtOrderList.Columns.Add("OrderQty");
            dtOrderList.Columns.Add("Total", typeof(double));

            populateDatagridviewDesign();
        }
        public void populateCustomer()
        {
            DataTable dt;
            dt = blCustomer.getCustomer();
            dgCustomer.Columns.Clear();
            dgCustomer.DataSource = dt;
            dgCustomer.Columns[0].Width = 120;
            dgCustomer.Columns[1].Width = 120;
            dgCustomer.Columns[2].Width = 120;

        }

        protected void populateInventory()
        {

            dtCasheirInv = blInventory.getInventoryCashier();
            //dgMain.Columns.Clear();
            dgInventory.DataSource = dtCasheirInv;
            dgInventory.Columns[5].Width = 50;
            //dgMain.Columns[3].Width = 220;
        }

        private void dgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow dr = dgCustomer.SelectedRows[0];
                txtCustomerCode.Text = dr.Cells[0].Value.ToString();

            }

            finally { }
        }

        private void dgInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            DataGridViewRow dr = dgInventory.SelectedRows[0];
            int i = dgInventory.CurrentRow.Index;

            String inputQty = Microsoft.VisualBasic.Interaction.InputBox("Qrder Qty", "Prompt", "0", 500, 300);

            int n;
            bool isNumeric = int.TryParse(inputQty, out n);
            if (isNumeric == true)
            {
                if (Convert.ToInt32(inputQty) > 0)
                {
                    var qty = Convert.ToInt32(dtCasheirInv.Rows[i][3]);

                    if (Convert.ToInt32(inputQty) > qty)
                    {
                        MessageBox.Show("out of stocks..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dtCasheirInv.Rows[i][5] = 0;
                        dtCasheirInv.Rows[i][0] = false;
                    }
                    else
                    {
                        dtCasheirInv.Rows[i][5] = inputQty;
                        dtCasheirInv.Rows[i][0] = true;


                        DataRow row = dtOrderList.Select("ItemCode= '" + dtCasheirInv.Rows[i][1].ToString() + "' ").FirstOrDefault();

                        if (row != null)
                        {
                            row["OrderQty"] = dtCasheirInv.Rows[i][5];
                            row["Total"] = Convert.ToDecimal(row["Price"]) * Convert.ToDecimal(dtCasheirInv.Rows[i][5]);
                        }
                        else
                        {
                            var iTotal = Convert.ToDecimal(dtCasheirInv.Rows[i][4]) * Convert.ToDecimal(dtCasheirInv.Rows[i][5]);
                            dtOrderList.Rows.Add(dtCasheirInv.Rows[i][1].ToString(), dtCasheirInv.Rows[i][2].ToString(), dtCasheirInv.Rows[i][4], dtCasheirInv.Rows[i][5], iTotal);
                        }


                    }
                }
                else
                {
                    dtCasheirInv.Rows[i][0] = false;
                    dtCasheirInv.Rows[i][5] = inputQty;

                    DataRow[] rows = dtOrderList.Select("ItemCode= '" + dtCasheirInv.Rows[i][1].ToString() + "' ");


                    foreach (var drow in rows)
                    {
                        drow.Delete();
                    }
                    dtOrderList.AcceptChanges();


                }
            }
            else
            {
                MessageBox.Show("Please input Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtCasheirInv.Rows[i][5] = 0;
                dtCasheirInv.Rows[i][0] = false;
            }
            //}
            //catch (Exception ex)
            //{
            //    //error logs

            //    return;
            //}

        }

        private void Computation()
        {

            subTotal = Convert.ToDouble(txtSubTotal.Text);
            Discount = Convert.ToDouble(txtDiscount.Text);

            txtTotal.Text = (subTotal - Discount).ToString("0.00");

        }


        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtOrderList.Rows.Count > 0 && txtCustomerCode.Text != "")
                {
                    group1.Visible = false;

                    int sum = Convert.ToInt32(dtOrderList.Compute("SUM(Total)", string.Empty));
                    txtSubTotal.Text = sum.ToString();
                    dgOrder.DataSource = dtOrderList;
                    dgOrder.Columns[4].Width = 70;

                    Computation();
                }
                else
                {
                    MessageBox.Show("Please select item and customer to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            finally { }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            frmPayment frm = new frmPayment();
            frm.populateData(dtOrderList, decimal.Parse(txtTotal.Text), txtOrno.Text, decimal.Parse(txtDiscount.Text), txtCustomerCode.Text);
            frm.Show();
            frm.MdiParent = this.MdiParent;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            group1.Visible = true;
        }

        void populateDatagridviewDesign()
        {
            dgOrder.BorderStyle = BorderStyle.None;
            dgOrder.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgOrder.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgOrder.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgOrder.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgOrder.BackgroundColor = Color.White;

            dgOrder.EnableHeadersVisualStyles = false;
            dgOrder.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgOrder.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgOrder.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgInventory.BorderStyle = BorderStyle.None;
            dgInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgInventory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgInventory.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgInventory.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgInventory.BackgroundColor = Color.White;

            dgInventory.EnableHeadersVisualStyles = false;
            dgInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgCustomer.BorderStyle = BorderStyle.None;
            dgCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgCustomer.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgCustomer.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgCustomer.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgCustomer.BackgroundColor = Color.White;

            dgCustomer.EnableHeadersVisualStyles = false;
            dgCustomer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgCustomer.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }


    }
}
