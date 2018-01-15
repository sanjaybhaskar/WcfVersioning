using System;
using System.Collections.Generic;

namespace DataVersioning.Business
{
  public class PurchaseOrder
  {
    public PurchaseOrder()
    {
      LineItems = new List<LineItem>();
    }

    public int CustomerId{ get; set; }

    public int PurchaseOrderId { get; set; }

    public List<LineItem> LineItems { get; private set; }

    public string Comments { get; set; }

    public DateTime OrderDate { get; set; }

    public bool Submit()
    {
      return true;
    }
  }
}
