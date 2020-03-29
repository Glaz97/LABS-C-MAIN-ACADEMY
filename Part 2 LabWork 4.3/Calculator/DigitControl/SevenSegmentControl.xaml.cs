using System.Windows;

namespace Calculator.DigitControl
{
    public partial class SevenSegmentControl
    {
        public SevenSegmentControl()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            Hide();
        }

        public void Display(int digit, bool isDot)
        {
            Dot.Visibility = isDot ? Visibility.Visible : Visibility.Hidden;
            switch (digit)
            {
                case 0:
                    ShowZero();
                    break;
                case 1:
                    ShowOne();
                    break;
                case 2:
                    ShowTwo();
                    break;
                case 3:
                    ShowThree();
                    break;
                case 4:
                    ShowFour();
                    break;
                case 5:
                    ShowFive();
                    break;
                case 6:
                    ShowSix();
                    break;
                case 7:
                    ShowSeven();
                    break;
                case 8:
                    ShowEight();
                    break;
                case 9:
                    ShowNine();
                    break;
                default:
                    Hide();
                    break;
            }
        }

        private void Hide()
        {
            Dot.Visibility = Visibility.Hidden;
            Top.Visibility = Visibility.Hidden;
            TopLeft.Visibility = Visibility.Hidden;
            TopRight.Visibility = Visibility.Hidden;
            Bottom.Visibility = Visibility.Hidden;
            BottomLeft.Visibility = Visibility.Hidden;
            BottomRight.Visibility = Visibility.Hidden;
            Middle.Visibility = Visibility.Hidden;
        }

        private void ShowZero()
        {
            Top.Visibility = Visibility.Visible;
            TopLeft.Visibility = Visibility.Visible;
            BottomLeft.Visibility = Visibility.Visible;
            Bottom.Visibility = Visibility.Visible;
            BottomRight.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Visible;
            Middle.Visibility = Visibility.Hidden;
        }

        private void ShowOne()
        {
            Top.Visibility = Visibility.Hidden;
            TopLeft.Visibility = Visibility.Hidden;
            BottomLeft.Visibility = Visibility.Hidden;
            Bottom.Visibility = Visibility.Hidden;
            TopRight.Visibility = Visibility.Visible;
            BottomRight.Visibility = Visibility.Visible;
            Middle.Visibility = Visibility.Hidden;
        }

        private void ShowTwo()
        {
            Top.Visibility = Visibility.Visible;
            TopLeft.Visibility = Visibility.Hidden;
            Middle.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Visible;
            BottomLeft.Visibility = Visibility.Visible;
            Bottom.Visibility = Visibility.Visible;
            BottomRight.Visibility = Visibility.Hidden;
        }

        private void ShowThree()
        {
            Top.Visibility = Visibility.Visible;
            TopLeft.Visibility = Visibility.Hidden;
            TopRight.Visibility = Visibility.Visible;
            Middle.Visibility = Visibility.Visible;
            BottomLeft.Visibility = Visibility.Hidden;
            Bottom.Visibility = Visibility.Visible;
            BottomRight.Visibility = Visibility.Visible;
        }

        private void ShowFour()
        {
            Top.Visibility = Visibility.Hidden;
            TopLeft.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Visible;
            Middle.Visibility = Visibility.Visible;
            BottomLeft.Visibility = Visibility.Hidden;
            BottomRight.Visibility = Visibility.Visible;
            Bottom.Visibility = Visibility.Hidden;
        }

        private void ShowFive()
        {
            Top.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Hidden;
            TopLeft.Visibility = Visibility.Visible;
            Middle.Visibility = Visibility.Visible;
            BottomLeft.Visibility = Visibility.Hidden;
            BottomRight.Visibility = Visibility.Visible;
            Bottom.Visibility = Visibility.Visible;
        }

        private void ShowSix()
        {
            Top.Visibility = Visibility.Visible;
            TopLeft.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Hidden;
            Middle.Visibility = Visibility.Visible;
            BottomLeft.Visibility = Visibility.Visible;
            BottomRight.Visibility = Visibility.Visible;
            Bottom.Visibility = Visibility.Visible;
        }

        private void ShowSeven()
        {
            Top.Visibility = Visibility.Visible;
            TopLeft.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Visible;
            Middle.Visibility = Visibility.Hidden;
            Bottom.Visibility = Visibility.Hidden;
            BottomLeft.Visibility = Visibility.Hidden;
            BottomRight.Visibility = Visibility.Visible;
        }

        private void ShowEight()
        {
            Top.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Visible;
            TopLeft.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Visible;
            Middle.Visibility = Visibility.Visible;
            BottomLeft.Visibility = Visibility.Visible;
            Bottom.Visibility = Visibility.Visible;
            BottomRight.Visibility = Visibility.Visible;
        }

        private void ShowNine()
        {
            Top.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Visible;
            TopLeft.Visibility = Visibility.Visible;
            TopRight.Visibility = Visibility.Visible;
            Middle.Visibility = Visibility.Visible;
            BottomLeft.Visibility = Visibility.Hidden;
            Bottom.Visibility = Visibility.Visible;
            BottomRight.Visibility = Visibility.Visible;
        }
    }
}