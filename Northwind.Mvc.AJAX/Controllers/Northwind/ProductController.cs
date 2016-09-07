using Newtonsoft.Json;
using Syncfusion.JavaScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using Northwind.Application;
using Northwind.Data;
using Northwind.Data.Resources;
using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Library.Mvc;
using EasyLOB.Library.Syncfusion;

namespace Northwind.Mvc
{
    public class ProductController : BaseControllerSCRUDApplication<ProductDTO, Product>
    {
        #region Methods

        public ProductController(INorthwindGenericApplicationDTO<ProductDTO, Product> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: Product
        // GET: Product/Index
        [HttpGet]
        public ActionResult Index(int? masterCategoryId = null, int? masterSupplierId = null)
        {
            ClearUrlDictionary();

            ProductCollectionModel productCollectionModel = new ProductCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index",
                MasterCategoryId = masterCategoryId, MasterSupplierId = masterSupplierId
            };

            try
            {
                IsSearch(productCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                productCollectionModel.OperationResult.ParseException(exception);
            }

            return View(productCollectionModel);
        }        

        // GET & POST: Product/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null, int? masterCategoryId = null, int? masterSupplierId = null)
        {
            WriteUrlDictionary(masterUrl);

            ProductCollectionModel productCollectionModel = new ProductCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction,
                MasterCategoryId = masterCategoryId, MasterSupplierId = masterSupplierId
            };

            try
            {
                IsSearch(productCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                productCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView("_ProductCollection", productCollectionModel);
        }

        // GET & POST: Product/Lookup
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Lookup(string text, string valueId, List<LookupModelElement> elements = null)
        {
            LookupModel lookupModel = new LookupModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Text = text,
                ValueId = valueId,
                Elements = elements
            };

            try
            {
                IsSearch(lookupModel.OperationResult);
            }
            catch (Exception exception)
            {
                lookupModel.OperationResult.ParseException(exception);
            }

            return PartialView("_ProductLookup", lookupModel);
        }

        // GET: Product/Create
        [HttpGet]
        public ActionResult Create(int? masterCategoryId = null, int? masterSupplierId = null)
        {
            ProductItemModel productItemModel = new ProductItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Product = new ProductViewModel(),
                ControllerAction = "Create",
                MasterCategoryId = masterCategoryId, MasterSupplierId = masterSupplierId
            };

            try
            {
                IsCreate(productItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(productItemModel);
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductItemModel productItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(productItemModel.OperationResult, (ProductDTO)productItemModel.Product.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }

        // GET: Product/Read/1
        [HttpGet]
        public ActionResult Read(int? productId, int? masterCategoryId = null, int? masterSupplierId = null)
        {
            ProductItemModel productItemModel = new ProductItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Product = new ProductViewModel(),
                ControllerAction = "Read",
                MasterCategoryId = masterCategoryId, MasterSupplierId = masterSupplierId
            };
            
            try
            {
                ProductDTO productDTO = Application.GetById(productItemModel.OperationResult, new object[] { productId });
                if (productDTO != null)
                {
                    productItemModel.Product = new ProductViewModel(productDTO);
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(productItemModel);
        }

        // GET: Product/Update/1
        [HttpGet]
        public ActionResult Update(int? productId, int? masterCategoryId = null, int? masterSupplierId = null)
        {
            ProductItemModel productItemModel = new ProductItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Product = new ProductViewModel(),
                ControllerAction = "Update",
                MasterCategoryId = masterCategoryId, MasterSupplierId = masterSupplierId
            };
            
            try
            {
                ProductDTO productDTO = Application.GetById(productItemModel.OperationResult, new object[] { productId });
                if (productDTO != null)
                {
                    productItemModel.Product = new ProductViewModel(productDTO);
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(productItemModel);
        }

        // POST: Product/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductItemModel productItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(productItemModel.OperationResult, (ProductDTO)productItemModel.Product.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }

        // GET: Product/Delete/1
        [HttpGet]
        public ActionResult Delete(int? productId, int? masterCategoryId = null, int? masterSupplierId = null)
        {
            ProductItemModel productItemModel = new ProductItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Product = new ProductViewModel(),
                ControllerAction = "Delete",
                MasterCategoryId = masterCategoryId, MasterSupplierId = masterSupplierId
            };
            
            try
            {
                ProductDTO productDTO = Application.GetById(productItemModel.OperationResult, new object[] { productId });
                if (productDTO != null)
                {
                    productItemModel.Product = new ProductViewModel(productDTO);
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(productItemModel);
        }

        // POST: Product/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductItemModel productItemModel)
        {
            try
            {
                if (Application.Delete(productItemModel.OperationResult, (ProductDTO)productItemModel.Product.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                productItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(productItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Product/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<ProductViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Product), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<ProductViewModel, ProductDTO, Product>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
                    if (dataManager.RequiresCounts)
                    {
                        countAll = Application.Count(where, args.ToArray());
                    }
                }
                catch (Exception exception)
                {
                    operationResult.ParseException(exception);
                }

                if (!operationResult.Ok)
                {
                    throw new InvalidOperationException(operationResult.Text);
                }
            }

            return Json(JsonConvert.SerializeObject(new { result = data, count = countAll }), JsonRequestBehavior.AllowGet);
        } 

        // POST: Product/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, ProductResources.EntitySingular + ".xlsx");
        }

        // POST: Product/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, ProductResources.EntitySingular + ".pdf");
        }

        // POST: Product/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, ProductResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}