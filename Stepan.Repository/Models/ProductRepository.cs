using Stepan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stepan.Repository.Models
{
    //public class ProductRepository :IProductRepository
    //{
    //    readonly I
    //        //public ProductRepository()
    //        //{
    //        //    this.
    //        //}
    //}

    public class ProductRepository : IProductRepository
    {
        StepanEktron_oldEntities db = new StepanEktron_oldEntities();

        public IEnumerable<ProductFinderWebsiteEx> GetAllCategories()
        {
            var pf = db.ProductFinders
                      .Select(x =>
                          new ProductFinderWebsiteEx
                          {
                              Name = x.Name,
                              FormAt25C = x.FormAt25C,
                              ViscosityAt200C = x.ViscosityAt200C
                          }).ToList();
            return pf;
        }

        public IEnumerable<ProductFinderWebsiteEx> GetCategory(string category)
        {
            var pf = db.ProductFinders
                .Where(y => y.Category == category).Select(x =>
                    new ProductFinderWebsiteEx
                    {
                        Name = x.Name,
                        FormAt25C = x.FormAt25C,
                        ViscosityAt200C = x.ViscosityAt200C
                    }).ToList();
            return pf;

        }

        public IEnumerable<ProductFinderWebsiteEx> GetAllBrandNames()
        {
            var pf = db.ProductFinders
                .Select(x =>
                    new ProductFinderWebsiteEx
                    {
                        Name = x.Name,
                        FormAt25C = x.FormAt25C,
                        ViscosityAt200C = x.ViscosityAt200C
                    }).ToList(); ;
            return pf;
        }

        public IEnumerable<ProductFinderWebsiteEx> GetBrandName(string brand)
        {
            var pf = db.ProductFinders
                .Where(y => y.Brand == brand).Select(x =>
                    new ProductFinderWebsiteEx
                    {
                        Name = x.Name,
                        FormAt25C = x.FormAt25C,
                        ViscosityAt200C = x.ViscosityAt200C
                    }).ToList(); ;
            return pf;
        }

        public IEnumerable<ProductFinderWebsiteEx> GetAllChemicalGroups()
        {
            var pf = (from p in db.ProductFinders
                      join t in db.ProductTaxonomySummaries
                      on p.id equals t.item_id
                      select new ProductFinderWebsiteEx
                      {
                          Name = p.Name,
                          FormAt25C = p.FormAt25C,
                          ViscosityAt200C = p.ViscosityAt200C
                      }).OrderBy(p => p.Name).ToList();
            return pf;
        }

        public IEnumerable<ProductFinderWebsiteEx> GetChemicalGroup(string chemGroup)
        {
            var pf = (from x in db.ProductFinders
                      join y in db.ProductTaxonomySummaries
                      on x.id equals y.item_id
                      where (y.chemGroups.Contains(chemGroup))
                      select new ProductFinderWebsiteEx
                      {
                          Name = x.Name,
                          FormAt25C = x.FormAt25C,
                          ViscosityAt200C = x.ViscosityAt200C
                      }).OrderBy(x => x.Name).ToList();
            return pf;
        }

        public IEnumerable<ProductFinderWebsiteEx> GetAllChemicalNames()
        {
            var pf = (from a in db.ProductFinders
                      join b in db.ProductFinderLinks on a.id equals b.ProductID
                      join c in db.ProductFinderTaxonomies on
                      b.TaxonomyID equals c.id
                      select new
                       ProductFinderWebsiteEx
                      {
                          Name = a.Name,
                          FormAt25C = a.FormAt25C,
                          ViscosityAt200C = a.ViscosityAt200C
                      }).OrderBy(a => a.Name).ToList();
            return pf;
        }

        public IEnumerable<ProductFinderWebsiteEx> GetChemicalName(string name)
        {
            var pf = (from a in db.ProductFinders
                      join b in db.ProductFinderLinks on
                      a.id equals b.ProductID
                      join c in db.ProductFinderTaxonomies
                      on b.TaxonomyID equals c.id
                      where c.Name == name
                      select new
                         ProductFinderWebsiteEx
                      {
                          Name = a.Name,
                          FormAt25C = a.FormAt25C,
                          ViscosityAt200C = a.ViscosityAt200C
                      }).OrderBy(a => a.Name).ToList();
            return pf;
        }

        public IEnumerable<ProductFinderWebsiteEx> GetSearchResult(string query)
        {
            var pf = (from a in db.ProductFinders
                      where a.Name == query || a.Brand == query || a.Category == query || a.ChemicalDescription == query
                      select new
                             ProductFinderWebsiteEx
                      {
                          Name = a.Name,
                          FormAt25C = a.FormAt25C,
                          ViscosityAt200C = a.ViscosityAt200C
                      }).OrderBy(a => a.Name).ToList();
            return pf;
        }
        public IEnumerable<SubCategoryInMobile> GetSubCategoryOfCategory(string category)
        {
            var pf = (from a in db.ProductFinders
                      where a.Category == category
                      select new
                              SubCategoryInMobile
                      {
                          Brand = a.Brand,
                         
                      }).OrderBy(a => a.Brand).ToList();

            return pf;
        }
        public IEnumerable<ProductFinderWithAllParameter> GetDescriptionOfSubCategory(string brand)
        {
            var pf = (from a in db.ProductFinders
                      where a.Brand == brand
                      select new ProductFinderWithAllParameter
                      {
                          Name = a.Name,
                          FormAt25C = a.FormAt25C,
                          ViscosityAt200C = a.ViscosityAt200C,
                          ViscosityAt25C = a.ViscosityAt25C,
                          ViscosityAtC = a.ViscosityAtC,
                          AcidNumber = a.AcidNumber,
                          AcidValue = a.AcidValue,
                          ApproxTgC = a.ApproxTgC,
                          CloudPoint = a.CloudPoint,
                          CMC = a.CMC,
                          Density = a.Density,
                          DravesWetting = a.DravesWetting,
                          FlashPoint = a.FlashPoint,
                          FoamDensity = a.FoamDensity,
                          FreeFattyAcid = a.FreeFattyAcid,
                          FreezePoint = a.FreezePoint,
                          HLB = a.HLB,
                          HydroxylValue = a.HydroxylValue,
                          InsulationValue = a.InsulationValue,
                          IntrafacialTension = a.IntrafacialTension,
                          Kosher = a.Kosher,
                          MolesOfEO = a.MolesOfEO,
                          MolesOfPO = a.MolesOfPO,
                          OH_Functionality = a.OH_Functionality,
                          PercentActive = a.PercentActive,
                          PourPoint = a.PourPoint,
                          Solids = a.Solids,
                          SpecificGravity = a.SpecificGravity,
                          SurfaceTension = a.SurfaceTension,
                          ThermalStability = a.ThermalStability,
                          Triglycerides = a.Triglycerides,
                          VOC = a.VOC
                      }).ToList();
            return pf;
        }

        public IEnumerable<ProductFinderCatalog> GetData(string parameter)
        {
            string markets = "";
            string chemicalGroups = "";
            string name = "";
            string[] data = parameter.Split('_');
            //for (int i = 0; i < data.Count(); i++)
            //{ }
            if (data.Count() == 1)
            {
                markets = data[0].ToString();
            }
            else if (data.Count() == 2)
            {
                markets = data[0].ToString();
                chemicalGroups = data[1].ToString();
            }
            else if (data.Count() == 3)
            {
                markets = data[0].ToString();
                chemicalGroups = data[1].ToString();
                name = data[2].ToString();
            }
            else
            {
                markets = data[0].ToString();
                chemicalGroups = data[1].ToString();
                name = data[2].ToString();
            }
            var pf = (from a in db.ProductFinders
                      join b in db.ProductTaxonomySummaries
                      on a.id equals b.item_id
                      where b.markets.StartsWith(markets) && b.markets.EndsWith(markets) || b.chemGroups.StartsWith(chemicalGroups) && b.chemGroups.EndsWith(chemicalGroups) || a.Name == name
                      select new ProductFinderCatalog
                      {
                          Name = a.Name,
                          ChemicalDescription = a.ChemicalDescription,
                          PercentActive = a.PercentActive,
                          FormAt25C = a.FormAt25C,
                          Application = b.applications
                      }).ToList();
            return pf;
        }
    }
}