﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.Model.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PublishYear { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}