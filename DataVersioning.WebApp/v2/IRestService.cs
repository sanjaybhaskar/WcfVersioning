using System.ServiceModel;
using System.ServiceModel.Web;

namespace DataVersioning.WebApp.v2
{
  // NOTE: If you change the interface name "IRestService" here, you must also update the reference to "IRestService" in Web.config.
  [ServiceContract]
  public interface IRestService
  {
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "PurchaseOrder")]
    int CreatePurchaseOrderv2(DTO.v2.PurchaseOrder purchaseOrder);

    [OperationContract]
    [WebInvoke(Method = "PUT", UriTemplate = "PurchaseOrder/{id}")]
    bool Updatev2(string id, DTO.v2.PurchaseOrder purchaseOrder);

    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "PurchaseOrder/{id}")]
    bool Deletev2(string id);

    [OperationContract]
    [WebGet(UriTemplate = "PurchaseOrder/{id}")]
    DTO.v2.PurchaseOrder Getv2(string id);
  }
}
