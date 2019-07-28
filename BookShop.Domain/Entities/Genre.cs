using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public string Description { get; set; }

        public IList<BookGenre> BookGenres { get; set; }
    }
}
