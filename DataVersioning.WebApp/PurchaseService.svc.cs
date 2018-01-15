using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataVersioning.DTO;
using DataVersioning.WebApp.Controllers;

namespace DataVersioning.WebApp
{
  // NOTE: If you change the class name "PurchaseService" here, you must also update the reference to "PurchaseService" in Web.config.
  public class PurchaseService : IPurchaseService
  {
    private PurchaseOrderController _controller = new PurchaseOrderController();

    public bool SubmitPO(PurchaseOrder purchaseOrder)
    {
      return _controller.Submit(purchaseOrder);
    }

    public PurchaseOrder Lookup(int id)
    {
      return _controller.Lookup(id);
    }
  }
}
