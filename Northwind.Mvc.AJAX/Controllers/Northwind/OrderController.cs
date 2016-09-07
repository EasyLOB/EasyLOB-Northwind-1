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
    public class OrderController : BaseControllerSCRUDApplication<OrderDTO, Order>
    {
        #region Methods

        public OrderController(INorthwindGenericApplicationDTO<OrderDTO, Order> application)
        {
            Application = application;            
        }
        
        #endregion
        
        #region Methods SCRUD

        // GET: Order
        // GET: Order/Index
        [HttpGet]
        public ActionResult Index(string masterCustomerId = null, int? masterEmployeeId = null, int? masterShipVia = null)
        {
            ClearUrlDictionary();

            OrderCollectionModel orderCollectionModel = new OrderCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Index",
                MasterCustomerId = masterCustomerId, MasterEmployeeId = masterEmployeeId, MasterShipVia = masterShipVia
            };

            try
            {
                IsSearch(orderCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                orderCollectionModel.OperationResult.ParseException(exception);
            }

            return View(orderCollectionModel);
        }        

        // GET & POST: Order/Search
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Search(string masterUrl = null, string masterControllerAction = null, string masterCustomerId = null, int? masterEmployeeId = null, int? masterShipVia = null)
        {
            WriteUrlDictionary(masterUrl);

            OrderCollectionModel orderCollectionModel = new OrderCollectionModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                ControllerAction = "Search",
                MasterControllerAction = masterControllerAction,
                MasterCustomerId = masterCustomerId, MasterEmployeeId = masterEmployeeId, MasterShipVia = masterShipVia
            };

            try
            {
                IsSearch(orderCollectionModel.OperationResult);
            }
            catch (Exception exception)
            {
                orderCollectionModel.OperationResult.ParseException(exception);
            }

            return PartialView("_OrderCollection", orderCollectionModel);
        }

        // GET & POST: Order/Lookup
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

            return PartialView("_OrderLookup", lookupModel);
        }

        // GET: Order/Create
        [HttpGet]
        public ActionResult Create(string masterCustomerId = null, int? masterEmployeeId = null, int? masterShipVia = null)
        {
            OrderItemModel orderItemModel = new OrderItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Order = new OrderViewModel(),
                ControllerAction = "Create",
                MasterCustomerId = masterCustomerId, MasterEmployeeId = masterEmployeeId, MasterShipVia = masterShipVia
            };

            try
            {
                IsCreate(orderItemModel.OperationResult);
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(orderItemModel);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderItemModel orderItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Create(orderItemModel.OperationResult, (OrderDTO)orderItemModel.Order.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }

        // GET: Order/Read/1
        [HttpGet]
        public ActionResult Read(int? orderId, string masterCustomerId = null, int? masterEmployeeId = null, int? masterShipVia = null)
        {
            OrderItemModel orderItemModel = new OrderItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Order = new OrderViewModel(),
                ControllerAction = "Read",
                MasterCustomerId = masterCustomerId, MasterEmployeeId = masterEmployeeId, MasterShipVia = masterShipVia
            };
            
            try
            {
                OrderDTO orderDTO = Application.GetById(orderItemModel.OperationResult, new object[] { orderId });
                if (orderDTO != null)
                {
                    orderItemModel.Order = new OrderViewModel(orderDTO);
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }            

            return PartialView(orderItemModel);
        }

        // GET: Order/Update/1
        [HttpGet]
        public ActionResult Update(int? orderId, string masterCustomerId = null, int? masterEmployeeId = null, int? masterShipVia = null)
        {
            OrderItemModel orderItemModel = new OrderItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Order = new OrderViewModel(),
                ControllerAction = "Update",
                MasterCustomerId = masterCustomerId, MasterEmployeeId = masterEmployeeId, MasterShipVia = masterShipVia
            };
            
            try
            {
                OrderDTO orderDTO = Application.GetById(orderItemModel.OperationResult, new object[] { orderId });
                if (orderDTO != null)
                {
                    orderItemModel.Order = new OrderViewModel(orderDTO);
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(orderItemModel);
        }

        // POST: Order/Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(OrderItemModel orderItemModel)
        {
            try
            {
                if (ValidateModelState(Application.Repository))
                {
                    if (Application.Update(orderItemModel.OperationResult, (OrderDTO)orderItemModel.Order.ToDTO()))
                    {
                        return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                    }
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }

        // GET: Order/Delete/1
        [HttpGet]
        public ActionResult Delete(int? orderId, string masterCustomerId = null, int? masterEmployeeId = null, int? masterShipVia = null)
        {
            OrderItemModel orderItemModel = new OrderItemModel()
            {
                IsSecurityOperations = this.IsSecurityOperations,
                Order = new OrderViewModel(),
                ControllerAction = "Delete",
                MasterCustomerId = masterCustomerId, MasterEmployeeId = masterEmployeeId, MasterShipVia = masterShipVia
            };
            
            try
            {
                OrderDTO orderDTO = Application.GetById(orderItemModel.OperationResult, new object[] { orderId });
                if (orderDTO != null)
                {
                    orderItemModel.Order = new OrderViewModel(orderDTO);
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return PartialView(orderItemModel);
        }

        // POST: Order/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OrderItemModel orderItemModel)
        {
            try
            {
                if (Application.Delete(orderItemModel.OperationResult, (OrderDTO)orderItemModel.Order.ToDTO()))
                {
                    return JsonResultSuccess(new { uri = ReadUrlDictionary() });
                }
            }
            catch (Exception exception)
            {
                orderItemModel.OperationResult.ParseException(exception);
            }

            return JsonResultOperationResult(orderItemModel.OperationResult);
        }
        
        #endregion Methods SCRUD
        
        #region Methods Syncfusion

        // POST: Order/DataSource
        [HttpPost]
        public ActionResult DataSource(DataManager dataManager)
        {
            IEnumerable data = new List<OrderViewModel>();
            int countAll = 0;
            ZOperationResult operationResult = new ZOperationResult();

            if (IsSearch())
            {
                try
                {
                    SyncfusionGrid syncfusionGrid = new SyncfusionGrid(typeof(Order), Application.UnitOfWork.DBMS);
                    ArrayList args = new ArrayList();
                    string where = syncfusionGrid.ToLinqWhere(dataManager.Search, dataManager.Where, args);
                    string orderBy = syncfusionGrid.ToLinqOrderBy(dataManager.Sorted);        
                    int take = (dataManager.Skip == 0 && dataManager.Take == 0) ? AppDefaults.SyncfusionRecordsBySearch : dataManager.Take; // Excel Filtering
                    data = ZViewHelper<OrderViewModel, OrderDTO, Order>.ToViewList(Application.Select(operationResult, where, args.ToArray(), orderBy, dataManager.Skip, take));
        
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

        // POST: Order/ExportToExcel
        [HttpPost]
        public void ExportToExcel(string gridModel)
        {
            ExportToExcel(gridModel, OrderResources.EntitySingular + ".xlsx");
        }

        // POST: Order/ExportToPdf
        [HttpPost]
        public void ExportToPdf(string gridModel)
        {
            ExportToPdf(gridModel, OrderResources.EntitySingular + ".pdf");
        }

        // POST: Order/ExportToWord
        [HttpPost]
        public void ExportToWord(string gridModel)
        {
            ExportToWord(gridModel, OrderResources.EntitySingular + ".docx");
        }
        
        #endregion Methods Syncfusion
    }
}