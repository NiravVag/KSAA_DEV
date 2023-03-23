using KSAA.Domain.Common;
using KSAA.Domain.Entities;
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
    public class CustomerCodeController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<CustomerCodeController> _logger;

        public CustomerCodeController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<CustomerCodeController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IActionResult> CustomerCodeList()
        {
            IEnumerable<CustomerCodeListModel> CustomerCodes = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/CustomerCode/GetAllCustomerCode", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();

                        var data = JsonConvert.DeserializeObject<CommonResponse<List<CustomerCodeListModel>>>(readTask);

                        CustomerCodes = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        CustomerCodes = Enumerable.Empty<CustomerCodeListModel>();
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
            return View(CustomerCodes);
        }
        public IActionResult CustomerCodeAdd()
        {
            CustomerCodeViewModel customerCodeViewModel = new CustomerCodeViewModel();
            return View(customerCodeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerCodeAdd(CustomerCodeViewModel customerCodeViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/CustomerCode/CreateCustomerCode", customerCodeViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("CustomerCodeList");
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

        public async Task<IActionResult> CustomerCodeEdits(CustomerCodeViewModel customerCodeViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/CustomerCode/UpdateCustomerCodeById", customerCodeViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("CustomerCodeList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<CustomerCodeViewModel>>(readTask);

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

        public async Task<IActionResult> GetCustomerCode(long id)
        {
            CustomerCodeViewModel customerCodeViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.GetAsync("api/CustomerCode/GetCustomerCodeById/" + id.ToString());
                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var responseString = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<CustomerCodeViewModel>>(responseString);
                        customerCodeViewModel = data.Data;
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

            return View("CustomerCodeEdit", customerCodeViewModel);
        }

        public async Task<IActionResult> DeleteCustomerCodes(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/CustomerCode/DeleteCustomerCodeById/" + id.ToString());
                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CustomerCodeList");
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

            return RedirectToAction("CustomerCodeList");
        }
    }
}