namespace API.Controllers
{
    using DTOModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Models.Configuration;
    using Models.Models;
    using Operations.IOperations;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserOperations userService;
        private readonly IConfiguration configuration;
        public UserController(ILogger<UserController> logger, IUserOperations userService, IConfiguration configuration) 
            : base(logger)
        {
            this.logger = logger;
            this.userService = userService;
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ApiResponse> Authenticate([FromBody] UserDTO userParam)
        {
            var appSettingsSection = this.configuration.GetSection("JWT");
            var appSettings = appSettingsSection.Get<JWT>();
            var user = await this.userService.Authenticate(userParam.UserName, userParam.Password, appSettings);

            if (user == null)
                return CreateResponse(new UnauthorizedAccessException("Username or password is incorrect"));

            return CreateResponse(user);
        }

        [AllowAnonymous]
        [HttpPost("adduser")]
        public async Task<ApiResponse> AddUser([FromBody] UserDTO userParam)
        {
            var user = await this.userService.AddUser(userParam.UserName, userParam.Password);

            if (user == null)
                return CreateResponse(new UnauthorizedAccessException("Username not created"));

            return CreateResponse(user);
        }

        [AllowAnonymous]
        [HttpPost("adduserrole")]
        public async Task<ApiResponse> AddUserRole(Role roleParam)
        {
            var role = await this.userService.AddRole(roleParam.Name);

            if (!role)
                return CreateResponse(new UnauthorizedAccessException("Username role not created or already exists"));

            return CreateResponse(role);
        }

    }
}
