using System.Data;
using System.Data.OleDb;

namespace KSAA.DocumentService.DAL
{
    public class OLEDBDataAccessLayer
    {
        OleDbConnection _pOleDBConnection;
        private static string _filePath = string.Empty;
        OleDbDataAdapter _pOleDBDataAdapter;
        OleDbCommand pOleDBCommand;
        OleDbDataReader _pSQLDataReader;

        public OLEDBDataAccessLayer()
        {
            
        }
        public OLEDBDataAccessLayer(string filePath)
        {
            _filePath = filePath;   
        }

        #region Private Methods
        private static string GetOleDBConnectionString()
        {
            return string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", _filePath);
        }

        private void Dispose()
        {
            if (pOleDBCommand != null)
                pOleDBCommand.Dispose();

            if (_pOleDBConnection.State != ConnectionState.Closed)
            {
                _pOleDBConnection.Close();
                _pOleDBConnection.Dispose();
            }
        }
        private void BuildCommand(CommandType cmdType, string cmdText)
        {
            pOleDBCommand = new OleDbCommand(cmdText, _pOleDBConnection);
            pOleDBCommand.CommandType = cmdType;
        }
        #endregion
        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText)
        {
            DataSet ds = new DataSet();
            _pOleDBConnection = new OleDbConnection(GetOleDBConnectionString());
            BuildCommand(cmdType, cmdText);
            _pOleDBDataAdapter = new OleDbDataAdapter();
            _pOleDBDataAdapter.SelectCommand = pOleDBCommand;
            _pOleDBDataAdapter.Fill(ds);
            return ds;
        }

        public string GetSheetName()
        {
            string sheetName = string.Empty;
            try
            {
                _pOleDBConnection = new OleDbConnection(GetOleDBConnectionString());
                _pOleDBConnection.Open();
                sheetName = Convert.ToString(_pOleDBConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"]);
                sheetName = sheetName == null ? "Sheet1$" : sheetName; 
                _pOleDBConnection.Close();
                return sheetName;
            }
            catch(Exception _ex)
            {
                throw _ex;
            }
            
        }
    }
}
