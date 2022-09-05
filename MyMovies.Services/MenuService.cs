using ConsoleTables;
using ConsoleTools;
using MyMovies.Entities;
using MyMovies.Repositories.Api.Interfaces;
using MyMovies.Repositories.Interfaces;
using Sharprompt;

namespace MyMovies.Services
{
    public class MenuService
    {
        private readonly IToWatchRepository _toWatchRepositoryApi;
        private readonly IWatchedRepository _watchedRepositoryApi;

        public MenuService(IToWatchRepository toWatchRepositoryApi, IWatchedRepository watchedRepositoryApi)
        {
            _toWatchRepositoryApi = toWatchRepositoryApi;
            _watchedRepositoryApi = watchedRepositoryApi;
        }

        public void InitializeMenu()
        {
            var menu = new ConsoleMenu()
                  .Add("Filmes para assistir", () => SubMenu<ToWatch>("Filmes para assistir", _toWatchRepositoryApi))
                  .Add("Filmes assistidos", () => SubMenu<Watched>("Filmes assistidos", _watchedRepositoryApi))
                  .Add("Sair", ConsoleMenu.Close)
                  .ConfigureMenu("Selecione uma opção");

            menu.Show();
        }

        public void SubMenu<T>(string title, IRepository<T> repository)
            where T : Movie
        {
            var menu = new ConsoleMenu()
                .Add("Listar", () => List(repository))
                .Add("Buscar", () => Saerch(repository))
                .Add("Adicionar", () => AddMovie(repository))
                .Add("Remover", () => RemoveMovie(repository))
                .Add("Alterar", () => ChangeMovie(repository))
                .Add("Voltar", ConsoleMenu.Close)
                .ConfigureMenu(title);
            menu.Show();
        }

        private void List<T>(IRepository<T> repository)
            where T : Movie
        {
            Console.Clear();
            var movies = repository.ReadAll();

            if (movies.Count == 0)
            {
                Console.WriteLine("A lista está vazia");
                Console.ReadKey();
                return;
            }

            ConsoleTable
                .From(movies)
                .Write(Format.Minimal);

            Console.ReadKey();
        }

        private void RemoveMovie<T>(IRepository<T> repository)
            where T : Movie
        {
            Console.Clear();
            var movies = repository.ReadAll();

            if (movies.Count == 0)
            {
                Console.WriteLine("A lista está vazia");
                Console.ReadKey();
                return;
            }

            var movie = Prompt.Select("Selecione o filme a ser removido", movies.Select(m => new { m.Id, m.Title }));
            repository.Delete(movie.Id);
        }

        private void AddMovie<T>(IRepository<T> repository)
            where T : Movie
        {
            T movie = (T)Activator.CreateInstance(typeof(T));
            Console.Clear();
            movie = Prompt.Bind(movie);
            repository.Create(movie);
        }

        private void ChangeMovie<T>(IRepository<T> repository)
            where T : Movie
        {
            Console.Clear();
            var movies = repository.ReadAll();

            if (movies.Count == 0)
            {
                Console.WriteLine("A lista está vazia");
                Console.ReadKey();
                return;
            }

            var option = Prompt.Select("Selecione o filme a ser alterado", movies.Select(x => new { Id = x.Id, Title = x.Title }));
            var movie = repository.Read(option.Id);

            movie = Prompt.Bind(movie);
            repository.Update(movie);
        }
        public void Saerch<T>(IRepository<T> repository)
            where T : Movie
        {
            Console.Clear();
            var title = Prompt.Input<string>("Digite o título ou uma parte", validators: new[] { Validators.Required("Valor obrigatório!")});

            var movies = repository.Search(title);

            if (movies.Count == 0)
            {
                Console.WriteLine($"Nenhum filme encontrado com o título: {title}");
                Console.ReadKey();
                return;
            }

            ConsoleTable
                .From(movies)
                .Write(Format.Minimal);

            Console.ReadKey();
        }
    }
}
