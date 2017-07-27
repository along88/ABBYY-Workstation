using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharperWorkstation.WorkstationModels
{
    class EditModel : IEditModel
    {
        private object grid;
        public object Grid
        {
            get { return grid; }
            set { grid = value; }
        }

        public IList<string> selectedCells
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string ControlNo
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private string connectionString = "Data Source=10.10.11.112;Initial Catalog=ABBYY_AppData;Integrated Security=False;User ID=svc-flexicap;Password=svcflex;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string errorMessage;
        

        public bool Connect()
        {

            SqlConnection sqlconnection = new SqlConnection(connectionString);
            try
            {
                sqlconnection.Open();
                //string sqlQuery = string.Format("SELECT * FROM Acord140_Critical inner join PremisesInformation on Acord140_Critical.Acord140_CriticalID = PremisesInformation.Acord140_CriticalID WHERE ControlNoIMS = '{0}'", controlNo);
                //command = new SqlCommand(sqlQuery, sqlconnection);
                //command.ExecuteNonQuery();
                //command.Dispose();
                //grid = ReturnData(sqlQuery);
                sqlconnection.Close();
                return true;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }

        }

        public DataTable LoadGrid(string query)
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

        public DataTable ExportGrid()
        {

            DataTable table = new DataTable();
            table = (DataTable)Grid;
            return table;
        }

    }
}
