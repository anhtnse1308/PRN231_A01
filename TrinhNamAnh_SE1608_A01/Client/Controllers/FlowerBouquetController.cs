using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Client.Extension;
using System.Net.Http.Json;

namespace Client.Controllers
{
    public class FlowerBouquetController : Controller
    {
        public FlowerBouquetController()
        {
        }

        // GET: FlowerBouquet
        public async Task<IActionResult> Index()
        {
            IEnumerable<FlowerBouquet> list = new List<FlowerBouquet>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("flowerBouquet");
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<IEnumerable<FlowerBouquet>>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = list;
            }
            return View();
        }

        // GET: FlowerBouquet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            FlowerBouquet model = new FlowerBouquet();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("customer/" + id);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<FlowerBouquet>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = model;
            }

            return View();
        }

        // GET: FlowerBouquet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlowerBouquet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlowerBouquetId,CategoryId,FlowerBouquetName,Description,UnitPrice,UnitsInStock,FlowerBouquetStatus,SupplierId")] FlowerBouquet flowerBouquet)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.PostAsJsonAsync<FlowerBouquet>("flowerBouquet", flowerBouquet);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    flowerBouquet = JsonConvert.DeserializeObject<FlowerBouquet>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = flowerBouquet;
            }
            return View(flowerBouquet);
        }

        // GET: FlowerBouquet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            FlowerBouquet model = new FlowerBouquet();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("customer/" + id);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<FlowerBouquet>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = model;
            }
            return View();
        }

        // POST: FlowerBouquet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlowerBouquetId,CategoryId,FlowerBouquetName,Description,UnitPrice,UnitsInStock,FlowerBouquetStatus,SupplierId")] FlowerBouquet flowerBouquet)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.PutAsJsonAsync<FlowerBouquet>("flowerBouquet", flowerBouquet);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    flowerBouquet = JsonConvert.DeserializeObject<FlowerBouquet>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = flowerBouquet;
            }
            return View(flowerBouquet);
        }
    }
}
