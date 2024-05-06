using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Model.Interfaces
{
    public interface IRateRepository
    {
        IEnumerable<Rate> GetAll();
        void Add(Rate rate);
        void Update(Rate rate);
        void Delete(Rate rate);
    }
}
