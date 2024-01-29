using DrugStore4.DrugStoreDb;
using DrugStore4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore4.Controllers
{
    
    public class RegistrationController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody] RegistrationModel registrationModel)
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
                else if ((await _userManager.FindByEmailAsync(registrationModel.Email)) != null)
                {
                    result.Code = 1;
                    result.Message = "Пользователь с таким почтовым ящиком (Email) уже зарегистрирован.";
                    return new JsonResult(result);
                }
                DrugStoreDb.User userIdentity = new DrugStoreDb.User()
                {
                    UserName = registrationModel.Email,
                    Email = registrationModel.Email,
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
    }
}
