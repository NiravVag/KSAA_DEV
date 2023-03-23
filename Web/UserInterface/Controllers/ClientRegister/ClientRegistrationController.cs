using KSAA.ClientRegister.Application.DTOs.ClientRegister;
using KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs;
using KSAA.ClientRegister.Application.Wrappers;
using KSAA.Domain.Common;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace KSAA.UserInterface.Web.Controllers.ClientRegister
{
    [Authorize]
    public class ClientRegistrationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly BackendUrl _options;
        private readonly ILogger<ClientRegistrationController> _logger;

        public ClientRegistrationController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<ClientRegistrationController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }
        public async Task<IActionResult> ClientRegistrationList()
        {
            IEnumerable<ClientRegistrationListModel> clientRegistrations = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/ClientRegistration/GetAllClientRegistration", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            //readTask.Wait();

                            var data = JsonConvert.DeserializeObject<CommonResponse<List<ClientRegistrationListModel>>>(readTask);

                            clientRegistrations = data.Data;

                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            clientRegistrations = Enumerable.Empty<ClientRegistrationListModel>();
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
            return View(clientRegistrations);
        }
        public IActionResult ClientRegistrationAdd()
        {
            ClientRegistrationViewModel ClientRegistrationViewModel = new ClientRegistrationViewModel();
            return View(ClientRegistrationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ClientRegistrationAdd(ClientRegistrationViewModel ClientRegistrationViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/ClientRegistration/CreateClientRegistration", ClientRegistrationViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("ClientRegistrationList");
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

        public async Task<IActionResult> ClientRegistrationEdit(ClientRegistrationViewModel ClientRegistrationViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/ClientRegistration/UpdateClientRegistrationById", ClientRegistrationViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("ClientRegistrationList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ClientRegistrationViewModel>>(readTask);

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

        public async Task<IActionResult> GetClientRegistration(long id)
        {
            ClientRegistrationViewModel ClientRegistrationViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.GetAsync("api/ClientRegistration/GetClientRegistrationById/" + id.ToString());
                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Response<ClientRegistrationViewModel>>(readTask);
                        ClientRegistrationViewModel = data.Data;
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
            return View("ClientRegistrationEdit", ClientRegistrationViewModel);
        }

        public async Task<IActionResult> DeleteClientRegistration(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/ClientRegistration/DeleteClientRegistrationById/" + id.ToString());
                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ClientRegistrationList");
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
            return RedirectToAction("ClientRegistrationList");
        }
    }
}
