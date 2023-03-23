using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.GL_Income.Application.DTOs.OutputRegister;
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
    public class OutputRegisterController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<OutputRegisterController> _logger;

        public OutputRegisterController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<OutputRegisterController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IActionResult> GetOutputRegisterList(string m, string y)
        {
            OutputRegisterViewModel outputRegisterViewModel = new OutputRegisterViewModel();
            //Month and Year Dropdown
            try
            {
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
                        var responseTask = await client.PostAsJsonAsync("api/OutputRegister/GetOutputRegisterList", new { month = m, year = y });
                        //responseTask.Wait();

                        var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<CommonResponse<List<OutputRegisterViewModel>>>(readTask);

                            outputRegisterViewModel.OutputRegisterGrid = data.Data;

                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            outputRegisterViewModel = null;
                            _logger.LogError(new Exception().Message);
                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

            return View(outputRegisterViewModel);
        }
    }
}
