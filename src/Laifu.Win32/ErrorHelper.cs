using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.System.Diagnostics.Debug;

namespace Laifu.Win32;

public static class ErrorHelper
{
    /// <summary>
    /// 获取错误码
    /// </summary>
    public static int ErrorCode => Marshal.GetLastWin32Error();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string ErrorCode2String(uint code)
    {
        var buffer = new StringBuilder(256);
        var flags = FORMAT_MESSAGE_OPTIONS.FORMAT_MESSAGE_FROM_SYSTEM
                    | FORMAT_MESSAGE_OPTIONS.FORMAT_MESSAGE_IGNORE_INSERTS;

        PWSTR str;

        unsafe
        {
            fixed (char* p = buffer.ToString())
            {
                str = new PWSTR(p);

                if (PInvoke.FormatMessage(
                        flags,
                        null,
                        code,
                        0U,
                        str,
                        (uint)buffer.Capacity,
                        null) == 0)
                    return $"Converter to string error.Error code is {ErrorCode}";
            }
        }

        return str.ToString().TrimEnd();
    }

    /// <summary>
    /// 
    /// </summary>
    public static string ErrorString
    {
        get
        {
            var code = (uint)ErrorCode;
            var str = ErrorCode2String(code);

            return $"[{code}] - {str}";
        }
    }
}