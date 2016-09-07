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
    public class CustomerDemographicController : BaseControllerSCRUDApplication<CustomerDemographicDTO, CustomerDemographic>
    {
        #region Methods

        public CustomerDemographicController(INorthwindGenericApplicationDTO<CustomerDemographicDTO, CustomerDemographic> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: CustomerDemographic
        // GET: CustomerDemographic/Index
        [HttpGet]
        public ActionResult Index()
        {
            ClearUrlDictionary();

            CustomerDemographicCollectionModel customerDemographicCollectionModel = new CustomerDemographicCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index"
            };

            try
            {
                IsSearch(customerDemographicCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                customerDemographicCollectionModel.OperationResult.ParseException(exception);
            }

            return View(customerDemographicCollectionModel);
        }        

        // GET & POST: CustomerDemographic/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null)
        {
            WriteUrlDictionary(masterUrl);

            CustomerDemographicCollectionModel customerDemographicCollectionModel = new CustomerDemographicCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction
            };

            try
            {
                IsSearch(customerDemographicCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                customerDemographicCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView("_CustomerDemographicCollection", customerDemographicCollectionModel);
        }

        // GET & POST: CustomerDemographic/Lookup
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

            return PartialView("_CustomerDemographicLookup", lookupModel);
        }

        // GET: CustomerDemographic/Create
        [HttpGet]
        public ActionResult Create()
        {
            CustomerDemographicItemModel customerDemographicItemModel = new CustomerDemographicItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                CustomerDemographic = new CustomerDemographicViewModel(),
                ControllerAction = "Create"
            };

            try
            {
                IsCreate(customerDemographicItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(customerDemographicItemModel);
        }

        // POST: CustomerDemographic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDemographicItemModel customerDemographicItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(customerDemographicItemModel.OperationResult, (CustomerDemographicDTO)customerDemographicItemModel.CustomerDemographic.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }

        // GET: CustomerDemographic/Read/1
        [HttpGet]
        public ActionResult Read(string customerTypeId)
        {
            CustomerDemographicItemModel customerDemographicItemModel = new CustomerDemographicItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                CustomerDemographic = new CustomerDemographicViewModel(),
                ControllerAction = "Read"
            };
            
            try
            {
                CustomerDemographicDTO customerDemographicDTO = Application.GetById(customerDemographicItemModel.OperationResult, new object[] { customerTypeId });
                if (customerDemographicDTO != null)
                {
                    customerDemographicItemModel.CustomerDemographic = new CustomerDemographicViewModel(customerDemographicDTO);
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(customerDemographicItemModel);
        }

        // GET: CustomerDemographic/Update/1
        [HttpGet]
        public ActionResult Update(string customerTypeId)
        {
            CustomerDemographicItemModel customerDemographicItemModel = new CustomerDemographicItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                CustomerDemographic = new CustomerDemographicViewModel(),
                ControllerAction = "Update"
            };
            
            try
            {
                CustomerDemographicDTO customerDemographicDTO = Application.GetById(customerDemographicItemModel.OperationResult, new object[] { customerTypeId });
                if (customerDemographicDTO != null)
                {
                    customerDemographicItemModel.CustomerDemographic = new CustomerDemographicViewModel(customerDemographicDTO);
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(customerDemographicItemModel);
        }

        // POST: CustomerDemographic/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CustomerDemographicItemModel customerDemographicItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(customerDemographicItemModel.OperationResult, (CustomerDemographicDTO)customerDemographicItemModel.CustomerDemographic.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }

        // GET: CustomerDemographic/Delete/1
        [HttpGet]
        public ActionResult Delete(string customerTypeId)
        {
            CustomerDemographicItemModel customerDemographicItemModel = new CustomerDemographicItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                CustomerDemographic = new CustomerDemographicViewModel(),
                ControllerAction = "Delete"
            };
            
            try
            {
                CustomerDemographicDTO customerDemographicDTO = Application.GetById(customerDemographicItemModel.OperationResult, new object[] { customerTypeId });
                if (customerDemographicDTO != null)
                {
                    customerDemographicItemModel.CustomerDemographic = new CustomerDemographicViewModel(customerDemographicDTO);
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(customerDemographicItemModel);
        }

        // POST: CustomerDemographic/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerDemographicItemModel customerDemographicItemModel)
        {
            try
            {
                if (Application.Delete(customerDemographicItemModel.OperationResult, (CustomerDemographicDTO)customerDemographicItemModel.CustomerDemographic.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                customerDemographicItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerDemographicItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: CustomerDemographic/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<CustomerDemographicViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(CustomerDemographic), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<CustomerDemographicViewModel, CustomerDemographicDTO, CustomerDemographic>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: CustomerDemographic/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, CustomerDemographicResources.EntitySingular + ".xlsx");
        }

        // POST: CustomerDemographic/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, CustomerDemographicResources.EntitySingular + ".pdf");
        }

        // POST: CustomerDemographic/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, CustomerDemographicResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}