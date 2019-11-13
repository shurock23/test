using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLayer
{
    public class blUserAdmin
    {
        DataAccess.clsDataAccess mclsDa = new DataAccess.clsDataAccess();
        DataTable dt;

        public DataTable getLogin(string username, string password)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@username", username);
            mclsDa.AddParamater("@password", password);
            return mclsDa.ExecuteQuery("getLogin", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();

        }

        public void UpdateAuditTrail(string username, string module, string action, string oldvalues, string newvalues)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@Username", username);
            mclsDa.AddParamater("@Module", module);
            mclsDa.AddParamater("@Action", action);
            mclsDa.AddParamater("@OldValues", oldvalues);
            mclsDa.AddParamater("@NewValues", newvalues);
            mclsDa.ExecuteQuery("UpdateAuditTrail", CommandType.StoredProcedure);
            mclsDa.dbClose();
        }

        public DataTable getAuditTrail()
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            return mclsDa.ExecuteQuery("getAuditTrail", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public DataTable getAuditTrailDateRange(DateTime dateTo, DateTime dateFrom)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@dateTo", dateTo);
            mclsDa.AddParamater("@dateFrom", dateFrom);
            return mclsDa.ExecuteQuery("getAuditTrailDateRange", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public void changePassword(string username, string password)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@userAdmin", username);
            mclsDa.AddParamater("@userPass", password);
            mclsDa.ExecuteQuery("UpdatePassowrd", CommandType.StoredProcedure);
            mclsDa.dbClose();
        }

        public DataTable rptInventory()
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            return mclsDa.ExecuteQuery("rptInventory", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }
        public DataTable rptCustomer()
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            return mclsDa.ExecuteQuery("rptCustomer", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public DataTable rptSalesReport(string Report, DateTime datedaily, string month, string year)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@Report", Report);
            mclsDa.AddParamater("@datedaily", datedaily);
            mclsDa.AddParamater("@month", month);
            mclsDa.AddParamater("@year", year);
            return mclsDa.ExecuteQuery("rptSalesReport", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

    }
}
