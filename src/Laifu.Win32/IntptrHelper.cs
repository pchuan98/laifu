using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laifu.Win32;

public static class IntptrHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ptr"></param>
    /// <param name="width"></param>
    /// <returns></returns>
    public static string To16Str(this IntPtr ptr, int width = 16)
        => Convert.ToString(ptr.ToInt64(), 16).PadLeft(width, '0');
}