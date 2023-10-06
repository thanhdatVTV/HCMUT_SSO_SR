using storemanager.Application.ViewModels.ResultView;
using storemanager.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storemanager.Application.Services.Interfaces
{
    public interface IshopsService
    {
        public Task<ResultViewModel> Create(string Name, string Location);
        public Task<ResultViewModel> GetId(Guid id);
        public Task<ResultViewModel> GetListShop();

    }
}
