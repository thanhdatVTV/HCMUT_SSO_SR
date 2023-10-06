using storemanager.Application.ViewModels.ResultView;
using storemanager.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storemanager.Application.Services.Interfaces
{
    public interface IproductsService
    {
        public Task<ResultViewModel> Create(string Name, string Price);
        public Task<ResultViewModel> GetList();
        public Task<ResultViewModel> GetId(Guid guid);

        public Task<ResultViewModel> GetName(string name);
    }
}
