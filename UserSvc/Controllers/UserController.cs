﻿using UserSvc.Models;
using UserSvc.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UserSvc.Repositories;
using UserSvc.vmModel;

namespace UserSvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            
            var result = await _userRepository.GetUsersAsync();
            if (result == null)
            {
                return NotFound();
            }

            var vmRes = new vmUser();
            vmRes.users = result;
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var result = await _userRepository.GetUserByIdAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        //[Authorize(Roles = "Administrator,User")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new User
            (
                request.FullName,
                request.Email,
                request.Password,
                1,
                1
            );
            await _userRepository.AddUserAsync(newUser);
            return CreatedAtAction(nameof(CreateUser), new { Id = newUser.Id,status="Success",message="User registration successful!" });
        }

        [Route("UpdateUser"),HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] UserByIdRequest? request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var newUser = new User
            //(
            //    request.Id,
            //    request.FullName,
            //    request.Email,
            //    request.Password,
            //    2,
            //    2
            //);
            await _userRepository.UpdateUserAsync(request);
            return CreatedAtAction(nameof(CreateUser), new { Id = request.Id, status = "Success", message = "Successfully updated user!" });
        }
    }
}
