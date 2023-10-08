using HCMUT_SSO.ViewModels.ResultView;

namespace HCMUT_SSO.Interfaces
{
    public interface IUserRepository
    {
        public Task<ResultViewModel> CheckUser(string userName, string password);
    }
}
