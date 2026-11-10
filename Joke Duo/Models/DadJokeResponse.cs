using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Joke_Duo.Models
{
    public class DadJokeResponse
    {
        [JsonPropertyName("joke")]
        public string? Joke { get; set; }

    }
}
