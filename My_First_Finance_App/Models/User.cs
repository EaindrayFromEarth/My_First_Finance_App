﻿using System.Transactions;

namespace My_First_Finance_App.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        // Other user-related properties
        public List<Transaction> Transactions { get; set; }
    }
}