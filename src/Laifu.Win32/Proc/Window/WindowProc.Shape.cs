using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32;

// ReSharper disable once CheckNamespace
namespace Laifu.Win32.Proc;

public partial class WindowProc
{
    /// <summary>
    /// 窗口的矩形区域（RECT），包含窗口的坐标和尺寸。
    /// </summary>
    public Rectangle Rectangle
    {
        get
        {
            if (PInvoke.GetWindowRect(Hwnd, out var rect).Value == 0)
                throw new Exception($"Get Window Rectangle Error. Code is {Marshal.GetLastWin32Error()}");

            return new Rectangle(rect.left, rect.top, rect.Width, rect.Height);
        }

        set
        {
            if (PInvoke.MoveWindow(Hwnd, value.X, value.Y, value.Width, value.Height, true) == 0)
                throw new Exception($"Set Window Rectangle Error. Code is {Marshal.GetLastWin32Error()}");
        }
    }

    /// <summary>
    /// 尺寸
    /// </summary>
    public Size Size => Rectangle.Size;

    /// <summary>
    /// 
    /// </summary>
    public int X
    {
        get => Rectangle.X;

        set
        {
            if (PInvoke.MoveWindow(Hwnd, value, Y, Width, Height, true) == 0)
                throw new Exception($"Set Window X Error. Code is {Marshal.GetLastWin32Error()}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Y
    {
        get => Rectangle.Y;

        set
        {
            if (PInvoke.MoveWindow(Hwnd, X, value, Width, Height, true) == 0)
                throw new Exception($"Set Window Y Error. Code is {Marshal.GetLastWin32Error()}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Height
    {
        get => Rectangle.Height;

        set
        {
            if (PInvoke.MoveWindow(Hwnd, X, Y, Width, value, true) == 0)
                throw new Exception($"Set Window Height Error. Code is {Marshal.GetLastWin32Error()}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public int Width
    {
        get => Rectangle.Width;

        set
        {
            if (PInvoke.MoveWindow(Hwnd, X, Y, value, Height, true) == 0)
                throw new Exception($"Set Window Width Error. Code is {Marshal.GetLastWin32Error()}");
        }
    }

    /// <summary>
    /// 客户区矩形区域（RECT），不包括窗口边框、标题栏和菜单的内部区域。
    /// </summary>
    public Rectangle ClientRect
    {
        get
        {
            if (PInvoke.GetClientRect(Hwnd, out var rect) == 0)
                throw new Exception($"Set Window Client Rect Error. Code is {Marshal.GetLastWin32Error()}");

            return rect;
        }
    }
}