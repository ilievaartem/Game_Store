using Game_Store.Models;
using Game_Store.Views.Pages.Account;
using Microsoft.AspNetCore.Identity;

namespace Game_Store.Controllers;

public class UserController
{
    private readonly UserManager<UserDetails> _userManager;
    private readonly SignInManager<UserDetails> _signInManager;

    public UserController(UserManager<UserDetails> userManager, SignInManager<UserDetails> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterUser(Register.RegisterModel model)
    {
        var user = new UserDetails() { UserName = model.Username };
        var result = await _userManager.CreateAsync(user, model.Password);
        return result;
    }

    public async Task<SignInResult> LoginUser(Login.LoginModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        return result;
    }
}
