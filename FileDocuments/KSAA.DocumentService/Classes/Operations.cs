using KSAA.DocumentService.DAL;
using KSAA.DocumentService.Interfaces;
using KSAA.DocumentService.Mapper;
using KSAA.Master.Application.DTOs.Master;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Reflection;

namespace KSAA.DocumentService.Classes
{
    public class Operations : IBase
    {
        private readonly DataAccessLayer sqlDataAccessLayer;
        private readonly OLEDBDataAccessLayer oleDBDataAccessLayer;
        private readonly ILogger _logger;

        public Operations()
        {

        }
        public Operations(string filePath, ILogger logger)
        {
            sqlDataAccessLayer = new DataAccessLayer();
            oleDBDataAccessLayer = new OLEDBDataAccessLayer(filePath);
            _logger = logger;
        }

        public async Task<ColumnsDataOperation> Import(DocumentTypeUpload docInformation)
        {
            bool isRecordInserted = false;
            GLIncomeRegisterColumns _glMapper = new GLIncomeRegisterColumns();
            try
            {
                //Read Data from excel sheet and create datatable
                var sheetName = oleDBDataAccessLayer.GetSheetName();
                string Query = string.Format("Select * FROM [{0}]", sheetName);
                var _dataSet = oleDBDataAccessLayer.ExecuteDataSet(System.Data.CommandType.Text, Query);
                _logger.LogInformation("Import Step1");

                if (_dataSet != null && _dataSet.Tables.Count > 0)
                {
                    _logger.LogInformation("Import Step2");
                    var exceldt = _dataSet.Tables[0];

                    _logger.LogInformation("Import Step3");
                    List<object> vals = new List<object>();
                    foreach (DataRow dr in exceldt.Rows)
                    {
                        dynamic expando = new ExpandoObject();
                        var expandoDict = expando as IDictionary<string, object>;
                        for (int i = 0; i < exceldt.Columns.Count; i++)
                        {
                            expandoDict.Add(exceldt.Columns[i].ColumnName, dr[exceldt.Columns[i].ColumnName]);
                        }
                        vals.Add(expando);
                    }
                    if (!docInformation.type.Equals("IAD"))
                    {
                        exceldt.Columns.Add("Month").Expression = Convert.ToString(docInformation.month);
                        exceldt.Columns.Add("Year").Expression = Convert.ToString(docInformation.year);
                    }
                    _logger.LogInformation("Import Step4");

                    if (!docInformation.type.Equals("IAD"))
                    {
                        await Task.Run(() =>
                        {
                            sqlDataAccessLayer.WriteToServerCommand(exceldt, GetFields(docInformation.type), sqlDataAccessLayer.GetTableName(docInformation.type));
                        });
                    }
                    //isRecordInserted = true;
                    return new ColumnsDataOperation()
                    {
                        Data = vals,
                        Columns = exceldt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList()
                    };
                }
                else
                {
                    //isRecordInserted = false;
                    return null;
                }

                ////for (int i = exceldt.Rows.Count - 1; i >= 0; i--)
                ////{
                ////    if (exceldt.Rows[i]["Employee Name"] == DBNull.Value || exceldt.Rows[i]["Email"] == DBNull.Value)
                ////    {
                ////        exceldt.Rows[i].Delete();
                ////    }
                ////}

                ////////exceldt.AcceptChanges();

            }
            catch (Exception _ex)
            {
                throw new Exception(_ex.Message);
            }

            //return isRecordInserted;
        }

        //public async Task<bool> Import(DocumentTypeUpload docInformation)
        //{
        //    bool isRecordInserted = false;
        //    GLIncomeRegisterColumns _glMapper = new GLIncomeRegisterColumns();
        //    try
        //    {
        //        //Read Data from excel sheet and create datatable
        //        var sheetName = oleDBDataAccessLayer.GetSheetName();
        //        string Query = string.Format("Select * FROM [{0}]", sheetName);
        //        var _dataSet = oleDBDataAccessLayer.ExecuteDataSet(System.Data.CommandType.Text, Query);

        //        if(_dataSet != null && _dataSet.Tables.Count > 0)
        //        {
        //            var exceldt = _dataSet.Tables[0];

        //            exceldt.Columns.Add("Month").Expression = Convert.ToString(docInformation.month);
        //            exceldt.Columns.Add("Year").Expression = Convert.ToString(docInformation.year);

        //            await Task.Run(() =>
        //            {
        //                sqlDataAccessLayer.WriteToServerCommand(exceldt, GetFields(docInformation.type),sqlDataAccessLayer.GetTableName(docInformation.type));
        //            });

        //            isRecordInserted = true;
        //        }
        //        else
        //        {
        //            isRecordInserted = false;
        //        }

        //        ////for (int i = exceldt.Rows.Count - 1; i >= 0; i--)
        //        ////{
        //        ////    if (exceldt.Rows[i]["Employee Name"] == DBNull.Value || exceldt.Rows[i]["Email"] == DBNull.Value)
        //        ////    {
        //        ////        exceldt.Rows[i].Delete();
        //        ////    }
        //        ////}

        //        ////////exceldt.AcceptChanges();

        //    }
        //    catch(Exception _ex)
        //    {
        //        throw new Exception(_ex.Message);
        //    }

        //    return isRecordInserted;
        //}

        public async Task<ColumnsDataOperation> UpdateInvoiceAmendmentData(DocumentTypeUpload docInformation)
        {
            bool isRecordInserted = false;
            try
            {
                //Read Data from excel sheet and create datatable
                var sheetName = oleDBDataAccessLayer.GetSheetName();
                string Query = string.Format("Select * FROM [{0}]", sheetName);
                var _dataSet = oleDBDataAccessLayer.ExecuteDataSet(System.Data.CommandType.Text, Query);
                _logger.LogInformation("Import Step1");

                if (_dataSet != null && _dataSet.Tables.Count > 0)
                {
                    _logger.LogInformation("Import Step2");
                    var exceldt = _dataSet.Tables[0];

                    _logger.LogInformation("Import Step3");
                    List<object> vals = new List<object>();
                    foreach (DataRow dr in exceldt.Rows)
                    {
                        dynamic expando = new ExpandoObject();
                        var expandoDict = expando as IDictionary<string, object>;
                        for (int i = 0; i < exceldt.Columns.Count; i++)
                        {
                            expandoDict.Add(exceldt.Columns[i].ColumnName, dr[exceldt.Columns[i].ColumnName]);
                        }
                        vals.Add(expando);
                    }
                    exceldt.Columns.Add("Month").Expression = Convert.ToString(docInformation.month);
                    exceldt.Columns.Add("Year").Expression = Convert.ToString(docInformation.year);

                    _logger.LogInformation("Import Step4");
                    await Task.Run(() =>
                    {
                        sqlDataAccessLayer.WriteToServerCommand(exceldt, GetFields(docInformation.type), sqlDataAccessLayer.GetTableName(docInformation.type));
                    });

                    //isRecordInserted = true;
                    return new ColumnsDataOperation()
                    {
                        Data = vals,
                        Columns = exceldt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList()
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception _ex)
            {
                throw new Exception(_ex.Message);
            }
        }

        public IDictionary<string, string> GetFields(string documentType)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();
            IFieldBase atype = this.CreateObjectFacoty(documentType);
            List<string> propNames = new List<string>();

            if (atype == null) return properties;
            Type t = atype.GetType();

            FieldInfo[] fields = t.GetFields();

            foreach (FieldInfo _field in fields)
            {
                properties.Add(Convert.ToString(_field.Name), (string)_field.GetValue(atype));
            }
            return properties;
        }

        private IFieldBase CreateObjectFacoty(string documentType)
        {
            IFieldBase? iFieldBase = null;
            if (documentType != null)
            {
                if (documentType.ToUpper() == "GLINR")
                {
                    iFieldBase = new GLIncomeRegisterColumns();
                }
                else if (documentType.ToUpper() == "SUPR")
                {
                    iFieldBase = new SupplyRegisterColumns();
                }
                else if (documentType.ToUpper() == "EINR")
                {
                    iFieldBase = new EInvoiceRegisterColumns();
                }
                else if (documentType.ToUpper() == "EWBILR")
                {
                    iFieldBase = new EWayBillRegisterColumns();
                }
                else if (documentType.ToUpper() == "LIBLGR")
                {
                    iFieldBase = new LiabilityLedgerColumns();
                }
                else if (documentType.ToUpper() == "ADVREC")
                {
                    iFieldBase = new AdvanceReceivedColumns();
                }
                else if (documentType.ToUpper() == "ITCR")
                {
                    iFieldBase = new ITCRegisterColumns();
                }
                else if (documentType.ToUpper() == "ITCGLR")
                {
                    iFieldBase = new ITCGLRegisterColumns();
                }
                else if (documentType.ToUpper() == "IAD")
                {
                    iFieldBase = new IADRegisterColumns();
                }
                else if (documentType.ToUpper() == "FOUTPUT")
                {
                    iFieldBase = new FinalOutputRegisterColumns();
                }
                
            }

            return iFieldBase;
        }

        public async Task<ColumnsDataOperation> PreViewDocument(DocumentTypeUpload docPreView)
        {
            try
            {
                //Read Data from excel sheet and create datatable
                var sheetName = oleDBDataAccessLayer.GetSheetName();
                string Query = string.Format("Select * FROM [{0}]", sheetName);
                var _dataSet = oleDBDataAccessLayer.ExecuteDataSet(System.Data.CommandType.Text, Query);

                if (_dataSet != null && _dataSet.Tables.Count > 0)
                {
                    var exceldt = _dataSet.Tables[0];

                    List<object> vals = new List<object>();
                    foreach (DataRow dr in exceldt.Rows)
                    {
                        dynamic expando = new ExpandoObject();
                        var expandoDict = expando as IDictionary<string, object>;
                        for (int i = 0; i < exceldt.Columns.Count; i++)
                        {
                            expandoDict.Add(exceldt.Columns[i].ColumnName, dr[exceldt.Columns[i].ColumnName]);
                        }
                        vals.Add(expando);
                    }
                    exceldt.Columns.Add("Month").Expression = Convert.ToString(docPreView.month);
                    exceldt.Columns.Add("Year").Expression = Convert.ToString(docPreView.year);

                    await Task.Run(() =>
                    {
                        sqlDataAccessLayer.WriteToServerCommand(exceldt, GetFields(docPreView.type), sqlDataAccessLayer.GetTableName(docPreView.type));
                    });

                    //isRecordInserted = true;
                    return new ColumnsDataOperation()
                    {
                        Data = vals,
                        Columns = exceldt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList()
                    };
                }
                else
                {
                    //isRecordInserted = false;
                    return null;
                }

            }
            catch (Exception _ex)
            {
                throw new Exception(_ex.Message);
            }
        }
    }
}
