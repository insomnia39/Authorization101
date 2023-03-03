using Authorization101.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using System.Linq;
using Authorization101.Token;

namespace Authorization101
{
    public static class AuthenticationController
    {
        [FunctionName("login")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "login")] User user,
            ILogger log)
        {
            #region input validation
            if (user == null) throw new Exception("Payload is missing");
            if (string.IsNullOrEmpty(user.Name)) throw new Exception("Name is missing");
            if (string.IsNullOrEmpty(user.Password)) throw new Exception("Password is missing");
            #endregion

            User dummyUser = Data.DummyUsers.FindUser(user.Name, user.Password)
                ?? throw new Exception("User not found");

            var jwt = TokenController.GenerateToken(dummyUser.Id);

            return new OkObjectResult(jwt);
        }
    }
}
