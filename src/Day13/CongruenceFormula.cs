namespace Day13
{
    public class CongruenceFormula
    {
        //This calculated as part of the Chinese Number Theorem.
        //A good run through is here:
        //http://homepages.math.uic.edu/~leon/mcs425-s08/handouts/chinese_remainder.pdf
        
        
        //X≡ A Mod n
        private readonly long _bigN;
        private readonly int _moduloValue;
        // ReSharper disable once InconsistentNaming
        private readonly int _AiValue;

        private long _ziNumber;
        private long ZiNumber
        {
            get
            {
                if (_ziNumber == default)
                {
                    _ziNumber =  _bigN / _moduloValue;
                }

                return _ziNumber;
            }
        }

        private long _yiNumber;
        private long YiNumber
        {
            get
            {
                if (_yiNumber == default)
                {
                    GetYi();
                }

                return _yiNumber;
            }
        }

        private void GetYi()
        {
            var ziInitial = ZiNumber % _moduloValue;
            var inverse =RaiseToThePowerVeryBig(ziInitial,_moduloValue-2,_moduloValue);
            var inverseSimplified = inverse % _moduloValue;
            _yiNumber = inverseSimplified;
        }

        private long RaiseToThePowerVeryBig(long value, int power, int modulo)
        {
            var workingValue = value;

            for (int i = 1; i < power; i++)
            {
                workingValue *= value;
                workingValue %= modulo;
            }
            
            return workingValue;
        }

        private long _wiNumber;
        private long WiNumber
        {
            get
            {
                if (_wiNumber == default)
                {
                    _wiNumber = ZiNumber * YiNumber;
                }

                return _wiNumber;
            }
        }

        public CongruenceFormula(long bigN, int moduloValue, int aiValue)
        {
            _bigN = bigN;
            _moduloValue = moduloValue;
            _AiValue = aiValue;
        }

        //This is for the formula aiwiyi ≡ ai (yi)^-1 yi
        public long GetAiWiNumber()
        {
            return _AiValue * WiNumber;
        }
    }
}