using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YxWebsite.Context;
using YxWebsite.Dtos;
using YxWebsite.Interfaces;

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
            //verify login

            return true;
        }
    }
}
