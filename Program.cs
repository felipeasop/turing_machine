using System.Diagnostics;
using System;
using System.IO;

namespace TuringMachine
{
    public static class Program
    {
        // Uso: dotnet run -- <arquivo_maquina.json> <arquivo_problema.in>
        public static int Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            if (args.Length != 2)
            {
                Console.Error.WriteLine("Argumentos inválidos. Uso correto: <arquivo_maquina.json> <arquivo_problema.in>");
                return 1;
            }

            var specPath = args[0];
            var inputPath = args[1];

            try
            {
                var machine = Parser.FromFile(specPath);

                var outputPath = Path.ChangeExtension(inputPath, ".txt");

                using var reader = new StreamReader(inputPath);
                using var writer = new StreamWriter(outputPath, false);

                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var input = line.Trim();
                    bool accepted = machine.Run(input);

                    Console.WriteLine(accepted ? "1" : "0");

                    writer.WriteLine(machine.GetFinalTapeContent());
                }
                stopwatch.Stop();
                Console.WriteLine($"{stopwatch.ElapsedSeconds} ms");

                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Erro: {e.Message}");
                return 1;
            }
        }
    }
}
