using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOP
{
    internal class controllDataBase
    {
        private static string _dataBasePath { get; set; }

        public controllDataBase(string dataBasePath){
            _dataBasePath = dataBasePath;
        }

        //========
        //Deleting
        //========
        public void Delete(string tableName, string columnName, string elementID)
        {
            using (SqlConnection Conn = new SqlConnection(_dataBasePath))
            {
                Conn.Open();
                string myquery = "delete from "+ tableName +" where " + columnName +"='" + elementID + "'";

                using (SqlCommand commandDeleting = new SqlCommand(myquery, Conn)) {
                    commandDeleting.ExecuteNonQuery();
                    Conn.Close();
                
                }       
            }
           
        }

        //=========
        //Inserting
        //=========

        public void Add(string tableName, string insertingElements)
        {
            using (SqlConnection Conn = new SqlConnection(_dataBasePath)) { 
            
                Conn.Open();
                string myquery = "insert into " + tableName + " values('" + insertingElements + "');";

                using (SqlCommand commandInserting = new SqlCommand(myquery, Conn))
                {
                    commandInserting.ExecuteNonQuery();
                    Conn.Close();
                }
            
            }
            
        }

        //==================
        //Getting table data
        //==================

        public DataTable Get(string tableName, string columnNames)
        {
            using (SqlConnection Conn = new SqlConnection(_dataBasePath))
            {
                Conn.Open();
                string myQuery = "select " + columnNames + " from " + tableName;

                using (SqlDataAdapter da = new SqlDataAdapter(myQuery, Conn)) { 
                    SqlCommandBuilder builder = new SqlCommandBuilder(da);
                    var ds = new DataSet();
                    da.Fill(ds, "Table");
                    DataTable table = ds.Tables["Table"];
                    Conn.Close();
                    return table;
                }


            }
        }

    }
}
