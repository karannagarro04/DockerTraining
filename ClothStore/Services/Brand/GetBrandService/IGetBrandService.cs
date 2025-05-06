using System;
using ClothStore.Domain.Brand.Models;

namespace ClothStore.Services.Brand.GetBrandService;

public interface IGetBrandService
{
    Task<Brands> GetBrandByIdAsync(int brandId);
    Task<IEnumerable<Brands>> GetAllBrandsAsync();
}
