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
    public class VendorCodeController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<VendorCodeController> _logger;

        public VendorCodeController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<VendorCodeController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IActionResult> VendorCodeList()
        {
            IEnumerable<VendorCodeListModel> vendorCodes = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/VendorCode/GetAllVendorCode", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<VendorCodeListModel>>>(readTask);
                        vendorCodes = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        vendorCodes = Enumerable.Empty<VendorCodeListModel>();
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
            return View(vendorCodes);
        }
        public IActionResult VendorCodeAdd()
        {
            VendorCodeViewModel vendorCodeViewModel = new VendorCodeViewModel();
            return View(vendorCodeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> VendorCodeAdd(VendorCodeViewModel vendorCodeViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/VendorCode/CreateVendorCode", vendorCodeViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("VendorCodeList");
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

        public async Task<IActionResult> VendorCodeEdit(VendorCodeViewModel vendorCodeViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/VendorCode/UpdateVendorCodeById", vendorCodeViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("VendorCodeList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<VendorCodeViewModel>>(readTask);

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

        public async Task<IActionResult> GetVendorCode(long id)
        {
            VendorCodeViewModel vendorCodeViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var responseTask = await client.GetAsync("api/VendorCode/GetVendorCodeById/" + id.ToString());
                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Response<VendorCodeViewModel>>(readTask);
                        vendorCodeViewModel = data.Data;
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
            return View("VendorCodeEdit", vendorCodeViewModel);
        }

        public async Task<IActionResult> DeleteVendorCodes(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/VendorCode/DeleteVendorCodeById/" + id.ToString());
                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("VendorCodeList");
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
            return RedirectToAction("VendorCodeList");
        }
    }
}