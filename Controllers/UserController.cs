using System.Security.Cryptography;
using heinousHorror.Helper;
using heinousHorror.Model;
using heinousHorror.Model.Game;
using heinousHorror.Model.TV;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static heinousHorror.Logic.UserProcessor;
using heinousHorror.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace heinousHorror.Controllers
{   [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuthenticationManger _jwtAuthenticationManager;

        public UserController(IJwtAuthenticationManger jwtAuthenticationManager)
        {
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [AllowAnonymous]
        [Route("api/user/createUser")]
        [HttpPost]
        public int SignUp([FromForm] User model)
        {
            if (!ModelState.IsValid)
                return 0;

            PasswordWithSaltHasher passwordHash = new PasswordWithSaltHasher();
            var hashWithSalt = passwordHash.HashWithSalt(model.Password, SHA256.Create(), saltLength:64);
            var password = hashWithSalt.Digest;
            var salt = hashWithSalt.Salt;
            var recordsCreated = CreateUser(model.Name, model.Email, password, salt);
            
            return recordsCreated;
        }

        [AllowAnonymous]
        [Route("api/user/login")]
        [HttpPost]
        public IActionResult Login([FromForm] User model)
        {
            var user = GetUserByName(model.Name);
            if (user.Password == null)
            {
                return Unauthorized();
            }
            var passwordHash = new PasswordWithSaltHasher();
            var isPasswordMatched = passwordHash.VerifyPassword(model.Password, user.Password, user.Salt, SHA256.Create());
            if (isPasswordMatched == false)
            {
                return Unauthorized();
            }
            var token = _jwtAuthenticationManager.Authenticate(model.Name, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);

            //Authorize , https://www.youtube.com/watch?v=vWkPdurauaA
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User userCred)
        {
            var token =_jwtAuthenticationManager.Authenticate(userCred.Name, userCred.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [Route("api/user/{id}")]
        [HttpGet]
        public string GetUserById(int? id)
        {
            if (id == null)
                return null;

            var userId = (int) id;
            var userData = GetUser(userId);
            return JsonConvert.SerializeObject(userData);
        }

        [Route("api/favorites/{id}")]
        [HttpGet]
        public string GetUserFavorites(int? id)
        {
            if (id == null)
                return null;

            var userId = (int)id;
            var userData = GetFavorites(userId);
            return JsonConvert.SerializeObject(userData);
        }

        [Route("api/user/{id}/favorites/movies")]
        [HttpPost]
        public int AddFavoriteMovie(int? id, [FromBody] Movies model)
        {
            if (!ModelState.IsValid)
                return 0;

            if (id == null)
                return 0;

            var userId = (int) id;
            var recordsCreated = CreateFavoriteMovie(model.Id, model.Poster_path, model.Original_title, model.Vote_average, userId);

            return recordsCreated;
        }

        [Route("api/user/{id}/favorites/tv")]
        [HttpPost]
        public int AddFavoriteTv(int? id, [FromBody] TvSeries model)
        {
            if (!ModelState.IsValid)
                return 0;

            if (id == null)
                return 0;

            var userId = (int)id;
            var recordsCreated = CreateFavoriteTv(model.Id, model.Poster_path, model.Original_name, model.Vote_average, userId);

            return recordsCreated;
        }

        [Route("api/user/{id}/favorites/games")]
        [HttpPost]
        public int AddFavoriteGame(int? id, [FromBody] Games model)
        {
            if (!ModelState.IsValid)
                return 0;

            if (id == null)
                return 0;

            var userId = (int)id;
            var recordsCreated = CreateFavoriteGame(model.Id, model.Cover, model.Name, model.Total_rating, userId);

            return recordsCreated;
        }
    }
}