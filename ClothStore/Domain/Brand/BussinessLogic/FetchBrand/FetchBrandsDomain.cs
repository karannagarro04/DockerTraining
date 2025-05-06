using System;
using ClothStore.Domain.Brand.Models;
using ClothStore.Services.Brand.GetBrandService;

namespace ClothStore.Domain.Brand.BussinessLogic.FetchBrand;

public class FetchBrandsDomain : IFetchBrandsDomain
{
    private readonly IGetBrandService _getBrandService;
    public FetchBrandsDomain(IGetBrandService getBrandService)
    {
        _getBrandService = getBrandService;
    }

    public Task<IEnumerable<Brands>> GetAllBrandsAsync()
    {
        return _getBrandService.GetAllBrandsAsync();
    }

    public Task<Brands> GetBrandByIdAsync(int brandId)
    {
        return _getBrandService.GetBrandByIdAsync(brandId);
    }
}
