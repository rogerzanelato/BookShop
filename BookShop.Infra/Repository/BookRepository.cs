using System.Collections.Generic;
using System.Linq;
using BookShop.Domain.Entities;
using BookShop.Domain.Interfaces;
using BookShop.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Domain.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public IList<Book> SelectWithRelationship()
        {
            return _context.Set<Book>()
                .Include(b => b.BookAuthors)
                .Include(b => b.BookGenres)
                .OrderBy(b => b.Title)
                .ToList();
        }

        public Book SelectWithRelationship(int id)
        {
            return _context.Set<Book>()
                .Include(b => b.BookAuthors)
                .Include(b => b.BookGenres)
                .SingleOrDefault(b => b.Id == id);
        }
    }
}
