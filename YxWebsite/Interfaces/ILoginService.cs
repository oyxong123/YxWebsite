using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILoginService
    {
        Task<bool> VerifyLogin(LoginDto loginDto);
        Task<bool> SignUp(LoginDto signUpDto);
    }
}
