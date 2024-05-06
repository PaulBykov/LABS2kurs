using _9.Model.Interfaces;


namespace _9.Model.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClubContext context;
        private IComputerRepository computerRepository;
        private IRateRepository rateRepository;

        public UnitOfWork(ClubContext context)
        {
            this.context = context;
        }

        public IComputerRepository Computers
        {
            get
            {
                if (computerRepository == null)
                {
                    computerRepository = new ComputerRepository(context);
                }
                return computerRepository;
            }
        }

        public IRateRepository Rates
        {
            get
            {
                if (rateRepository == null)
                {
                    rateRepository = new RateRepository(context);
                }
                return rateRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

}
