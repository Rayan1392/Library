using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class AuthorService : IAuthorService<Author>
    {
        private readonly IRepository<Author> _authorRepository;
        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public void Delete(Author entity)
        {
            try
            {
                if (entity != null)
                {
                    _authorRepository.Delete(entity);
                    _authorRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Author Get(int Id)
        {
            try
            {
                var obj = _authorRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Author> GetAll()
        {
            try
            {
                var obj = _authorRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Insert(Author entity)
        {
            try
            {
                if (entity != null)
                {
                    _authorRepository.Insert(entity);
                    _authorRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(Author entity)
        {
            try
            {
                if (entity != null)
                {
                    _authorRepository.Remove(entity);
                    _authorRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(Author entity)
        {
            try
            {
                if (entity != null)
                {
                    _authorRepository.Update(entity);
                    _authorRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
