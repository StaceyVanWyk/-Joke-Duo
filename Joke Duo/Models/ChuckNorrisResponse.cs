using System.Text.Json.Serialization;

namespace Joke_Duo.Models;

public class ChuckNorrisResponse
{
	[JsonPropertyName("value")]
	public string? Value { get; set; }
}
