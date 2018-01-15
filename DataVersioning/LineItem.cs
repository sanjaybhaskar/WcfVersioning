namespace DataVersioning.Business
{
  public class LineItem
  {
    public int Line { get; set; }

    public int ItemId { get; set; }

    public double Price { get; set; }

    public int Qty { get; set; }

    public int PurchaseOrderId { get; set; }
  }
}
