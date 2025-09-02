using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuringMachine
{
    public class Tape
    {
        private readonly Dictionary<int, char> _cells;
        private int _head;
        private readonly char _blank;

        public Tape(string input, char blank)
        {
            _blank = blank;
            _cells = new Dictionary<int, char>();
            _head = 0;

            if (!string.IsNullOrEmpty(input))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != blank)
                    {
                        _cells[i] = input[i];
                    }
                }
            }
        }

        public char Read() => _cells.TryGetValue(_head, out var c) ? c : _blank;

        public void Write(char c)
        {
            if (c == _blank) _cells.Remove(_head);
            else _cells[_head] = c;
        }

        public void Move(char dir)
        {
            _head += dir switch
            {
                'R' => 1,
                'L' => -1,
                _ => throw new InvalidOperationException($"Direção inválida: '{dir}' (esperado 'L' ou 'R').")
            };
        }

        public string GetFinalTapeContent()
        {
            if (_cells.Count == 0)
            {
                return string.Empty;
            }

            int minKey = _cells.Keys.Min();
            int maxKey = _cells.Keys.Max();
            int length = maxKey - minKey + 1;

            if (length > 20_000_000)
            {
                return $"[Fita muito grande para ser exibida. De {minKey} a {maxKey}]";
            }

            char[] buffer = new char[length];
            Array.Fill(buffer, _blank);

            foreach (var cell in _cells)
            {
                buffer[cell.Key - minKey] = cell.Value;
            }

            return new string(buffer);
        }
    }
}
