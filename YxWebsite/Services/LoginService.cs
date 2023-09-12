using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using YxWebsite.Context;
using YxWebsite.Dtos;
using YxWebsite.Interfaces;
using YxWebsite.Models;

namespace YxWebsite.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IMapper _mapper;
        private readonly IAuditTrailsService AuditTrailsService;

        public LoginService(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<bool> VerifyLogin(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                throw new Exception("No login details provided.");
            }
            try
            {
                //verify login

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SignUp(LoginDto signUpDto)
        {
            if (signUpDto == null)
            {
                throw new Exception("No sign up details provided.");
            }

            try
            {
                if (await CheckHasUsernameDuplicated(signUpDto))
                {
                    throw new Exception("Too bad, someone has taken this username earlier than you :{");
                }
                if (!signUpDto.Password.Equals(signUpDto.ConfirmPassword))
                {
                    throw new Exception("Did you have a typo? Because the two passwords you provided are different :/");
                }

                // Encrypt password with sha256 + salt.
                LoginModel _loginModel = _mapper.Map<LoginModel>(signUpDto);
                (_loginModel.Password, _loginModel.Salt) = HashPassword(_loginModel.Password);

                using (ApplicationDbContext _context = _contextFactory.CreateDbContext())
                {
                    await _context.AddAsync(_loginModel);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> CheckHasUsernameDuplicated(LoginDto loginNew)
        {
            try
            {
                using (var _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLogin == null)
                    {
                        throw new Exception("Login Table not initialized.");
                    }

                    // Case insensitive
                    var isLoginCodeExists = await _context.DbLogin.AnyAsync(u => u.Username == loginNew.Username && u.Id != loginNew.Id);

                    return isLoginCodeExists;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private (string, string) HashPassword(string password)
        {
            string salt = GenerateString(4);
            byte[] asByteArray = Encoding.Default.GetBytes(password + salt);
            byte[] hashedPasswordBytes = SHA256.HashData(asByteArray);
            string hashedPassword = Convert.ToBase64String(hashedPasswordBytes);
            return new (hashedPassword, salt);
        }

        private string GenerateString(int length)
        {
            Random Random = new Random();
            string inclusion = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string generatedString = "";
            for (int i = 0; i < length; i++)
            {
                int x = Random.Next(inclusion.Length);  // Select a random index value within the string length of inclusion.
                generatedString = generatedString + inclusion[x];  // Find char from inclusion string using random index, then add it to the generating string.
            }
            return generatedString;
        }
    }
}
