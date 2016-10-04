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
    public class CategoryController : BaseControllerSCRUDApplication<CategoryDTO, Category>
    {
        #region Methods

        public CategoryController(INorthwindGenericApplicationDTO<CategoryDTO, Category> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: Category
        // GET: Category/Index
        [HttpGet]
        public ActionResult Index()
        {
            ClearUrlDictionary();

            CategoryCollectionModel categoryCollectionModel = new CategoryCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index"
            };

            try
            {
                IsSearch(categoryCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                categoryCollectionModel.OperationResult.ParseException(exception);
            }

            return View(categoryCollectionModel);
        }        

        // GET & POST: Category/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null)
        {
            WriteUrlDictionary(masterUrl);

            CategoryCollectionModel categoryCollectionModel = new CategoryCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction
            };

            try
            {
                IsSearch(categoryCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                categoryCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView(categoryCollectionModel);
        }

        // GET & POST: Category/Lookup
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

            return PartialView("_CategoryLookup", lookupModel);
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            CategoryItemModel categoryItemModel = new CategoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Category = new CategoryViewModel(),
                ControllerAction = "Create"
            };

            try
            {
                IsCreate(categoryItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(categoryItemModel);
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryItemModel categoryItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(categoryItemModel.OperationResult, (CategoryDTO)categoryItemModel.Category.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }

        // GET: Category/Read/1
        [HttpGet]
        public ActionResult Read(int? categoryId)
        {
            CategoryItemModel categoryItemModel = new CategoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Category = new CategoryViewModel(),
                ControllerAction = "Read"
            };
            
            try
            {
                CategoryDTO categoryDTO = Application.GetById(categoryItemModel.OperationResult, new object[] { categoryId });
                if (categoryDTO != null)
                {
                    categoryItemModel.Category = new CategoryViewModel(categoryDTO);
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(categoryItemModel);
        }

        // GET: Category/Update/1
        [HttpGet]
        public ActionResult Update(int? categoryId)
        {
            CategoryItemModel categoryItemModel = new CategoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Category = new CategoryViewModel(),
                ControllerAction = "Update"
            };
            
            try
            {
                CategoryDTO categoryDTO = Application.GetById(categoryItemModel.OperationResult, new object[] { categoryId });
                if (categoryDTO != null)
                {
                    categoryItemModel.Category = new CategoryViewModel(categoryDTO);
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(categoryItemModel);
        }

        // POST: Category/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CategoryItemModel categoryItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(categoryItemModel.OperationResult, (CategoryDTO)categoryItemModel.Category.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }

        // GET: Category/Delete/1
        [HttpGet]
        public ActionResult Delete(int? categoryId)
        {
            CategoryItemModel categoryItemModel = new CategoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Category = new CategoryViewModel(),
                ControllerAction = "Delete"
            };
            
            try
            {
                CategoryDTO categoryDTO = Application.GetById(categoryItemModel.OperationResult, new object[] { categoryId });
                if (categoryDTO != null)
                {
                    categoryItemModel.Category = new CategoryViewModel(categoryDTO);
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(categoryItemModel);
        }

        // POST: Category/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoryItemModel categoryItemModel)
        {
            try
            {
                if (Application.Delete(categoryItemModel.OperationResult, (CategoryDTO)categoryItemModel.Category.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                categoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(categoryItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Category/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<CategoryViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Category), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<CategoryViewModel, CategoryDTO, Category>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Category/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, CategoryResources.EntitySingular + ".xlsx");
        }

        // POST: Category/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, CategoryResources.EntitySingular + ".pdf");
        }

        // POST: Category/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, CategoryResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}