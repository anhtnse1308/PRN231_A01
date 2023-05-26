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
    public class CustomerController : Controller
    {
        public CustomerController()
        {
        }
        // GET: Customer
        public async Task<IActionResult> Index()
        {
            IEnumerable<Customer> list = new List<Customer>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("customer");
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<IEnumerable<Customer>>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = list;
            }
            return View();
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Customer customer = new Customer();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.GetAsync("customer/"+id);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customer>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = customer;
            }

            return View();
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,Email,CustomerName,City,Country,Password,Birthday")] Customer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Helper.baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage getData = await client.PostAsJsonAsync<Customer>("customer", customer);
                if (getData.IsSuccessStatusCode)
                {
                    string rs = getData.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Customer>(rs);
                }
                else
                {
                    Console.WriteLine("Read API failed");
                }
                ViewData.Model = customer;
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            return View();
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,Email,CustomerName,City,Country,Password,Birthday")] Customer customer)
        {
            
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
