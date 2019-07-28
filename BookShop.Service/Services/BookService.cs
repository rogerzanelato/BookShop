using System;
using System.Collections.Generic;
using BookShop.Domain.Entities;
using BookShop.Domain.Interfaces;
using BookShop.Domain.Repository;
using BookShop.Service.Validator;
using FluentValidation;

namespace BookShop.Service.Services
{
    public class BookService : IService<Book>
    {
        protected IBookRepository _repository;

        protected BaseService<Book> _baseService { get; set; }

        public BookService(IBookRepository repository)
        {
            _repository = repository;
            _baseService = new BaseService<Book>(repository);
        }
        
        public Book Get(int id)
        {
            if (id != 0)
                throw new ArgumentException("The id can't be zero");

            return _repository.SelectWithRelationship(id);
        }

        public IList<Book> Get() => _repository.SelectWithRelationship();

        public Book Post<V>(Book obj) where V : AbstractValidator<Book>
        {
            return ((IService<Book>)_baseService).Post<V>(obj);
        }

        public Book Put<V>(Book obj) where V : AbstractValidator<Book>
        {
            return ((IService<Book>)_baseService).Put<V>(obj);
        }

        public void Delete(int id)
        {
            ((IService<Book>)_baseService).Delete(id);
        }
    }
}
