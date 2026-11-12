using System;
using System.Collections.Generic;
using System.Text;

namespace Joke_Duo.Services.Interfaces
{
    //Application communicates with two APIs
    public interface  IConfigurationService
    {
        string ChuckNorrisUrl { get;  }

        string DadJokeUrl { get; }
    }
}
//I could write these URLs directly inside JokeApiHttpService.cs but thta would mix up configuration information with HTTP communication.