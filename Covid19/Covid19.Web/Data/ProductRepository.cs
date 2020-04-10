﻿namespace Covid19.Web.Data
{
	using Entities;

	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		public ProductRepository(DataContext context) : base(context)
		{
		}
	}

}
