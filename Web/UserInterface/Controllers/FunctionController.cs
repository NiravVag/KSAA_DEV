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

namespace KSAA.UserInterface.Web.Controllers
{
    [Authorize]
    public class FunctionController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<FunctionController> _logger;

        public FunctionController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<FunctionController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IActionResult> FunctionList()
        {
            IEnumerable<FunctionListModel> Functions = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/Function/GetAllFunction", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        var data = JsonConvert.DeserializeObject<CommonResponse<IEnumerable<FunctionListModel>>>(readTask);
                        Functions = data.Data;
                    }
                    else
                    {
                        //log response status here..

                        Functions = Enumerable.Empty<FunctionListModel>();
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
            return View(Functions);
        }

        public IActionResult FunctionAdd()
        {
            FunctionViewModel FunctionViewModel = new FunctionViewModel();
            return View(FunctionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FunctionAdd(FunctionViewModel FunctionViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/Function/CreateFunction", FunctionViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
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

        public async Task<IActionResult> FunctionEdit(FunctionViewModel FunctionViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/Function/UpdateFunctionById", FunctionViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<FunctionViewModel>>(readTask);

                        return Json(data);
                        //return RedirectToAction("FunctionList");
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

        public async Task<IActionResult> GetFunction(long id)
        {
            FunctionViewModel FunctionViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var getDocumentTask = await client.GetAsync("api/Function/GetFunctionById/" + id);
                    var result = getDocumentTask;
                    if (getDocumentTask.IsSuccessStatusCode)
                    {
                        /*var responseString = await getDocumentTask.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<Response<FunctionViewModel>>(responseString);
                        FunctionViewModel = response.Data;*/

                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<FunctionViewModel>>(readTask);
                        //readTask.Wait();

                        FunctionViewModel = data.Data;
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

            return View("FunctionEdit", FunctionViewModel);
        }

        public async Task<IActionResult> DeleteFunctionById(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/Function/DeleteFunctionById/" + id);
                    var result = deleteTask;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("FunctionList");
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

            return RedirectToAction("FunctionList");
        }
    }
}