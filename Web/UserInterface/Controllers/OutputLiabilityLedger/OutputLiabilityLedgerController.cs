using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.OutputLiability;
using KSAA.GL_Income.Application.DTOs.OutputSupply;
using KSAA.GL_Income.Application.Wrappers;
using KSAA.Master.Application.DTOs.Master;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace KSAA.UserInterface.Web.Controllers.OutputLiabilityLedger
{
    [Authorize]
    public class OutputLiabilityLedgerController : Controller
    {
        private readonly BackendUrl _options;
        private readonly ILogger<OutputLiabilityLedgerController> _logger;

        public OutputLiabilityLedgerController(IOptions<BackendUrl> options, ILogger<OutputLiabilityLedgerController> logger)
        {
            _options = options.Value;
            _logger = logger;
        }
        public async Task<IActionResult> LiabilityControlSheet(string m, string y)
        {
            try
            {
                OutputLiabilityListModel outputLiability = new OutputLiabilityListModel();

                //Month and Year Dropdown
                List<CommonRequest> MonthYearList = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/GL_Income/GetSLMonthYear", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<CommonRequest>>(readTask);

                        var months = data.Data.Months.Select(x => new SelectListItem(x, x)).ToList();
                        months.Insert(0, new SelectListItem() { Value = "", Text = "----- Select Month -----" });

                        var years = data.Data.Years.Select(x => new SelectListItem(x, x)).ToList();
                        years.Insert(0, new SelectListItem() { Value = "", Text = "----- Select Years -----" });

                        ViewBag.Months = months;
                        ViewBag.Years = years;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        MonthYearList = Enumerable.Empty<CommonRequest>().ToList();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                if (m != null && y != null && m != "" && y != "")
                {
                    ViewBag.Month = m.ToString();
                    ViewBag.Year = y.ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(_options.GLIncomeUrl);
                        var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                        var responseTask = await client.PostAsJsonAsync("api/OutputLiability/GetLiabilityControlSheet", new { month = m, year = y });
                        //responseTask.Wait();

                        var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<CommonResponse<OutputLiabilityListModel>>(readTask);

                            outputLiability = data.Data;

                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            outputLiability = null;
                            _logger.LogError(new Exception().Message);
                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }

                    }
                }
                return View(outputLiability);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

        }
        public async Task<IActionResult> GenLiabilityControlSheet(string m, string y)
        {
            try
            {
                OutputLiabilityListModel outputLiabilityList = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/OutputLiability/LiabilityControlSheetGen", new { month = m, year = y });

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<OutputLiabilityListModel>>(readTask);

                        outputLiabilityList = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        outputLiabilityList = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                //return Json(outputLiabilityList);
                string message = "SUCCESS";
                return Json(new { Message = message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
        }

        //New Logic of Upate Data of Liability Control Sheet EditTable
        public async Task<HttpResponseMessage> UpdateLiabilityControlDataById(OutputRegisterViewModel outputliablityEdit)
        {
            //OutputRegisterViewModel outputliablityEdit = new OutputRegisterViewModel();
            var result = new HttpResponseMessage();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/OutputLiability/UpdateLiabilityControlDataById", outputliablityEdit);

                    result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<OutputRegisterViewModel>>(readTask);

                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        outputliablityEdit = data.Data;
                    }
                    else //web api sent error response 
                    {
                        outputliablityEdit = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //return Forbid();
            }
            return result;
        }

        #region Old Logic of AddToSupply
        public async Task<IActionResult> AddToSupply(string m, string y)
        {
            OutputLiabilityListModel outputliablity = new OutputLiabilityListModel();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/OutputLiability/AddToSupply", new { month = m, year = y });

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<OutputLiabilityListModel>>(readTask);

                        outputliablity = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..
                        outputliablity = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                string message = "SUCCESS";
                return Json(new { Message = message });
            }
            catch (Exception ex)
            {


                _logger.LogError(ex.Message);
                return Forbid();
            }

        }
        #endregion

        public async Task<IActionResult> PreviewOutputLiabilityDocument(FilePreview preview)
        {
            IEnumerable<OutputSupplyViewModel> previewData = null;
            try
            {
                //object previewData = null;

                using (var client = new HttpClient())
                {
                    //preview.type = preview.type;
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.PostAsJsonAsync("api/OutputLiability/GetPreviewDocument", preview);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<OutputSupplyViewModel>>>(readTask);
                        previewData = data.Data;
                        //return Content(readTask, "application/json");
                        return Json(previewData);
                    }
                    else
                    {
                        //log response status here..

                        previewData = Enumerable.Empty<OutputSupplyViewModel>();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //return BadRequest(_ex.Message);
                return Forbid();
            }
            return Json(previewData);
        }
    }
}