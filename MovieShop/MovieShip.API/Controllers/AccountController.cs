using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel model) 
        {
            if (ModelState.IsValid)
            {
                //save to db, register user
                var createdUser = await _userService.RegisterUser(model);
                //201 created 
                return Ok(createdUser);
            }
            //400
            return BadRequest("Please check the data you entered");
        }
        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<ActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserDetails(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.Login(model.Email, model.Password);
                return Ok(user);
            }
            return BadRequest("Please check the data you entered");
        }
    }
}
