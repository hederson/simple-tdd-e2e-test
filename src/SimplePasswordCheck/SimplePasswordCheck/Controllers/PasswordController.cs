using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplePasswordCheck.Core.Password.Application.Dto;
using SimplePasswordCheck.Core.Password.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Controllers
{
    [Route("api/password")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordValidatorAppService passwordAppService;

        public PasswordController(IPasswordValidatorAppService passwordAppService)
        {
            this.passwordAppService = passwordAppService;
        }
        /// <summary>
        /// Check if password has one digit, one lower letter, one upper letter and at least one special character (!@#$%^&amp;*()-+) 
        /// and hasn`t space and duplicated characters        
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /validate
        ///     {
        ///        "password": "23dciewdun2834u"
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("validate")]
        [Produces("application/json")]
        public ActionResult<PasswordValidationResponse> Validate(PasswordValidationRequest request)
        {
            return Ok(passwordAppService.Validate(request)); 
        }
    }
}
