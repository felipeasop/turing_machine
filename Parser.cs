using System.IO;
using System.Text.Json;

namespace TuringMachine
{
    public static class Parser
    {
        public static TuringMachine FromFile(string path, long maxSteps = 100_000_000_000)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Arquivo de definição não encontrado.", path);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            string json = File.ReadAllText(path);
            var spec = JsonSerializer.Deserialize<Specification>(json, options);

            if (spec == null) throw new InvalidDataException($"Definição inválida: {path}");

            return new TuringMachine(spec, maxSteps);
        }
    }
}
