using System;
using System.Collections.Generic;
using System.Linq;

namespace TuringMachine
{
    public class TuringMachine
    {
        private readonly Dictionary<int, State> _states;
        private readonly int _initialState;
        private readonly char _blank;
        private readonly long _maxSteps;
        private Tape? _tape;

        public TuringMachine(Specification spec, long maxSteps)
        {
            if (spec == null) throw new ArgumentNullException(nameof(spec));
            _initialState = spec.InitialState;
            _blank = spec.White;
            _maxSteps = maxSteps;

            var transitions = spec.Transitions ?? throw new InvalidDataException("O campo 'transitions' não pode ser nulo.");
            var finalStates = new HashSet<int>(spec.FinalStates ?? new List<int>());

            var uniqueStateIds = new HashSet<int>(finalStates);
            uniqueStateIds.Add(_initialState);

            foreach (var transition in transitions)
            {
                uniqueStateIds.Add(transition.From);
                uniqueStateIds.Add(transition.To);
            }

            _states = uniqueStateIds.ToDictionary(
                id => id,
                id => new State(id) { IsFinal = finalStates.Contains(id) }
            );

            foreach (var t in transitions)
            {
                if (_states.TryGetValue(t.From, out var state))
                {
                    state.AddTransition(t);
                }
            }

            ValidateFinalStates();
        }

        public bool Run(string input)
        {
            _tape = new Tape(input ?? string.Empty, _blank);
            int currentStateId = _initialState;

            for (long step = 0; step < _maxSteps; step++)
            {
                if (!_states.TryGetValue(currentStateId, out var state)) return false;
                if (state.IsFinal) return true;

                char readSymbol = _tape.Read();
                var transition = state.GetTransition(readSymbol);

                if (transition == null) return false;

                _tape.Write(transition.Write);
                _tape.Move(transition.Dir);
                currentStateId = transition.To;

            }

            Console.Error.WriteLine($"\nA excecução da entrada excedeu o limite de passos ({_maxSteps}) e foi interrompida.");
            return false;
        }

        public string GetFinalTapeContent() => _tape?.GetFinalTapeContent() ?? string.Empty;

        private void ValidateFinalStates()
        {
            foreach (var state in _states.Values)
            {
                if (state.IsFinal && state.Transitions.Any())
                {
                    throw new InvalidDataException($"Regra violada: O estado final {state.Id} possui transições de saída.");
                }
            }
        }
    }
}
