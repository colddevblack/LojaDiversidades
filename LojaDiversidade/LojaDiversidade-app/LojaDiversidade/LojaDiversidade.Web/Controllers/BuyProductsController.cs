﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LojaDiversidade.Web.Models;
using LojaDiversidade.Web.Roles;
using LojaDiversidade.Web.Services.Contracts;

namespace LojaDiversidade.Web.Controllers;

//[Authorize(Roles = Role.Client)]
public class BuyProductsController : Controller
{
    private readonly ILogger<BuyProductsController> _logger;
    private readonly IProductService _productService;
    private readonly ICartService _cartService;

    public BuyProductsController(ILogger<BuyProductsController> logger,
        IProductService productService,
        ICartService cartService)
    {
        _logger = logger;
        _productService = productService;
        _cartService = cartService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllProducts(string.Empty);

        if (products is null)
        {
            return View("Error");
        }

        return View(products);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<ProductViewModel>> ProductDetails(int id)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var product = await _productService.FindProductById(id,token);

        if (product is null)
            return View("Error");

        return View(product);
    }

    [HttpPost]
    [ActionName("ProductDetails")]
    [Authorize]
    public async Task<ActionResult<ProductViewModel>> ProductDetailsPost
        (ProductViewModel productVM)
    {
        var token = await HttpContext.GetTokenAsync("access_token");

        CartViewModel cart = new()
        {
            CartHeader = new CartHeaderViewModel
            {
                UserId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value
            }
        };

        CartItemViewModel cartItem = new() 
        {
            Quantity = productVM.Quantity,
            ProductId = productVM.Id,
            Product = await _productService.FindProductById(productVM.Id, token)
        };

        List<CartItemViewModel> cartItemsVM = new List<CartItemViewModel>();
        cartItemsVM.Add(cartItem);
        cart.CartItems = cartItemsVM;

        var result = await _cartService.AddItemToCartAsync(cart, token);

        if (result is not null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(productVM);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(string message)
    {
        return View(new ErrorViewModel { ErrorMessage = message });
    }

    [Authorize]
    public async Task<IActionResult> Login()
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
    }
}