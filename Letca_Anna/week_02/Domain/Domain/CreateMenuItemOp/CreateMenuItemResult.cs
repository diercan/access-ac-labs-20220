﻿using CSharp.Choices.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.CreateMenuItemOp
{
    [AsChoice]
    public static partial class CreateMenuItemResult
    {
        public interface ICreateMenuItemResult { };

        public class MenuItemCreated : ICreateMenuItemResult
        {
            public MenuItem MenuItem;
            public MenuItemCreated(MenuItem menuItem)
            {
                MenuItem = menuItem;
            }
        }

        public class MenuItemWithInvalidPriceNotCreated : ICreateMenuItemResult
        {
            public string Reason { get; }

            public MenuItemWithInvalidPriceNotCreated(string reason)
            {
                Reason = reason;
                Console.WriteLine(reason);
            }
        }

        public class MenuItemWithEmptyNameNotCreated : ICreateMenuItemResult
        {
            public string Reason { get; }

            public MenuItemWithEmptyNameNotCreated(string reason)
            {
                Reason = reason;
                Console.WriteLine(reason);
            }
        }
    }
}
