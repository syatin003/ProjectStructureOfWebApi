using Stepan.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;
using Stepan.Common.Services;

namespace service.Api.Controllers
{
    [RoutePrefix("api/stepan")]
    public class stepanController : ApiController
    {
        readonly IProductService service;
        public stepanController(IProductService service)
        {
            this.service = service;
        }
        /// <summary>
        /// Get all Products according to all Categories.
        /// </summary>    
        [HttpGet]
        [Route("GetAllCategories")]
        public IHttpActionResult GetAllCategories()
        {
            try
            {
                var data = service.GetAllCategories();
                return Ok(data);
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }

        /// <summary>
        /// Get all Products according to parameter(category).
        /// </summary>
        /// <param name="category">The CategoryName of the Product.</param>
        [HttpGet]
        [Route("GetCategory")]
        public IHttpActionResult GetCategory(string category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException("Please specify atleast one parameter");
                }
                else
                {
                    var data = service.GetCategory(category);
                    int check = data.Count();
                    if (check == 0)
                    {
                        throw new System.ArgumentException("Product Not Found in Database according to Category Name");
                    }
                    return Ok(data);
                }
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }
        /// <summary>
        /// Get all Products according to all Brands.
        /// </summary>
        [HttpGet]
        [Route("GetAllBrandNames")]
        public IHttpActionResult GetAllBrandNames()
        {
            try
            {
                var data = service.GetAllBrandNames();
                return Ok(data);
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }
        /// <summary>
        /// Get all Products according to parameter(brand).
        /// </summary>
        /// <param name="brand">The BrandName of the Product.</param>
        [HttpGet]
        [Route("GetBrandName")]
        public IHttpActionResult GetBrandName(string brand)
        {
            try
            {
                if (brand == null)
                {
                    throw new ArgumentNullException("Please specify atleast one parameter");
                }
                else
                {
                    var data = service.GetBrandName(brand);
                    int check = data.Count();
                    if (check == 0)
                    {
                        throw new System.ArgumentException("Product Not Found in Database according to Brand Name");
                    }
                    return Ok(data);
                }
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }

        }

        /// <summary>
        /// Get all Products according to all ChemicalGroups.
        /// </summary>
        [HttpGet]
        [Route("GetAllChemicalGroups")]
        public IHttpActionResult GetAllChemicalGroups()
        {
            try
            {
                var data = service.GetAllChemicalGroups();
                return Ok(data);
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }
        /// <summary>
        /// Get all Products according to parameter(ChemicalGroup).
        /// </summary>
        /// <param name="chemGroup">The ChemicalGroup of the Product.</param>
        [HttpGet]
        [Route("GetChemicalGroup")]
        public IHttpActionResult GetChemicalGroup(string chemGroup)
        {
            try
            {
                if (chemGroup == null)
                {
                    throw new ArgumentNullException("Please specify atleast one parameter");
                }
                else
                {
                    var data = service.GetChemicalGroup(chemGroup);
                    int check = data.Count();
                    if (check == 0)
                    {
                        throw new System.ArgumentException("Product Not Found in Database according to Chemical Description");
                    }
                    return Ok(data);
                }
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }
        /// <summary>
        /// Get all Products according to all ChemicalName.
        /// </summary>
        [HttpGet]
        [Route("GetAllChemicalNames")]
        public IHttpActionResult GetAllChemicalNames()
        {
            try
            {
                var data = service.GetAllChemicalNames();
                return Ok(data);
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }
        /// <summary>
        /// Get all Products according to parameter(ChemicalName).
        /// </summary>
        /// <param name="name">The ChemicalName of the Product.</param>
        [HttpGet]
        [Route("GetChemicalName")]
        public IHttpActionResult GetChemicalName(string name)
        {
            try
            {
                if (name == null)
                {
                    throw new ArgumentNullException("Please specify atleast one parameter");
                }
                else
                {
                    var data = service.GetChemicalName(name);
                    int check = data.Count();
                    if (check == 0)
                    {
                        throw new System.ArgumentException("Product Not Found in Database according to Chemical Name ");
                    }
                    return Ok(data);
                }
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }

        }
        /// <summary>
        /// Get all Products according to parameter(Search Parameter).
        /// </summary>
        /// <param name="query">The SearchParameter(ProductName,BrandName,CategoryName,ChemicalDescription) of the Product.</param>
        [HttpGet]
        [Route("GetSearchResult")]
        public IHttpActionResult GetSearchResult(string query)
        {
            try
            {
                if (query == null)
                {
                    throw new ArgumentNullException("Please specify atleast one parameter");
                }
                else
                {
                    //join b in db.ProductFinderLinks on
                    //a.id equals b.ProductID
                    var data = service.GetSearchResult(query);
                    int check = data.Count();
                    if (check == 0)
                    {
                        throw new System.ArgumentException("Product Not Found in Database according to search parameter");
                    }
                    return Ok(data);
                }
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }
        /// <summary>
        /// Get all Brands according to parameter(category).
        /// </summary>
        /// <param name="category">The Category of the Product.</param>
        [HttpGet]
        [Route("GetSubCategoryOfCategory")]
        public IHttpActionResult GetSubCategoryOfCategory(string category)
        {
            try
            {
                if (category == null)
                {
                    throw new ArgumentNullException("Please specify atleast one parameter");
                }
                else
                {
                    var data = service.GetSubCategoryOfCategory(category);
                    int check = data.Count();
                    if (check == 0)
                    {
                        throw new System.ArgumentException("Product Not Found in Database according to Category Name ");
                    }
                    return Ok(data);
                }
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }
        /// <summary>
        /// Get all Description of Products according to parameter(brand).
        /// </summary>
        /// <param name="brand">The BrandName of the Product.</param>
        [HttpGet]
        [Route("GetDescriptionOfSubCategory")]
        public IHttpActionResult GetDescriptionOfSubCategory(string brand)
        {
            try
            {
                if (brand == null)
                {
                    throw new ArgumentNullException("Please specify atleast one parameter");
                }
                else
                {
                    var data = service.GetDescriptionOfSubCategory(brand);
                    int check = data.Count();
                    if (check == 0)
                    {
                        throw new System.ArgumentException("Product Not Found in Database according to Brand Name");
                    }

                    return Ok(data);
                }
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }
        /// <summary>
        /// Get all Information of Products according to HashTags(parameter).
        /// </summary>
        /// <param name="parameter">The HashTags of the Product.</param>
        [HttpGet]
        [Route("GetData")]
        public IHttpActionResult GetData(string parameter)
        {
            try
            {
                if (parameter == null)
                {
                    throw new ArgumentNullException("Please specify atleast one parameter");
                }
                else
                {
                    var data = service.GetData(parameter);
                    int check = data.Count();
                    if (check == 0)
                    {
                        throw new System.ArgumentException("Product Not Found in Database according to Category Name ");
                    }
                    return Ok(data);
                }
            }
            catch (Exception exp)
            {
                ExceptionLogging.SendExcepToDB(exp);
                return BadRequest(exp.Message);
            }
        }




        //[RoutePrefix("api/stepan")]
        //public class stepanController : ApiController
        //{
        //    ProductRepository pr = new ProductRepository();
        //    /// <summary>
        //    /// Get all Products according to all Categories.
        //    /// </summary>    
        //    [HttpGet]
        //    [Route("GetAllCategories")]
        //    public IHttpActionResult GetAllCategories()
        //    {
        //        try
        //        {
        //            var data = service.GetAllCategories();
        //            return Ok(data);
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Products according to parameter(category).
        //    /// </summary>
        //    /// <param name="category">The CategoryName of the Product.</param>
        //    [HttpGet]
        //    [Route("GetCategory")]
        //    public IHttpActionResult GetCategory(string category)
        //    {
        //        try
        //        {
        //            if (category == null)
        //            {
        //                throw new ArgumentNullException("Please specify atleast one parameter");
        //            }
        //            else
        //            {
        //                var data = service.GetCategory(category);
        //                int check = data.Count();
        //                if (check == 0)
        //                {
        //                    throw new System.ArgumentException("Product Not Found in Database according to Category Name");
        //                }
        //                return Ok(data);
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Products according to all Brands.
        //    /// </summary>
        //    [HttpGet]
        //    [Route("GetAllBrandNames")]
        //    public IHttpActionResult GetAllBrandNames()
        //    {
        //        try
        //        {
        //            var data = service.GetAllBrandNames();
        //            return Ok(data);
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Products according to parameter(brand).
        //    /// </summary>
        //    /// <param name="brand">The BrandName of the Product.</param>
        //    [HttpGet]
        //    [Route("GetBrandName")]
        //    public IHttpActionResult GetBrandName(string brand)
        //    {
        //        try
        //        {
        //            if (brand == null)
        //            {
        //                throw new ArgumentNullException("Please specify atleast one parameter");
        //            }
        //            else
        //            {
        //                var data = service.GetBrandName(brand);
        //                int check = data.Count();
        //                if (check == 0)
        //                {
        //                    throw new System.ArgumentException("Product Not Found in Database according to Brand Name");
        //                }
        //                return Ok(data);
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }

        //    }

        //    /// <summary>
        //    /// Get all Products according to all ChemicalGroups.
        //    /// </summary>
        //    [HttpGet]
        //    [Route("GetAllChemicalGroups")]
        //    public IHttpActionResult GetAllChemicalGroups()
        //    {
        //        try
        //        {
        //            var data = service.GetAllChemicalGroups();
        //            return Ok(data);
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Products according to parameter(ChemicalGroup).
        //    /// </summary>
        //    /// <param name="chemGroup">The ChemicalGroup of the Product.</param>
        //    [HttpGet]
        //    [Route("GetChemicalGroup")]
        //    public IHttpActionResult GetChemicalGroup(string chemGroup)
        //    {
        //        try
        //        {
        //            if (chemGroup == null)
        //            {
        //                throw new ArgumentNullException("Please specify atleast one parameter");
        //            }
        //            else
        //            {
        //                var data = service.GetChemicalGroup(chemGroup);
        //                int check = data.Count();
        //                if (check == 0)
        //                {
        //                    throw new System.ArgumentException("Product Not Found in Database according to Chemical Description");
        //                }
        //                return Ok(data);
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Products according to all ChemicalName.
        //    /// </summary>
        //    [HttpGet]
        //    [Route("GetAllChemicalNames")]
        //    public IHttpActionResult GetAllChemicalNames()
        //    {
        //        try
        //        {
        //            var data = service.GetAllChemicalNames();
        //            return Ok(data);
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Products according to parameter(ChemicalName).
        //    /// </summary>
        //    /// <param name="name">The ChemicalName of the Product.</param>
        //    [HttpGet]
        //    [Route("GetChemicalName")]
        //    public IHttpActionResult GetChemicalName(string name)
        //    {
        //        try
        //        {
        //            if (name == null)
        //            {
        //                throw new ArgumentNullException("Please specify atleast one parameter");
        //            }
        //            else
        //            {
        //                var data = service.GetChemicalName(name);
        //                int check = data.Count();
        //                if (check == 0)
        //                {
        //                    throw new System.ArgumentException("Product Not Found in Database according to Chemical Name ");
        //                }
        //                return Ok(data);
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }

        //    }
        //    /// <summary>
        //    /// Get all Products according to parameter(Search Parameter).
        //    /// </summary>
        //    /// <param name="query">The SearchParameter(ProductName,BrandName,CategoryName,ChemicalDescription) of the Product.</param>
        //    [HttpGet]
        //    [Route("GetSearchResult")]
        //    public IHttpActionResult GetSearchResult(string query)
        //    {
        //        try
        //        {
        //            if (query == null)
        //            {
        //                throw new ArgumentNullException("Please specify atleast one parameter");
        //            }
        //            else
        //            {
        //                //join b in db.ProductFinderLinks on
        //                //a.id equals b.ProductID
        //                var data = service.GetSearchResult(query);
        //                int check = data.Count();
        //                if (check == 0)
        //                {
        //                    throw new System.ArgumentException("Product Not Found in Database according to search parameter");
        //                }
        //                return Ok(data);
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Brands according to parameter(category).
        //    /// </summary>
        //    /// <param name="category">The Category of the Product.</param>
        //    [HttpGet]
        //    [Route("GetSubCategoryOfCategory")]
        //    public IHttpActionResult GetSubCategoryOfCategory(string category)
        //    {
        //        try
        //        {
        //            if (category == null)
        //            {
        //                throw new ArgumentNullException("Please specify atleast one parameter");
        //            }
        //            else
        //            {
        //                var data = service.GetSubCategoryOfCategory(category);
        //                int check = data.Count();
        //                if (check == 0)
        //                {
        //                    throw new System.ArgumentException("Product Not Found in Database according to Category Name ");
        //                }
        //                return Ok(data);
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Description of Products according to parameter(brand).
        //    /// </summary>
        //    /// <param name="brand">The BrandName of the Product.</param>
        //    [HttpGet]
        //    [Route("GetDescriptionOfSubCategory")]
        //    public IHttpActionResult GetDescriptionOfSubCategory(string brand)
        //    {
        //        try
        //        {
        //            if (brand == null)
        //            {
        //                throw new ArgumentNullException("Please specify atleast one parameter");
        //            }
        //            else
        //            {
        //                var data = service.GetDescriptionOfSubCategory(brand);
        //                int check = data.Count();
        //                if (check == 0)
        //                {
        //                    throw new System.ArgumentException("Product Not Found in Database according to Brand Name");
        //                }

        //                return Ok(data);
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //    /// <summary>
        //    /// Get all Information of Products according to HashTags(parameter).
        //    /// </summary>
        //    /// <param name="parameter">The HashTags of the Product.</param>
        //    [HttpGet]
        //    [Route("GetData")]
        //    public IHttpActionResult GetData(string parameter)
        //    {
        //        try
        //        {
        //            if (parameter == null)
        //            {
        //                throw new ArgumentNullException("Please specify atleast one parameter");
        //            }
        //            else
        //            {
        //                var data = service.GetData(parameter);
        //                int check = data.Count();
        //                if (check == 0)
        //                {
        //                    throw new System.ArgumentException("Product Not Found in Database according to Category Name ");
        //                }
        //                return Ok(data);
        //            }
        //        }
        //        catch (Exception exp)
        //        {
        //            ExceptionLogging.SendExcepToDB(exp);
        //            return BadRequest(exp.Message);
        //        }
        //    }
        //}
    }
}
