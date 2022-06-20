using System;
using System.Collections.Generic;
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

        public void Delete(string tableName, string columnName, string elementID)
        {
            using (SqlConnection Conn = new SqlConnection(_dataBasePath))
            {

                Conn.Open();
                string myquery = "delete from "+ tableName +" where " + columnName +"='" + elementID + "'";

                using (SqlCommand command = new SqlCommand(myquery, Conn)) { 
                    command.ExecuteNonQuery();
                    Conn.Close();
                
                }
                    
                
            }
           
        }
    }
}
