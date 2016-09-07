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
    public class ShipperController : BaseControllerSCRUDApplication<ShipperDTO, Shipper>
    {
        #region Methods

        public ShipperController(INorthwindGenericApplicationDTO<ShipperDTO, Shipper> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: Shipper
        // GET: Shipper/Index
        [HttpGet]
        public ActionResult Index()
        {
            ClearUrlDictionary();

            ShipperCollectionModel shipperCollectionModel = new ShipperCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index"
            };

            try
            {
                IsSearch(shipperCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                shipperCollectionModel.OperationResult.ParseException(exception);
            }

            return View(shipperCollectionModel);
        }        

        // GET & POST: Shipper/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null)
        {
            WriteUrlDictionary(masterUrl);

            ShipperCollectionModel shipperCollectionModel = new ShipperCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction
            };

            try
            {
                IsSearch(shipperCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                shipperCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView("_ShipperCollection", shipperCollectionModel);
        }

        // GET & POST: Shipper/Lookup
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

            return PartialView("_ShipperLookup", lookupModel);
        }

        // GET: Shipper/Create
        [HttpGet]
        public ActionResult Create()
        {
            ShipperItemModel shipperItemModel = new ShipperItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Shipper = new ShipperViewModel(),
                ControllerAction = "Create"
            };

            try
            {
                IsCreate(shipperItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(shipperItemModel);
        }

        // POST: Shipper/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperItemModel shipperItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(shipperItemModel.OperationResult, (ShipperDTO)shipperItemModel.Shipper.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }

        // GET: Shipper/Read/1
        [HttpGet]
        public ActionResult Read(int? shipperId)
        {
            ShipperItemModel shipperItemModel = new ShipperItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Shipper = new ShipperViewModel(),
                ControllerAction = "Read"
            };
            
            try
            {
                ShipperDTO shipperDTO = Application.GetById(shipperItemModel.OperationResult, new object[] { shipperId });
                if (shipperDTO != null)
                {
                    shipperItemModel.Shipper = new ShipperViewModel(shipperDTO);
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(shipperItemModel);
        }

        // GET: Shipper/Update/1
        [HttpGet]
        public ActionResult Update(int? shipperId)
        {
            ShipperItemModel shipperItemModel = new ShipperItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Shipper = new ShipperViewModel(),
                ControllerAction = "Update"
            };
            
            try
            {
                ShipperDTO shipperDTO = Application.GetById(shipperItemModel.OperationResult, new object[] { shipperId });
                if (shipperDTO != null)
                {
                    shipperItemModel.Shipper = new ShipperViewModel(shipperDTO);
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(shipperItemModel);
        }

        // POST: Shipper/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ShipperItemModel shipperItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(shipperItemModel.OperationResult, (ShipperDTO)shipperItemModel.Shipper.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }

        // GET: Shipper/Delete/1
        [HttpGet]
        public ActionResult Delete(int? shipperId)
        {
            ShipperItemModel shipperItemModel = new ShipperItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Shipper = new ShipperViewModel(),
                ControllerAction = "Delete"
            };
            
            try
            {
                ShipperDTO shipperDTO = Application.GetById(shipperItemModel.OperationResult, new object[] { shipperId });
                if (shipperDTO != null)
                {
                    shipperItemModel.Shipper = new ShipperViewModel(shipperDTO);
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(shipperItemModel);
        }

        // POST: Shipper/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ShipperItemModel shipperItemModel)
        {
            try
            {
                if (Application.Delete(shipperItemModel.OperationResult, (ShipperDTO)shipperItemModel.Shipper.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                shipperItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(shipperItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Shipper/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<ShipperViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Shipper), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<ShipperViewModel, ShipperDTO, Shipper>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Shipper/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, ShipperResources.EntitySingular + ".xlsx");
        }

        // POST: Shipper/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, ShipperResources.EntitySingular + ".pdf");
        }

        // POST: Shipper/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, ShipperResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}