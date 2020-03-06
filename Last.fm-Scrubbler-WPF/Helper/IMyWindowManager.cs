namespace Scrubbler.Helper
{
  interface IMyWindowManager
  {
    void ShowWindow(object content);
    bool? ShowDialog(object content);
  }
}