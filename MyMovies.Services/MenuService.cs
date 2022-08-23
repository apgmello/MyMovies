using ConsoleTools;
using MyMovies.Entities;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Services
{
    public class MenuService
    {
        private readonly IRepository<Movie> _toWatchRepositoryApi;
        private readonly IRepository<Movie> _watchedRepositoryApi;

        public MenuService(IRepository<ToWatch> toWatchRepositoryApi, IRepository<Watched> watchedRepositoryApi)
        {
            _toWatchRepositoryApi = (IRepository<Movie>)toWatchRepositoryApi;
            _watchedRepositoryApi = (IRepository<Movie>)watchedRepositoryApi;
        }

        public void InitializeMenu()
        {
            var menu = new ConsoleMenu()
                  .Add("1 - Filmes para assistir", () => SubMenu("Filmes para assistir", _toWatchRepositoryApi))
                  .Add("2 - Filmes assistidos", () => SubMenu("Filmes assistidos", _watchedRepositoryApi))
                  .Add("3 - Sair", ConsoleMenu.Close)
                  .ConfigureMenu("Selecione uma opção");

            menu.Show();
        }
        public void SubMenu(string title, IRepository<Movie> repository)
        {
            var menu = new ConsoleMenu();
            menu.Show();
        }
    }
}
