using _9.Model.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace _9.Model.Repository
{
    public class ComputerRepository : IComputerRepository
    {
        private readonly ClubContext context;

        public ComputerRepository(ClubContext context)
        {
            this.context = context;
        }

        public IEnumerable<Computer> GetAll()
        {
            return context.Computers.ToList();
        }

        public void Add(Computer computer)
        {
            context.Computers.Add(computer);
            context.SaveChanges();
        }

        public void Update(Computer computer)
        {
            context.Entry(computer).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Computer computer)
        {
            context.Computers.Remove(computer);
            context.SaveChanges();
        }
    }
}
