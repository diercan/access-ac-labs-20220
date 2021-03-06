﻿using Domain.Models;
using Persistence.EfCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infra.Free;
using static Domain.Domain.CreateMenuOp.CreateMenuResult;
using static Domain.Domain.CreateOrderOp.CreateOrderResult;

namespace Domain.Domain.CreateOrderOp
{
    public struct CreateOrderCmd
    {
        public int ClientId { get; }
        public int RestaurantId { get; }
        public int TableNumber { get; }
        public String ItemNames { get; }
        public String ItemQuantities { get; }
        public String ItemComments { get; }
        public double TotalPrice { get; }
        public String Status { get; }
        public String PaymentStatus { get; }

        public CreateOrderCmd(int clientID, int restaurantID, int tableNumber, String itemNames, String itemQuantities, String itemComments, double totalPrice, String status, String payment)
        {
            ClientId = clientID;
            RestaurantId = restaurantID;
            TableNumber = tableNumber;
            ItemNames = itemNames;
            ItemQuantities = itemQuantities;
            ItemComments = itemComments;
            TotalPrice = totalPrice;
            Status = status;
            PaymentStatus = payment;
        }

        public (bool, String) IsValid()
        {
            try
            {
                return (true, "None");
            }
            catch (Exception exp)
            {
                return (false, exp.ToString());
            }
        }

        public bool IncorectInputType(dynamic value, Type expectedType) => value.GetType() != expectedType ? true : false;  // Checks if a variable is the correct type
    }

    public class CreateOrderCmdInputGen : InputGenerator<CreateOrderCmd, CreateOrderCmdInput>
    {
        public CreateOrderCmdInputGen()
        {
            mappings.Add(CreateOrderCmdInput.ValidInput, () => new CreateOrderCmd(1, 1, 1, "item", "1", "comment1", 10, "CREATED", "ACCEPTED"));
            mappings.Add(CreateOrderCmdInput.InvalidClient, () => new CreateOrderCmd(0, 1, 1, "item", "1", "comment1", 10, "CREATED", "ACCEPTED"));
            mappings.Add(CreateOrderCmdInput.InvalidAmount, () => new CreateOrderCmd(0, 1, 1, "item", "1", "comment1", -10, "CREATED", "ACCEPTED"));
        }
    }
    public enum CreateOrderCmdInput
    {
        ValidInput,
        InvalidClient,
        InvalidAmount,
        InvalidRestaurant 
    }
}