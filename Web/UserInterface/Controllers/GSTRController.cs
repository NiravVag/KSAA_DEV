using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.GL_Income.Application.DTOs.GLIncome;
using KSAA.GL_Income.Application.DTOs.GSTR;
using KSAA.GL_Income.Application.DTOs.OutputLiability;
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
    public class GSTRController : Controller
    {
        private BackendUrl _options;

        public GSTRController(IOptions<BackendUrl> options)
        {
            _options = options.Value;
        }
        public async Task<IActionResult> GSTR1Replica(string m, string y)
        {
            GSTRReplicaListModel gSTRReplica = new GSTRReplicaListModel();
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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/GSTRReplica/GetGSTRReplicaView", new { month = m, year = y });
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<GSTRReplicaListModel>>(readTask);

                        gSTRReplica = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        gSTRReplica = null;
                        //_logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }

                }
            }
            return View(gSTRReplica);
        }
    }
}