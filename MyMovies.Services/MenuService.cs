using ConsoleTables;
using ConsoleTools;
using MyMovies.Entities;
using MyMovies.Entities.Dto;
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
                  .Add("Filmes para assistir", () => SubMenu("Filmes para assistir", _toWatchRepositoryApi))
                  .Add("Filmes assistidos", () => SubMenu("Filmes assistidos", _watchedRepositoryApi))
                  .Add("Sair", ConsoleMenu.Close)
                  .ConfigureMenu("Selecione uma opção");

            menu.Show();
        }

        public void SubMenu<T, TDto>(string title, IRepository<T, TDto> repository)
            where T : Movie
            where TDto : Dto
        {
            var menu = new ConsoleMenu()
                .Add("Listar", () => List(repository))
                .Add("Buscar", () => Search(repository))
                .Add("Adicionar", () => AddMovie(repository))
                .Add("Remover", () => RemoveMovie(repository))
                .Add("Alterar", () => ChangeMovie(repository))
                .Add("Voltar", ConsoleMenu.Close)
                .ConfigureMenu(title);
            menu.Show();
        }

        private void List<T, TDto>(IRepository<T, TDto> repository)
            where T : Movie
            where TDto : Dto
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

        private void RemoveMovie<T, TDto>(IRepository<T, TDto> repository)
            where T : Movie
            where TDto : Dto
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

        private void AddMovie<T, TDto>(IRepository<T, TDto> repository)
            where T : Movie
            where TDto : Dto
        {
            var movie = Activator.CreateInstance<T>();
            Console.Clear();
            movie = Prompt.Bind(movie);
            repository.Create(movie);
        }

        private void ChangeMovie<T, TDto>(IRepository<T, TDto> repository)
            where T : Movie
            where TDto : Dto
        {
            Console.Clear();
            var movies = repository.ReadAll();

            if (movies?.Count == 0 || movies is null)
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
        public void Search<T, TDto>(IRepository<T, TDto> repository)
            where T : Movie
            where TDto : Dto
        {
            Console.Clear();
            var search = Activator.CreateInstance<TDto>();
            Console.WriteLine("Entre com os dados para a pesquisa");
            search = Prompt.Bind(search);
            search.Page = 1;
            search.MaxResults = 5;

            List<T> movies;
            do
            {
                movies = repository.Search(search);

                if (movies?.Count == 0 || movies is null)
                {
                    if (search.Page == 1)
                    {
                        Console.WriteLine($"Nenhum filme encontrado com os filtros informados");
                        Console.ReadKey();
                    }
                    return;
                }
                Console.Clear();
                ConsoleTable
                    .From(movies)
                    .Write(Format.Minimal);

                if (movies.Count == search.MaxResults)
                {
                    search.Page++;
                    Console.WriteLine("Pressione uma tecla");
                    Console.ReadKey();
                }
            } while (movies.Count == search.MaxResults);

            Console.ReadKey();
        }
    }
}
