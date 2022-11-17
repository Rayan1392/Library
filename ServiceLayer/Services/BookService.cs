using DomainLayer.Models;
using RepositoryLayer.IRepository;
using ServiceLayer.Contracts;

namespace ServiceLayer.Services
{
    public class BookService : IBookService<Book>
    {
        private readonly IRepository<Book> _bookRepository;
        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public void Delete(Book entity)
        {
            try
            {
                if (entity != null)
                {
                    _bookRepository.Delete(entity);
                    _bookRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Book Get(int Id)
        {
            try
            {
                var obj = _bookRepository.Get(Id);
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

        public IEnumerable<Book> GetAll()
        {
            try
            {
                var obj = _bookRepository.GetAll();
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

        public void Insert(Book entity)
        {
            try
            {
                if (entity != null)
                {
                    _bookRepository.Insert(entity);
                    _bookRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(Book entity)
        {
            try
            {
                if (entity != null)
                {
                    _bookRepository.Remove(entity);
                    _bookRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Update(Book entity)
        {
            try
            {
                if (entity != null)
                {
                    _bookRepository.Update(entity);
                    _bookRepository.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
