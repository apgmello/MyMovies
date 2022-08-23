using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    public static class Extensions
    {
        public static ConsoleMenu ConfigureMenu(this ConsoleMenu consoleMenu, string title)
        {
            consoleMenu.Configure(config =>
            {
                config.WriteHeaderAction = () => Console.WriteLine(title);
                config.Selector = "--> ";
                config.Title = "";
                config.EnableFilter = true;
                config.FilterPrompt = "Escolha uma opção: ";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });
            return consoleMenu;
        }
    }
}
