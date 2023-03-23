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
    public class AdvanceMappingController : Controller
	{
        private IConfiguration _configuration;
        private BackendUrl _options;

        public AdvanceMappingController(IConfiguration configuration, IOptions<BackendUrl> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }

        public async Task<IActionResult> AdvanceMappingList()
        {
            IEnumerable<AdvanceMappingListModel> AdvanceMappings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                var responseTask = await client.PostAsync("api/AdvanceMapping/GetAllAdvanceMapping", requestContent);
                //responseTask.Wait();

                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    //readTask.Wait();

                    var data = JsonConvert.DeserializeObject<CommonResponse<List<AdvanceMappingListModel>>>(readTask);
                    AdvanceMappings = data.Data;

                }
                else
                {
                    //log response status here..

                    AdvanceMappings = Enumerable.Empty<AdvanceMappingListModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(AdvanceMappings);
        }

        public IActionResult AdvanceMappingAdd()
        {
            AdvanceMappingViewModel AdvanceMappingViewModel = new AdvanceMappingViewModel();
            return View(AdvanceMappingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AdvanceMappingAdd(AdvanceMappingViewModel AdvanceMappingViewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                //HTTP POST
                var postTask = await client.PostAsJsonAsync("api/AdvanceMapping/CreateAdvanceMapping", AdvanceMappingViewModel);
                //postTask.Wait();

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    //return RedirectToAction("AdvanceMappingList");
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

        public async Task<IActionResult> AdvanceMappingEdit(AdvanceMappingViewModel AdvanceMappingViewModel)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                //HTTP POST
                var postTask = await client.PutAsJsonAsync("api/AdvanceMapping/UpdateAdvanceMappingById", AdvanceMappingViewModel);

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    //return RedirectToAction("AdvanceMappingList");
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<AdvanceMappingViewModel>>(readTask);

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

        public async Task<IActionResult> GetAdvanceMapping(long id)
        {
            AdvanceMappingViewModel AdvanceMappingViewModel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                var responseTask = await client.GetAsync("api/AdvanceMapping/GetAdvanceMappingById/" + id.ToString());
                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<CommonResponse<AdvanceMappingViewModel>>(readTask);
                    AdvanceMappingViewModel = response.Data;
                }
            }

            return View("AdvanceMappingEdit", AdvanceMappingViewModel);
        }

        public async Task<IActionResult> DeleteAdvanceMappingById(long id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.MasterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                var deleteTask = await client.DeleteAsync("api/AdvanceMapping/DeleteAdvanceMappingById/" + id.ToString());
                var result = deleteTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("AdvanceMappingList");
                }
            }

            return RedirectToAction("AdvanceMappingList");
        }
    }
}