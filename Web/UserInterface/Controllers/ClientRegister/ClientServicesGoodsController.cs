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
    public class ClientServicesGoodsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly BackendUrl _options;
        private readonly ILogger<ClientServicesGoodsController> _logger;

        public ClientServicesGoodsController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<ClientServicesGoodsController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }
        public async Task<IActionResult> ClientServicesGoodsList()
        {
            IEnumerable<ClientServicesGoodsListModel> clientServicesGoodss = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/ClientServicesGoods/GetAllClientServicesGoods", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            //readTask.Wait();

                            var data = JsonConvert.DeserializeObject<CommonResponse<List<ClientServicesGoodsListModel>>>(readTask);

                            clientServicesGoodss = data.Data;

                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            clientServicesGoodss = Enumerable.Empty<ClientServicesGoodsListModel>();
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
            return View(clientServicesGoodss);
        }
        public IActionResult ClientServicesGoodsAdd()
        {
            ClientServicesGoodsViewModel ClientServicesGoodsViewModel = new ClientServicesGoodsViewModel();
            return View(ClientServicesGoodsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ClientServicesGoodsAdd(ClientServicesGoodsViewModel ClientServicesGoodsViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/ClientServicesGoods/CreateClientServicesGoods", ClientServicesGoodsViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("ClientServicesGoodsList");
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

        public async Task<IActionResult> ClientServicesGoodsEdit(ClientServicesGoodsViewModel ClientServicesGoodsViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/ClientServicesGoods/UpdateClientServicesGoodsById", ClientServicesGoodsViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("ClientServicesGoodsList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<ClientServicesGoodsViewModel>>(readTask);

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

        public async Task<IActionResult> GetClientServicesGoods(long id)
        {
            ClientServicesGoodsViewModel ClientServicesGoodsViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.GetAsync("api/ClientServicesGoods/GetClientServicesGoodsById/" + id.ToString());
                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Response<ClientServicesGoodsViewModel>>(readTask);
                        ClientServicesGoodsViewModel = data.Data;
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
            return View("ClientServicesGoodsEdit", ClientServicesGoodsViewModel);
        }

        public async Task<IActionResult> DeleteClientServicesGoods(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/ClientServicesGoods/DeleteClientServicesGoodsById/" + id.ToString());
                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("ClientServicesGoodsList");
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
            return RedirectToAction("ClientServicesGoodsList");
        }
    }
}
