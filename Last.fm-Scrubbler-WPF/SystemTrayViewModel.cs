using Caliburn.Micro;
using Scrubbler.Helper;
using Scrubbler.Properties;
using System;
using System.Windows;

namespace Scrubbler
{
  /// <summary>
  /// ViewModel for the <see cref="SystemTrayView"/> and parent
  /// ViewModel of the whole application.
  /// </summary>
  class SystemTrayViewModel : Screen
  {
    #region Member

    /// <summary>
    /// WindowManager used to show the <see cref="_screenToShow"/>.
    /// </summary>
    private readonly IMyWindowManager _windowManager;

    /// <summary>
    /// The actual "main" screen that will be shown.
    /// </summary>
    private readonly IChildDisplay _screenToShow;

    #endregion Member

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="windowManager">WindowManager used to show the <paramref name="screenToShow"/>.</param>
    /// <param name="screenToShow">The actual "main" screen that will be shown.</param>
    public SystemTrayViewModel(IMyWindowManager windowManager, IChildDisplay screenToShow)
    {
      _windowManager = windowManager ?? throw new ArgumentNullException(nameof(windowManager));
      _screenToShow = screenToShow ?? throw new ArgumentNullException(nameof(screenToShow));
      _screenToShow.Closed += ScreenToShow_Deactivated;

      if (!Settings.Default.StartMinimized)
        ShowScreen();
    }

    #endregion Construction

    /// <summary>
    /// Shows the main application screen.
    /// </summary>
    public void ShowScreen()
    {
      if(!_screenToShow.IsActive)
        _windowManager.ShowWindow(_screenToShow);
    }

    /// <summary>
    /// Saves settings and exits the application.
    /// </summary>
    public void Exit()
    {
      if (_screenToShow is IDisposable screen)
        screen.Dispose();

      Settings.Default.Save();
      Application.Current.Shutdown();
    }

    /// <summary>
    /// Exits the application if the main application screen
    /// was closed and we do not minimize to tray.
    /// </summary>
    /// <param name="sender">Ignored.</param>
    /// <param name="e">EventArgs.</param>
    private void ScreenToShow_Deactivated(object sender, EventArgs e)
    {
      if (!Settings.Default.MinimizeToTray)
        Exit();
    }
  }
}