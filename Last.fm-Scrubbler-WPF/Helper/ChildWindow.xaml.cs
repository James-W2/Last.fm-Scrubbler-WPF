using System.Windows;

namespace Scrubbler.Helper
{
  /// <summary>
  /// Interaction logic for ChildWindow.xaml
  /// </summary>
  public partial class ChildWindow : Window
  {
    public ChildWindow(object content)
    {
      InitializeComponent();
      Content = content;
      SizeToContent = SizeToContent.WidthAndHeight;
      if (content is IChildDisplay d)
      {
        Title = d.Title;
      }
    }
  }
}
