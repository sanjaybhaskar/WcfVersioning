using PurchaseOrder = DataVersioning.Business.PurchaseOrder;

namespace DataVersioning.WebApp.Controllers
{
  public class PurchaseOrderController
  {
    public bool Submit(DTO.PurchaseOrder purchaseOrder)
    {
      var businessObject = ConvertToBO(purchaseOrder);
      return businessObject.Submit();
    }

    public bool Submit(DTO.v2.PurchaseOrder purchaseOrder)
    {
      var businessObject = ConvertToBO(purchaseOrder);
      return businessObject.Submit();
    }

    public static Business.PurchaseOrder ConvertToBO(DTO.v2.PurchaseOrder purchaseOrder)
    {
      var retval = new Business.PurchaseOrder
                     {
                       CustomerId = purchaseOrder.CustomerId,
                       PurchaseOrderId = purchaseOrder.PurchaseOrderId,
                       OrderDate =  purchaseOrder.OrderDate
                     };
      foreach (var lineItem in purchaseOrder.LineItems)
      {
        // Probably want some validation logic around the Price to make
        // sure callers aren't changing this too...
        var boLineItem = new Business.LineItem
                           {
                             ItemId = lineItem.ItemId,
                             Line = lineItem.Line,
                             Price = lineItem.Price,
                             PurchaseOrderId = retval.PurchaseOrderId,
                             Qty = lineItem.Quantity
                           };

        retval.LineItems.Add(boLineItem);
      }
      return retval;
    }


    public static Business.PurchaseOrder ConvertToBO(DTO.v3.PurchaseOrder purchaseOrder)
    {
      var retval = ConvertToBO((DTO.v2.PurchaseOrder)purchaseOrder);
      retval.Comments = purchaseOrder.Comments;
      return retval;
    }

    public static Business.PurchaseOrder ConvertToBO(DTO.PurchaseOrder purchaseOrder)
    {
      var retval = new Business.PurchaseOrder
                     {
                       CustomerId = purchaseOrder.CustomerId,
                       PurchaseOrderId = purchaseOrder.PurchaseOrderId
                     };
      foreach (var lineItem in purchaseOrder.LineItems)
      {
        // Probably want some validation logic around the Price to make
        // sure callers aren't changing this too...
        var boLineItem = new Business.LineItem
                           {
                             ItemId = lineItem.ItemId,
                             Line = lineItem.Line,
                             Price = lineItem.Price,
                             PurchaseOrderId = retval.PurchaseOrderId,
                             Qty = lineItem.Qty
                           };

        retval.LineItems.Add(boLineItem);
      }
      return retval;
    }

    public static DTO.PurchaseOrder ConvertToDTO(Business.PurchaseOrder purchaseOrder)
    {
      var retval = new DTO.PurchaseOrder
      {
        CustomerId = purchaseOrder.CustomerId,
        PurchaseOrderId = purchaseOrder.PurchaseOrderId
      };
      foreach (var lineItem in purchaseOrder.LineItems)
      {
        // Probably want some validation logic around the Price to make
        // sure callers aren't changing this too...
        var boLineItem = new DTO.LineItem
        {
          ItemId = lineItem.ItemId,
          Line = lineItem.Line,
          Price = lineItem.Price,
          PurchaseOrderId = retval.PurchaseOrderId,
          Qty = lineItem.Qty
        };

        retval.LineItems.Add(boLineItem);
      }
      return retval;
    }

    public static DTO.v2.PurchaseOrder ConvertToDTOv2(Business.PurchaseOrder purchaseOrder)
    {
      var retval = new DTO.v2.PurchaseOrder
      {
        CustomerId = purchaseOrder.CustomerId,
        PurchaseOrderId = purchaseOrder.PurchaseOrderId,
        OrderDate = purchaseOrder.OrderDate
      };
      foreach (var lineItem in purchaseOrder.LineItems)
      {
        // Probably want some validation logic around the Price to make
        // sure callers aren't changing this too...
        var boLineItem = new DTO.v2.LineItem
        {
          ItemId = lineItem.ItemId,
          Line = lineItem.Line,
          Price = lineItem.Price,
          PurchaseOrderId = retval.PurchaseOrderId,
          Quantity = lineItem.Qty
        };

        retval.LineItems.Add(boLineItem);
      }
      return retval;
    }

    public DataVersioning.DTO.PurchaseOrder Lookup(int id)
    {
      Business.PurchaseOrder po = new PurchaseOrder() { PurchaseOrderId = id };
      return ConvertToDTO(po);
    }

    internal DataVersioning.DTO.v2.PurchaseOrder Lookupv2(int id)
    {
      Business.PurchaseOrder po = new PurchaseOrder() { PurchaseOrderId = id };
      return ConvertToDTOv2(po);
    }

    public bool Delete(int id)
    {
      return true;
    }
  }
}
