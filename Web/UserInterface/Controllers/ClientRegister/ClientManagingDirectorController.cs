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
    public class ClientManagingDirectorController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly BackendUrl _options;
        private readonly ILogger<ClientManagingDirectorController> _logger;

        public ClientManagingDirectorController(IConfiguration configuration, IOptions<BackendUrl> options,ILogger<ClientManagingDirectorController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }
        public async Task<IActionResult> ClientManagingDirectorList()
        {
            IEnumerable<ClientManagingDirectorListModel> clientManagingDirectors = null;
            try { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                var responseTask = await client.PostAsync("api/ClientManagingDirector/GetAllClientManagingDirector", requestContent);
                //responseTask.Wait();

                var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();

                        var data = JsonConvert.DeserializeObject<CommonResponse<List<ClientManagingDirectorListModel>>>(readTask);

                        clientManagingDirectors = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        clientManagingDirectors = Enumerable.Empty<ClientManagingDirectorListModel>();
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
            return View(clientManagingDirectors);
        }
        public IActionResult ClientManagingDirectorAdd()
        {
            ClientManagingDirectorViewModel ClientManagingDirectorViewModel = new ClientManagingDirectorViewModel();
            return View(ClientManagingDirectorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ClientManagingDirectorAdd(ClientManagingDirectorViewModel ClientManagingDirectorViewModel)
        {
            try { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                //HTTP POST
                var postTask = await client.PostAsJsonAsync("api/ClientManagingDirector/CreateClientManagingDirector", ClientManagingDirectorViewModel);
                //postTask.Wait();

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    //return RedirectToAction("ClientManagingDirectorList");
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

        public async Task<IActionResult> ClientManagingDirectorEdit(ClientManagingDirectorViewModel ClientManagingDirectorViewModel)
        {
            try { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                //HTTP POST
                var postTask = await client.PutAsJsonAsync("api/ClientManagingDirector/UpdateClientManagingDirectorById", ClientManagingDirectorViewModel);

                var result = postTask;
                if (result.IsSuccessStatusCode)
                {
                    //return RedirectToAction("ClientManagingDirectorList");
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<ClientManagingDirectorViewModel>>(readTask);
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

        public async Task<IActionResult> GetClientManagingDirector(long id)
        {
            ClientManagingDirectorViewModel ClientManagingDirectorViewModel = null;
            try { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                var responseTask = await client.GetAsync("api/ClientManagingDirector/GetClientManagingDirectorById/" + id.ToString());
                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Response<ClientManagingDirectorViewModel>>(readTask);
                    ClientManagingDirectorViewModel = data.Data;
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
            return View("ClientManagingDirectorEdit", ClientManagingDirectorViewModel);
        }

        public async Task<IActionResult> DeleteClientManagingDirector(long id)
        {
            try { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.ClientRegisterUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                var deleteTask = await client.DeleteAsync("api/ClientManagingDirector/DeleteClientManagingDirectorById/" + id.ToString());
                var result = deleteTask;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("ClientManagingDirectorList");
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
            return RedirectToAction("ClientManagingDirectorList");
        }
    }
}
