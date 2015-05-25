using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stepan.Common
{
    public interface IProductRepository 
    {
        IEnumerable<ProductFinderWebsiteEx> GetAllCategories();

        IEnumerable<ProductFinderWebsiteEx> GetCategory(string category);
        IEnumerable<ProductFinderWebsiteEx> GetAllBrandNames();
        IEnumerable<ProductFinderWebsiteEx> GetBrandName(string brand);
        IEnumerable<ProductFinderWebsiteEx> GetAllChemicalGroups();
        IEnumerable<ProductFinderWebsiteEx> GetChemicalGroup(string chemGroup);
        IEnumerable<ProductFinderWebsiteEx> GetAllChemicalNames();
        IEnumerable<ProductFinderWebsiteEx> GetChemicalName(string name);
        IEnumerable<ProductFinderWebsiteEx> GetSearchResult(string query);
        IEnumerable<SubCategoryInMobile> GetSubCategoryOfCategory(string category);
        IEnumerable<ProductFinderWithAllParameter> GetDescriptionOfSubCategory(string brand);
        IEnumerable<ProductFinderCatalog> GetData(string parameter);
    }
}