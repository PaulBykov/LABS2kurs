using System;


namespace _9.Model.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IComputerRepository Computers { get; }
        IRateRepository Rates { get; }
        void Save();
    }
}
