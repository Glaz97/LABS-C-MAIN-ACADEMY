using System;
using Calculator.DigitControl;

namespace Calculator.CalculatorModel
{
    public enum Command
    {
        None,
        MRC,
        MMinus,
        MPlus,
        C,
        CE,
        Root,
        Percent,
        Divide,
        Plus,
        Minus,
        Multiply,
        Dot,
        Equals,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Zero
    }

    public class CalculatorModel
    {
        private Command _command;
        private float _current;
        private bool _dot;
        private int _explen;
        private bool _isDigitCmd;
        private bool _isError;
        private bool _isMemory;
        private int _mantlen;
        private float _memory;
        private bool _memoryRecalled;
        private float _previous;
        private float? _stacked;
        private int _zeroes;

        public CalculatorModel()
        {
            Clear();
        }

        public IndicatorState ProcessButton(Command command)
        {
            if (command != Command.C && _isError)
                return new IndicatorState
                {
                    Value = _current,
                    IsError = _isError,
                    IsMemory = _isMemory,
                    MantissaLength = _zeroes
                };
            if (command == Command.MRC)
                RecallMemory();
            else
                _memoryRecalled = false;
            switch (command)
            {
                case Command.Zero:
                case Command.One:
                case Command.Two:
                case Command.Three:
                case Command.Four:
                case Command.Five:
                case Command.Six:
                case Command.Seven:
                case Command.Eight:
                case Command.Nine:
                    ProcessDigit(command);
                    break;
                case Command.Dot:
                    ProcessDot();
                    break;
                case Command.Plus:
                case Command.Minus:
                case Command.Multiply:
                case Command.Divide:
                    StoreCommand(command);
                    break;
                case Command.Root:
                    Root();
                    break;
                case Command.Equals:
                    ExecuteCommand();
                    break;
                case Command.CE:
                    ClearCurrent();
                    break;
                case Command.MPlus:
                case Command.MMinus:
                    ProcessMemory(command);
                    break;
                case Command.Percent:
                    ProcessPercent();
                    break;
                case Command.C:
                    Clear();
                    break;
            }

            return new IndicatorState
            {
                Value = _current,
                IsError = _isError,
                IsMemory = _isMemory,
                MantissaLength = _zeroes
            };
        }

        #region Model internals

        private void ProcessPercent()
        {
            if (_command == Command.None)
            {
                ClearCurrent();
                return;
            }
            var delta = _previous/100*_current;
            _current = delta;
            ExecuteCommand();
        }

        private void ProcessMemory(Command cmd)
        {
            if (_memory == 0 && _current == 0)
                return;
            _isMemory = true;
            if (cmd == Command.MPlus)
                _memory += _current;
            else
                _memory -= _current;
        }

        private void RecallMemory()
        {
            if (!_isMemory)
                return;
            _current = _memory;
            if (_memoryRecalled == false)
                _memoryRecalled = true;
            else
            {
                _isMemory = false;
                _memoryRecalled = false;
                _memory = 0;
            }
        }

        private void ProcessDigit(Command dgt)
        {
            int digit;
            switch (dgt)
            {
                case Command.Zero:
                    digit = 0;
                    break;
                case Command.One:
                    digit = 1;
                    break;
                case Command.Two:
                    digit = 2;
                    break;
                case Command.Three:
                    digit = 3;
                    break;
                case Command.Four:
                    digit = 4;
                    break;
                case Command.Five:
                    digit = 5;
                    break;
                case Command.Six:
                    digit = 6;
                    break;
                case Command.Seven:
                    digit = 7;
                    break;
                case Command.Eight:
                    digit = 8;
                    break;
                case Command.Nine:
                    digit = 9;
                    break;
                default:
                    return;
            }

            if (!_isDigitCmd)
            {
                _current = 0;
                _dot = false;
                _zeroes = 0;
                _explen = 0;
                _mantlen = 0;
            }
            _isDigitCmd = true;
            if (!_dot)
            {
                if (digit == 0 && _explen == 0)
                    return;
                if (_explen == 8)
                    return;
                if (_explen != 0)
                    _current *= 10;
                _current += digit;
                _explen++;
                return;
            }
            if (8 - _explen - _mantlen - _zeroes > 0)
            {
                if (digit != 0)
                {
                    _zeroes = 0;
                    _mantlen++;
                    _current = _current + (float) Math.Pow(10, -_mantlen)*digit;
                }
                else
                    _zeroes++;
            }
        }

        private void ProcessDot()
        {
            _dot = true;
        }

        private void ClearCurrent()
        {
            _current = 0;
            _dot = false;
            _zeroes = 0;
        }

        private void StoreCommand(Command cmd)
        {
            _command = cmd;
            _previous = _current;
            _stacked = null;
            _isDigitCmd = false;
        }

        private void Root()
        {
            if (_current < 0)
            {
                _isError = true;
                return;
            }
            _command = Command.Root;
            _current = (float) Math.Sqrt(_current);
        }

        private void ExecuteCommand()
        {
            _isDigitCmd = false;
            if (_command == Command.None)
                return;
            if (_stacked == null)
                _stacked = _current;
            else
            {
                _previous = _current;
                _current = (float) _stacked;
            }

            switch (_command)
            {
                case Command.Plus:
                    _current += _previous;
                    break;
                case Command.Minus:
                    _current = _previous - _current;
                    break;
                case Command.Multiply:
                    _current *= _previous;
                    break;
                case Command.Divide:
                    if (_current == 0)
                    {
                        _isError = true;
                        return;
                    }
                    _current = _previous/_current;
                    break;
            }
        }

        private void Clear()
        {
            _current = 0;
            _previous = 0;
            _isError = false;
            _explen = 0;
            _mantlen = 0;
            _command = Command.None;
            _dot = false;
            _zeroes = 0;
            _isDigitCmd = true;
            _stacked = null;
        }

        #endregion
    }
}