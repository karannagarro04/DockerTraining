using System;
using ClothStore.Domain.Brand.Models;

namespace ClothStore.Domain.Brand.BussinessLogic.FetchBrand;

public interface IFetchBrandsDomain
{
    Task<Brands> GetBrandByIdAsync(int brandId);
    Task<IEnumerable<Brands>> GetAllBrandsAsync();
}
