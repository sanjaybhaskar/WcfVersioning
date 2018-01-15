using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataVersioning.DTO
{
  [DataContract(Namespace = Namespaces.V1)]
  public class PurchaseOrder
  {
    public PurchaseOrder()
    {
      LineItems = new List<LineItem>();
    }

    [DataMember]
    public int CustomerId { get; set; }

    [DataMember]
    public List<LineItem> LineItems { get; private set; }

    [DataMember]
    public int PurchaseOrderId { get; set; }
  }
}
