using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Configuration;
using Models.Models;
using Operations.IOperations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Operations
{
    public class UserOperations : IUserOperations
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private readonly IConfiguration _appSettings;

        private RoleManager<IdentityRole> _roleManager;
        public UserOperations(SignInManager<User> signInManager, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<User> Authenticate(string username, string password, JWT key)
        {
            var pwdCheck = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (!pwdCheck.Equals(SignInResult.Success))
                return null;

            //---------------------
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key.Secret));

            var token = new JwtSecurityToken(
                issuer: key.ValidIssuer,
                audience: key.ValidAudience,
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );


            user.Token = new JwtSecurityTokenHandler().WriteToken(token);
            await _userManager.UpdateAsync(user);

            // remove password before returning
            user.PasswordHash = null;
            user.SecurityStamp = null;

            //---------------------

            user = await _userManager.FindByNameAsync(username);
            return user;

        }

        public async Task<User> AddUser(string username, string password)
        {
            var user = new User();
            user.UserName = username;
            user.Password = password;
            var hashedPwd = _userManager.PasswordHasher.HashPassword(user, password);
            user.PasswordHash = hashedPwd;

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                user = await _userManager.FindByNameAsync(username);

                bool x = await _roleManager.RoleExistsAsync("Admin");
                if (!x)
                {
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    await _roleManager.CreateAsync(role);
                }
                if (user != null)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }
                return user;

                //result = await _userManager.AddLoginAsync(user, null);
            }

            return user;

        }

        public async Task<bool> AddRole(string rolename)
        {
            bool x = await _roleManager.RoleExistsAsync(rolename);
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = rolename;
                var addedrole = await _roleManager.CreateAsync(role);
                return true;
            }
            return false;
        }

       
    }
}
