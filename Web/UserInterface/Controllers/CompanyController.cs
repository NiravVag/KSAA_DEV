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
    public class CompanyController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(IConfiguration configuration, IOptions<BackendUrl> options,ILogger<CompanyController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IActionResult> CompanyList()
        {
            IEnumerable<CompanyListModel> Companys = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/Company/GetAllCompany", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();

                        var data = JsonConvert.DeserializeObject<CommonResponse<List<CompanyListModel>>>(readTask);

                        Companys = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        Companys = Enumerable.Empty<CompanyListModel>();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
            return View(Companys);
        }
        public IActionResult CompanyAdd()
        {
            CompanyViewModel CompanyViewModel = new CompanyViewModel();
            return View(CompanyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CompanyAdd(CompanyViewModel companyViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/Company/CreateCompany", companyViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("CompanyList");
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
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
        }

        public async Task<IActionResult> CompanyEdit(CompanyViewModel companyViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PutAsJsonAsync("api/Company/UpdateCompanyById", companyViewModel);

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("CompanyList");
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<CompanyViewModel>>(readTask);

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
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
        }

        public async Task<IActionResult> GetCompany(long id)
        {
            CompanyViewModel companyViewModel = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var result = await client.GetAsync("api/Company/GetCompanyById/" + id);
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<CommonResponse<CompanyViewModel>>(readTask);
                        companyViewModel = response.Data;
                    }
                    else
                    {
                        _logger.LogError(new Exception().Message);
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

            return View("CompanyEdit", companyViewModel);
        }

        public async Task<IActionResult> DeleteCompany(long id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.MasterUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var deleteTask = await client.DeleteAsync("api/Company/DeleteCompanyById/" + id.ToString());
                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CompanyList");
                    }
                    else
                    {
                        _logger.LogError(new Exception().Message);
                    }
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }

            return RedirectToAction("CompanyList");
        }
    }
}