using System.Runtime.Serialization;

namespace DataVersioning.DTO.v3
{
  [DataContract(Namespace = Namespaces.V3)]
  public class PurchaseOrder : DTO.v2.PurchaseOrder
  {
    [DataMember()]
    public string Comments { get; set; }
  }
}
