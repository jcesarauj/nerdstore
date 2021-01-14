using NerdStore.Catalog.Aplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Aplication.Contract
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
