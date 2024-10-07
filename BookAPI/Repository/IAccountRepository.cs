using BookAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(LoginModel loginModel);

    }

}