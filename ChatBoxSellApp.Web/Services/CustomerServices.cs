﻿using ChatBoxSellApp.Data.DataDBContext;
using ChatBoxSellApp.Data.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBoxSellApp.Web.Services
{
    public interface ICustomerServices
    {
        string GetIDCustomerByUser(string id);
        void CreatNewCustomerByNewUser(string id);
        Customer GetDashBoardByID(string id);
    }
    public class CustomerServices : ICustomerServices
    {
        private readonly IAccountResponsitory _User;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IStoreProduce _StoreProduce;
        private readonly ICustomerResponsitory _Customer;
        public CustomerServices(IAccountResponsitory User, IPasswordHasher passwordHasher, IStoreProduce StoreProduce, ICustomerResponsitory Customer)
        {
            _User = User;
            _passwordHasher = passwordHasher;
            _StoreProduce = StoreProduce;
            _Customer = Customer;
        }
        public string GetIDCustomerByUser(string id)
        {
            return _User.GetById(id).ID_Customer;
        }
        public void CreatNewCustomerByNewUser(string id)
        {
            var User = _User.GetById(id);
            _Customer.Add(new Customer { ID_Customer = User.ID_Customer, DateCreate = DateTime.Now });

        }
        public Customer GetDashBoardByID(string id)
        {
            return _Customer.GetById(id);
        }

    }

}