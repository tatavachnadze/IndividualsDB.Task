using TBC.Services.Interfaces.Repositories;

namespace TBC.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TbcDbContext _context;

        private readonly Lazy<IIndividualRepository> _individualsRepository;
        private readonly Lazy<ICityRepository> _cityRepository;

        public UnitOfWork(TbcDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(context));
        }

        public IIndividualRepository IndividualsRepository => _individualsRepository.Value;

        public ICityRepository CityRepository => _cityRepository.Value;

        public int SaveChanges() => _context.SaveChanges();

        public void BeginTransaction()
        {
            if (_context.Database.CurrentTransaction != null) //database abrunebs databasefacade-is obiekts romlitac shemdeg database-is sxvadasxva punkciebze gavdivart mat shoris
            {
                throw new InvalidOperationException("A Transaction is already in progress.");
            }

            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _context.Database.CurrentTransaction?.Commit();
            }
            catch
            {
                _context.Database.CurrentTransaction?.Rollback();
                throw;
            }
            finally
            {
                _context.Database.CurrentTransaction?.Dispose();
            }
        }

        public void RollBack()
        {
            try
            {
                _context.Database.CurrentTransaction?.Rollback();
            }
            finally
            {
                _context.Database.CurrentTransaction?.Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
