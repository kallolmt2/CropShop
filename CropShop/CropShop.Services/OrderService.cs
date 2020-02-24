using CropShop.Core.Contracts;
using CropShop.Core.Models;
using CropShop.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropShop.Services
{
    public class OrderService : IOrderService 
    {
        IRepository<Order> orderContext;
        public OrderService(IRepository<Order> OrderContext)
        {
            this.orderContext = OrderContext;
        }

        public void CreateOrder(Order baseOrder, List<BasketItemViewModel> basektItems)
        {
            foreach (var item in basektItems)
            {
                baseOrder.OrderItems.Add(new OrderItem()
                {
                    ProductId = item.Id,
                    Image= item.Image,
                    Price= item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity
                });
            }

            orderContext.Insert(baseOrder);
            orderContext.Commit();
        }
    }
}
