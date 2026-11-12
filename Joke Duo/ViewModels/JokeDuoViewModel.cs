
using Joke_Duo.Services.Interfaces;
using Joke_Duo.ViewModels;

using System.Windows.Input;

namespace JokeDuo.ViewModels
{
    public class JokeDuoViewModel : BaseViewModel
    {
        private readonly IJokeApiService _jokeApiService;

        private string _chuckNorrisJoke = "Press the button to get a joke!";
        public string ChuckNorrisJoke
        {
            get => _chuckNorrisJoke;
            set
            {
                _chuckNorrisJoke = value;
                OnPropertyChanged();
            }
        }

        private string _dadJoke = "Press the button to get a joke!";
        public string DadJoke
        {
            get => _dadJoke;
            set
            {
                _dadJoke = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;
        private Command _getNewJokesCommand;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
                _getNewJokesCommand?.ChangeCanExecute();
            }
        }

        public ICommand GetNewJokesCommand => _getNewJokesCommand;

        public JokeDuoViewModel(IJokeApiService jokeApiService)
        {
            _jokeApiService = jokeApiService;

            _getNewJokesCommand = new Command(
                async () => await GetNewJokesAsync(),
                () => !IsLoading);
        }

        private async Task GetNewJokesAsync()
        {
            if (IsLoading)
                return;

            IsLoading = true;

            try
            {
                try
                {
                    ChuckNorrisJoke =
                        await _jokeApiService.GetChuckNorrisJokeAsync();
                }
                catch (Exception)
                {
                    ChuckNorrisJoke =
                        "Could not load a Chuck Norris joke. Please try again.";
                }

                try
                {
                    DadJoke =
                        await _jokeApiService.GetDadJokeAsync();
                }
                catch (Exception)
                {
                    DadJoke =
                        "Could not load a dad joke. Please try again.";
                }
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
