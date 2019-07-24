﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelPartner.Model
{
    public class Currency
    {
        public const int NO_VALUE = -1;
        public const int NOT_CHOOSEN = -1;
        private string name;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name
        {
            get => name; set
            {
                name = value.ToLower();
            }
        }
        public string ShortName { get; set; }
        public double Value { get; set; }
        public int Order { get; set; }

        public Currency()
        {

        }
    }
}