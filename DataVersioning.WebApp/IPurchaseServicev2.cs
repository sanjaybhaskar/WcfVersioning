using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataVersioning.WebApp
{
  // NOTE: If you change the interface name "IPurchaseServicev2" here, you must also update the reference to "IPurchaseServicev2" in Web.config.
  [ServiceContract(Namespace = DTO.Namespaces.V2)]
  public interface IPurchaseServicev2
  {
    [OperationContract]
    bool SubmitPO(DTO.v2.PurchaseOrder purchaseOrder);

    [OperationContract]
    DTO.v2.PurchaseOrder Lookup(int id);
  }
}
