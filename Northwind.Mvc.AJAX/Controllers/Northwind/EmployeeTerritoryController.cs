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
    public class EmployeeTerritoryController : BaseControllerSCRUDApplication<EmployeeTerritoryDTO, EmployeeTerritory>
    {
        #region Methods

        public EmployeeTerritoryController(INorthwindGenericApplicationDTO<EmployeeTerritoryDTO, EmployeeTerritory> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: EmployeeTerritory
        // GET: EmployeeTerritory/Index
        [HttpGet]
        public ActionResult Index(int? masterEmployeeId = null, string masterTerritoryId = null)
        {
            ClearUrlDictionary();

            EmployeeTerritoryCollectionModel employeeTerritoryCollectionModel = new EmployeeTerritoryCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index",
                MasterEmployeeId = masterEmployeeId, MasterTerritoryId = masterTerritoryId
            };

            try
            {
                IsSearch(employeeTerritoryCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                employeeTerritoryCollectionModel.OperationResult.ParseException(exception);
            }

            return View(employeeTerritoryCollectionModel);
        }        

        // GET & POST: EmployeeTerritory/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null, int? masterEmployeeId = null, string masterTerritoryId = null)
        {
            WriteUrlDictionary(masterUrl);

            EmployeeTerritoryCollectionModel employeeTerritoryCollectionModel = new EmployeeTerritoryCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction,
                MasterEmployeeId = masterEmployeeId, MasterTerritoryId = masterTerritoryId
            };

            try
            {
                IsSearch(employeeTerritoryCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                employeeTerritoryCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView("_EmployeeTerritoryCollection", employeeTerritoryCollectionModel);
        }

        // GET & POST: EmployeeTerritory/Lookup
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

            return PartialView("_EmployeeTerritoryLookup", lookupModel);
        }

        // GET: EmployeeTerritory/Create
        [HttpGet]
        public ActionResult Create(int? masterEmployeeId = null, string masterTerritoryId = null)
        {
            EmployeeTerritoryItemModel employeeTerritoryItemModel = new EmployeeTerritoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                EmployeeTerritory = new EmployeeTerritoryViewModel(),
                ControllerAction = "Create",
                MasterEmployeeId = masterEmployeeId, MasterTerritoryId = masterTerritoryId
            };

            try
            {
                IsCreate(employeeTerritoryItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(employeeTerritoryItemModel);
        }

        // POST: EmployeeTerritory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeTerritoryItemModel employeeTerritoryItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(employeeTerritoryItemModel.OperationResult, (EmployeeTerritoryDTO)employeeTerritoryItemModel.EmployeeTerritory.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }

        // GET: EmployeeTerritory/Read/1
        [HttpGet]
        public ActionResult Read(int? employeeId, string territoryId, int? masterEmployeeId = null, string masterTerritoryId = null)
        {
            EmployeeTerritoryItemModel employeeTerritoryItemModel = new EmployeeTerritoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                EmployeeTerritory = new EmployeeTerritoryViewModel(),
                ControllerAction = "Read",
                MasterEmployeeId = masterEmployeeId, MasterTerritoryId = masterTerritoryId
            };
            
            try
            {
                EmployeeTerritoryDTO employeeTerritoryDTO = Application.GetById(employeeTerritoryItemModel.OperationResult, new object[] { employeeId, territoryId });
                if (employeeTerritoryDTO != null)
                {
                    employeeTerritoryItemModel.EmployeeTerritory = new EmployeeTerritoryViewModel(employeeTerritoryDTO);
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(employeeTerritoryItemModel);
        }

        // GET: EmployeeTerritory/Update/1
        [HttpGet]
        public ActionResult Update(int? employeeId, string territoryId, int? masterEmployeeId = null, string masterTerritoryId = null)
        {
            EmployeeTerritoryItemModel employeeTerritoryItemModel = new EmployeeTerritoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                EmployeeTerritory = new EmployeeTerritoryViewModel(),
                ControllerAction = "Update",
                MasterEmployeeId = masterEmployeeId, MasterTerritoryId = masterTerritoryId
            };
            
            try
            {
                EmployeeTerritoryDTO employeeTerritoryDTO = Application.GetById(employeeTerritoryItemModel.OperationResult, new object[] { employeeId, territoryId });
                if (employeeTerritoryDTO != null)
                {
                    employeeTerritoryItemModel.EmployeeTerritory = new EmployeeTerritoryViewModel(employeeTerritoryDTO);
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(employeeTerritoryItemModel);
        }

        // POST: EmployeeTerritory/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EmployeeTerritoryItemModel employeeTerritoryItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(employeeTerritoryItemModel.OperationResult, (EmployeeTerritoryDTO)employeeTerritoryItemModel.EmployeeTerritory.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }

        // GET: EmployeeTerritory/Delete/1
        [HttpGet]
        public ActionResult Delete(int? employeeId, string territoryId, int? masterEmployeeId = null, string masterTerritoryId = null)
        {
            EmployeeTerritoryItemModel employeeTerritoryItemModel = new EmployeeTerritoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                EmployeeTerritory = new EmployeeTerritoryViewModel(),
                ControllerAction = "Delete",
                MasterEmployeeId = masterEmployeeId, MasterTerritoryId = masterTerritoryId
            };
            
            try
            {
                EmployeeTerritoryDTO employeeTerritoryDTO = Application.GetById(employeeTerritoryItemModel.OperationResult, new object[] { employeeId, territoryId });
                if (employeeTerritoryDTO != null)
                {
                    employeeTerritoryItemModel.EmployeeTerritory = new EmployeeTerritoryViewModel(employeeTerritoryDTO);
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(employeeTerritoryItemModel);
        }

        // POST: EmployeeTerritory/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeTerritoryItemModel employeeTerritoryItemModel)
        {
            try
            {
                if (Application.Delete(employeeTerritoryItemModel.OperationResult, (EmployeeTerritoryDTO)employeeTerritoryItemModel.EmployeeTerritory.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                employeeTerritoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(employeeTerritoryItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: EmployeeTerritory/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<EmployeeTerritoryViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(EmployeeTerritory), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<EmployeeTerritoryViewModel, EmployeeTerritoryDTO, EmployeeTerritory>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: EmployeeTerritory/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, EmployeeTerritoryResources.EntitySingular + ".xlsx");
        }

        // POST: EmployeeTerritory/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, EmployeeTerritoryResources.EntitySingular + ".pdf");
        }

        // POST: EmployeeTerritory/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, EmployeeTerritoryResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}