using System;
using System.Threading.Tasks;

namespace storemanager.Infrastructure.SeedWorks
{
    public interface IUnitOfWork    
    {   
        Task<int> SaveChangeAsync();   
		Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);
    }  
}