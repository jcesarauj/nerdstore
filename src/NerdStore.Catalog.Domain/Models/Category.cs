using NerdStore.Core.DomainObjects;
using System.Collections.Generic;

namespace NerdStore.Catalog.Domain.Models
{
	public class Category : Entity
	{
		protected Category() { }

		public Category(string name, int code)
		{
			Name = name;
			Code = code;
		}

		public string Name { get; private set; }
		public int Code { get; private set; }

		public ICollection<Product> Products { get; set; } //EF Relation

		public void Validate()
		{
			AssertionConcern.ValidateIfIsEmpty(Name, "O campo Nome do produto não pode ser vazio");
			AssertionConcern.ValidateIfEqual(Code, 0, "O campo Código do produto não pode ser 0");
		}
	}
}
