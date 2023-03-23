using System.Data;
using System.Data.SqlClient;

namespace KSAA.DocumentService.DAL
{
    public class DataAccessLayer
    {
        private const string tblMonthlyGLIncomeRegister = "tbl_Monthly_GL_Income_Register";
        private const string tblMonthlySupplyRegister = "tbl_Monthly_Supply_Register";
        private const string tblITCRegister = "tbl_ITC_Register";
        private const string tblLiabilityLedger = "tbl_Liability_Ledger";
        private const string tblEInvoiceRegister = "tbl_E_Invoice_Register";
        private const string tblEWayBillRegister = "tbl_E_Way_Bill_Register";
        private const string tblAdvanceReceived = "tbl_Advance_Received_Module";
        private const string tblFinalOutputRegister = "tbl_Final_Output_Register_KSAA_Template";
            
            
        private const string constr = "Data Source=20.110.59.160;Initial Catalog=KSAA_Dev;User ID=AppDevUser;Password=KSAAdev@2022;Integrated security=false";
        SqlConnection _pSQLCon;
        SqlDataAdapter _pSQLDataAdapter;
        SqlCommand _pSQLCommand;
        SqlDataReader _pSQLDataReader;
        SqlBulkCopy _pSQLBulkCopy;
        
        public DataAccessLayer()
        {
            
        }

        #region Private Methods
        private static string GetConnectionString()
        {
            //IConfiguration configuration = new ConfigurationManager();
            //return configuration.GetConnectionString("ExcelMSSQLConnection");
            return constr;
        }
        private void Dispose()
        {
            if (_pSQLCommand != null)
                _pSQLCommand.Dispose();

            if (_pSQLCon.State != ConnectionState.Closed)
            {
                _pSQLCon.Close();
                _pSQLCon.Dispose();
            }
        }
        private void BuildCommand(CommandType cmdType, string cmdText)
        {
            _pSQLCommand = new SqlCommand(cmdText, _pSQLCon);
            _pSQLCommand.CommandType = cmdType;
        }
        #endregion

        #region Public Methods
        public SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] parameters)
        {
            try
            {
                _pSQLCon = new SqlConnection(GetConnectionString());
                BuildCommand(cmdType, cmdText);
                foreach (SqlParameter param in parameters)
                {
                    _pSQLCommand.Parameters.Add(param);
                }
                _pSQLCon.Open();
                _pSQLDataReader = _pSQLCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return _pSQLDataReader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_pSQLCommand != null)
                {
                    _pSQLCommand.Dispose();
                }
            }
        }
        public object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] parameters)
        {
            try
            {
                _pSQLCon = new SqlConnection(GetConnectionString());
                BuildCommand(cmdType, cmdText);
                foreach (SqlParameter param in parameters)
                {
                    _pSQLCommand.Parameters.Add(param);
                }
                _pSQLCon.Open();
                return _pSQLCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_pSQLCommand != null)
                {
                    _pSQLCommand.Dispose();
                }
            }
        }
        public int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] param)
        {
            try
            {
                int result;
                _pSQLCon = new SqlConnection(GetConnectionString());
                _pSQLCommand = new SqlCommand(cmdText, _pSQLCon);
                _pSQLCommand.CommandType = cmdType;
                _pSQLCon.Open();

                foreach (SqlParameter par in param)
                {
                    _pSQLCommand.Parameters.Add(par);
                }
                result = _pSQLCommand.ExecuteNonQuery();
                _pSQLCon.Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
        }

        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText, params SqlParameter[] parameters)
        {
            DataSet ds = new DataSet();
            _pSQLCon = new SqlConnection(GetConnectionString());
            BuildCommand(cmdType, cmdText);
            _pSQLDataAdapter = new SqlDataAdapter();

            foreach (SqlParameter param in parameters)
            {
                _pSQLCommand.Parameters.Add(param);
            }
            _pSQLDataAdapter.SelectCommand = _pSQLCommand;
            _pSQLDataAdapter.Fill(ds);
            return ds;
        }

        public DataSet ExecuteDataSet(CommandType cmdType, string cmdText)
        {
            DataSet ds = new DataSet();
            _pSQLCon = new SqlConnection(GetConnectionString());
            BuildCommand(cmdType, cmdText);
            _pSQLDataAdapter = new SqlDataAdapter();
            _pSQLDataAdapter.SelectCommand = _pSQLCommand;
            _pSQLDataAdapter.Fill(ds);
            return ds;
        }

        public DataTable ExecuteDataTable(CommandType cmdType, string cmdText, params SqlParameter[] parameters)
        {
            DataSet ds = ExecuteDataSet(cmdType, cmdText, parameters);
            return ds.Tables[0];
        }

        public void WriteToServerCommand(DataTable dataTable, IDictionary<string,string> columnMpping, string tableName)
        {
            try
            {
                _pSQLCon = new SqlConnection(GetConnectionString());
                _pSQLBulkCopy = new SqlBulkCopy(_pSQLCon);
                _pSQLBulkCopy.DestinationTableName = tableName;
                if (columnMpping != null && columnMpping.Count > 0)
                {
                    foreach (var col in columnMpping)
                    {
                        _pSQLBulkCopy.ColumnMappings.Add(col.Value, col.Key);
                    }
                }
                _pSQLCon.Open();
                _pSQLBulkCopy.WriteToServer(dataTable);
                _pSQLCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
            
        }

        public string GetTableName(string documentType)
        {
            if (documentType != null)
            {
                if (documentType.ToUpper() == "GLINR")
                {
                    return tblMonthlyGLIncomeRegister;
                }
                else if (documentType.ToUpper() == "SUPR")
                {
                    return tblMonthlySupplyRegister;
                }
                else if (documentType.ToUpper() == "EINR")
                {
                    return tblEInvoiceRegister;
                }
                else if (documentType.ToUpper() == "EWBILR")
                {
                    return tblEWayBillRegister;
                }
                else if (documentType.ToUpper() == "LIBLGR")
                {
                    return tblLiabilityLedger;
                }
                else if (documentType.ToUpper() == "ADVREC")
                {
                    return tblAdvanceReceived;
                }
                else if (documentType.ToUpper() == "ITCR")
                {
                    return tblITCRegister;
                }
                else if (documentType.ToUpper() == "ITCGLR")
                {
                    return "";
                }
                else if (documentType.ToUpper() == "FOUTPUT")
                {
                    return tblFinalOutputRegister;
                }
                
            }

            return "";
        }
        public void Close()
        {
            this.Dispose();
        }

#endregion
    }
}
