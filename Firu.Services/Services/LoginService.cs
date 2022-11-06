using Firu.Data.Extensions;
using Firu.Services.Helpers;
using Firu.Services.Interfaces;
using Firu.Services.Parameters.Login;
using Firu_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Firu_Core.Entities;
using Firu.Data.dbContext;

namespace Firu.Services.Services
{
    public class LoginService: ILoginService
    {
        private readonly FiruDBContext _context;
        protected readonly IMapper _mapper;

        public LoginService(
            FiruDBContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetLoggedResponse> Get(GetLoggedRequest request)
        {
            var response = new GetLoggedResponse();

            if ((request.EmailOrUser) != null && (request.EmailOrUser) != "" && (request.Password) != null && (request.Password) != "")
            {
                var predicate = PredicateBuilder.True<UserInfo>();

                predicate = predicate.And(c => c.UserName.Contains(request.EmailOrUser) || c.Email.Contains(request.EmailOrUser));

                predicate = predicate.And(c => c.Password.Contains(request.Password));

                var exists = await _context.Set<UserInfo>()
                    .Where(predicate)
                    .FirstOrDefaultAsync();

                if (exists != null)
                {
                    response.Login = true;

                    var newUser = new UserInfoDto()
                    {
                        UserId = exists.UserId,
                        FirstName = exists.FirstName,
                        LastName = exists.LastName,
                        UserName = exists.UserName,
                        Email = exists.Email
                    };

                    response.UserLogged = _mapper.Map<UserInfoDto>(newUser);

                }
            }

            return response;
        }

        public async Task<GetCheckingExistentFieldsResponse> Get(GetCheckingExistentFieldsRequest request)
        {
            var response = new GetCheckingExistentFieldsResponse();

            if ((request.UserName) != null && (request.UserName) != "")
            {
                var predicate = PredicateBuilder.True<UserInfo>();

                predicate = predicate.And(c => c.UserName.Contains(request.UserName));

                var exists = await _context.Set<UserInfo>()
                    .Where(predicate)
                    .FirstOrDefaultAsync();

                if (exists != null)
                {
                    response.UserName = true;
                }
            }

            if ((request.Email) != null && (request.Email) != "")
            {
                var predicate = PredicateBuilder.True<UserInfo>();

                predicate = predicate.And(c => c.Email.Contains(request.Email));

                var exists = await _context.Set<UserInfo>()
                    .Where(predicate)
                    .FirstOrDefaultAsync();

                if (exists != null)
                {
                    response.Email = true;
                }
            }
            return response;
        }

        public async Task<PostUserResponse> Post(PostUserRequest request)
        {
            var response = new PostUserResponse();

            var holdUser = new UserInfo()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
            };

            if (request.Email != null)
            {
                _context.UserInfo.Add(holdUser);
                await _context.SaveChangesAsync();
            }

            return response;
        }
    }
}
