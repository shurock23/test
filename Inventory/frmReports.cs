using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace Inventory
{
    public partial class frmReports : Form
    {
        public frmReports()
        {
            InitializeComponent();
        }

        blUserAdmin bladmin = new blUserAdmin();
        DataTable dtReport = new DataTable();
        string msg = string.Empty;

        private void btnPrint_Click(object sender, EventArgs e)
        {
            msg = string.Empty;
            dgReports.DataSource = null;
            dtReport = null;
            btnSendEmail.Enabled = false;
            txtEmail.Enabled = false;

            if (rblnventory.Checked)
            {
                dgReports.DataSource = bladmin.rptInventory();
                dgReports.Columns[5].Width = 120;
            }
            else if (rbCustomer.Checked)
            {
                dgReports.DataSource = bladmin.rptCustomer();
                dgReports.Columns[0].Width = 120;
                dgReports.Columns[2].Width = 120;
            }
            else if (rbDailyReport.Checked)
            {
                msg = "Daily Sales Report";
                dtReport = bladmin.rptSalesReport("Daily", dtDaily.Value, "", "");
                dgReports.DataSource = dtReport;
                dgReports.Columns[0].Width = 120;
                dgReports.Columns[2].Width = 120;
                dgReports.Columns[4].Width = 120;
            }
            else if (rbMonthly.Checked)
            {
                if (cmbMonth.Text != "" && cmbYear.Text != "")
                {
                    msg = "Monthly Sales Report";
                    dtReport = bladmin.rptSalesReport("Monthly", dtDaily.Value, cmbMonth.Text, cmbYear.Text);
                    dgReports.DataSource = dtReport;
                    dgReports.Columns[0].Width = 120;
                    dgReports.Columns[2].Width = 120;
                    dgReports.Columns[4].Width = 120;

                }
                else
                {
                    MessageBox.Show("Please fill up the blank", "Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (rbYearly.Checked)
            {
                if (cmbYearly.Text != "")
                {
                    msg = "Yearly Sales Report";
                    dtReport = bladmin.rptSalesReport("Yearly", dtDaily.Value, cmbMonth.Text, cmbYearly.Text);
                    dgReports.DataSource = dtReport;
                    dgReports.Columns[0].Width = 120;
                    dgReports.Columns[2].Width = 120;
                    dgReports.Columns[4].Width = 120;
                }
                else
                {
                    MessageBox.Show("Please fill up the blank", "Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (dgReports.Rows.Count > 0)
            {
                btnSendEmail.Enabled = true;
                txtEmail.Enabled = true;

            }
        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMonthly.Checked == true)
            {
                cmbMonth.Enabled = true;
                cmbYear.Enabled = true;
            }
            else
            {
                cmbMonth.Enabled = false;
                cmbYear.Enabled = false;
            }
        }

        private void rbYearly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYearly.Checked == true)
            { cmbYearly.Enabled = true; }
            else { cmbYearly.Enabled = false; }
        }

        private void rbDailyReport_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDailyReport.Checked == true)
            { dtDaily.Enabled = true; }
            else { dtDaily.Enabled = false; }
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            cmbMonth.Enabled = false;
            cmbYear.Enabled = false;
            dtDaily.Enabled = false;
            cmbYearly.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void SendEmailReport()
        {
            try
            {
                string headerBody = "<p>" + "<B>" + msg + "</br>";
                string textBody = " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + "><tr bgcolor='#4da6ff'><td><b>Transaction Code</td> <td><b>ORNO</b></td> <td><b>Transaction Date</b></td>  <td><b>Total Amount</b></td> <td><b>Customer Code</b></td></tr>";

                for (int i = 0; i < dtReport.Rows.Count; i++)
                {
                    textBody += "<tr><td>" + dtReport.Rows[i]["Transaction Code"].ToString() + "</td><td> " + dtReport.Rows[i]["ORNO"].ToString() + "</td><td> " + dtReport.Rows[i]["Transaction Date"] + "</td> <td> " + dtReport.Rows[i]["Total Amount"] + "</td> <td> " + dtReport.Rows[i]["Customer Code"] + "</td></tr>";
                }

                textBody += "</table>";



                MailMessage mail = new MailMessage();

                mail.From = new MailAddress("debelen.shopinventory@gmail.com");
                mail.To.Add(txtEmail.Text);
                mail.Subject = "Sales Report";
                mail.Body = headerBody + textBody;
                mail.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new System.Net.NetworkCredential("debelen.shopinventory@gmail.com", "debelen@shopinventory123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;

                smtp.Timeout = 30000;

                smtp.Send(mail);

                bladmin.UpdateAuditTrail(userConfiguration.User, "Report Form", "Send email", "", txtEmail.Text);
                MessageBox.Show("Successfully sent to your email.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (FormatException ex)
            {
                MessageBox.Show("Invalid email format.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Sending email failed.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != string.Empty)
            {
                if (CheckForInternetConnection())
                {
                    SendEmailReport();
                    txtEmail.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("No Internet connection found.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please input email address.", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
