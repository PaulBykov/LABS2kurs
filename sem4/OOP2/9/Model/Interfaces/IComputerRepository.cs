using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Model.Interfaces
{
    public interface IComputerRepository
    {
        IEnumerable<Computer> GetAll();
        void Add(Computer computer);
        void Update(Computer computer);
        void Delete(Computer computer);
    }
}
