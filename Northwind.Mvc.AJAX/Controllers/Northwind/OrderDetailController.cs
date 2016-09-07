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
    public class OrderDetailController : BaseControllerSCRUDApplication<OrderDetailDTO, OrderDetail>
    {
        #region Methods

        public OrderDetailController(INorthwindGenericApplicationDTO<OrderDetailDTO, OrderDetail> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: OrderDetail
        // GET: OrderDetail/Index
        [HttpGet]
        public ActionResult Index(int? masterOrderId = null, int? masterProductId = null)
        {
            ClearUrlDictionary();

            OrderDetailCollectionModel orderDetailCollectionModel = new OrderDetailCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index",
                MasterOrderId = masterOrderId, MasterProductId = masterProductId
            };

            try
            {
                IsSearch(orderDetailCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                orderDetailCollectionModel.OperationResult.ParseException(exception);
            }

            return View(orderDetailCollectionModel);
        }        

        // GET & POST: OrderDetail/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null, int? masterOrderId = null, int? masterProductId = null)
        {
            WriteUrlDictionary(masterUrl);

            OrderDetailCollectionModel orderDetailCollectionModel = new OrderDetailCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction,
                MasterOrderId = masterOrderId, MasterProductId = masterProductId
            };

            try
            {
                IsSearch(orderDetailCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                orderDetailCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView("_OrderDetailCollection", orderDetailCollectionModel);
        }

        // GET & POST: OrderDetail/Lookup
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

            return PartialView("_OrderDetailLookup", lookupModel);
        }

        // GET: OrderDetail/Create
        [HttpGet]
        public ActionResult Create(int? masterOrderId = null, int? masterProductId = null)
        {
            OrderDetailItemModel orderDetailItemModel = new OrderDetailItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                OrderDetail = new OrderDetailViewModel(),
                ControllerAction = "Create",
                MasterOrderId = masterOrderId, MasterProductId = masterProductId
            };

            try
            {
                IsCreate(orderDetailItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(orderDetailItemModel);
        }

        // POST: OrderDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetailItemModel orderDetailItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(orderDetailItemModel.OperationResult, (OrderDetailDTO)orderDetailItemModel.OrderDetail.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }

        // GET: OrderDetail/Read/1
        [HttpGet]
        public ActionResult Read(int? orderId, int? productId, int? masterOrderId = null, int? masterProductId = null)
        {
            OrderDetailItemModel orderDetailItemModel = new OrderDetailItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                OrderDetail = new OrderDetailViewModel(),
                ControllerAction = "Read",
                MasterOrderId = masterOrderId, MasterProductId = masterProductId
            };
            
            try
            {
                OrderDetailDTO orderDetailDTO = Application.GetById(orderDetailItemModel.OperationResult, new object[] { orderId, productId });
                if (orderDetailDTO != null)
                {
                    orderDetailItemModel.OrderDetail = new OrderDetailViewModel(orderDetailDTO);
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(orderDetailItemModel);
        }

        // GET: OrderDetail/Update/1
        [HttpGet]
        public ActionResult Update(int? orderId, int? productId, int? masterOrderId = null, int? masterProductId = null)
        {
            OrderDetailItemModel orderDetailItemModel = new OrderDetailItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                OrderDetail = new OrderDetailViewModel(),
                ControllerAction = "Update",
                MasterOrderId = masterOrderId, MasterProductId = masterProductId
            };
            
            try
            {
                OrderDetailDTO orderDetailDTO = Application.GetById(orderDetailItemModel.OperationResult, new object[] { orderId, productId });
                if (orderDetailDTO != null)
                {
                    orderDetailItemModel.OrderDetail = new OrderDetailViewModel(orderDetailDTO);
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(orderDetailItemModel);
        }

        // POST: OrderDetail/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(OrderDetailItemModel orderDetailItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(orderDetailItemModel.OperationResult, (OrderDetailDTO)orderDetailItemModel.OrderDetail.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }

        // GET: OrderDetail/Delete/1
        [HttpGet]
        public ActionResult Delete(int? orderId, int? productId, int? masterOrderId = null, int? masterProductId = null)
        {
            OrderDetailItemModel orderDetailItemModel = new OrderDetailItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                OrderDetail = new OrderDetailViewModel(),
                ControllerAction = "Delete",
                MasterOrderId = masterOrderId, MasterProductId = masterProductId
            };
            
            try
            {
                OrderDetailDTO orderDetailDTO = Application.GetById(orderDetailItemModel.OperationResult, new object[] { orderId, productId });
                if (orderDetailDTO != null)
                {
                    orderDetailItemModel.OrderDetail = new OrderDetailViewModel(orderDetailDTO);
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(orderDetailItemModel);
        }

        // POST: OrderDetail/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderDetailItemModel orderDetailItemModel)
        {
            try
            {
                if (Application.Delete(orderDetailItemModel.OperationResult, (OrderDetailDTO)orderDetailItemModel.OrderDetail.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                orderDetailItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderDetailItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: OrderDetail/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<OrderDetailViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(OrderDetail), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<OrderDetailViewModel, OrderDetailDTO, OrderDetail>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: OrderDetail/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, OrderDetailResources.EntitySingular + ".xlsx");
        }

        // POST: OrderDetail/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, OrderDetailResources.EntitySingular + ".pdf");
        }

        // POST: OrderDetail/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, OrderDetailResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}