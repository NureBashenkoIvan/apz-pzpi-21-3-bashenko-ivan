using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class UserService : IUserService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private User? _user;

        public UserService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager,
            IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

            return usersDto;
        }

        public async Task<IdentityResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                _logger.LogError($"User with ID {userId} not found.");
                return IdentityResult.Failed(new IdentityError { Description = $"User with ID {userId} not found." });
            }

            var rolesForUser = await _userManager.GetRolesAsync(user);

            foreach (var role in rolesForUser)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, role);
                if (!result.Succeeded)
                {
                    _logger.LogError($"Failed to remove user {user.Id} from role {role}.");
                    return result;
                }
            }

            var resultDelete = await _userManager.DeleteAsync(user);

            if (!resultDelete.Succeeded)
            {
                _logger.LogError($"Failed to delete user {user.Id}.");
            }

            return resultDelete;
        }
    }
}
