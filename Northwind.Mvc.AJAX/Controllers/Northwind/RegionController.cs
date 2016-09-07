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
    public class RegionController : BaseControllerSCRUDApplication<RegionDTO, Region>
    {
        #region Methods

        public RegionController(INorthwindGenericApplicationDTO<RegionDTO, Region> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: Region
        // GET: Region/Index
        [HttpGet]
        public ActionResult Index()
        {
            ClearUrlDictionary();

            RegionCollectionModel regionCollectionModel = new RegionCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index"
            };

            try
            {
                IsSearch(regionCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                regionCollectionModel.OperationResult.ParseException(exception);
            }

            return View(regionCollectionModel);
        }        

        // GET & POST: Region/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null)
        {
            WriteUrlDictionary(masterUrl);

            RegionCollectionModel regionCollectionModel = new RegionCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction
            };

            try
            {
                IsSearch(regionCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                regionCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView("_RegionCollection", regionCollectionModel);
        }

        // GET & POST: Region/Lookup
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

            return PartialView("_RegionLookup", lookupModel);
        }

        // GET: Region/Create
        [HttpGet]
        public ActionResult Create()
        {
            RegionItemModel regionItemModel = new RegionItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Region = new RegionViewModel(),
                ControllerAction = "Create"
            };

            try
            {
                IsCreate(regionItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(regionItemModel);
        }

        // POST: Region/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegionItemModel regionItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(regionItemModel.OperationResult, (RegionDTO)regionItemModel.Region.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }

        // GET: Region/Read/1
        [HttpGet]
        public ActionResult Read(int? regionId)
        {
            RegionItemModel regionItemModel = new RegionItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Region = new RegionViewModel(),
                ControllerAction = "Read"
            };
            
            try
            {
                RegionDTO regionDTO = Application.GetById(regionItemModel.OperationResult, new object[] { regionId });
                if (regionDTO != null)
                {
                    regionItemModel.Region = new RegionViewModel(regionDTO);
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(regionItemModel);
        }

        // GET: Region/Update/1
        [HttpGet]
        public ActionResult Update(int? regionId)
        {
            RegionItemModel regionItemModel = new RegionItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Region = new RegionViewModel(),
                ControllerAction = "Update"
            };
            
            try
            {
                RegionDTO regionDTO = Application.GetById(regionItemModel.OperationResult, new object[] { regionId });
                if (regionDTO != null)
                {
                    regionItemModel.Region = new RegionViewModel(regionDTO);
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(regionItemModel);
        }

        // POST: Region/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RegionItemModel regionItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(regionItemModel.OperationResult, (RegionDTO)regionItemModel.Region.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }

        // GET: Region/Delete/1
        [HttpGet]
        public ActionResult Delete(int? regionId)
        {
            RegionItemModel regionItemModel = new RegionItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Region = new RegionViewModel(),
                ControllerAction = "Delete"
            };
            
            try
            {
                RegionDTO regionDTO = Application.GetById(regionItemModel.OperationResult, new object[] { regionId });
                if (regionDTO != null)
                {
                    regionItemModel.Region = new RegionViewModel(regionDTO);
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(regionItemModel);
        }

        // POST: Region/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RegionItemModel regionItemModel)
        {
            try
            {
                if (Application.Delete(regionItemModel.OperationResult, (RegionDTO)regionItemModel.Region.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                regionItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(regionItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Region/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<RegionViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Region), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<RegionViewModel, RegionDTO, Region>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Region/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, RegionResources.EntitySingular + ".xlsx");
        }

        // POST: Region/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, RegionResources.EntitySingular + ".pdf");
        }

        // POST: Region/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, RegionResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}