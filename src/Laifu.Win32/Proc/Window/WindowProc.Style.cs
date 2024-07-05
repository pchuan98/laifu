using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32;
using Windows.Win32.UI.WindowsAndMessaging;

// ReSharper disable once CheckNamespace
namespace Laifu.Win32.Proc;

// https://learn.microsoft.com/zh-cn/windows/win32/winmsg/window-styles
public enum WindowStyle : uint
{
    /// <summary>
    /// 窗口具有细线边框。
    /// </summary>
    Border = 0x00800000,

    /// <summary>
    /// 窗口具有标题栏，包含 <see cref="Border"/> 样式。
    /// </summary>
    Caption = 0x00C00000,

    /// <summary>
    /// 窗口是子窗口。具有此样式的窗口不能有菜单栏。此样式不能与 <see cref="Popup"/> 样式一起使用。
    /// </summary>
    Child = 0x40000000,

    /// <summary>
    /// 排除在父窗口内进行绘制时子窗口占用的区域。创建父窗口时使用此样式。
    /// </summary>
    ClipChildren = 0x02000000,

    /// <summary>
    /// 相对于彼此剪裁子窗口; 当特定子窗口收到 <b>WM_PAINT</b> 消息时，会将所有其他重叠的子窗口剪裁到子窗口的区域之外进行更新。
    /// 如果未指定 <see cref="ClipSiblings"/> 且子窗口重叠，则可以在相邻子窗口的工作区内绘制。
    /// </summary>
    ClipSiblings = 0x04000000,

    /// <summary>
    /// 窗口最初处于禁用状态。已禁用的窗口无法接收用户的输入。
    /// 若要在创建窗口后更改此设置，请使用 <b>EnableWindow</b> 函数。
    /// </summary>
    Disabled = 0x08000000,

    /// <summary>
    /// 窗口具有通常与对话框一起使用的样式的边框。具有此样式的窗口不能具有标题栏。
    /// </summary>
    DlgFrame = 0x00400000,

    /// <summary>
    /// 窗口是一组控件的第一个控件。 组由第一个控件及其后定义的所有控件组成，以及具有 <see cref="Group"/> 样式的下一个控件。
    /// 每个组中的第一个控件通常具有 <see cref="TabsTop"/> 样式，以便用户可以在组之间移动。 用户随后可以使用方向键将键盘焦点从组中的一个控件更改为组中的下一个控件。
    /// </summary>
    Group = 0x00020000,

    /// <summary>
    /// 窗口具有水平滚动条。
    /// </summary>
    HScroll = 0x00100000,

    /// <summary>
    /// 窗口最初最小化。与 <see cref="Minimize"/> 样式相同。
    /// </summary>
    Iconic = 0x20000000,

    /// <summary>
    /// 窗口最初是最大化的。
    /// </summary>
    Maximize = 0x01000000,

    /// <summary>
    /// 窗口有一个“最大化”按钮。不能与 <see cref="WindowStyleEx.ContextHelp"/> 样式组合使用。还必须指定 <see cref="SysMenu"/> 样式。
    /// </summary>
    MaximizeBox = 0x00010000,

    /// <summary>
    /// 窗口最初最小化。 与 <see cref="Iconic"/> 样式相同。
    /// </summary>
    Minimize = 0x20000000,

    /// <summary>
    /// 窗口有一个最小化按钮。 不能与 <see cref="WindowStyleEx.ContextHelp"/> 样式组合使用。 还必须指定 <see cref="SysMenu"/> 样式。
    /// </summary>
    MinimizeBox = 0x00020000,

    /// <summary>
    /// 窗口是一个重叠的窗口。重叠的窗口带有标题栏和边框。与 <see cref="Tiled"/> 样式相同。
    /// </summary>
    Overlapped = 0x00000000,

    /// <summary>
    /// 窗口是重叠的窗口。与 <see cref="TiledWindow"/> 样式相同。
    /// </summary>
    OverlappedWindow = (Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox),

    /// <summary>
    /// 窗口是弹出窗口。此样式不能与 <see cref="Child"/> 样式一起使用。
    /// </summary>
    Popup = 0x80000000,

    /// <summary>
    /// 窗口是弹出窗口。必须组合 <see cref="Caption"/> 和 <see cref="PopupWindow"/> 样式，使窗口菜单可见。
    /// </summary>
    PopupWindow = (Popup | Border | SysMenu),

    /// <summary>
    /// 窗口具有大小调整边框。与 <see cref="ThickFrame"/> 样式相同。
    /// </summary>
    SizeBox = 0x00040000,

    /// <summary>
    /// 窗口的标题栏上有一个窗口菜单。还必须指定 <see cref="Caption"/> 样式。
    /// </summary>
    SysMenu = 0x00080000,

    /// <summary>
    /// 窗口是一个控件，可以接收键盘焦点。按 Tab 键将键盘焦点更改为具有 <see cref="TabsTop"/> 样式的下一个控件。
    /// </summary>
    TabsTop = 0x00010000,

    /// <summary>
    /// 窗口具有调整大小边框。与 <see cref="SizeBox"/> 样式相同。
    /// </summary>
    ThickFrame = 0x00040000,

    /// <summary>
    /// 该窗口是一个重叠的窗口。重叠的窗口带有标题栏和边框。与 <see cref="Overlapped"/> 样式相同。
    /// </summary>
    Tiled = 0x00000000,

    /// <summary>
    /// 该窗口是一个重叠的窗口。与 <see cref="OverlappedWindow"/> 样式相同。
    /// </summary>
    TiledWindow = (Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox),

    /// <summary>
    /// 窗口最初是可见的。
    /// </summary>
    Visible = 0x10000000,

    /// <summary>
    /// 窗口具有垂直滚动条。
    /// </summary>
    VScroll = 0x00200000
}

public enum WindowStyleEx : uint
{
    /// <summary>
    /// 窗口接受拖放文件。
    /// </summary>
    AcceptFiles = 0x00000010,

    /// <summary>
    /// 在顶级窗口可见时强行将其放在任务栏上。
    /// </summary>
    AppWindow = 0x00040000,

    /// <summary>
    /// 窗口有一个带有凹陷边缘的边框。
    /// </summary>
    ClientEdge = 0x00000200,

    /// <summary>
    /// 使用双缓冲按从下到上绘制顺序绘制窗口的所有后代。
    /// 从下到上绘制顺序允许后代窗口具有半透明 (alpha) 和透明度 (颜色键) 效果，但前提是后代窗口还设置了 <see cref="Transparent"/> 位。
    /// 通过双重缓冲，可以在不闪烁的情况下绘制窗口及其后代。 如果窗口的类样式为 <b>CS_OWNDC </b> 或 <b>CS_CLASSDC</b>，则无法使用此选项。
    /// </summary>
    Composited = 0x02000000,

    /// <summary>
    /// 窗口的标题栏包含问号。 当用户单击该问号时，光标将变成带指针的问号。 如果用户随后单击子窗口，则子窗口将收到 <b>WM_HELP</b> 消息。
    /// 子窗口应将消息传递到父窗口过程，父窗口过程应使用 <b>HELP_WM_HELP</b> 命令调用 WinHelp 函数。 帮助应用程序显示一个弹出窗口，该窗口通常包含子窗口的帮助。
    /// </summary>
    ContextHelp = 0x00000400,

    /// <summary>
    /// 窗口本身包含应参与对话框导航的子窗口。 如果指定了此样式，则执行导航操作（例如处理 TAB 键、箭头键或键盘助记键）时，对话管理器将递归为此窗口的子级。
    /// <see cref="ContextHelp"/> 不能与 <see cref="WindowStyle.MaximizeBox"/> 或 <see cref="WindowStyle.MinimizeBox"/> 样式一起使用。
    /// </summary>
    ControlParent = 0x00010000,

    /// <summary>
    /// 窗口有一个双边框：（可选）可以通过在 dwStyle 参数中指定 <see cref="WindowStyle.Caption"/> 样式来创建带有标题栏的窗口。
    /// </summary>
    DlgModalFrame = 0x00000001,

    /// <summary>
    /// 该窗口是一个分层窗口。 如果窗口的 类样式 为 <b>CS_OWNDC</b> 或 <b>CS_CLASSDC</b>，则不能使用此样式。
    /// Windows 8：顶级窗口和子窗口支持WS_EX_LAYERED样式。 以前的 Windows 版本仅支持 顶级窗口WS_EX_LAYERED 。
    /// </summary>
    Layered = 0x00080000,

    /// <summary>
    /// 如果 shell 语言是希伯来语、阿拉伯语或其他支持阅读顺序对齐的语言，则窗口的水平原点位于右边缘。 增加水平值后向左。
    /// </summary>
    LayoutRtl = 0x00400000,

    /// <summary>
    /// 窗口具有泛型左对齐属性。 这是默认设置。
    /// </summary>
    Left = 0x00000000,

    /// <summary>
    /// 如果 shell 语言是希伯来语、阿拉伯语或其他支持阅读顺序对齐的语言，则垂直滚动条 (（如果存在) ）位于工作区左侧。 对于其他语言，将忽略该样式。
    /// </summary>
    LeftScrollbar = 0x00004000,

    /// <summary>
    /// 窗口文本使用从左到右的阅读顺序属性显示。 这是默认值。
    /// </summary>
    LtrReading = 0x00000000,

    /// <summary>
    /// 该窗口是 MDI 子窗口。
    /// </summary>
    MdiChild = 0x00000040,

    /// <summary>
    /// 用户单击时，使用此样式创建的顶级窗口不会成为前台窗口。 当用户最小化或关闭前台窗口时，系统不会将此窗口带到前台。
    /// 不应通过编程访问或通过键盘导航（如讲述人）激活窗口。
    /// 若要激活窗口，请使用 SetActiveWindow 或 SetForegroundWindow 函数。
    /// 默认情况下，窗口不会显示在任务栏上。 若要强制窗口显示在任务栏上，请使用 <see cref="AppWindow"/> 样式。
    /// </summary>
    NoActivate = 0x08000000,

    /// <summary>
    /// 窗口不将其窗口布局传递给其子窗口。
    /// </summary>
    NoInheritLayout = 0x00100000,

    /// <summary>
    /// 使用此样式创建的子窗口在创建或销毁时不会将 <b>WM_PARENTNOTIFY</b> 消息发送到其父窗口。
    /// </summary>
    NoParentNotify = 0x00000004,

    /// <summary>
    /// 窗口不会呈现到重定向图面。 这适用于没有可见内容或使用表面以外的机制提供其视觉对象的窗口。
    /// </summary>
    NoRedirectionBitmap = 0x00200000,

    /// <summary>
    /// 窗口是重叠的窗口。
    /// </summary>
    OverlappedWindow = (WindowEdge | ClientEdge),

    /// <summary>
    /// 窗口是调色板窗口，它是一个无模式对话框，显示命令数组。
    /// </summary>
    PaletteWindow = (WindowEdge | ToolWindow | TopMost),

    /// <summary>
    /// 窗口具有通用的“右对齐”属性。 这依赖于窗口类。 仅当 shell 语言是希伯来语、阿拉伯语或其他支持阅读顺序对齐的语言时，此样式才有效;否则，将忽略该样式。
    /// 对静态控件或编辑控件使用 WS_EX_RIGHT 样式的效果与分别使用 SS_RIGHT 或 ES_RIGHT 样式的效果相同。
    /// 将此样式用于按钮控件的效果与使用 BS_RIGHT 和 BS_RIGHTBUTTON 样式的效果相同。
    /// </summary>
    Right = 0x00001000,

    /// <summary>
    /// 如果 shell 语言是希伯来语、阿拉伯语或其他支持阅读顺序对齐的语言，则垂直滚动条 (。 这是默认值。
    /// </summary>
    RightScrollbar = 0x00000000,

    /// <summary>
    /// 如果 shell 语言是希伯来语、阿拉伯语或其他支持阅读顺序对齐的语言，则使用从右到左的阅读顺序属性显示窗口文本。 对于其他语言，将忽略该样式。
    /// </summary>
    RtlReading = 0x00002000,

    /// <summary>
    /// 窗口具有三维边框样式，旨在用于不接受用户输入的项。
    /// </summary>
    StaticEdge = 0x00020000,

    /// <summary>
    /// 该窗口旨在用作浮动工具栏。 工具窗口具有短于普通标题栏的标题栏和使用较小的字体绘制的窗口标题。
    /// 工具窗口不会显示在任务栏中，也不会显示在用户按 Alt+TAB 时显示的对话框中。
    /// 如果工具窗口具有系统菜单，则其图标不会显示在标题栏上。 但是，可以通过右键单击或键入 ALT+SPACE 来显示系统菜单。
    /// </summary>
    ToolWindow = 0x00000080,

    /// <summary>
    /// 窗口应放置在所有非最顶部窗口的上方，并且应保持在窗口上方，即使窗口已停用也是如此。 若要添加或删除此样式，请使用 SetWindowPos 函数。
    /// </summary>
    TopMost = 0x00000008,

    /// <summary>
    /// 在绘制由同一线程) 创建的窗口下的同级 (之前，不应绘制窗口。 该窗口显示为透明，因为基础同级窗口的位已被绘制。
    /// 若要在不受这些限制的情况下实现透明度，请使用 SetWindowRgn 函数。
    /// </summary>
    Transparent = 0x00000020,

    /// <summary>
    /// 窗口的边框带有凸起的边缘。
    /// </summary>
    WindowEdge = 0x00000100
}

public partial class WindowProc
{
    /// <summary>
    /// 窗口的样式（WS_开头的常量），定义窗口的外观和行为。
    /// </summary>
    public List<WindowStyle> Styles
    {
        get
        {
            var styles = Enum.GetValues(typeof(WindowStyle));

            foreach (WindowStyle style in styles)
            {
                Console.WriteLine(style);
            }



            //var lStyle = LStyles;

            //for (int i = 0; i < styles.Length; i++)
            //{

            //}

            //var ss = styles.Cast<WindowStyle>().Where(style => ((long)style | lStyle) == lStyle).ToList();

            //return styles;
            return new();
        }
    }

    public long LStyles => NativeHelper.GetWindowLong(Hwnd, WINDOW_LONG_PTR_INDEX.GWL_STYLE);

    /// <summary>
    /// 窗口的扩展样式（WS_EX_开头的常量），提供额外的外观和行为选项。
    /// </summary>
    public int ExtendedStyles { get; set; }
}