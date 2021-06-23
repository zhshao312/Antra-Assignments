﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class ClientUpdateRequestModel
    {
       // public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phones { get; set; }
        public string Address { get; set; }
        public int? AddedBy { get; set; }
        //public DateTime? AddedOn { get; set; }
    }
}