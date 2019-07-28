using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int Pages { get; set; }

        public int Stock { get; set; }

        public string Isbn10 { get; set; }

        public string Isbn13 { get; set; }

        public string EditionYear { get; set; }

        public IList<BookAuthor> BookAuthors { get; set; }

        public IList<BookGenre> BookGenres { get; set; }
    }
}
