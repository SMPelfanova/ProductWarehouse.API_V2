﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.EF.Constants;

namespace ProductWarehouse.Persistence.EF.Configurations;

public class ProductConfiguration : EntityConfiguration<Product>
{
	public override void Configure(EntityTypeBuilder<Product> builder)
	{
		base.Configure(builder);

		builder.Property(p => p.Photo).IsRequired(false);
		builder.Property(p => p.IsDeleted).HasDefaultValue(false);
		builder.Property(p => p.Description).IsRequired();

		builder.Property(p => p.Title)
			.IsRequired()
			.HasMaxLength(DatabaseConstants.Hundred);

		builder.Property(p => p.Price)
			.HasColumnType(DatabaseConstants.DecimalColumnType)
			.IsRequired();

		builder.HasOne(b => b.Brand)
			.WithMany(p => p.Products)
			.HasForeignKey(b => b.BrandId)
			.IsRequired();
	}
}