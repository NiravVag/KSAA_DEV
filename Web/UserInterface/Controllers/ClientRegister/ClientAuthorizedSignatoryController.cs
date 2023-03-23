using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.Domain.Common;
using KSAA.GL_Income.Application.Wrappers;
using KSAA.Master.Application.DTOs.Master;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace KSAA.UserInterface.Web.Controllers.ClientRegister
{
    [Authorize]
    public class ClientAuthorizedSignatoryController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<ClientAuthorizedSignatoryController> _logger;

        public ClientAuthorizedSignatoryController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<ClientAuthorizedSignatoryController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }
        public async Task<IActionResult> ClientAuthorizedSignatoryList()
        {
            IEnumerable<ClientAuthorizedSignatoryListModel> clientAuthorizedSignatorys = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/ClientAuthorizedSignatory/GetAllClientAuthorizedSignatory", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            //readTask.Wait();

                            var data = JsonConvert.DeserializeObject<CommonResponse<List<ClientAuthorizedSignatoryListModel>>>(readTask);

                            clientAuthorizedSignatorys = data.Data;

                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            clientAuthorizedSignatorys = Enumerable.Empty<ClientAuthorizedSignatoryListModel>();
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
            return View(clientAuthorizedSignatorys);
        }
        public IActionResult ClientAuthorizedSignatoryAdd()
        {
            ClientAuthorizedSignatoryViewModel ClientAuthorizedSignatoryViewModel = new ClientAuthorizedSignatoryViewModel();
            return View(ClientAuthorizedSignatoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ClientAuthorizedSignatoryAdd(ClientAuthorizedSignatoryViewModel ClientAuthorizedSignatoryViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/ClientAuthorizedSignatory/CreateClientAuthorizedSignatory", ClientAuthorizedSignatoryViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("ClientAuthorizedSignatoryList");
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

        public async Task<IActionResult> ClientAuthorizedSignatoryEdit(ClientAuthorizedSignatoryViewModel ClientAuthorizedSignatoryViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/ClientAuthorizedSignatory/UpdateClientAuthorizedSignatoryById", ClientAuthorizedSignatoryViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("ClientAuthorizedSignatoryList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ClientAuthorizedSignatoryViewModel>>(readTask);

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

        public async Task<IActionResult> GetClientAuthorizedSignatory(long id)
        {
            ClientAuthorizedSignatoryViewModel ClientAuthorizedSignatoryViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.GetAsync("api/ClientAuthorizedSignatory/GetClientAuthorizedSignatoryById/" + id.ToString());
                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Response<ClientAuthorizedSignatoryViewModel>>(readTask);
                        ClientAuthorizedSignatoryViewModel = data.Data;
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
            return View("ClientAuthorizedSignatoryEdit", ClientAuthorizedSignatoryViewModel);
        }

        public async Task<IActionResult> DeleteClientAuthorizedSignatory(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/ClientAuthorizedSignatory/DeleteClientAuthorizedSignatoryById/" + id.ToString());
                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ClientAuthorizedSignatoryList");
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
            return RedirectToAction("ClientAuthorizedSignatoryList");
        }
    }
}