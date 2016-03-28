namespace MyMvvmTwo.Dialogs
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public class DialogCloser
    {
        public static readonly DependencyProperty DialogResultProperty = 
            DependencyProperty.RegisterAttached("DialogResult",
                typeof(bool?),
                typeof(DialogCloser),
                new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window ?? TryFindParentWindow(d);

            if (window != null)
            {
                window.DialogResult = e.NewValue as bool?;
            }
        }

        public static void SetDialogResult(Control target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }

        private static Window TryFindParentWindow(DependencyObject d)
        {
            var parent = GetParentObject(d);

            if (parent == null)
            {
                return null;
            }

            var window = parent as Window;

            if (window != null)
            {
                return window;
            }

            return TryFindParentWindow(parent);
        }

        private static DependencyObject GetParentObject(DependencyObject d)
        {
            if (d == null)
            {
                return null;
            }

            var contentElement = d as ContentElement;
            if (contentElement != null)
            {
                var parent = ContentOperations.GetParent(contentElement);

                if (parent != null)
                {
                    return parent;
                }

                var frameworkContentElement = contentElement as FrameworkContentElement;

                return frameworkContentElement?.Parent;
            }

            var frameworkElement = d as FrameworkElement;
            if (frameworkElement != null)
            {
                var parent = frameworkElement.Parent;

                if (parent != null)
                {
                    return parent;
                }
            }

            return VisualTreeHelper.GetParent(d);
        }
    }
}
