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
    public class FunctionModuleController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<FunctionModuleController> _logger;

        public FunctionModuleController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<FunctionModuleController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IActionResult> FunctionModuleList()
        {
            IEnumerable<FunctionModuleListModel> functionModule = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/FunctionModule/GetAllFunctionModule", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        var data = JsonConvert.DeserializeObject<CommonResponse<IEnumerable<FunctionModuleListModel>>>(readTask);
                        functionModule = data.Data;
                    }
                    else
                    {
                        //log response status here..

                        functionModule = Enumerable.Empty<FunctionModuleListModel>();
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
            return View(functionModule);
        }

        public async Task<IActionResult> FunctionModuleAdd()
        {
            FunctionModuleViewModel functionModuleViewModel = new FunctionModuleViewModel();

            //Functions Dropdown
            List<FunctionViewModel> functionList = null;
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
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<FunctionViewModel>>>(readTask);

                        functionList = data.Data;

                        functionList.Insert(0, new FunctionViewModel() { Id = 0, FunctionName = "----- Select Function -----" });

                        ViewBag.Functions = functionList;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        functionList = Enumerable.Empty<FunctionViewModel>().ToList();
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

            return View(functionModuleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> FunctionModuleAdd(FunctionModuleViewModel functionModuleViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/FunctionModule/CreateFunctionModule", functionModuleViewModel);
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

        public async Task<IActionResult> FunctionModuleEdit(FunctionModuleViewModel functionModuleViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/FunctionModule/UpdateFunctionModuleById", functionModuleViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<FunctionModuleViewModel>>(readTask);

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

        public async Task<IActionResult> GetFunctionModule(long id)
        {
            //Functions Dropdown
            List<FunctionViewModel> functionList = null;
            FunctionModuleViewModel functionModuleViewModel = null;
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
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<FunctionViewModel>>>(readTask);

                        functionList = data.Data;

                        functionList.Insert(0, new FunctionViewModel() { Id = 0, FunctionName = "----- Select Function -----" });

                        ViewBag.Functions = functionList;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        functionList = Enumerable.Empty<FunctionViewModel>().ToList();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var getDocumentTask = await client.GetAsync("api/FunctionModule/GetFunctionModuleById/" + id);
                    var result = getDocumentTask;
                    if (getDocumentTask.IsSuccessStatusCode)
                    {
                        /*var responseString = await getDocumentTask.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<Response<FunctionModuleViewModel>>(responseString);
                        functionModuleViewModel = response.Data;*/

                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<FunctionModuleViewModel>>(readTask);
                        //readTask.Wait();

                        functionModuleViewModel = data.Data;
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

            return View("FunctionModuleEdit", functionModuleViewModel);
        }

        public async Task<IActionResult> DeleteFunctionModuleById(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/FunctionModule/DeleteFunctionModuleById/" + id);
                    var result = deleteTask;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("FunctionModuleList");
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
            return RedirectToAction("FunctionModuleList");
        }
    }
}
