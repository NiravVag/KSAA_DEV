using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using GemBox.Spreadsheet;
using Grpc.Core;
using KSAA.Domain.Common;
using KSAA.Domain.Entities;
using KSAA.GL_Income.Application.DTOs.FinalOutputRegister;
using KSAA.UserInterface.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NUnit.Framework.Internal.Execution;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace KSAA.UserInterface.Web.Controllers
{
    [Authorize]
    public class FinalOutputRegisterController : Controller
    {
        private IConfiguration _configuration;
        private BackendUrl _options;
        private ILogger<FinalOutputRegisterController> _logger;
        private IWebHostEnvironment _webHostEnvironment;

        public FinalOutputRegisterController(IConfiguration configuration, IOptions<BackendUrl> options, ILogger<FinalOutputRegisterController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _options = options.Value;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> FinalOutputRegisterList(string m, string y)
        {

            try
            {
                FinalOutputRegisterListModel finalOutputRegister = new FinalOutputRegisterListModel();
                //Month and Year Dropdown
                List<CommonRequest> MonthYearList = null;

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_options.GLIncomeUrl);
                    var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                    var responseTask = await client.PostAsJsonAsync("api/GL_Income/GetSLMonthYear", requestContent);
                    //responseTask.Wait();

                    var result = responseTask;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<CommonResponse<CommonRequest>>(readTask);

                        var months = data.Data.Months.Select(x => new SelectListItem(x, x)).ToList();
                        months.Insert(0, new SelectListItem() { Value = "", Text = "----- Select Month -----" });

                        var years = data.Data.Years.Select(x => new SelectListItem(x, x)).ToList();
                        years.Insert(0, new SelectListItem() { Value = "", Text = "----- Select Years -----" });

                        ViewBag.Months = months;
                        ViewBag.Years = years;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        MonthYearList = Enumerable.Empty<CommonRequest>().ToList();
                        _logger.LogError(new Exception().Message);
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }

                if (m != null && y != null && m != "" && y != "")
                {
                    ViewBag.Month = m.ToString();
                    ViewBag.Year = y.ToString();
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(_options.GLIncomeUrl);
                        var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                        var responseTask = await client.PostAsJsonAsync("api/FinalOutputRegister/FinalOutputRegisterList", new { month = m, year = y });
                        //responseTask.Wait();

                        var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = await result.Content.ReadAsStringAsync();
                            var data = JsonConvert.DeserializeObject<CommonResponse<FinalOutputRegisterListModel>>(readTask);

                            finalOutputRegister = data.Data;

                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            finalOutputRegister = null;
                            _logger.LogError(new Exception().Message);
                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                }
                return View(finalOutputRegister);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Forbid();
            }
        }

        public async Task<IActionResult> GenrateFinalOutputRegister(string m, string y)
        {
            FinalOutputRegisterListModel genComparison = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_options.GLIncomeUrl);
                var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                var responseTask = await client.PostAsJsonAsync("api/FinalOutputRegister/GenFinalOutputRegister", new { month = m, year = y });

                var result = responseTask;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CommonResponse<FinalOutputRegisterListModel>>(readTask);

                    genComparison = data.Data;

                }
                else //web api sent error response 
                {
                    //log response status here..

                    genComparison = null;

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            //return Json(gL_Income);
            string message = "SUCCESS";
            return Json(new { Message = message });
        }

        public IActionResult Export(string m, string y)
        {
            MemoryStream spreadsheetStream = new System.IO.MemoryStream();
            var FileName = "FinalOutPutRegister_" + m + "_" + y + ".xlsx";
            try
            {
                FinalOutputRegisterListModel finalOutputRegister = new FinalOutputRegisterListModel();

                if (m != null && y != null && m != "" && y != "")
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(_options.GLIncomeUrl);
                        var requestContent = new StringContent("{}", Encoding.UTF8, "application/json");
                        var responseTask = client.PostAsJsonAsync("api/FinalOutputRegister/FinalOutputRegisterExport", new { month = m, year = y }).Result;
                        //responseTask.Wait();

                        var result = responseTask;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsStringAsync();

                            var data = JsonConvert.DeserializeObject<CommonResponse<FinalOutputRegisterListModel>>(readTask.Result);
                            DataTable dt = new DataTable();

                            ListtoDataTableConverter converter = new ListtoDataTableConverter();
                            dt = converter.ToDataTable(data.Data.finalOutputRegistersList);
                            dt.TableName = "Table1";

                            using (var workbook = new XLWorkbook())
                            {
                                // create worksheets etc..
                                workbook.AddWorksheet(dt);
                                // return 
                                using (var stream = new MemoryStream())
                                {
                                    workbook.SaveAs(stream);
                                    //stream.Flush();
                                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", FileName);
                                }
                            }
                        }
                        else //web api sent error response 
                        {
                            //log response status here..

                            finalOutputRegister = null;
                            _logger.LogError(new Exception().Message);
                            ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return File(spreadsheetStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", FileName);
        }

    }
    public class ListtoDataTableConverter
    {
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }

}
