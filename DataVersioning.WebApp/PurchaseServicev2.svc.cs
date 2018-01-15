using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataVersioning.DTO.v2;
using DataVersioning.WebApp.Controllers;

namespace DataVersioning.WebApp
{
  // NOTE: If you change the class name "PurchaseServicev2" here, you must also update the reference to "PurchaseServicev2" in Web.config.
  public class PurchaseServicev2 : IPurchaseServicev2
  {
    private PurchaseOrderController _controller = new PurchaseOrderController();

    public bool SubmitPO(DTO.v2.PurchaseOrder purchaseOrder)
    {
      return _controller.Submit(purchaseOrder);
    }

    public PurchaseOrder Lookup(int id)
    {
      return _controller.Lookupv2(id);
    }
  }
}
