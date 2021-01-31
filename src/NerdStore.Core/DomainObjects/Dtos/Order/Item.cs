using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.DomainObjects.Dtos.Order
{
	public class Item : Dto
	{
		public Guid Id { get; set; }
		public int Quantity { get; set; }
	}
}
