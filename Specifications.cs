using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TuringMachine
{
    public class Specification
    {
        [JsonPropertyName("initial")]
        public int InitialState { get; init; }

        [JsonPropertyName("final")]
        public List<int> FinalStates { get; init; } = new();

        [JsonPropertyName("white")]
        public char White { get; init; }

        [JsonPropertyName("transitions")]
        public List<Transition> Transitions { get; init; } = new();
    }
}
