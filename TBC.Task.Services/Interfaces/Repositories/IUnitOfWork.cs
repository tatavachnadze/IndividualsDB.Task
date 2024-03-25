namespace TBC.Services.Interfaces.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IIndividualRepository IndividualsRepository { get; }
		ICityRepository CityRepository { get; }
		int SaveChanges();
		void BeginTransaction();
		void CommitTransaction();
		void RollBack();
	}
}
