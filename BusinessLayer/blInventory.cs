using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace BusinessLayer
{
    public class blInventory
    {

        DataAccess.clsDataAccess mclsDa = new DataAccess.clsDataAccess();
        DataTable dt;

        public DataTable getData()
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            return mclsDa.ExecuteQuery("getInventory", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }


        public void UpdateInventory(string ItemCode, string ItemName, int stock, decimal price, string desc, string createdby)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@ItemCode", ItemCode);
            mclsDa.AddParamater("@ItemName", ItemName);
            mclsDa.AddParamater("@Stock", stock);
            mclsDa.AddParamater("@Price", price);
            mclsDa.AddParamater("@ItemDescription", desc);
            mclsDa.AddParamater("@Createdby", createdby);
            mclsDa.ExecuteQuery("UpdateInventory", CommandType.StoredProcedure);
            mclsDa.dbClose();
        }

        public DataTable getOrNoDetails(string itemcode)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@ItemCode", itemcode);
            return mclsDa.ExecuteQuery("getOrNoDetails", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public void UpdateStocks(string ItemCode, string OrNo , int qty)
        {
             mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@ItemCode", ItemCode);      
            mclsDa.AddParamater("@Stock", qty);
            mclsDa.AddParamater("@OrNo", OrNo);
            mclsDa.ExecuteQuery("UpdateStocks", CommandType.StoredProcedure);
            mclsDa.dbClose();
        }

        public DataTable getInventoryCashier()
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            return mclsDa.ExecuteQuery("getInventoryCashier", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public DataTable getItemOrder(string transactionCode)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@TransactionCode", transactionCode);
            return mclsDa.ExecuteQuery("getItemOrder", CommandType.StoredProcedure).Tables[0];
            mclsDa.dbClose();
        }

        public void DeleteItem(string ItemCode)
        {
            mclsDa.dbConnection();
            mclsDa.ClearParameter();
            mclsDa.AddParamater("@ItemCode", ItemCode);
            mclsDa.ExecuteQuery("DeleteItem", CommandType.StoredProcedure);
            mclsDa.dbClose();
        }
    }
}
