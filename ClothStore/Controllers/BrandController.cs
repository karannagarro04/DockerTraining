using ClothStore.Domain.Brand.BussinessLogic.FetchBrand;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClothStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IFetchBrandsDomain _fetchBrandsDomain;
        public BrandController(IFetchBrandsDomain fetchBrandsDomain)
        {
            _fetchBrandsDomain = fetchBrandsDomain;
        }

        [HttpGet("{brandId}")]
        public async Task<IActionResult> GetBrandById(int brandId)
        {
            var brand = await _fetchBrandsDomain.GetBrandByIdAsync(brandId);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _fetchBrandsDomain.GetAllBrandsAsync();
            if (brands == null || !brands.Any())
            {
                return NotFound();
            }
            return Ok(brands);
        }
    }
}