using KSAA.DAL;
using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.Master.Application.DTOs.Master;
using KSAA.User.Application.DTOs.Role;
using KSAA.User.Application.DTOs.User;
using KSAA.User.Application.Wrappers;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace KSAA.UserInterface.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<UserController> _logger;

        public UserController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<UserController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }
        // GET: Users
        public async Task<IActionResult> UserList()
        {
            IEnumerable<UserListModel> users = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/User/GetAllUsers", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        //readTask.Wait();

                        //  Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(readTask);
                        //  var users1 = myDeserializedClass.data.ToList();
                        //users = users1.Select(x => new UserListModel
                        //{ 
                        //    Id=x.id,
                        //    FirstName=x.firstName,
                        //    LastName=x.lastName,
                        //    Email=x.email,
                        //    UserType=x.userType,
                        //    UserTypeName=x.userTypeName,
                        //    CompanyName=x.companyName,
                        //    Company = x.company,
                        //    IsActive=x.isActive,
                        //    UserRoleName = x.userRoleName,
                        //}).Where(x => x.IsActive != IsActive.Delete);

                        var data = JsonConvert.DeserializeObject<CommonResponse<List<UserListModel>>>(readTask);
                        users = data.Data;

                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        users = Enumerable.Empty<UserListModel>();
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
            return View(users);
        }

        public async Task<IActionResult> UserAdd()
        {
            UserViewModel userViewModel = new UserViewModel();

            //Company Dropdown
            List<CompanyViewModel> CompanysList = null;

            //User Role Dropdown
            List<RoleListModel> RolesList = null;

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
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<CompanyViewModel>>>(readTask);

                        CompanysList = data.Data;

                        CompanysList.Insert(0, new CompanyViewModel() { Id = 0, Company_Name = "----- Select Company -----" });

                        ViewBag.Companys = CompanysList;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        CompanysList = Enumerable.Empty<CompanyViewModel>().ToList();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/Role/GetAllRole", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<RoleListModel>>>(readTask);

                        RolesList = data.Data;

                        RolesList.Insert(0, new RoleListModel() { Id = 0, Name = "----- Select Role -----" });

                        ViewBag.Roles = RolesList;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        RolesList = Enumerable.Empty<RoleListModel>().ToList();
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
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserAdd(UserViewModel userViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/User/CreateUser", userViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("UserList");
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

        public async Task<IActionResult> GetUserById(int id)
        {
            //Company Dropdown
            List<CompanyViewModel> CompanysList = null;

            //User Role Dropdown
            List<RoleListModel> RolesList = null;

            UserViewModel users = null;

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
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<CompanyViewModel>>>(readTask);

                        CompanysList = data.Data;

                        CompanysList.Insert(0, new CompanyViewModel() { Id = 0, Company_Name = "----- Select Company -----" });

                        ViewBag.Companys = CompanysList;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        CompanysList = Enumerable.Empty<CompanyViewModel>().ToList();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsync("api/Role/GetAllRole", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<List<RoleListModel>>>(readTask);

                        RolesList = data.Data;

                        RolesList.Insert(0, new RoleListModel() { Id = 0, Name = "----- Select Role -----" });

                        ViewBag.Roles = RolesList;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        RolesList = Enumerable.Empty<RoleListModel>().ToList();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    //HTTP GET
                    var responseTask = await client.GetAsync("api/User/GetUserById?id=" + id.ToString());
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<UserViewModel>>(readTask);

                        users = data.Data;
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
            return View("~/Views/User/UserUpdate.cshtml", users);
        }

        public async Task<IActionResult> UpdateUser(UserViewModel userViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    //HTTP POST
                    var responseTask = await client.PutAsJsonAsync("api/User/UpdateUserById", userViewModel);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("UserList", userViewModel);
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<UserViewModel>>(readTask);

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

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);

                    //HTTP DELETE
                    var deleteTask = await client.DeleteAsync("api/User/Delete?id=" + id.ToString());
                    //deleteTask.Wait();

                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("UserList");
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
            return RedirectToAction("UserList");

        }

    }
}
