using System.Collections.Generic;

namespace GOAP
{
    public class WorldStates
    {
        private readonly Dictionary<string, int> _states = new();

        public bool HasState(string key)
        {
            return _states.ContainsKey(key);
        }

        public void AddState(string key, int value)
        {
            _states.Add(key, value);
        }

        public void ModifyState(string key, int value)
        {
            if (_states.TryAdd(key, value)) return;
            _states[key] += value;
            if (_states[key] <= 0)
                RemoveState(key);
        }

        public void RemoveState(string key)
        {
            if (_states.ContainsKey(key))
                _states.Remove(key);
        }

        public void SetState(string key, int value)
        {
            if (_states.ContainsKey(key))
                _states[key] = value;
            else
                _states.Add(key, value);
        }

        public Dictionary<string, int> GetStates()
        {
            return _states;
        }
    }
}