using NewApi.Persistence.Ef;
using Taav.Contracts.Interfaces;

namespace ComplexProject.Persistence.Ef
{
    public class EFUnitOfWork : UnitOfWork
    {
		private readonly EfDataContext _dataContext;

		public EFUnitOfWork(EfDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task Begin() // start transaction
		{
			await _dataContext.Database.BeginTransactionAsync();
		}

		public async Task CommitPartial()// complete project between mission
		{
			await _dataContext.SaveChangesAsync();
		}

		public async Task Commit() // end transaction and complete
		{
			await _dataContext.SaveChangesAsync();
			await _dataContext.Database.CommitTransactionAsync();
		}

		public async Task Rollback() // all mission must complete or none of them must not
		{
			await _dataContext.Database.RollbackTransactionAsync();
		}

		public async Task Complete() // complete mission after all codes
		{
			await _dataContext.SaveChangesAsync();
		}
	}
}
