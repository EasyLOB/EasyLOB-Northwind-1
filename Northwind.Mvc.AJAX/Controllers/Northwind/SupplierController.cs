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
    public class SupplierController : BaseControllerSCRUDApplication<SupplierDTO, Supplier>
    {
        #region Methods

        public SupplierController(INorthwindGenericApplicationDTO<SupplierDTO, Supplier> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: Supplier
        // GET: Supplier/Index
        [HttpGet]
        public ActionResult Index()
        {
            ClearUrlDictionary();

            SupplierCollectionModel supplierCollectionModel = new SupplierCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index"
            };

            try
            {
                IsSearch(supplierCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                supplierCollectionModel.OperationResult.ParseException(exception);
            }

            return View(supplierCollectionModel);
        }        

        // GET & POST: Supplier/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null)
        {
            WriteUrlDictionary(masterUrl);

            SupplierCollectionModel supplierCollectionModel = new SupplierCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction
            };

            try
            {
                IsSearch(supplierCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                supplierCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView("_SupplierCollection", supplierCollectionModel);
        }

        // GET & POST: Supplier/Lookup
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

            return PartialView("_SupplierLookup", lookupModel);
        }

        // GET: Supplier/Create
        [HttpGet]
        public ActionResult Create()
        {
            SupplierItemModel supplierItemModel = new SupplierItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Supplier = new SupplierViewModel(),
                ControllerAction = "Create"
            };

            try
            {
                IsCreate(supplierItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                supplierItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(supplierItemModel);
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierItemModel supplierItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(supplierItemModel.OperationResult, (SupplierDTO)supplierItemModel.Supplier.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                supplierItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(supplierItemModel.OperationResult);
        }

        // GET: Supplier/Read/1
        [HttpGet]
        public ActionResult Read(int? supplierId)
        {
            SupplierItemModel supplierItemModel = new SupplierItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Supplier = new SupplierViewModel(),
                ControllerAction = "Read"
            };
            
            try
            {
                SupplierDTO supplierDTO = Application.GetById(supplierItemModel.OperationResult, new object[] { supplierId });
                if (supplierDTO != null)
                {
                    supplierItemModel.Supplier = new SupplierViewModel(supplierDTO);
                }
            }
            catch (Exception exception)
            {
                supplierItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(supplierItemModel);
        }

        // GET: Supplier/Update/1
        [HttpGet]
        public ActionResult Update(int? supplierId)
        {
            SupplierItemModel supplierItemModel = new SupplierItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Supplier = new SupplierViewModel(),
                ControllerAction = "Update"
            };
            
            try
            {
                SupplierDTO supplierDTO = Application.GetById(supplierItemModel.OperationResult, new object[] { supplierId });
                if (supplierDTO != null)
                {
                    supplierItemModel.Supplier = new SupplierViewModel(supplierDTO);
                }
            }
            catch (Exception exception)
            {
                supplierItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(supplierItemModel);
        }

        // POST: Supplier/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SupplierItemModel supplierItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(supplierItemModel.OperationResult, (SupplierDTO)supplierItemModel.Supplier.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                supplierItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(supplierItemModel.OperationResult);
        }

        // GET: Supplier/Delete/1
        [HttpGet]
        public ActionResult Delete(int? supplierId)
        {
            SupplierItemModel supplierItemModel = new SupplierItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Supplier = new SupplierViewModel(),
                ControllerAction = "Delete"
            };
            
            try
            {
                SupplierDTO supplierDTO = Application.GetById(supplierItemModel.OperationResult, new object[] { supplierId });
                if (supplierDTO != null)
                {
                    supplierItemModel.Supplier = new SupplierViewModel(supplierDTO);
                }
            }
            catch (Exception exception)
            {
                supplierItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(supplierItemModel);
        }

        // POST: Supplier/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SupplierItemModel supplierItemModel)
        {
            try
            {
                if (Application.Delete(supplierItemModel.OperationResult, (SupplierDTO)supplierItemModel.Supplier.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                supplierItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(supplierItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Supplier/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<SupplierViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Supplier), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<SupplierViewModel, SupplierDTO, Supplier>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Supplier/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, SupplierResources.EntitySingular + ".xlsx");
        }

        // POST: Supplier/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, SupplierResources.EntitySingular + ".pdf");
        }

        // POST: Supplier/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, SupplierResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}