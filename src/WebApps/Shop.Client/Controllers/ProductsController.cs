 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Client.ApiServices;
using Shop.Client.Models;

namespace Shop.Client.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductApiService _productApiService;

        public ProductsController(IProductApiService productApiService)
        {
            _productApiService = productApiService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            //await LogTokenAndClaims();
            return View(await _productApiService.GetProducts());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            return View();
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,Summary,Description,ImageFile,Price")] Product product)
        {
            return View();
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            return View();
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Category,Summary,Description,ImageFile,Price")] Product product)
        {
            return View();
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            return View();
        }

        private bool ProductExists(string id)
        {
            return true;
        }
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
