using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrubbler.Helper
{
  interface IChildDisplay
  {
    string Title { get; }
    event EventHandler<CloseChildDisplayEventArgs> CloseRequested;
    event EventHandler Closed;
  }

  public class CloseChildDisplayEventArgs : EventArgs
  {
    public bool Result { get; }

    public CloseChildDisplayEventArgs(bool result)
    {
      Result = result;
    }
  }
}
