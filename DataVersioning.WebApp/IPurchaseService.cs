using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataVersioning.WebApp
{
  // NOTE: If you change the interface name "IPurchaseService" here, you must also update the reference to "IPurchaseService" in Web.config.
  [ServiceContract(Namespace = DTO.Namespaces.V1)]
  public interface IPurchaseService
  {
    [OperationContract]
    bool SubmitPO(DTO.PurchaseOrder purchaseOrder);

    [OperationContract]
    DTO.PurchaseOrder Lookup(int id);
  }
}
