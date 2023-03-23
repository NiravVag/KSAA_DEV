using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.Domain.Entities.GL_Income;
using KSAA.GL_Income.Application.DTOs.GLIncome;
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
    public class GL_IncomeController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;

        public GL_IncomeController(IConfiguration configuration, IOptions<BackendUrl> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }

        public async Task<IActionResult> GLIncomeControlSheet(string m, string y)
        {
            GL_IncomeListModel gL_Income = new GL_IncomeListModel();

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
                    var responseTask = await client.PostAsJsonAsync("api/GL_Income/GetGLIncomeControlSheet", new { month = m, year = y });
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<GL_IncomeListModel>>(readTask);

                        gL_Income = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        gL_Income = null;

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }

            return View(gL_Income);
        }

        public async Task<IActionResult> ControlSheetGen(string m, string y)
        {
            GL_IncomeListModel gL_Income = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.GLIncomeUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                var responseTask = await client.PostAsJsonAsync("api/GL_Income/GenControlSheet", new { month = m, year = y });

                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<GL_IncomeListModel>>(readTask);

                    gL_Income = data.Data;

                }
                else //web api sent error response 
                {
                    //log response status here..

                    gL_Income = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            //return Json(gL_Income);
            string message = "SUCCESS";
            return Json(new { Message = message });
        }

        public async Task<IActionResult> AddToSupply(string m, string y)
        {
            GL_IncomeListModel gL_Income = new GL_IncomeListModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.GLIncomeUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                var responseTask = await client.PostAsJsonAsync("api/GL_Income/AddToSupply", new { month = m, year = y });

                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<GL_IncomeListModel>>(readTask);

                    gL_Income = data.Data;

                }
                else //web api sent error response 
                {
                    //log response status here..

                    gL_Income = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            string message = "SUCCESS";
            return Json(new { Message = message });
        }

        public async Task<IActionResult> PreviewControlSheetDocument(FilePreview preview)
        {
            IEnumerable<SupplyModel> previewData = null;
            try
            {
                //object previewData = null;

                using (var client = new HttpClient())
                {
                    //preview.type = preview.type;
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.PostAsJsonAsync("api/GL_Income/GetPreviewDocument", preview);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<SupplyModel>>>(readTask);
                        previewData = data.Data;
                        //return Content(readTask, "application/json");
                        return Json(previewData);
                    }
                    else
                    {
                        //log response status here..

                        previewData = Enumerable.Empty<SupplyModel>();

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
