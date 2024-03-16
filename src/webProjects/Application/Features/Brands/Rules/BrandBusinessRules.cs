using Application.Features.Brands.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Domain.Entities;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public void BrandIdShouldExistWhenSelected(Brand? brand)
    {
        if (brand is null)
            throw new Exception(BrandRulesMessages.BrandIsNotExists);
    }

    public async Task BrandNameCanNotBeDuplicatedWhenUpdated(Brand brand)
    {
        Brand? result = await _brandRepository.GetAsync(x => x.Id != brand.Id && x.Name.ToLower() == brand.Name.ToLower());
        if (result is not null)
            throw new Exception(BrandRulesMessages.BrandNameAlreadyExists);
    }
}
