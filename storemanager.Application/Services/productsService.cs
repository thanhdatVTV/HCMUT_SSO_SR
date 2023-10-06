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
    public class productsService : BaseService, IproductsService
    {
        private readonly IRepository<Tblproduct> _productRepo;


        public productsService(IUnitOfWork unitOfWork, IRepository<Tblproduct> productRepo) : base(unitOfWork)
        {
            _productRepo = productRepo;
        }
        public async Task<ResultViewModel> Create(string Name, string Price)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                Guid id = Guid.NewGuid();
                var customer = new Tblproduct(id, Name, Price);
                _productRepo.Add(customer);
                await UnitOfWork.SaveChangeAsync();
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> GetId(Guid id)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {

                var customer = _productRepo.GetAsyncId(id).Result;
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "Lỗi thêm dữ liệu " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> GetList()
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var customer = _productRepo.GetAsync().Result;
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> GetName(string name)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {

                var customer = _productRepo.GetAsyncName(name).Result;
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "Lỗi thêm dữ liệu " + ex.Message.ToString();
            }
            return model;
        }
    }
}
