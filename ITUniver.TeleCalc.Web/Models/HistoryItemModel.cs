﻿using ITUniver.TeleCalc.Web.Interfaces;
using System;
using System.Web.Mvc;

namespace ITUniver.TeleCalc.Web.Models
{
    public class HistoryItemModel : IEntity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Operation { get; set; }

        public int Initiator { get; set; }

        public string Args { get; set; }

        public double? Result { get; set; }

        public DateTime CalcDate { get; set; }

        public int Time { get; set; }
    }
}