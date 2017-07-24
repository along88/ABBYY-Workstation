using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//using Microsoft.Office.Interop.Excel;
using System.Configuration;
namespace SharperWorkstation.WorkstationModels
{
    public class SearchModel : ISearchModel
    {
        private string controlNo; 
        private string errorMessage;
        private DataTable grid;
        private string connectionString = "Data Source=10.10.11.112;Initial Catalog=ABBYY_AppData;Integrated Security=False;User ID=svc-flexicap;Password=svcflex;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public string ControlNo
        {
            get{ return controlNo; }
            set{ controlNo = value; }
        }
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        public DataTable Grid
        {
            get { return grid; }
            set { grid = value; }
        }
            
        public bool Connect()
        {
            
           SqlConnection sqlconnection = new SqlConnection(connectionString);
           try
            {
                sqlconnection.Open();
                sqlconnection.Close();
                return true;
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
                return false;
            }

        }

        public DataTable ReturnData(string query)
        {

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }


    }
}
