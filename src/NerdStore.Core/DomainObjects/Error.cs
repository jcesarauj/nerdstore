using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.DomainObjects
{
	public class Error
	{
		public Error(string code, string description)
		{
			Code = code;
			Description = description;
		}

		public string Code { get; private set; }
		public string Description { get; private set; }
	}
}
