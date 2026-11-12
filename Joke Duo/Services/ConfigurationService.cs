

using Joke_Duo.Models;

using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Joke_Duo.Services.Interfaces;

namespace Joke_Duo.Services;

public class ConfigurationService : IConfigurationService
{
   public string ChuckNorrisUrl { get;  } = "https://api.chucknorris.io/jokes/random";
   public string DadJokeUrl { get;  } = "https://icanhazdadjoke.com/";

}
