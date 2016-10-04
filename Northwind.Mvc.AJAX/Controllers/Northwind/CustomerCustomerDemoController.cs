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
    public class CustomerCustomerDemoController : BaseControllerSCRUDApplication<CustomerCustomerDemoDTO, CustomerCustomerDemo>
    {
        #region Methods

        public CustomerCustomerDemoController(INorthwindGenericApplicationDTO<CustomerCustomerDemoDTO, CustomerCustomerDemo> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: CustomerCustomerDemo
        // GET: CustomerCustomerDemo/Index
        [HttpGet]
        public ActionResult Index(string masterCustomerTypeId = null, string masterCustomerId = null)
        {
            ClearUrlDictionary();

            CustomerCustomerDemoCollectionModel customerCustomerDemoCollectionModel = new CustomerCustomerDemoCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index",
                MasterCustomerTypeId = masterCustomerTypeId, MasterCustomerId = masterCustomerId
            };

            try
            {
                IsSearch(customerCustomerDemoCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                customerCustomerDemoCollectionModel.OperationResult.ParseException(exception);
            }

            return View(customerCustomerDemoCollectionModel);
        }        

        // GET & POST: CustomerCustomerDemo/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null, string masterCustomerTypeId = null, string masterCustomerId = null)
        {
            WriteUrlDictionary(masterUrl);

            CustomerCustomerDemoCollectionModel customerCustomerDemoCollectionModel = new CustomerCustomerDemoCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction,
                MasterCustomerTypeId = masterCustomerTypeId, MasterCustomerId = masterCustomerId
            };

            try
            {
                IsSearch(customerCustomerDemoCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                customerCustomerDemoCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView(customerCustomerDemoCollectionModel);
        }

        // GET & POST: CustomerCustomerDemo/Lookup
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

            return PartialView("_CustomerCustomerDemoLookup", lookupModel);
        }

        // GET: CustomerCustomerDemo/Create
        [HttpGet]
        public ActionResult Create(string masterCustomerTypeId = null, string masterCustomerId = null)
        {
            CustomerCustomerDemoItemModel customerCustomerDemoItemModel = new CustomerCustomerDemoItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                CustomerCustomerDemo = new CustomerCustomerDemoViewModel(),
                ControllerAction = "Create",
                MasterCustomerTypeId = masterCustomerTypeId, MasterCustomerId = masterCustomerId
            };

            try
            {
                IsCreate(customerCustomerDemoItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(customerCustomerDemoItemModel);
        }

        // POST: CustomerCustomerDemo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCustomerDemoItemModel customerCustomerDemoItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(customerCustomerDemoItemModel.OperationResult, (CustomerCustomerDemoDTO)customerCustomerDemoItemModel.CustomerCustomerDemo.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }

        // GET: CustomerCustomerDemo/Read/1
        [HttpGet]
        public ActionResult Read(string customerId, string customerTypeId, string masterCustomerTypeId = null, string masterCustomerId = null)
        {
            CustomerCustomerDemoItemModel customerCustomerDemoItemModel = new CustomerCustomerDemoItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                CustomerCustomerDemo = new CustomerCustomerDemoViewModel(),
                ControllerAction = "Read",
                MasterCustomerTypeId = masterCustomerTypeId, MasterCustomerId = masterCustomerId
            };
            
            try
            {
                CustomerCustomerDemoDTO customerCustomerDemoDTO = Application.GetById(customerCustomerDemoItemModel.OperationResult, new object[] { customerId, customerTypeId });
                if (customerCustomerDemoDTO != null)
                {
                    customerCustomerDemoItemModel.CustomerCustomerDemo = new CustomerCustomerDemoViewModel(customerCustomerDemoDTO);
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(customerCustomerDemoItemModel);
        }

        // GET: CustomerCustomerDemo/Update/1
        [HttpGet]
        public ActionResult Update(string customerId, string customerTypeId, string masterCustomerTypeId = null, string masterCustomerId = null)
        {
            CustomerCustomerDemoItemModel customerCustomerDemoItemModel = new CustomerCustomerDemoItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                CustomerCustomerDemo = new CustomerCustomerDemoViewModel(),
                ControllerAction = "Update",
                MasterCustomerTypeId = masterCustomerTypeId, MasterCustomerId = masterCustomerId
            };
            
            try
            {
                CustomerCustomerDemoDTO customerCustomerDemoDTO = Application.GetById(customerCustomerDemoItemModel.OperationResult, new object[] { customerId, customerTypeId });
                if (customerCustomerDemoDTO != null)
                {
                    customerCustomerDemoItemModel.CustomerCustomerDemo = new CustomerCustomerDemoViewModel(customerCustomerDemoDTO);
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(customerCustomerDemoItemModel);
        }

        // POST: CustomerCustomerDemo/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CustomerCustomerDemoItemModel customerCustomerDemoItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(customerCustomerDemoItemModel.OperationResult, (CustomerCustomerDemoDTO)customerCustomerDemoItemModel.CustomerCustomerDemo.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }

        // GET: CustomerCustomerDemo/Delete/1
        [HttpGet]
        public ActionResult Delete(string customerId, string customerTypeId, string masterCustomerTypeId = null, string masterCustomerId = null)
        {
            CustomerCustomerDemoItemModel customerCustomerDemoItemModel = new CustomerCustomerDemoItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                CustomerCustomerDemo = new CustomerCustomerDemoViewModel(),
                ControllerAction = "Delete",
                MasterCustomerTypeId = masterCustomerTypeId, MasterCustomerId = masterCustomerId
            };
            
            try
            {
                CustomerCustomerDemoDTO customerCustomerDemoDTO = Application.GetById(customerCustomerDemoItemModel.OperationResult, new object[] { customerId, customerTypeId });
                if (customerCustomerDemoDTO != null)
                {
                    customerCustomerDemoItemModel.CustomerCustomerDemo = new CustomerCustomerDemoViewModel(customerCustomerDemoDTO);
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(customerCustomerDemoItemModel);
        }

        // POST: CustomerCustomerDemo/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerCustomerDemoItemModel customerCustomerDemoItemModel)
        {
            try
            {
                if (Application.Delete(customerCustomerDemoItemModel.OperationResult, (CustomerCustomerDemoDTO)customerCustomerDemoItemModel.CustomerCustomerDemo.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                customerCustomerDemoItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(customerCustomerDemoItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: CustomerCustomerDemo/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<CustomerCustomerDemoViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(CustomerCustomerDemo), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<CustomerCustomerDemoViewModel, CustomerCustomerDemoDTO, CustomerCustomerDemo>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: CustomerCustomerDemo/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, CustomerCustomerDemoResources.EntitySingular + ".xlsx");
        }

        // POST: CustomerCustomerDemo/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, CustomerCustomerDemoResources.EntitySingular + ".pdf");
        }

        // POST: CustomerCustomerDemo/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, CustomerCustomerDemoResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}