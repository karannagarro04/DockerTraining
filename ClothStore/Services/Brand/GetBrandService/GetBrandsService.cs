using System;
using ClothStore.Domain.Brand.Models;
using EntityModel = ClothStore.Models;
using ClothStore.Repository;
using AutoMapper;

namespace ClothStore.Services.Brand.GetBrandService;

public class GetBrandsService : IGetBrandService
{
    private readonly IReadOnlyRepository<EntityModel.Brand> _repository;
    private readonly IMapper _mapper;

    public GetBrandsService(IReadOnlyRepository<EntityModel.Brand> repository, IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task<Brands> GetBrandByIdAsync(int brandId)
    {
        var brand = await _repository.GetById(brandId);
        return _mapper.Map<Brands>(brand);
    }

    public async Task<IEnumerable<Brands>> GetAllBrandsAsync()
    {
        var brands = await _repository.GetAll();
        return _mapper.Map<IEnumerable<Brands>>(brands);
    }
}
