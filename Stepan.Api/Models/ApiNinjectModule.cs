using Stepan.Common;
using Stepan.Common.Services;
using Stepan.Repository.Models;
using Stepan.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stepan.Api.Models
{
    public class ApiNinjectModule :Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IProductService>().To<ProductService>();
        }
    }
}