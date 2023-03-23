using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.User.Application.DTOs.Role;
using KSAA.User.Application.Wrappers;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace KSAA.UserInterface.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RoleController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<RoleController> logger)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
        }

        // GET: Roles
        public async Task<IActionResult> RoleList()
        {
            IEnumerable<RoleListModel> roles = null;
            try
            {
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
                        roles = data.Data;
                        //readTask.Wait();
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        roles = Enumerable.Empty<RoleListModel>();
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
            return View(roles);
        }

        public IActionResult RoleAdd()
        {
            RoleViewModel roleViewModel = new RoleViewModel();
            return View(roleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAdd(RoleViewModel roleViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    //HTTP POST
                    var postTask = await client.PostAsJsonAsync("api/Role/CreateRole", roleViewModel);
                    //postTask.Wait();

                    var result = postTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("RoleList");
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

        public async Task<IActionResult> GetRoleById(int id)
        {
            RoleViewModel roles = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    //HTTP GET
                    var responseTask = await client.GetAsync("api/Role/GetRoleById?id=" + id.ToString());
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<RoleViewModel>>(readTask);
                        //readTask.Wait();

                        roles = data.Data;
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
            return View("~/Views/Role/RoleUpdate.cshtml", roles);
        }

        public async Task<IActionResult> UpdateRole(RoleViewModel roleViewModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.UserEndpoint);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    //HTTP POST
                    var responseTask = await client.PutAsJsonAsync("api/Role/UpdateRoleById", roleViewModel);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        //return RedirectToAction("RoleList", roleViewModel);
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<RoleViewModel>>(readTask);

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
                    var deleteTask = await client.DeleteAsync("api/Role/Delete?id=" + id.ToString());
                    //deleteTask.Wait();

                    var result = deleteTask;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("RoleList");
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
            return RedirectToAction("RoleList");
        }
    }
}
