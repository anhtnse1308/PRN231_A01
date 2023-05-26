using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using Client.Extension;

namespace Client.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController()
        {
        }
        // GET: Category
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> list = new List<Category>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("category");
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<IEnumerable<Category>>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = list;
            }
            return View();
        }
    }
}
