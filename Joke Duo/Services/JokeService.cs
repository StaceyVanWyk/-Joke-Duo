

using Joke_Duo.Models;

using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Joke_Duo.Services;

public class JokeService
{
    private readonly HttpClient _httpClient;

    private const string ChuckNorrisUrl =
        "https://api.chucknorris.io/jokes/random";

    private const string DadJokeUrl =
        "https://icanhazdadjoke.com/";

    public JokeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Fetch a random Chuck Norris joke
    public async Task<string> GetChuckNorrisJokeAsync()
    {
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            ChuckNorrisUrl);

        var response =
            await SendRequestAsync<ChuckNorrisResponse>(request);

        if (string.IsNullOrWhiteSpace(response.Value))
        {
            throw new InvalidDataException(
                "The Chuck Norris API returned an empty joke.");
        }

        return response.Value;
    }

    // Fetch a random Dad joke
    public async Task<string> GetDadJokeAsync()
    {
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            DadJokeUrl);

        request.Headers.Accept.ParseAdd("application/json");

        var response =
            await SendRequestAsync<DadJokeResponse>(request);

        if (string.IsNullOrWhiteSpace(response.Joke))
        {
            throw new InvalidDataException(
                "The Dad Joke API returned an empty joke.");
        }

        return response.Joke;
    }

    // Send the HTTP request and deserialize the JSON response
    private async Task<T> SendRequestAsync<T>(
        HttpRequestMessage request)
    {
        using var httpResponse =
            await _httpClient.SendAsync(request);

        httpResponse.EnsureSuccessStatusCode();

        try
        {
            var result =
                await httpResponse.Content.ReadFromJsonAsync<T>();

            if (result == null)
            {
                throw new InvalidDataException(
                    "The API returned an empty response.");
            }

            return result;
        }
        catch (JsonException ex)
        {
            throw new InvalidDataException(
                "The API returned invalid JSON data.", ex);
        }
    }
}
