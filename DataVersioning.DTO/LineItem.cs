using System.Runtime.Serialization;

namespace DataVersioning.DTO
{
  [DataContract(Namespace = Namespaces.V1)]
  public class LineItem
  {
    [DataMember]
    public int Line { get; set; }

    [DataMember]
    public int ItemId { get; set; }

    [DataMember]
    public double Price { get; set; }

    [DataMember]
    public int Qty { get; set; }

    [DataMember]
    public int PurchaseOrderId { get; set; }
  }
}
