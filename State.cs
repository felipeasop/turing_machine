using System;
using System.Collections.Generic;

namespace TuringMachine
{
    public class State
    {
        public int Id { get; }
        public bool IsFinal { get; set; }

        private readonly Dictionary<char, Transition> _transitions;

        public State(int id)
        {
            Id = id;
            IsFinal = false;
            _transitions = new Dictionary<char, Transition>();
        }

        public void AddTransition(Transition t)
        {
            if (_transitions.ContainsKey(t.Read))
                throw new InvalidDataException(
                    $"Transição duplicada no estado {Id} para símbolo '{t.Read}'.");

            _transitions[t.Read] = t;
        }

        public Transition? GetTransition(char read)
        {
            _transitions.TryGetValue(read, out var t);
            return t;
        }

        public IEnumerable<Transition> Transitions => _transitions.Values;
    }
}
