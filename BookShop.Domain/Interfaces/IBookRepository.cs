using BookShop.Domain.Entities;
using System.Collections.Generic;

namespace BookShop.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book SelectWithRelationship(int id);

        IList<Book> SelectWithRelationship();
    }
}
