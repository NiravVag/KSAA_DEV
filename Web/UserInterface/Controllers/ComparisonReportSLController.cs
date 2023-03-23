using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.GL_Income;
using KSAA.GL_Income.Application.DTOs.ComparisonReport;
using KSAA.Master.Application.DTOs.Master;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace KSAA.UserInterface.Web.Controllers
{
    [Authorize]
    public class ComparisonReportSLController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<ComparisonReportSLController> _logger;

        public ComparisonReportSLController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<ComparisonReportSLController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        //Compare SL with EInvoice
        public async Task<IActionResult> ComparisonSheetSLInvoice(string m, string y, string a)
        {
            ComparisonReportSLEInvoiceListModel comparisonReportSLEInvoiceList = new ComparisonReportSLEInvoiceListModel();

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
                    var responseTask = await client.PostAsJsonAsync("api/ComparisonReport/GetComparisonReportSLEInvoiceSheet", new { month = m, year = y, action = a });
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ComparisonReportSLEInvoiceListModel>>(readTask);

                        comparisonReportSLEInvoiceList = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        comparisonReportSLEInvoiceList = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }

            if (m != null && y != null && m != "" && y != "")
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/ComparisonReport/GetComparisonReportSLEInvoiceSheet", new { month = m, year = y, action = a });
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ComparisonReportSLEInvoiceListModel>>(readTask);

                        comparisonReportSLEInvoiceList = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        comparisonReportSLEInvoiceList = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return View(comparisonReportSLEInvoiceList);
        }

        public async Task<IActionResult> GenrateComparisonSheetSLEinvoice(string m, string y)
        {
            ComparisonReportSLEInvoiceListModel genComparison = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.GLIncomeUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                var responseTask = await client.PostAsJsonAsync("api/ComparisonReport/GenComparisonSheetSLEInvoice", new { month = m, year = y });

                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<ComparisonReportSLEInvoiceListModel>>(readTask);

                    genComparison = data.Data;

                }
                else //web api sent error response 
                {
                    //log response status here..

                    genComparison = null;
                    _logger.LogError(new Exception().Message);
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            //return Json(gL_Income);
            string message = "SUCCESS";
            return Json(new { Message = message });
        }

        //Compare SL with EWay
        public async Task<IActionResult> ComparisonSheetSLEWay(string m, string y, string a)
        {
            ComparisonReportSLEWayListModel comparisonReportSLEWayList = new ComparisonReportSLEWayListModel();

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
                    var responseTask = await client.PostAsJsonAsync("api/ComparisonReport/GetComparisonReportSLEWaySheet", new { month = m, year = y, action = a });
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ComparisonReportSLEWayListModel>>(readTask);

                        comparisonReportSLEWayList = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        comparisonReportSLEWayList = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return View(comparisonReportSLEWayList);
        }

        public async Task<IActionResult> UpdateComparisonSheetSLEWay(string m, string y)
        {
            ComparisonReportSLEWayListModel updateComparison = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.GLIncomeUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                var responseTask = await client.PostAsJsonAsync("api/ComparisonReport/UpdateComparisonSheetSLEWay", new { month = m, year = y });

                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<ComparisonReportSLEWayListModel>>(readTask);

                    updateComparison = data.Data;

                }
                else //web api sent error response 
                {
                    //log response status here..

                    updateComparison = null;
                    _logger.LogError(new Exception().Message);
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            //return Json(gL_Income);
            string message = "SUCCESS";
            return Json(new { Message = message });
        }

        //Dropdown EInvoice Action Logic
        public async Task<HttpResponseMessage> SLEInvoiceUpdateAction(string action, int id, string updateType, int year)
        {
            ComparisonReportSLEInvoiceListModel comparisonReportSLEInvoiceAction = new ComparisonReportSLEInvoiceListModel();

            var result = new HttpResponseMessage();

            if (action != null && id > 0 && updateType != "" && year > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/ComparisonReport/SLEInvoiceUpdateAction", new { action = action, id = id, updateType = updateType, year = year });
                    //responseTask.Wait();

                    result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ComparisonReportSLEInvoiceListModel>>(readTask);

                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        comparisonReportSLEInvoiceAction = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        comparisonReportSLEInvoiceAction = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return result;
        }

        //Dropdown EWayAction Logic
        public async Task<HttpResponseMessage> SLEWayUpdateAction(string action, int id, string updateType, int year)
        {
            ComparisonReportSLEWayListModel comparisonReportSLEWayAction = new ComparisonReportSLEWayListModel();

            var result = new HttpResponseMessage();

            if (action != null && id > 0 && updateType != "" && year > 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/ComparisonReport/SLEWayUpdateAction", new { action = action, id = id, updateType = updateType, year = year });
                    //responseTask.Wait();

                    result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ComparisonReportSLEWayListModel>>(readTask);

                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        comparisonReportSLEWayAction = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        comparisonReportSLEWayAction = null;
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            return result;
        }

        //Priview SL
        public async Task<IActionResult> PreviewSLDocument(string m, string y, string a)
        {
            IEnumerable<CompairsonReportsSLEInvoiceEWay> previewData = null;
            try
            {
                using (var client = new HttpClient())
                {
                    //preview.type = preview.type;
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.PostAsJsonAsync("api/ComparisonReport/GetPreviewSLDocument", new { month = m, year = y, action = a });
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<CompairsonReportsSLEInvoiceEWay>>>(readTask);
                        previewData = data.Data;
                        //return Content(readTask, "application/json");
                        return Json(previewData);
                    }
                    else
                    {
                        //log response status here..

                        previewData = Enumerable.Empty<CompairsonReportsSLEInvoiceEWay>();
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
    }
}
