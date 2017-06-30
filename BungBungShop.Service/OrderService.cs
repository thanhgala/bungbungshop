using BungBungShop.Data.Infrastructure;
using BungBungShop.Data.Repositories;
using BungBungShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BungBungShop.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        bool Create(Order order, List<OrderDetail> orderDetails);
        void SaveChanges();
    }

    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository oderDetailRepository, IUnitOfWork unitOfWork)
        {
            this._orderRepository = orderRepository;    
            this._orderDetailRepository = oderDetailRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public bool Create(Order order, List<OrderDetail> orderDetails)
        {
                _orderRepository.Add(order);
                _unitOfWork.Comit();

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = order.ID;
                    _orderDetailRepository.Add(orderDetail);
                }
                _unitOfWork.Comit();
                return true;
        }

        public void SaveChanges()
        {
            _unitOfWork.Comit();
        }

    }
}
