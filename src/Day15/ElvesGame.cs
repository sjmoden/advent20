using System;
using System.Collections.Generic;

namespace Day15
{
    public class ElvesGame:IElvesGame
    {
        private readonly Dictionary<int,int>_lastPositions = new Dictionary<int, int>();
        private readonly Dictionary<int,bool>_firstTimeValueSaid = new Dictionary<int, bool>();
        public int Position;
        private int _previousValue;


        public ElvesGame SetUpGame(List<int> startingList)
        {
            foreach (var item in startingList)
            {
                AddNewValue(item);
            }
            
            return this;
        }

        private void AddNewValue(int value)
        {
            UpdateLastPositionsWithLastValue();
            SetFirstTimeStatus(value);
            
            Position++;
            _previousValue = value;
        }

        private void UpdateLastPositionsWithLastValue()
        {
            if (!_lastPositions.TryGetValue(_previousValue, out _))
            {
                _lastPositions.Add(_previousValue, Position);
            }
            else
            {
                _lastPositions[_previousValue] = Position;
            }
        }

        private void SetFirstTimeStatus(int value)
        {
            if (!_firstTimeValueSaid.TryGetValue(value, out _))
            {
                _firstTimeValueSaid.Add(value, true);
            }
            else
            {
                _firstTimeValueSaid[value] = false;
            }
        }

        public int GetNextValue()
        {
            if (!_firstTimeValueSaid.TryGetValue(_previousValue, out var firstTimeSaid) || firstTimeSaid)
            {
                AddNewValue(0);
                return 0;
            }

            if (!_lastPositions.TryGetValue(_previousValue, out var previousPosition))
            {
                throw new Exception("An entry does not exist in the dictionary when expected");
            }

            var difference = Position - previousPosition;
            AddNewValue(difference);
            return difference;
        }
    }
}