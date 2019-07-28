using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public string Biography { get; set; }

        public IList<BookAuthor> BookAuthors { get; set; }
    }
}
