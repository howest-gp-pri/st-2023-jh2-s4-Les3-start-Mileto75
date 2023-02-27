using Microsoft.AspNetCore.Mvc;
using Pri.Ca.Core.Interfaces.Services;
using Wba.MyfirstWebapp.Web.ViewModels;

namespace Wba.MyfirstWebapp.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            GamesIndexViewModel gamesIndexViewModel = new();

            //access service layer
            var result = await _gameService.GetAllAsync();
            if(!result.Issuccess) 
            {
                //pass error to view
                gamesIndexViewModel.IsSuccess = false;
                gamesIndexViewModel.Errors = result.ValidationErrors.Select(v => v.ErrorMessage);
                return View(gamesIndexViewModel);
            }
            gamesIndexViewModel.Games = result.Games.Select(r => new BaseViewModel 
            {
                Id =  r.Id,
                Name = r.Name,
                
            });
            gamesIndexViewModel.IsSuccess = true;

            var sales = await _gameService.GetTopSalesAsync();
            return View(gamesIndexViewModel);
        }
    }
}
