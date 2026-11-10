using System;
using System.Collections.Generic;
using System.Text;

namespace Joke_Duo.Services.Interfaces
{
    public interface IJokeApiService
    {
        Task<string> GetChuckNorrisJokeAsync();

        Task<string> GetDadJokeAsync();
    }
}
