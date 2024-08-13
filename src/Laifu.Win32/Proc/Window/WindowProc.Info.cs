using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

// ReSharper disable once CheckNamespace
namespace Laifu.Win32.Proc;

public partial class WindowProc
{
    /// <summary>
    /// 窗口句柄
    /// </summary>
    internal HWND Hwnd;

    public WindowProc(object obj)
    {
        Hwnd = obj switch
        {
            HWND hwnd => Hwnd = hwnd,
            IntPtr ptr => Hwnd = new HWND(ptr),
            WindowProc proc => Hwnd = proc.Hwnd,
            _ => throw new NotSupportedException("The window proc only support the Intptr/HWND/WindowProc")
        };
    }



    /// <summary>
    /// 窗口的标题文本，显示在窗口的标题栏中。
    /// </summary>
    public string Caption
    {
        get
        {
            var count = PInvoke.GetWindowTextLength(Hwnd) + 1;

            unsafe
            {
                var buffer = stackalloc char[count];
                var pwstr = new PWSTR(buffer);

                return PInvoke.GetWindowText(Hwnd, pwstr, count) == 0 ? string.Empty : pwstr.ToString();
            }
        }

        set
        {
            if (PInvoke.SetWindowText(Hwnd, value).Value == 0)
                throw new Exception($"Set Window Caption Error. Code is {ErrorHelper.ErrorString}");
        }
    }

    /// <summary>
    /// 窗口的句柄（HWND），是操作窗口的唯一标识符。
    /// </summary>
    public string Handle => Convert.ToString(Hwnd.Value, 16).PadLeft(16, '0');

    /// <summary>
    /// 窗口过程（Window Procedure）的指针或地址，用于处理窗口消息的回调函数。
    /// </summary>
    public long Proc => NativeHelper.GetWindowLong(Hwnd, WINDOW_LONG_PTR_INDEX.GWL_WNDPROC);

    /// <summary>
    /// 窗口所属的应用程序实例句柄（HINSTANCE），用于标识加载窗口资源的模块。
    /// </summary>
    public long InstanceHandle => NativeHelper.GetWindowLong(Hwnd, WINDOW_LONG_PTR_INDEX.GWLP_HINSTANCE);

    /// <summary>
    /// 窗口的用户数据，可以存储任意的应用程序定义的数据。
    /// </summary>
    public long UserData => NativeHelper.GetWindowLong(Hwnd, WINDOW_LONG_PTR_INDEX.GWL_USERDATA);




    #region Windows

    /// <summary>
    /// 下一个窗口的句柄，用于窗口列表遍历。
    /// </summary>
    nint Next { get; }

    /// <summary>
    /// 前一个窗口的句柄，用于窗口列表遍历。
    /// </summary>
    nint Previous { get; }

    /// <summary>
    /// 父窗口的句柄，指向包含当前窗口的窗口。
    /// </summary>
    nint Parent { get; set; }

    /// <summary>
    /// 第一个子窗口的句柄，用于子窗口列表遍历。
    /// </summary>
    nint FirstChild { get; }

    /// <summary>
    /// 所有者窗口的句柄，通常用于模态对话框和控件。
    /// </summary>
    nint Owner { get; }

    #endregion

    #region Class



    /// <summary>
    /// 窗口类样式（CS_开头的常量），定义窗口类的行为和特性。
    /// </summary>
    int ClassStyle { get; }

    /// <summary>
    /// 分配给窗口类的额外字节数，可以用于存储窗口类相关的数据。
    /// </summary>
    int ClassBytes { get; }

    /// <summary>
    /// 窗口类所属的应用程序实例句柄（HINSTANCE），用于标识加载窗口类资源的模块。
    /// </summary>
    nint ClassInstanceHandle { get; }

    /// <summary>
    /// 窗口类的窗口过程（Window Procedure）的指针或地址，用于处理窗口消息的回调函数。
    /// </summary>
    nint ClassWindowProc { get; }

    /// <summary>
    /// 窗口类的菜单名称，用于窗口类的默认菜单。
    /// </summary>
    string ClassMenuName { get; }

    /// <summary>
    /// 窗口类的图标句柄，用于窗口类的默认图标。
    /// </summary>
    nint ClassIconHandle { get; }

    /// <summary>
    /// 窗口类的光标句柄，用于窗口类的默认光标。
    /// </summary>
    nint ClassCursorHandle { get; }

    /// <summary>
    /// 窗口类的原子值（Atom），是窗口类的唯一标识符。
    /// </summary>
    short ClassAtom { get; }

    /// <summary>
    /// 窗口类的背景画刷句柄，用于绘制窗口类的背景。
    /// </summary>
    nint ClassBackgroundBrush { get; }

    /// <summary>
    /// 分配给窗口类的额外字节数，可以用于存储窗口类相关的数据。
    /// </summary>
    int ClassWindowBytes { get; }

    #endregion

    #region Process

    /// <summary>
    /// 创建窗口的进程ID，用于标识窗口所属的进程。
    /// </summary>
    int ProcessId { get; }

    /// <summary>
    /// 创建窗口的线程ID，用于标识窗口所属的线程。
    /// </summary>
    int ThreadId { get; }

    #endregion
}