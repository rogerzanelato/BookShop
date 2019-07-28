using System;
using System.Collections.Generic;
using BookShop.Domain.Entities;
using BookShop.Domain.Interfaces;
using BookShop.Domain.Repository;
using FluentValidation;

namespace BookShop.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        protected virtual IRepository<T> _repository { get; set; }
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);
            return obj;
        }

        public virtual T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }

        public virtual void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero");

            _repository.Delete(id);
        }

        public virtual T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero");

            return _repository.Select(id);
        }

        public virtual IList<T> Get() => _repository.Select();

        protected virtual void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
