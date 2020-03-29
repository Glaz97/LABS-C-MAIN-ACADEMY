using System.Windows.Input;
using Calculator.CalculatorModel;
using Calculator.DigitControl;

namespace Calculator.CalculatorViewModel
{
    public class CalculatorViewModel
        : ViewModelBase<CalculatorViewModel>
    {
        private readonly CalculatorModel.CalculatorModel _calculator;
        private IndicatorState _indicatorState;

        public CalculatorViewModel()
        {
            ButtonClick = new RelayCommand(ButtonClicked);

            State = new IndicatorState
            {
                IsError = false,
                IsMemory = false,
                Value = 0,
                MantissaLength = 0
            };

            _calculator = new CalculatorModel.CalculatorModel();
        }

        public IndicatorState State
        {
            get { return _indicatorState; }
            set { SetProperty(ref _indicatorState, value, x => x.State); }
        }

        public ICommand ButtonClick { get; private set; }

        private void ButtonClicked(object arg)
        {
            Command cmd;
            switch (arg.ToString())
            {
                case "1":
                    cmd = Command.One;
                    break;
                case "2":
                    cmd = Command.Two;
                    break;
                case "3":
                    cmd = Command.Three;
                    break;
                case "4":
                    cmd = Command.Four;
                    break;
                case "5":
                    cmd = Command.Five;
                    break;
                case "6":
                    cmd = Command.Six;
                    break;
                case "7":
                    cmd = Command.Seven;
                    break;
                case "8":
                    cmd = Command.Eight;
                    break;
                case "9":
                    cmd = Command.Nine;
                    break;
                case "0":
                    cmd = Command.Zero;
                    break;
                case "C":
                    cmd = Command.C;
                    break;
                case "MRC":
                    cmd = Command.MRC;
                    break;
                case "M+":
                    cmd = Command.MPlus;
                    break;
                case "M-":
                    cmd = Command.MMinus;
                    break;
                case "√":
                    cmd = Command.Root;
                    break;
                case "÷":
                    cmd = Command.Divide;
                    break;
                case "%":
                    cmd = Command.Percent;
                    break;
                case "+":
                    cmd = Command.Plus;
                    break;
                case "-":
                    cmd = Command.Minus;
                    break;
                case "×":
                    cmd = Command.Multiply;
                    break;
                case "•":
                    cmd = Command.Dot;
                    break;
                case "CE":
                    cmd = Command.CE;
                    break;
                case "=":
                    cmd = Command.Equals;
                    break;
                default:
                    return;
            }
            State = _calculator.ProcessButton(cmd);
        }
    }
}