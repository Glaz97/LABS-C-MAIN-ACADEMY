using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator.DigitControl
{
    public partial class Indicator
    {
        private static SevenSegmentControl[] _digits;
        private static TextBlock _minus;
        private static TextBlock _memory;
        private static TextBlock _error;

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof (IndicatorState), typeof (Indicator),
                new PropertyMetadata(null, UpdateIndicator));

        public Indicator()
        {
            InitializeComponent();
            _digits = new[] {Seven, Six, Five, Four, Three, Two, One, Zero};
            _minus = Minus;
            _error = Error;
            _memory = Memory;
        }

        public IndicatorState State
        {
            get { return (IndicatorState) GetValue(StateProperty); }
            set { SetValue(StateProperty, value); }
        }

        private static void UpdateIndicator(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is IndicatorState newState))
                return;

            var state = new IndicatorState
            {
                IsError = newState.IsError,
                IsMemory = newState.IsMemory,
                Value = newState.Value,
                MantissaLength = newState.MantissaLength
            };
            ProcessState(state);
        }

        private static void ProcessState(IndicatorState state)
        {
            _memory.Visibility = state.IsMemory ? Visibility.Visible : Visibility.Hidden;
            _minus.Visibility = state.Value < 0 ? Visibility.Visible : Visibility.Hidden;
            _error.Visibility = state.IsError ? Visibility.Visible : Visibility.Hidden;
            var val = Math.Abs((float) Math.Round(state.Value, 7));
            var intval = (int) val;
            if (intval > 99999999)
            {
                _error.Visibility = Visibility.Visible;
                return;
            }

            var rawLeft = (int) val;

            var lPow = rawLeft != 0 ? (int) (Math.Log10(rawLeft)) + 1 : 1;
            int rPow;

            for (rPow = 0; rPow < 7; rPow++)
            {
                var floated = Math.Round(val*Math.Pow(10, rPow), 1);
                var inted = (int) (Math.Round(val*Math.Pow(10, rPow), 1));
                if (Math.Abs(floated - inted) < 0.1)
                    break;
            }
            if (lPow + rPow > 8)
                rPow = 8 - lPow;
            var rawRight = (int) (Math.Round(val - rawLeft, rPow)*Math.Pow(10, rPow));
            rPow += state.MantissaLength;
            for (var k = 0; k < state.MantissaLength; k++)
                rawRight = rawRight*10;

            var first = 8 - lPow - rPow;

            var dp = 0;
            for (var i = 0; i < 8 - rPow; i++)
            {
                var segment = _digits[i];
                if (i < first)
                    segment.Clear();
                else
                {
                    var digit = (int) (rawLeft/Math.Pow(10, lPow - dp - 1));
                    rawLeft -= (int) (digit*Math.Pow(10, lPow - dp - 1));
                    segment.Display(digit, dp == lPow - 1);
                    dp++;
                }
            }

            dp = 0;
            for (var i = first + lPow; i < 8; i++)
            {
                var segment = _digits[i];
                var digit = (int) (rawRight/Math.Pow(10, rPow - dp - 1));
                rawRight -= (int) (digit*Math.Pow(10, rPow - dp - 1));
                segment.Display(digit, false);
                dp++;
            }
        }
    }
}