using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DataVersioning.WebApp
{
  // NOTE: If you change the interface name "IRestService" here, you must also update the reference to "IRestService" in Web.config.
  [ServiceContract]
  public interface IRestService
  {
    #region V1_Methods
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate="v1/PurchaseOrder")]
    int CreatePurchaseOrder(DTO.PurchaseOrder purchaseOrder);

    [OperationContract]
    [WebInvoke(Method = "PUT", UriTemplate = "v1/PurchaseOrder/{id}")]
    bool Update(string id, DTO.PurchaseOrder purchaseOrder);

    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "v1/PurchaseOrder/{id}")]
    bool Delete(string id);

    [OperationContract]
    [WebGet(UriTemplate = "v1/PurchaseOrder/{id}")]
    DTO.PurchaseOrder Get(string id);
    #endregion

    #region V2_Methods
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "v2/PurchaseOrder")]
    int CreatePurchaseOrderv2(DTO.v2.PurchaseOrder purchaseOrder);

    [OperationContract]
    [WebInvoke(Method = "PUT", UriTemplate = "v2/PurchaseOrder/{id}")]
    bool Updatev2(string id, DTO.v2.PurchaseOrder purchaseOrder);

    [OperationContract]
    [WebInvoke(Method = "DELETE", UriTemplate = "v2/PurchaseOrder/{id}")]
    bool Deletev2(string id);

    [OperationContract]
    [WebGet(UriTemplate = "v2/PurchaseOrder/{id}")]
    DTO.v2.PurchaseOrder Getv2(string id);
    #endregion
  }
}
