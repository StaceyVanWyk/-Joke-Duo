
using JokeDuo.Views;

namespace JokeDuo
{
    public partial class AppShell : Shell
    {
        public AppShell(JokeDuoView jokeDuoView)
        {
            InitializeComponent();

            Items.Add(new ShellContent
            {
                Title = "Joke Duo",
                Content = jokeDuoView
            });
        }
    }
}
