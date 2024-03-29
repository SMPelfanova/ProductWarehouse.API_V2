﻿using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Products;

public class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, ProductSizeDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateProductSizeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<ProductSizeDto> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
	{
		var productSize = _mapper.Map<ProductSize>(request);
		var result  = await _unitOfWork.ProductSizes.AddAsync(productSize, cancellationToken);

		await _unitOfWork.SaveChangesAsync(cancellationToken);
		
		var productSizeDto = _mapper.Map<ProductSizeDto>(result);

		return productSizeDto;
	}
}