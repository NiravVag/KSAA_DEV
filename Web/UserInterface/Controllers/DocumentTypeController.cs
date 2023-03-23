using DocumentFormat.OpenXml.Spreadsheet;
using KSAA.DocumentService.Classes;
using KSAA.DocumentService.Extensions;
using KSAA.DocumentService.Interfaces;
using KSAA.Domain.Common;
using KSAA.Master.Application.DTOs.IAD;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Wrappers;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NHibernate.Criterion;
using NUnit.Framework;
using System.Data;
using System.Text;

namespace KSAA.UserInterface.Web.Controllers
{
    [Authorize]
    public class DocumentTypeController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private ILogger<DocumentTypeController> _logger;

        public DocumentTypeController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<DocumentTypeController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IActionResult> DocumentTypeList()
        {
            IEnumerable<DocumentTypeListModel> documentTypes = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/DocumentType/GetAllDocumentType", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();

                        var data = JsonConvert.DeserializeObject<CommonResponse<List<DocumentTypeListModel>>>(readTask);

                        documentTypes = data.Data;

                    }
                    else
                    {
                        //log response status here..

                        documentTypes = Enumerable.Empty<DocumentTypeListModel>();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
            return View(documentTypes);
        }

        public IActionResult DocumentTypeAdd()
        {
            DocumentTypeViewModel documentTypeViewModel = new DocumentTypeViewModel();
            return View(documentTypeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DocumentTypeAdd(DocumentTypeViewModel documentTypeViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/DocumentType/CreateDocumentType", documentTypeViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("DocumentTypeList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<string>>(readTask);

                        return Json(data.message);
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<ErrorResponse>(await postTask.Content.ReadAsStringAsync());
                        _logger.LogError(new Exception().Message);
                        return BadRequest(error);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
        }

        public async Task<IActionResult> DocomentTypeEdits(DocumentTypeViewModel documentTypeViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/DocumentType/UpdateDocumentTypeById", documentTypeViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("DocumentTypeList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<DocumentTypeViewModel>>(readTask);

                        return Json(data);
                    }
                    else
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<ErrorResponse>(readTask);
                        _logger.LogError(new Exception().Message);
                        return BadRequest(data);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
        }

        public async Task<IActionResult> GetDocument(long id)
        {
            DocumentTypeViewModel documentTypeViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.GetAsync("api/DocumentType/GetDocumentTypeById/" + id.ToString());
                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Response<DocumentTypeViewModel>>(readTask);
                        documentTypeViewModel = data.Data;
                    }
                    else
                    {
                        _logger.LogError(new Exception().Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

            return View("DocumentTypeEdit", documentTypeViewModel);
        }

        public async Task<IActionResult> DeleteDocument(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/DocumentType/DeleteDocumentTypeById/" + id.ToString());
                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("DocumentTypeList");
                    }
                    else
                    {
                        _logger.LogError(new Exception().Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

            return RedirectToAction("DocumentTypeList");
        }

        [HttpGet]
        public IActionResult DocumentTypeUpload(string id)
        {
            DocumentTypeUpload documentTypeUpload = new DocumentTypeUpload();
            documentTypeUpload.type = id;
            return View(documentTypeUpload);
        }

        //[HttpPost]
        //public async Task<IActionResult> DocumentTypeUpload(DocumentTypeUpload collection)
        //{
        //    try
        //    {
        //        if (collection.formfile == null || collection.formfile.Length == 0)
        //            return Content("file not selected");
        //            //return BadRequest("file not selected");

        //        string filePath = await IFormFileExtensions.SaveFileAsync(collection.formfile);
        //        IBase iBase = new Operations(filePath);
        //        var dataInserted = await iBase.Import(collection);
        //        //return Ok(collection);

        //        TempData["Message"] = "File Uploaded Successfully";

        //        return RedirectToAction("DocumentTypeUpload", "DocumentType");
        //    }
        //    catch (Exception _ex)
        //    {
        //        //return BadRequest(_ex.Message);
        //        return Content(_ex.Message);
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> DocumentTypeUpload([FromForm] DocumentTypeUpload collection)
        {
            try
            {
                _logger.LogInformation("Step1");
                if (collection.file == null || collection.file.Length == 0)
                    return BadRequest(new
                    {
                        message = "File not selected"
                    });
                //return BadRequest("file not selected");

                _logger.LogInformation("Step2");
                string filePath = await IFormFileExtensions.SaveFileAsync(collection.file);
                _logger.LogInformation("Step3");
                IBase iBase = new Operations(filePath, _logger);
                _logger.LogInformation("Step4");

                //Create validate method and pass collection

                var dataInserted = await iBase.Import(collection);
                _logger.LogInformation("Step5");
                //return Ok(collection);

                return Json(new
                {
                    data = dataInserted.Data,
                    columns = dataInserted.Columns
                });
                //return RedirectToAction("DocumentTypeUpload", "DocumentType");
                //return RedirectToAction("PreViewDocumentUpload", "DocumentType");
            }
            catch (Exception _ex)
            {
                _logger.LogInformation(_ex.Message);
                //return BadRequest(_ex.Message);
                return Forbid();
            }

        }

        public async Task<IActionResult> GetData(string m, string y, string t)
        {
            try
            {
                object previewData = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.PostAsJsonAsync("api/DocumentType/GetData", new { month = m, year = y, type = t });

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        var data = JsonConvert.DeserializeObject<CommonResponse<long>>(readTask);
                        //previewData = data.Data;
                        return Json(data.Data);
                        //return Json(readTask);
                    }
                    else
                    {
                        //log response status here..

                        previewData = Enumerable.Empty<object>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        return BadRequest();
                    }
                }
            }
            catch (Exception _ex)
            {
                //return BadRequest(_ex.Message);
                return Forbid();
            }
        }

        public async Task<IActionResult> DeleteData(string m, string y, string t)
        {
            try
            {
                object previewData = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.PostAsJsonAsync("api/DocumentType/DeleteData", new { month = m, year = y, type = t });

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("DocumentTypeList");
                        //var readTask = await result.Content.ReadAsStringAsync();
                        //var data = JsonConvert.DeserializeObject<CommonResponse<string>>(readTask);

                        return Json(new { });
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<ErrorResponse>(await responseTask.Content.ReadAsStringAsync());

                        return BadRequest(error);
                    }
                }
            }
            catch (Exception _ex)
            {
                //return BadRequest(_ex.Message);
                return Forbid();
            }
        }

        public async Task<IActionResult> PreViewDocumentUpload(FilePreview preview)
        {
            /* DocumentTypeUpload documentTypeUpload = new DocumentTypeUpload();
             return View(documentTypeUpload);*/

            try
            {
                object previewData = null;

                using (var client = new HttpClient())
                {
                    //preview.type = preview.type;
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.PostAsJsonAsync("api/DocumentType/GetPreViewDocument", preview);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        //var data = JsonConvert.DeserializeObject<CommonResponse<List<object>>(readTask);
                        //previewData = data.Data;
                        return Content(readTask, "application/json");
                        //return Json(readTask);
                    }
                    else
                    {
                        //log response status here..

                        previewData = Enumerable.Empty<object>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                return View(previewData);
            }
            catch (Exception _ex)
            {
                //return BadRequest(_ex.Message);
                return Forbid();
            }
        }

        // Invoice Amendment Document

        [HttpPost]
        public async Task<IActionResult> DocumentInvoiceAmendmentUpload([FromForm] DocumentTypeUpload collection)
        {
            try
            {
                _logger.LogInformation("Step1");
                if (collection.file == null || collection.file.Length == 0)
                    return BadRequest(new
                    {
                        message = "File not selected"
                    });
                //return BadRequest("file not selected");

                _logger.LogInformation("Step2");
                string filePath = await IFormFileExtensions.SaveFileAsync(collection.file);
                _logger.LogInformation("Step3");
                IBase iBase = new Operations(filePath, _logger);
                _logger.LogInformation("Step4");

                //Create validate method and pass collection

                var dataInserted = await iBase.Import(collection);
                _logger.LogInformation("Step5");
                //return Ok(collection);

                if (dataInserted.Data.Count > 0)
                {
                    var invoiceAmendmentUpdatesList = new InvoiceAmendmentUpdateListModel();

                     var invoiceAmendmentUpdates = new List<InvoiceAmendmentUpdateViewModel>();
                    foreach (var item in dataInserted.Data)
                    {
                        var IADData = new InvoiceAmendmentUpdateViewModel();
                        ICollection<KeyValuePair<String, Object>> IADUpdatedDataList = (ICollection<KeyValuePair<String, Object>>)item;
                        foreach (var IADUpdatedData in IADUpdatedDataList)
                        {
                            if (IADUpdatedData.Key == "Original_Invoice_Against_CN_DN_Receipt_No_Agaisnt_refund_no")
                            {
                                IADData.InvoiceNumber = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Client_Code")
                            {
                                IADData.ClientCode = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_GSTIN")
                            {
                                IADData.RevisedGSTIN = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_POS")
                            {
                                IADData.RevisedPOS = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Document_Type")
                            {
                                IADData.RevisedDocumentType = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Invoice_No_Debit_Credit_Note")
                            {
                                IADData.RevisedInvoiceNoDebitCreditNote = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Invoice_Date")
                            {
                                IADData.RevisedInvoiceDate = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Shipping_Bill_No")
                            {
                                IADData.RevisedShippingBillNo = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Shipping_Bill_Date")
                            {
                                IADData.RevisedShippingBillDate = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Port_Code")
                            {
                                IADData.RevisedPortCode = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_GST_Payment_Type")
                            {
                                IADData.RevisedGSTPaymentType = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Taxable_Value")
                            {
                                IADData.RevisedTaxableValue = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_HSN_SAC")
                            {
                                IADData.RevisedHSNSAC = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Rate")
                            {
                                IADData.RevisedRate = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Cess")
                            {
                                IADData.RevisedCess = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_CGST")
                            {
                                IADData.RevisedCGST = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_SGST")
                            {
                                IADData.RevisedSGST = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_IGST")
                            {
                                IADData.RevisedIGST = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Revised_Total_Tax")
                            {
                                IADData.RevisedTotalTax = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "Remarks_for_Change_in_Liability")
                            {
                                IADData.RemarksforChangeinLiability = IADUpdatedData.Value.ToString();
                            }
                            if (IADUpdatedData.Key == "GSTR_1_presentation_Remark")
                            {
                                IADData.GSTR1presentationRemark = IADUpdatedData.Value.ToString();
                            }
                            IADData.Month = collection.month;
                            IADData.Year = collection.year;
                        }

                        invoiceAmendmentUpdates.Add(IADData);
                        invoiceAmendmentUpdatesList.invoiceAmendmentUpdates = new List<InvoiceAmendmentUpdateViewModel>();
                        invoiceAmendmentUpdatesList.invoiceAmendmentUpdates = invoiceAmendmentUpdates;
                    }

                    _logger.LogInformation("web-1 invoiceAmendmentUpdates != null");

                    if (invoiceAmendmentUpdates != null)
                    {
                        _logger.LogInformation("web-1.1 invoiceAmendmentUpdates != null");
                        var temp = await InvoiceAmUpdateData(invoiceAmendmentUpdatesList);
                        _logger.LogInformation("web-1.1 End calling");
                    }

                }
                string message = "SUCCESS";
                return Json(new { Message = message });
            }
            catch (Exception _ex)
            {
                _logger.LogInformation(_ex.Message);
                _logger.LogError(_ex.Message);
                //return BadRequest(_ex.Message);
                return Forbid();
            }

        }

        public async Task<IActionResult> InvoiceAmUpdateData(InvoiceAmendmentUpdateListModel invoiceAmendmentUpdatesList)
        {
            try
            {
                _logger.LogInformation("web-1 in controller - InvoiceAmUpdateData");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    //var requestContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(invoiceAmendmentUpdatesList), Encoding.UTF8, "application/json");
                    var requestContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(invoiceAmendmentUpdatesList), Encoding.UTF8, "application/json");

                    _logger.LogInformation("web-2 in controller - InvoiceAmUpdateData" + Newtonsoft.Json.JsonConvert.SerializeObject(invoiceAmendmentUpdatesList));

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/DocumentType/UpdateInvoiceAmendment", invoiceAmendmentUpdatesList);

                    _logger.LogInformation("web-3 postTask");

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("web-4 result.IsSuccessStatusCode");

                        //return RedirectToAction("DocumentTypeList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<string>>(readTask);

                        _logger.LogInformation("web-5 data");

                        return Json(data);
                    }
                    else
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<ErrorResponse>(readTask);
                        _logger.LogError(new Exception().Message);
                        return BadRequest(data);
                    }
                }
            }
            catch(Exception _ex)
            {
                _logger.LogError(_ex.Message);
                //return BadRequest(_ex.Message);
                return Forbid();
            }
            
        }

        //Formate File Export

        public IActionResult DownloadFile()
        {
            String path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\KSAA_Files_Formate\\Invoice_Amendment_Module_Template.xlsx");
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            String file = Convert.ToBase64String(bytes);
            byte[] bytes1 = Convert.FromBase64String(file);

            return File(bytes1, "application/vnd.ms-excel", "Invoice_Amendment_Module_Template.xlsx");
        }
    }
}
