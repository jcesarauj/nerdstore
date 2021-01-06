using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Models
{
	public class Dimensions
	{
		public Dimensions(decimal height, decimal width, decimal depth)
		{
			Height = height;
			Width = width;
			Depth = depth;

			Validate();
		}

		public decimal Height { get; private set; }
		public decimal Width { get; private set; }
		public decimal Depth { get; private set; }

		public void Validate()
		{
			AssertionConcern.ValidateIfEqual(Height, 0, "O campo Altura da dimensão não pode ser 0");
			AssertionConcern.ValidateIfEqual(Width, 0, "O campo Largura da dimensão não pode ser 0");
			AssertionConcern.ValidateIfEqual(Depth, 0, "O campo Profundidade da dimensão não pode ser 0");
		}
	}
}
