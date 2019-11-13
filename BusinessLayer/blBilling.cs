using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLayer
{
    public class blBilling
    {
        DataAccess.clsDataAccess mclsDa = new DataAccess.clsDataAccess();
        DataTable dt;


        public DataTable UpdateTransactionHeader(string transCode, string customerCode, string Orno, decimal discount, decimal total, string createdby)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@TransactionCode", transCode);
            mclsDa.AddParamater("@CustomerCode", customerCode);
            mclsDa.AddParamater("@OrNo", Orno);
            mclsDa.AddParamater("@Discount", discount);
            mclsDa.AddParamater("@Total", total);
            mclsDa.AddParamater("@Createdby", createdby);
            mclsDa.AddParamater("@GetId", SqlDbType.Int, ParameterDirection.Output);
            return mclsDa.ExecuteQuery("UpdateTransactionHeader", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public void UpdateTransactionDetails(DataTable dt, int transactionId)
        {

            foreach (DataRow row in dt.Rows)
            {
                mclsDa.dbConnection();
                mclsDa.ClearParameter();
                mclsDa.AddParamater("@TransactionId", transactionId);
                mclsDa.AddParamater("@ItemCode", row["ItemCode"].ToString());
                mclsDa.AddParamater("@OrderQty", row["OrderQty"].ToString());
                mclsDa.ExecuteQuery("UpdateTransactionDetails", CommandType.StoredProcedure);
                mclsDa.dbClose();
            }

        }

        public void UpdateCustomerPayment(int transactionId, string customerCode, decimal amountPaid, string createdBy, string paymentType,string cheque)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@TransactionId", transactionId);
            mclsDa.AddParamater("@CustomerCode", customerCode);
            mclsDa.AddParamater("@AmountPaid", amountPaid);
            mclsDa.AddParamater("@CreatedBy", createdBy);
            mclsDa.AddParamater("@PaymentType", paymentType);
            mclsDa.AddParamater("@Cheque", cheque);
            mclsDa.ExecuteQuery("UpdateCustomerPayment", CommandType.StoredProcedure);
            mclsDa.dbClose();
        }

        public DataTable getTransactionCode()
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            return mclsDa.ExecuteQuery("getTransactionCode", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public DataTable getTransCodeBalance(string customerCode)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@CustomerCode", customerCode);
            return mclsDa.ExecuteQuery("getTransCodeBalance", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public DataTable getRemainingBalance(string customerCode,string transCode)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@CustomerCode", customerCode);
            mclsDa.AddParamater("@TransactionCode", transCode);
            return mclsDa.ExecuteQuery("getRemainingBalance", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }



    }
}
