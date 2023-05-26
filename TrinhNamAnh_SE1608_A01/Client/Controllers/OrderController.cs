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

namespace Client.Controllers
{
    public class OrderController : Controller
    {
        public OrderController()
        {
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            IEnumerable<Order> list = new List<Order>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("order");
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<IEnumerable<Order>>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = list;
            }
            return View();
        }
        public async Task<IActionResult> IndexHistory(int? id)
        {
            IEnumerable<Order> list = new List<Order>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("order");
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<IEnumerable<Order>>(rs);
                    list = list.Where(o => o.CustomerId == id);
                    if (list != null)
                    {
                        return View("Index");
                    }
                    else
                    {
                        RedirectToPage("IndexMember", "Home");
                    }
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = list;
            }
            return View("Index");
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Order model = new Order();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("order/" + id);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<Order>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = model;
            }

            return View();
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,OrderDate,ShippedDate,Total,OrderStatus")] Order order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.PostAsJsonAsync<Order>("order", order);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    order = JsonConvert.DeserializeObject<Order>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = order;
            }
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Order model = new Order();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("order/" + id);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    model = JsonConvert.DeserializeObject<Order>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = model;
            }

            return View();
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,OrderDate,ShippedDate,Total,OrderStatus")] Order order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.PutAsJsonAsync<Order>("order", order);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    order = JsonConvert.DeserializeObject<Order>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = order;
            }
            return View(order);
        }
    }
}
