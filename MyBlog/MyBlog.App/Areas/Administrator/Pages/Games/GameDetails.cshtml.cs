namespace MyBlog.App.Areas.Administrator.Pages.Games
{
    using Microsoft.AspNetCore.Mvc;
    using MyBlog.App.Extensions;
    using MyBlog.App.Helpers.Messages;
    using MyBlog.Common;
    using MyBlog.CommonModels.ViewModels.Games;
    using MyBlog.Services.Interfaces;

    public class GameDetailsModel : BasePageModel
    {
        public GameDetailsViewModel GameDetailsViewModel { get; private set; }
        private readonly IGameService gameService;

        public int GameId { get; set; }

        public GameDetailsModel(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public IActionResult OnGet(int id)
        {
            var game = this.gameService.GetGame(id);

            if (game == null)
            {
                this.TempData.Put(CommonConstants.LayoutMessageKey, new MessageModel()
                {
                    Type = MessageType.Danger,
                    Message = CommonConstants.NotFoundMessage
                });
            }

            this.GameId = id;

            this.GameDetailsViewModel = game;

            return this.Page();
        }
    }
}