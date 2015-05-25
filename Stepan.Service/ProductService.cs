using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stepan.Common.Services;
using Stepan.Common;
namespace Stepan.Service
{
   public class ProductService  : IProductService
    {
       readonly IProductRepository repo;
       public ProductService(IProductRepository repo)
       {
           this.repo = repo;
       }
        public IEnumerable<ProductFinderWebsiteEx> GetAllCategories()
        {
            return repo.GetAllCategories();
        }

        public IEnumerable<ProductFinderWebsiteEx> GetCategory(string category)
        {
            return repo.GetCategory(category);
        }

        public IEnumerable<ProductFinderWebsiteEx> GetAllBrandNames()
        {
            return repo.GetAllBrandNames();
        }

        public IEnumerable<ProductFinderWebsiteEx> GetBrandName(string brand)
        {
            return repo.GetBrandName(brand);
        }

        public IEnumerable<ProductFinderWebsiteEx> GetAllChemicalGroups()
        {
            return repo.GetAllChemicalGroups();
        }

        public IEnumerable<ProductFinderWebsiteEx> GetChemicalGroup(string chemGroup)
        {
            return repo.GetChemicalGroup(chemGroup);
        }

        public IEnumerable<ProductFinderWebsiteEx> GetAllChemicalNames()
        {
            return repo.GetAllChemicalNames();
        }

        public IEnumerable<ProductFinderWebsiteEx> GetChemicalName(string name)
        {
            return repo.GetChemicalName(name);
        }

        public IEnumerable<ProductFinderWebsiteEx> GetSearchResult(string query)
        {
            return repo.GetSearchResult(query);
        }

        public IEnumerable<SubCategoryInMobile> GetSubCategoryOfCategory(string category)
        {
            return repo.GetSubCategoryOfCategory(category);
        }

        public IEnumerable<ProductFinderWithAllParameter> GetDescriptionOfSubCategory(string brand)
        {
            return repo.GetDescriptionOfSubCategory(brand);
        }

        public IEnumerable<ProductFinderCatalog> GetData(string parameter)
        {
            return repo.GetData(parameter);
        }
    }
}