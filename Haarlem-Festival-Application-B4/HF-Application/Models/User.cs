﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HF_Application.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool Admin { get; set; }
        public string Email { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

    }
}