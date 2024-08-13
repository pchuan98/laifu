using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;

namespace Laifu.Win32;

public static class NativeHelper
{
    internal static long GetWindowLong(HWND hwnd, WINDOW_LONG_PTR_INDEX index)
    {
#if X64
        var rec = PInvoke.GetWindowLongPtr(hwnd, index);

        if (rec != 0) return rec.ToInt64();

        var code = ErrorHelper.ErrorCode;
        var str = ErrorHelper.ErrorCode2String((uint)code);
        throw new Exception($"GetWindowLong [{(int)index}] - Error. Message is '{str}'");
#elif X86
        var rec = PInvoke.GetWindowLong(hwnd, index);

        if (rec != 0) return rec;

        var code = ErrorHelper.ErrorCode;
        var str = ErrorHelper.ErrorCode2String((uint)code);
        throw new Exception($"GetWindowLong [{(int)index}] - Error. Message is '{str}'");
#endif
    }

    internal static long SetWindowLong(HWND hwnd, WINDOW_LONG_PTR_INDEX index, long value)
    {
#if X64
        var rec = PInvoke.SetWindowLongPtr(hwnd, index, (nint)value);

        if (rec != 0) return rec.ToInt64();

        var code = ErrorHelper.ErrorCode;
        var str = ErrorHelper.ErrorCode2String((uint)code);

        throw new Exception($"GetWindowLong [{(int)index}] - Error. Message is '{str}'");
#elif X86
        var rec = PInvoke.SetWindowLong(hwnd, index, (int)value);

        if (rec != 0) return rec;

        var code = ErrorHelper.ErrorCode;
        var str = ErrorHelper.ErrorCode2String((uint)code);
        throw new Exception($"SetWindowLong [{(int)index}] - Error. Message is '{str}'");
#endif
    }
}