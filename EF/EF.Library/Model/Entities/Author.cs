﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Library.Model.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ///У книги может быть много авторов
        public List<Book> books { get; set; }

    }
}
