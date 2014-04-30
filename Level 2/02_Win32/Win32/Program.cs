using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win32
{
    public partial class Program
    {
        static void Main()
        {
            //var f = new Form();
            //var btn = new Button();
            //btn.Parent = f;
            //btn.Text = "OK";
            //btn.Left = btn.Top = 20;

            //btn.Click += (o, e) =>
            //{
            //    System.Windows.Forms.MessageBox.Show("234234");
            //};

            //Application.Run(f);

            WndProc wndProc = WndProc2; 
            WNDCLASS wnd = new WNDCLASS();
            
            wnd.hIcon = LoadIcon(IntPtr.Zero, 
                (int)SystemIcons.IDI_ASTERISK);
            wnd.hCursor = LoadCursor(IntPtr.Zero,
                (int)StandardCursors.IDC_NO);

            wnd.style = (uint)ClassStyles.HorizontalRedraw
                | (uint)ClassStyles.VerticalRedraw;
            wnd.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(wndProc);
            wnd.lpszClassName = "C#_Win32";
            wnd.hbrBackground = GetStockObject(StockObjects.WHITE_BRUSH);

            var res = RegisterClassW(ref wnd);

            if (res == 0)
                return;

            IntPtr hwnd = CreateWindowEx(
                WindowStylesEx.WS_EX_APPWINDOW,
                "C#_Win32", "Form",
                WindowStyles.WS_OVERLAPPEDWINDOW,
                100, 100, 600, 400,
                IntPtr.Zero, IntPtr.Zero, 
                IntPtr.Zero, IntPtr.Zero
            );

            IntPtr btn = CreateWindowEx(
                0,
                "BUTTON", "OK",
                WindowStyles.WS_CHILD |
                    WindowStyles.WS_VISIBLE,
                40, 40, 80, 23,
                hwnd, new IntPtr(1001),
                IntPtr.Zero, IntPtr.Zero
            );

            btn = CreateWindowEx(
                0,
                "BUTTON", "Cancel",
                WindowStyles.WS_CHILD |
                    WindowStyles.WS_VISIBLE,
                160, 40, 80, 23,
                hwnd, new IntPtr(1002),
                IntPtr.Zero, IntPtr.Zero
            );

            if (hwnd == IntPtr.Zero)
            {
                int err = Marshal.GetLastWin32Error();
            }

            ShowWindow(hwnd, ShowWindowCommands.Normal);

            MSG msg;

            while(GetMessage(out msg, IntPtr.Zero, 0, 0) != 0)
            {
                DispatchMessage(ref msg);
            }
        }
        static bool x = false;
        static IntPtr WndProc2(IntPtr hwnd, WM msg, IntPtr wParam, IntPtr lParam)
        {
            IntPtr dc, old, pen;
            PAINTSTRUCT ps;
            RECT rect;

            switch(msg)
            {
                case WM.WM_PAINT:
                    //if (!x)
                    {
                        dc = BeginPaint(hwnd, out ps);
                        //Debug.WriteLine("RECT " + ps.rcPaint.Left);
                        GetClientRect(hwnd, out rect);

                        DrawText(dc, "Hello Win32!", 458,
                            ref rect, 0);

                        pen = CreatePen(0, 1, 0xff);
                        old = SelectObject(dc, pen);
                        Rectangle(dc, 100, 100, 200, 200);

                        SelectObject(dc, old);

                        EndPaint(hwnd, ref ps);
                        Debug.WriteLine(msg);
                        //x = true;
                    }
                    return IntPtr.Zero;
                case WM.WM_DESTROY:
                    PostQuitMessage(0);
                    return IntPtr.Zero;
                case WM.WM_COMMAND:
                    if (wParam.ToInt32() == 1001)
                        PostQuitMessage(0);
                    return IntPtr.Zero;
                default:
                    Debug.WriteLine(msg);
                    return DefWindowProc(hwnd, msg, wParam, lParam);
            }
        }
    }
}
