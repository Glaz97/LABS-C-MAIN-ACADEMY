using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator.Templates
{
    [TemplatePart(Name = "PART_TITLEBAR", Type = typeof (UIElement))]
    [TemplatePart(Name = "PART_MAXIMIZE_RESTORE", Type = typeof (Button))]
    [TemplatePart(Name = "PART_CLOSE", Type = typeof (Button))]
    public class CustomWindow : Window
    {
        protected CustomWindow()
        {
            CreateCommandBindings();
        }

        private Button CloseButton { get; set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            AttachToVisualTree();
        }

        private void CreateCommandBindings()
        {
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, (a, b) => Close()));
        }

        private void AttachToVisualTree()
        {
            AttachCloseButton();
        }

        private void AttachCloseButton()
        {
            if (CloseButton != null)
            {
                CloseButton.Command = null;
            }

            var closeButton = GetChildControl<Button>("PART_CLOSE");
            if (closeButton != null)
            {
                closeButton.Command = ApplicationCommands.Close;
                CloseButton = closeButton;
            }
        }

        private T GetChildControl<T>(string controlName) where T : DependencyObject
        {
            var control = GetTemplateChild(controlName) as T;
            return control;
        }
    }
}