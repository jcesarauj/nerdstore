using System;
using System.Collections.Generic;

namespace NerdStore.Core.DomainObjects.Dtos.Order
{
	public class ListProductsOrder : Dto
    {
        public Guid OrderId { get; set; }
        public ICollection<Item> Itens { get; set; }
    }

    
}
