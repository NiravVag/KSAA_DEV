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
    public class ClientBankAccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly BackendUrl _options;
        private readonly ILogger<ClientAuthorizedSignatoryController> _logger;

        public ClientBankAccountController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<ClientAuthorizedSignatoryController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }
        public async Task<IActionResult> ClientBankAccountList()
        {
            IEnumerable<ClientBankAccountListModel> clientBankAccounts = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/ClientBankAccount/GetAllClientBankAccount", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            //readTask.Wait();

                            var data = JsonConvert.DeserializeObject<CommonResponse<List<ClientBankAccountListModel>>>(readTask);

                            clientBankAccounts = data.Data;

                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            clientBankAccounts = Enumerable.Empty<ClientBankAccountListModel>();
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
            return View(clientBankAccounts);
        }
        public IActionResult ClientBankAccountAdd()
        {
            ClientBankAccountViewModel ClientBankAccountViewModel = new ClientBankAccountViewModel();
            return View(ClientBankAccountViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ClientBankAccountAdd(ClientBankAccountViewModel ClientBankAccountViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/ClientBankAccount/CreateClientBankAccount", ClientBankAccountViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("ClientBankAccountList");
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

        public async Task<IActionResult> ClientBankAccountEdit(ClientBankAccountViewModel ClientBankAccountViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/ClientBankAccount/UpdateClientBankAccountById", ClientBankAccountViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("ClientBankAccountList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ClientBankAccountViewModel>>(readTask);

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

        public async Task<IActionResult> GetClientBankAccount(long id)
        {
            ClientBankAccountViewModel ClientBankAccountViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.GetAsync("api/ClientBankAccount/GetClientBankAccountById/" + id.ToString());
                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Response<ClientBankAccountViewModel>>(readTask);
                        ClientBankAccountViewModel = data.Data;
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
            return View("ClientBankAccountEdit", ClientBankAccountViewModel);
        }

        public async Task<IActionResult> DeleteClientBankAccount(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/ClientBankAccount/DeleteClientBankAccountById/" + id.ToString());
                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ClientBankAccountList");
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
            return RedirectToAction("ClientBankAccountList");
        }
    }
}
