﻿using prjShoppingForum.Models.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tw.com.essentialoil.Order.Models
{
    public class OrderView
    {
        public IQueryable<tOrder> Order { get; set; }
        public IQueryable<tOrderDetail> OrderDetail { get; set; }
    }
}