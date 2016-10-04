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
    public class TerritoryController : BaseControllerSCRUDApplication<TerritoryDTO, Territory>
    {
        #region Methods

        public TerritoryController(INorthwindGenericApplicationDTO<TerritoryDTO, Territory> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: Territory
        // GET: Territory/Index
        [HttpGet]
        public ActionResult Index(int? masterRegionId = null)
        {
            ClearUrlDictionary();

            TerritoryCollectionModel territoryCollectionModel = new TerritoryCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index",
                MasterRegionId = masterRegionId
            };

            try
            {
                IsSearch(territoryCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                territoryCollectionModel.OperationResult.ParseException(exception);
            }

            return View(territoryCollectionModel);
        }        

        // GET & POST: Territory/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null, int? masterRegionId = null)
        {
            WriteUrlDictionary(masterUrl);

            TerritoryCollectionModel territoryCollectionModel = new TerritoryCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction,
                MasterRegionId = masterRegionId
            };

            try
            {
                IsSearch(territoryCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                territoryCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView(territoryCollectionModel);
        }

        // GET & POST: Territory/Lookup
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

            return PartialView("_TerritoryLookup", lookupModel);
        }

        // GET: Territory/Create
        [HttpGet]
        public ActionResult Create(int? masterRegionId = null)
        {
            TerritoryItemModel territoryItemModel = new TerritoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Territory = new TerritoryViewModel(),
                ControllerAction = "Create",
                MasterRegionId = masterRegionId
            };

            try
            {
                IsCreate(territoryItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(territoryItemModel);
        }

        // POST: Territory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TerritoryItemModel territoryItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(territoryItemModel.OperationResult, (TerritoryDTO)territoryItemModel.Territory.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }

        // GET: Territory/Read/1
        [HttpGet]
        public ActionResult Read(string territoryId, int? masterRegionId = null)
        {
            TerritoryItemModel territoryItemModel = new TerritoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Territory = new TerritoryViewModel(),
                ControllerAction = "Read",
                MasterRegionId = masterRegionId
            };
            
            try
            {
                TerritoryDTO territoryDTO = Application.GetById(territoryItemModel.OperationResult, new object[] { territoryId });
                if (territoryDTO != null)
                {
                    territoryItemModel.Territory = new TerritoryViewModel(territoryDTO);
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(territoryItemModel);
        }

        // GET: Territory/Update/1
        [HttpGet]
        public ActionResult Update(string territoryId, int? masterRegionId = null)
        {
            TerritoryItemModel territoryItemModel = new TerritoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Territory = new TerritoryViewModel(),
                ControllerAction = "Update",
                MasterRegionId = masterRegionId
            };
            
            try
            {
                TerritoryDTO territoryDTO = Application.GetById(territoryItemModel.OperationResult, new object[] { territoryId });
                if (territoryDTO != null)
                {
                    territoryItemModel.Territory = new TerritoryViewModel(territoryDTO);
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(territoryItemModel);
        }

        // POST: Territory/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TerritoryItemModel territoryItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(territoryItemModel.OperationResult, (TerritoryDTO)territoryItemModel.Territory.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }

        // GET: Territory/Delete/1
        [HttpGet]
        public ActionResult Delete(string territoryId, int? masterRegionId = null)
        {
            TerritoryItemModel territoryItemModel = new TerritoryItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Territory = new TerritoryViewModel(),
                ControllerAction = "Delete",
                MasterRegionId = masterRegionId
            };
            
            try
            {
                TerritoryDTO territoryDTO = Application.GetById(territoryItemModel.OperationResult, new object[] { territoryId });
                if (territoryDTO != null)
                {
                    territoryItemModel.Territory = new TerritoryViewModel(territoryDTO);
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(territoryItemModel);
        }

        // POST: Territory/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TerritoryItemModel territoryItemModel)
        {
            try
            {
                if (Application.Delete(territoryItemModel.OperationResult, (TerritoryDTO)territoryItemModel.Territory.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                territoryItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(territoryItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Territory/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<TerritoryViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Territory), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<TerritoryViewModel, TerritoryDTO, Territory>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Territory/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, TerritoryResources.EntitySingular + ".xlsx");
        }

        // POST: Territory/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, TerritoryResources.EntitySingular + ".pdf");
        }

        // POST: Territory/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, TerritoryResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}