using System.Text.Json.Serialization;

namespace TuringMachine
{
    public class Transition
    {
        [JsonPropertyName("from")]
        public int From { get; init; }

        [JsonPropertyName("to")]
        public int To { get; init; }

        [JsonPropertyName("read")]
        public char Read { get; init; }

        [JsonPropertyName("write")]
        public char Write { get; init; }

        // Espera-se apenas 'L' ou 'R'
        [JsonPropertyName("dir")]
        public char Dir { get; init; }
    }
}
