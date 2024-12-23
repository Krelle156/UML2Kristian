﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Data;
using PizzaLibrary.Exeptions;
using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Services
{
    public class OrderRepository : IOrderRepository
    {
        #region instance fields
        private List<IOrder> _orderList;
        #endregion
        #region constructors
        public OrderRepository()
        {
            _orderList = new List<IOrder>();
        }
        #endregion
        public int Count { get { return _orderList.Count; } }

        public void AddOrder(IOrder order)
        {
            _orderList.Add(order);
        }

        public List<IOrder> GetAll()
        {
            return new List<IOrder>(_orderList);
        }

        public IOrder GetOrderById(int id)
        {
            for (int i = id; i < _orderList.Count; i++)
            {
                if (_orderList[i].Id == id) return _orderList[i];
            }
            for (int i = 0; i < _orderList.Count - id; i++)
            {
                if (_orderList[i].Id == id) return _orderList[i];
            }

            throw new NoSuchItemFoundException();
        }

        public void PrintALlOrders()
        {
            foreach (IOrder order in _orderList)
            {
                Console.WriteLine(order.ToString());
            }
        }

        public void RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
