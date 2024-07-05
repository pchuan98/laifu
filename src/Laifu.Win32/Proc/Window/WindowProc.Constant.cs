using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32;

// ReSharper disable once CheckNamespace
namespace Laifu.Win32.Proc;

public partial class WindowProc
{
    public static WindowProc GetDesktop => new(PInvoke.GetDesktopWindow());

    public static List<WindowProc> CurrentWindows
    {
        get
        {
            var result = new List<WindowProc>();
            PInvoke.EnumWindows((hwnd, _) =>
            {
                result.Add(new WindowProc(hwnd));
                return true;
            }, IntPtr.Zero);

            return result;
        }
    }


}