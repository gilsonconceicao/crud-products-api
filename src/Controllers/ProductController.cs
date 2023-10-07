using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace crud_products_api.src.Controllers;
[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllProducts() 
    {
        return Ok("Teste: Product"); 
    }
}
