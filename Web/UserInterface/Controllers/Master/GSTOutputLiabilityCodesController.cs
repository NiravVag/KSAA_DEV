using KSAA.Domain.Common;
using KSAA.Master.Application.DTOs.Master;
using KSAA.Master.Application.DTOs.Master.ListDTOs;
using KSAA.Master.Application.Wrappers;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace KSAA.UserInterface.Web.Controllers.Master
{
    [Authorize]
    public class GSTOutputLiabilityCodesController : Controller
	{
        private IConfiguration _configuration;
        private BackendUrl _options;
        public GSTOutputLiabilityCodesController(IConfiguration configuration, IOptions<BackendUrl> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }

        public async Task<IActionResult> GSTOutputLiabilityCodesList()
        {
            IEnumerable<GSTOutputLiabilityCodesListModel> GSTOutputLiabilityCodess = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                var responseTask = await client.PostAsync("api/GSTOutputLiabilityCodes/GetAllGSTOutputLiabilityCodes", requestContent);
                //responseTask.Wait();

                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    //readTask.Wait();

                    var data = JsonConvert.DeserializeObject<CommonResponse<List<GSTOutputLiabilityCodesListModel>>>(readTask);

                    GSTOutputLiabilityCodess = data.Data;
                }
                else
                {
                    //log response status here..

                    GSTOutputLiabilityCodess = Enumerable.Empty<GSTOutputLiabilityCodesListModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(GSTOutputLiabilityCodess);
        }
        public IActionResult GSTOutputLiabilityCodesAdd()
        {
            GSTOutputLiabilityCodesViewModel GSTOutputLiabilityCodesViewModel = new GSTOutputLiabilityCodesViewModel();
            return View(GSTOutputLiabilityCodesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GSTOutputLiabilityCodesAdd(GSTOutputLiabilityCodesViewModel GSTOutputLiabilityCodesViewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                //HTTP POST
                var postTask = await client.PostAsJsonAsync("api/GSTOutputLiabilityCodes/CreateGSTOutputLiabilityCodes", GSTOutputLiabilityCodesViewModel);
                //postTask.Wait();

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    //return RedirectToAction("GSTOutputLiabilityCodesList");
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<string>>(readTask);

                    return Json(data.message);
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<ErrorResponse>(await postTask.Content.ReadAsStringAsync());

                    return BadRequest(error);
                }
            }
        }
        public async Task<IActionResult> GSTOutputLiabilityCodesEdit(GSTOutputLiabilityCodesViewModel GSTOutputLiabilityCodesViewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                //HTTP POST
                var postTask = await client.PutAsJsonAsync("api/GSTOutputLiabilityCodes/UpdateGSTOutputLiabilityCodesById", GSTOutputLiabilityCodesViewModel);

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    //return RedirectToAction("GSTOutputLiabilityCodesList");
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<GSTOutputLiabilityCodesViewModel>>(readTask);

                    return Json(data);
                }
                else
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<ErrorResponse>(readTask);
                    return BadRequest(data);
                }
            }
        }

        public async Task<IActionResult> GetGSTOutputLiabilityCodes(long id)
        {
            GSTOutputLiabilityCodesViewModel GSTOutputLiabilityCodesViewModel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                var responseTask = await client.GetAsync("api/GSTOutputLiabilityCodes/GetGSTOutputLiabilityCodesById/" + id.ToString());
                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<CommonResponse<GSTOutputLiabilityCodesViewModel>>(readTask);
                    GSTOutputLiabilityCodesViewModel = response.Data;
                }
            }

            return View("GSTOutputLiabilityCodesEdit", GSTOutputLiabilityCodesViewModel);
        }

        public async Task<IActionResult> DeleteGSTOutputLiabilityCodesById(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                var deleteTask = await client.DeleteAsync("api/GSTOutputLiabilityCodes/DeleteGSTOutputLiabilityCodesById/" + id.ToString());
                var result = deleteTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GSTOutputLiabilityCodesList");
                }
            }

            return RedirectToAction("GSTOutputLiabilityCodesList");
        }
    }

}