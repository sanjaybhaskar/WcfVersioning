using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataVersioning.DTO.v2
{
  [DataContract(Namespace = Namespaces.V2)]
  public class PurchaseOrder
  {
    public PurchaseOrder()
    {
      LineItems = new List<DTO.v2.LineItem>();
    }

    [DataMember]
    public int CustomerId { get; set; }

    [DataMember]
    public List<DTO.v2.LineItem> LineItems { get; private set; }

    [DataMember]
    public int PurchaseOrderId { get; set; }

    [DataMember(Order = 100)]
    public DateTime OrderDate { get; set; }
  }
}
