namespace Covid19.Web.Data.Entities
{
	using System;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
		public int Id { get; set; }

		[MaxLength(100, ErrorMessage ="El campo {0} solo puede tener {1} caracteres.")]
		[Required]
		public string Name { get; set; }

		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]  //decorados, modificaciones C2 currencie 2, ApplyFormatInEditMode flaso para que no aparezca en formato
		public decimal Price { get; set; }

		[Display(Name = "Imagen")]
		public string ImageUrl { get; set; }

		[Display(Name = "Last Purchase")]
		public DateTime? LastPurchase { get; set; }

		[Display(Name = "Last Sale")]
		public DateTime? LastSale { get; set; }

		[Display(Name = "Is Availabe?")]
		public bool IsAvailabe { get; set; }

		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double Stock { get; set; }

	}
}
