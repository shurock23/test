using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class clsDataAccess
    {
        public SqlConnection sqlConn { get; set; }
        public SqlParameter sqlParam { get; set; }
        public SqlCommand sqlCom { get; set; }
        public SqlTransaction sqlTrans { get; set; }
        string cons = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        public void dbConnection()
        {
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = cons;
            sqlConn.Open();
            sqlParam = new SqlParameter();
            sqlCom = new SqlCommand();
        }

        public void dbClose()
        {
            //czxcxz
            sqlConn.Close();
        }

        public void ClearParameter()
        {
            sqlParam = new SqlParameter();
            sqlCom = new SqlCommand();
        }

        public void AddParamater(string ParaName, object ParaValue)
        {
            sqlCom.Parameters.AddWithValue(ParaName, ParaValue);
        }

        public void AddParamater(string ParaName, object ParaValue , ParameterDirection ParamDirect)
        {
            sqlCom.Parameters.AddWithValue(ParaName, ParaValue).Direction = ParameterDirection.Output;          
        }

        public DataSet ExecuteQuery(string SQL, CommandType ctype)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            sqlCom.CommandTimeout = 0;
            sqlCom.Transaction = sqlTrans;
            sqlCom.CommandText = SQL;
            sqlCom.CommandType = ctype;
            sqlCom.Connection = sqlConn;
            da.SelectCommand = sqlCom;
            da.Fill(ds);
            return ds;
        }

    }
}
