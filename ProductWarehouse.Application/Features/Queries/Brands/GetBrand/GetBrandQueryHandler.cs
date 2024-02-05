﻿using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Brands.GetBrand;
public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Sizes.GetByIdAsync(request.Id);
        var mapper = _mapper.Map<BrandDto>(result);

        return mapper;
    }
}