using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.GL_Income.Application.DTOs.AdvanceRecAdj;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
using KSAA.GL_Income.Application.Wrappers;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace KSAA.UserInterface.Web.Controllers.AdvanceRecAdj
{
    [Authorize]
    public class AdvRecAmendmentController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<AdvRecAmendmentController> _logger;

        public AdvRecAmendmentController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<AdvRecAmendmentController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        //Advance Received Module
        public async Task<IActionResult> AdvanceReceived(string m, string y)
        {
            AdvanceReceivedListModule advanceReceivedList = new AdvanceReceivedListModule();

            //Month and Year Dropdown
            try
            {
                List<CommonRequest> MonthYearList = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetAdvReceivedMonthYear", requestContent);
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

            //Advance Received List
            try
            {
                if (m != null && y != null && m != "" && y != "")
                {
                    ViewBag.Month = m.ToString();
                    ViewBag.Year = y.ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(_options.GLIncomeUrl);
                        var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                        var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetAdvanceReceivedList", new { month = m, year = y });
                        //responseTask.Wait();

                        var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<CommonResponse<AdvanceReceivedListModule>>(readTask);

                            advanceReceivedList = data.Data;

                        }
                        else //web api sent error response 
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<ErrorResponse>(readTask);
                            _logger.LogError(new Exception().Message);
                            return BadRequest(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
            return View(advanceReceivedList);
        }

        //Advance Amendment Module
        public async Task<IActionResult> AdvanceAmendment(string m, string y)
        {
            AdvanceReceivedListModule advanceAmendmentList = new AdvanceReceivedListModule();

            //Month and Year Dropdown
            try
            {
                List<CommonRequest> MonthYearList = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetAdvReceivedMonthYear", requestContent);
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

            try
            {
                if (m != null && y != null && m != "" && y != "")
                {
                    ViewBag.Month = m.ToString();
                    ViewBag.Year = y.ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(_options.GLIncomeUrl);
                        var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                        var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetAdvanceReceivedList", new { month = m, year = y });
                        //responseTask.Wait();

                        var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<CommonResponse<AdvanceReceivedListModule>>(readTask);

                            advanceAmendmentList = data.Data;

                        }
                        else //web api sent error response 
                        {
                            //log response status here..
                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<ErrorResponse>(readTask);
                            _logger.LogError(new Exception().Message);
                            return BadRequest(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
            return View(advanceAmendmentList);
        }

        public async Task<HttpResponseMessage> GetReceivedAmendmentById(long id, string month, string year)
        {
            AdvanceAmendmentListModel addAdvanceAmendment = new AdvanceAmendmentListModel();

            var result = new HttpResponseMessage();

            if (id > 0 && month != null && year != "")
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetReceivedAmendmentById", new { id = id, month = month, year = year });
                    //responseTask.Wait();

                    result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<AdvanceAmendmentListModel>>(readTask);

                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        addAdvanceAmendment = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        addAdvanceAmendment = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return result;
        }

        public async Task<IActionResult> AddReceivedAmendmentById(AdvanceAmendmentViewModel amendmentViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    //HTTP POST
                    var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/AddReceivedAmendmentById", amendmentViewModel);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<string>>(readTask);

                        return Json(data.message);
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<ErrorResponse>(await responseTask.Content.ReadAsStringAsync());
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

        //Priview Add Amendment By Id
        public async Task<IActionResult> PreviewAddAmendmentById(long id, string month, string year)
        {
            IEnumerable<AdvanceAmendmentViewModel> previewData = null;
            try
            {
                using (var client = new HttpClient())
                {
                    //preview.type = preview.type;
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetPreviewAddAmendmentById", new { id = id, month = month, year = year });
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<AdvanceAmendmentViewModel>>>(readTask);
                        previewData = data.Data;
                        //return Content(readTask, "application/json");
                        return Json(previewData);
                    }
                    else
                    {
                        //log response status here..
                        previewData = Enumerable.Empty<AdvanceAmendmentViewModel>();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception _ex)
            {
                //return BadRequest(_ex.Message);
                return Forbid();
            }
            return Json(previewData);
        }

        //Advance Adjustment Module
        public async Task<IActionResult> AdvanceAdjustment(string m, string y)
        {
            AdvanceAdjustmentViewModel advanceAdjustmentViewModel = new AdvanceAdjustmentViewModel();

            //Month and Year Dropdown
            try
            {
                List<CommonRequest> MonthYearList = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetAdvReceivedMonthYear", requestContent);
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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

            try
            {
                if (m != null && y != null && m != "" && y != "")
                {
                    ViewBag.Month = m.ToString();
                    ViewBag.Year = y.ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(_options.GLIncomeUrl);
                        var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                        var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetAdvanceAdjustmentList", new { month = m, year = y });
                        //responseTask.Wait();

                        var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<CommonResponse<List<AdvanceAdjustmentViewModel>>>(readTask);

                            advanceAdjustmentViewModel.AdvanceAdjustmentList = data.Data;
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<ErrorResponse>(readTask);
                            _logger.LogError(new Exception().Message);
                            return BadRequest(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
            return View(advanceAdjustmentViewModel);
        }

        //Add Tag Invoice - Get Register Detail
        public async Task<IActionResult> GetAdvanceRegisterDetailById(long id, string month, string year)
        {
            AdvanceAdjustmentViewModel advanceAdjustmentViewModel = new AdvanceAdjustmentViewModel();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetAdvanceRegisterDetailById", new { month = month, year = year, id = id });

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("CompanyList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<AdvanceAdjustmentViewModel>>(readTask);

                        return Json(data.Data);
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

        //Add Tag Invoice - Get Invoice Number List
        public async Task<IActionResult> GetSLInvoiceNoList(string month, string year)
        {
            IEnumerable<OutputRegisterViewModel> outputRegisters = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetSLInvoiceNoList", new { month = month, year = year });

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("CompanyList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<OutputRegisterViewModel>>>(readTask);

                        return Json(data.Data);
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

        //Add Tag Invoice - Submit Tag Invoice
        public async Task<IActionResult> AddTagInvoiceById(AdvanceAdjustmentTagReceiptModel tagReceiptViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    //HTTP POST
                    var responseTask = await client.PostAsJsonAsync("api/AdvRecAmendment/AddTagInvoiceById", tagReceiptViewModel);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<string>>(readTask);

                        return Json(data.message);
                    }
                    else
                    {
                        var error = JsonConvert.DeserializeObject<ErrorResponse>(await responseTask.Content.ReadAsStringAsync());
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

        //Add Tag Invoice - Get SLInvoice Detail
        public async Task<IActionResult> GetSLInvoiceDetail(long id, string month, string year)
        {
            OutputRegisterViewModel slInvoiceDetail = new OutputRegisterViewModel();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/AdvRecAmendment/GetSLInvoiceDetailById", new { month = month, year = year, id = id });

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("CompanyList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<OutputRegisterViewModel>>(readTask);

                        return Json(data.Data);
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
    }
}
