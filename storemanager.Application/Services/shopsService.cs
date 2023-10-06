using storemanager.Application.SeedWorks;
using storemanager.Application.Services.Interfaces;
using storemanager.Application.ViewModels.ResultView;
using storemanager.Entity.Entities;
using storemanager.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storemanager.Application.Services
{
    public class shopsService : BaseService, IshopsService
    {
        private readonly IRepository<Tblshop> _customerRepo;


        public shopsService(IUnitOfWork unitOfWork, IRepository<Tblshop> customerRepo) : base(unitOfWork)
        {
            _customerRepo = customerRepo;
        }
        public async Task<ResultViewModel> Create( string Name, string Location)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                Guid id = Guid.NewGuid();
                var customer = new Tblshop(id, Name, Location);
                _customerRepo.Add(customer);
                await UnitOfWork.SaveChangeAsync();
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message ="Lỗi thêm dữ liệu "+ ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> GetId(Guid id)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                
                var customer=_customerRepo.GetAsyncId(id).Result;                
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "Lỗi thêm dữ liệu " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> GetListShop()
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var customer = _customerRepo.GetAsync().Result;               
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = ex.Message.ToString();
            }
            return model;
        }
    }
}
