﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseGilFortoul.Models
{
    public class FormaPago
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public bool Estado { get; set; }
    }
}
