using Joke_Duo.Models;
using Joke_Duo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
namespace Joke_Duo.Services
{
    public  class JokeApiHttpService : IJokeApiService
    {

        private readonly HttpClient _httpClient;
        private readonly IConfigurationService _configurationService;


        public JokeApiHttpService(
    HttpClient httpClient,
    IConfigurationService configurationService)
        {
            _httpClient = httpClient;
            _configurationService = configurationService;
        }



        public async Task<string> GetChuckNorrisJokeAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ChuckNorrisJoke>(
                _configurationService.ChuckNorrisUrl);

            if (response == null || string.IsNullOrWhiteSpace(response.value))
            {
                throw new HttpRequestException(
                    "Unable to retrieve a Chuck Norris joke.");
            }

            return response.value;
        }


        public async Task<string> GetDadJokeAsync()
        {
            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                _configurationService.DadJokeUrl);

            request.Headers.Add("Accept", "application/json");

            using var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var dadJoke = await response.Content.ReadFromJsonAsync<DadJoke>();

            if (dadJoke == null || string.IsNullOrWhiteSpace(dadJoke.joke))
            {
                throw new HttpRequestException(
                    "Unable to retrieve a dad joke.");
            }

            return dadJoke.joke;
        }
    }
}
