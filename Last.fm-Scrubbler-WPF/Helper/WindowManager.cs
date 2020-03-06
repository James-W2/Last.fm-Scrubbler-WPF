namespace Scrubbler.Helper
{
  public class WindowManager : IMyWindowManager
  {
    public bool? ShowDialog(object content)
    {
      var window = new ChildWindow(content);
      return window.ShowDialog();
    }

    public void ShowWindow(object content)
    {
      var window = new ChildWindow(content);
      window.Show();
    }
  }
}
