using System.Net;
using System.ServiceModel.Web;
using DataVersioning.DTO;
using DataVersioning.WebApp.Controllers;

namespace DataVersioning.WebApp
{
  // NOTE: If you change the class name "RestService" here, you must also update the reference to "RestService" in Web.config.
  public class RestService : IRestService
  {
    private PurchaseOrderController _controller = new PurchaseOrderController();
    public int CreatePurchaseOrder(PurchaseOrder purchaseOrder)
    {
      int retval = -1;
      if (_controller.Submit(purchaseOrder))
      {
        retval = purchaseOrder.PurchaseOrderId;
      }
      else
      {
        WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
      }

      return retval;
    }

    public bool Update(string id, PurchaseOrder purchaseOrder)
    {
      purchaseOrder.PurchaseOrderId = int.Parse(id);
      return _controller.Submit(purchaseOrder);
    }

    public bool Delete(string id)
    {
      return _controller.Delete(int.Parse(id));
    }

    public PurchaseOrder Get(string id)
    {
      return _controller.Lookup(int.Parse(id));
    }

    public int CreatePurchaseOrderv2(DTO.v2.PurchaseOrder purchaseOrder)
    {
      int retval = -1;
      if (_controller.Submit(purchaseOrder))
      {
        retval = purchaseOrder.PurchaseOrderId;
      }
      else
      {
        WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
      }
      return retval;
    }

    public bool Updatev2(string id, DTO.v2.PurchaseOrder purchaseOrder)
    {
      purchaseOrder.PurchaseOrderId = int.Parse(id);
      return _controller.Submit(purchaseOrder);
    }

    public bool Deletev2(string id)
    {
      return _controller.Delete(int.Parse(id));
    }

    public DTO.v2.PurchaseOrder Getv2(string id)
    {
      return _controller.Lookupv2(int.Parse(id));
    }
  }
}
