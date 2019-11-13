using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessLayer
{
    public class blCustomer
    {
        DataAccess.clsDataAccess mclsDa = new DataAccess.clsDataAccess();
        DataTable dt;

        public DataTable getCustomer()
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            return mclsDa.ExecuteQuery("getCustomer", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public void UpdateCustomer(string CustomerCode, string Name, string mobileNo)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@CustomerCode", CustomerCode);
            mclsDa.AddParamater("@CustomerName", Name);
            mclsDa.AddParamater("@MobileNo", mobileNo);
            mclsDa.ExecuteQuery("UpdateCustomer", CommandType.StoredProcedure);
            mclsDa.dbClose();
        }

        public DataTable getCustomerPayment(string customderCode)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@CustomerCode", customderCode);
            return mclsDa.ExecuteQuery("getCustomerPayment", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public void DeleteCustomer(string customerCode)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@CustomerCode", customerCode);
            mclsDa.ExecuteQuery("DeleteCustomer", CommandType.StoredProcedure);
            mclsDa.dbClose();
        }
    }
}
