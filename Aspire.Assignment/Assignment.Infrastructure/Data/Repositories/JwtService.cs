using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Assignment.Contracts.Data.Entities.Identity;
using Assignment.Contracts.Data.Repositories;
using Assignment.Contracts.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Assignment.Infrastructure.Data.Repositories
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AuthenticationResponse CreateJwtToken(ApplicationUser applicationUser){
            //step1: Get the Expiration time from the appsettings
            //step2: Configure all your claims
            //step3: Create a symmetric security Key
            //step4: Configure your signing credentitals ie Signature
            //Step5: Create the tokenDescriptor instance and provide the necessary fields to generate your token.
            //step5: Create tokenHandler instance to generate the token

            DateTime expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Authentication:Jwt:EXPIRATION_TIME"]));

            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                // new Claim(ClaimTypes.Name, (applicationUser.PersonName == null)?"":applicationUser.PersonName),
                new Claim(ClaimTypes.Name,applicationUser.PersonName ?? applicationUser.UserName), //Simplified the above ternary operation using null coalesce operator.
                new Claim(ClaimTypes.Email, applicationUser.Email)
            };

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Jwt:Secret"]));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            // Creating the tokengenerator Object and make it ready to generate the token
            // JwtSecurityToken tokenGenerator = new JwtSecurityToken(
            //     _configuration["Jwt:Issuer"],
            //     _configuration["Jwt:Audience"],
            //     claims,
            //     expires:expiration,
            //     signingCredentials:signingCredentials
            // );

            var tokenDescriptor = new SecurityTokenDescriptor(){
                Audience = _configuration["Authentication:Jwt:ValidAudience"],
                Issuer = _configuration["Authentication:Jwt:ValidIssuer"],
                Subject = new ClaimsIdentity(claims),
                Expires = expiration,
                SigningCredentials = signingCredentials
            };
            

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.CreateEncodedJwt(tokenDescriptor);

            return new AuthenticationResponse(){
                Token = token,
                PersonName = applicationUser.PersonName,
                Email = applicationUser.Email
            };

        }
    }
}