﻿namespace ProductWarehouse.Application.Exceptions;
public class OrderNotFoundException : Exception
{
    public OrderNotFoundException(string message) : base(message)
    {
    }
}