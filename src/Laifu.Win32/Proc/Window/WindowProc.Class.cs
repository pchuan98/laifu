using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32;
using Windows.Win32.Foundation;

// ReSharper disable once CheckNamespace
namespace Laifu.Win32.Proc;

public partial class WindowProc
{
    /// <summary>
    /// 窗口类名，定义窗口类的名称，用于窗口类注册和创建。
    /// </summary>
    public string ClassName
    {
        get
        {
            unsafe
            {
                var buffer = stackalloc char[256];
                var pwstr = new PWSTR(buffer);

                return PInvoke.GetClassName(Hwnd, pwstr, 256) == 0 ? string.Empty : pwstr.ToString();
            }
        }
    }
}