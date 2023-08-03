using BlazorCrud.Web.Models;
using BlazorCrud.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Web.Services
{
    public interface IPersonService
    {
        Task<bool> AddUpdate(Person person);
        Task<bool> Delete(string personId);
        Task<Person> FindById(string personId);
        Task<List<Person>> GetAll();
    }

    public class PersonService : IPersonService
    {
        private readonly DBContext _dbContext;

        public PersonService(DBContext dbContext) => _dbContext = dbContext;
        public async Task<bool> AddUpdate(Person person)
        {
            try
            {
                if (person.PersonId == null)

                    await _dbContext.Person.AddAsync(person);
                else
                    _dbContext.Person.Update(person);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public async Task<bool> Delete(string personId)
        {
            try
            {
                var person = await FindById(personId);
                _dbContext.Person.Remove(person);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<Person> FindById(string personId)
        {
            return await _dbContext.FindAsync<Person>(Guid.Parse(personId)) ?? new Person();
        }

        public async Task<List<Person>> GetAll()
        {
            return await _dbContext.Person.ToListAsync();
        }
    }
}
