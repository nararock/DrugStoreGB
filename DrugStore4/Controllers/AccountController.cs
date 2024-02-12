using DrugStore4.DrugStoreDb;
using DrugStore4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore4.Controllers
{
    
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Registrate([FromBody] RegistrationModel registrationModel)
        {
            CommonResponse result = new CommonResponse();
            try
            {

                if (registrationModel == null || registrationModel.Email == null || registrationModel.Password == null)
                {
                    result.Code = 1;
                    result.Message = "Все поля должны быть заполнены.";
                    return new JsonResult(result);
                }
                else if (registrationModel.Password != registrationModel.DoublePassword)
                {
                    result.Code = 1;
                    result.Message = "Введенные пароли не совпадают.";
                    return new JsonResult(result);
                }
                else if ((await _userManager.FindByEmailAsync(registrationModel.Email)) != null)
                {
                    result.Code = 1;
                    result.Message = "Пользователь с таким почтовым ящиком (Email) уже зарегистрирован.";
                    return new JsonResult(result);
                }
                DrugStoreDb.User userIdentity = new DrugStoreDb.User()
                {
                    Nickname = registrationModel.Nickname,
                    UserName = registrationModel.Email,
                    Email = registrationModel.Email,
                    PhoneNumber = registrationModel.Telephone,
                    City = registrationModel.City,
                    District = registrationModel.District,
                    EmailConfirmed = true
                };
                var answer = await _userManager.CreateAsync(userIdentity, registrationModel.Password);

                if (answer.Succeeded)
                {
                    result.Code = 0;
                    result.Message = "Регистрация завершена.";
                    return new JsonResult(result);
                }
                foreach (var item in answer.Errors)
                {
                    result.Message += item.Description + " ";
                }
                result.Code = 1;
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                result.Code = 1;
                result.Message = e.Message + " Произошла ошибка, попробуйте еще раз.";
                return new JsonResult(result);
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginModel loginModel)
        {
            CommonResponse result = new CommonResponse();
            if (loginModel.Email == null || loginModel.Password == null)
            {
                result.Code = 1;
                result.Message = "Все поля должны быть заполнены.";
                return new JsonResult(result);
            }
            var answer = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, true, false);
            if (answer.Succeeded)
            {
                result.Code = 0;
                result.Message = "Регистрация завершена.";
                return new JsonResult(result);
            }
            result.Code = 1;
            result.Message = "Ваша почта или пароль не верны.";
            return new JsonResult(result);
        }

        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
