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
    public partial class frmAuditTrail : Form
    {
        public frmAuditTrail()
        {
            InitializeComponent();
        }

        BusinessLayer.blUserAdmin blAdmin = new BusinessLayer.blUserAdmin();
        DataTable dt;

     

        private void frmAuditTrail_Load(object sender, EventArgs e)
        {
            dt = blAdmin.getAuditTrail();
            dgAuditTrail.Columns.Clear();
            dgAuditTrail.DataSource = dt;
            dgAuditTrail.Columns[0].Width = 50;
            dgAuditTrail.Columns[4].Width = 150;

            populateDatagridviewDesign();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            dt = blAdmin.getAuditTrailDateRange(dateTo.Value, dateFrom.Value);
            dgAuditTrail.Columns.Clear();
            dgAuditTrail.DataSource = dt;
            dgAuditTrail.Columns[0].Width = 50;
            dgAuditTrail.Columns[4].Width = 150;
        }

        void populateDatagridviewDesign()
        {
            dgAuditTrail.BorderStyle = BorderStyle.None;
            dgAuditTrail.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgAuditTrail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgAuditTrail.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgAuditTrail.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgAuditTrail.BackgroundColor = Color.White;

            dgAuditTrail.EnableHeadersVisualStyles = false;
            dgAuditTrail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgAuditTrail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgAuditTrail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
