using System.Runtime.Serialization;

namespace DataVersioning.DTO.v2
{
  [DataContract(Namespace = Namespaces.V2)]
  public class LineItem
  {
    [DataMember]
    public int Line { get; set; }

    [DataMember]
    public int ItemId { get; set; }

    [DataMember]
    public double Price { get; set; }

    [DataMember]
    public int Quantity { get; set; }

    [DataMember]
    public int PurchaseOrderId { get; set; }
  }
}
