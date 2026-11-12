using System.Text.Json.Serialization;

namespace Joke_Duo.Models;

//Chuck Norris API return JSON containing a joke.
// Resonse model.
public class ChuckNorrisJoke
{
	public string value { get; set; }
	public string id { get; set; }
}
