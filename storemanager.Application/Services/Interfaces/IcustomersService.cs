using storemanager.Application.ViewModels.ResultView;
using storemanager.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storemanager.Application.Services.Interfaces
{
    public interface IcustomersService
    {
        public Task<ResultViewModel> Create(string FullName, DateTime DOB, string Email);
        public Task<ResultViewModel> GetList();
        public Task<ResultViewModel> GetId(Guid guid);
    }
}
