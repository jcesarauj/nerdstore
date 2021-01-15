using NerdStore.Catalog.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Application.Contract
{
	public interface IProductAppService
	{
		Task<IEnumerable<ProductViewModel>> List();
		Task<ProductViewModel> GetById(Guid productId);
		void Add(ProductViewModel product);
		void Update(ProductViewModel product);
		void Delete(Guid productId);

	}
}
