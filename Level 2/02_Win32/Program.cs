using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Win32
{
    partial class Program
    {
        static void Main(string[] args)
        {
            IntPtr hInstance = System.Diagnostics.Process.GetCurrentProcess().Handle;
            WNDCLASS wndclass = new WNDCLASS();
            string szAppName = "HelloWin";
            wndclass.style = (uint)ClassStyles.HorizontalRedraw | (uint)ClassStyles.VerticalRedraw;
            WndProc wndproc = WndProc2;
            wndclass.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(wndproc);

            //wndclass.cbClsExtra = 0;
            //wndclass.cbWndExtra = 0;
            wndclass.hInstance = hInstance;
            wndclass.hIcon = LoadIcon(
            IntPtr.Zero, new IntPtr((int)SystemIcons.IDI_EXCLAMATION));
            wndclass.hCursor = LoadCursor(
            IntPtr.Zero, (int)StandardCursors.IDC_CROSS);
            wndclass.hbrBackground = GetStockObject(StockObjects.WHITE_BRUSH);
            //wndclass.lpszMenuName = null;
            wndclass.lpszClassName = szAppName;

            //WindowStylesEx.WS_EX_OVERLAPPEDWINDOW
            ushort regResult = RegisterClassW(ref wndclass);
            if (regResult == 0)
            {
                MessageBox(IntPtr.Zero, "This program requires Windows NT!",
                        szAppName, (int)MessageBoxOptions.IconError);
                return;
            }

            IntPtr hwnd = CreateWindowEx(
                WindowStylesEx.WS_EX_APPWINDOW,
                szAppName,
                "Win32 from C#",
                //(uint)Native.WindowStyles.WS_CHILD |
                WindowStyles.WS_OVERLAPPEDWINDOW |
                WindowStyles.WS_VISIBLE,
                100,100,500,200,
                IntPtr.Zero,IntPtr.Zero,IntPtr.Zero,IntPtr.Zero
            );

            IntPtr btn = CreateWindowEx(
                0,
                "BUTTON",
                "OK",
                WindowStyles.WS_CHILD |
                WindowStyles.WS_VISIBLE,
                10, 10, 50, 20,
                hwnd, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero
            );

            if (hwnd == IntPtr.Zero)
            {
                int lastError = Marshal.GetLastWin32Error();
                string errorMessage = new Win32Exception(lastError).Message;
            }

            ShowWindow(hwnd, ShowWindowCommands.Normal);
            UpdateWindow(hwnd);
            MSG msg;

            while (GetMessage(out msg, IntPtr.Zero, 0, 0) != 0)
            {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }

            return;
        }

        static IntPtr WndProc2(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam)
        {
            IntPtr hdc;
            PAINTSTRUCT ps;
            RECT rect;

            switch (msg)
            {
                case WM.WM_PAINT:
                    hdc = BeginPaint(hWnd, out ps);
                    GetClientRect(hWnd, out rect);

                    DrawText(hdc, "Hello, Windows 98!", -1, ref rect,
                    DT_SINGLELINE | DT_CENTER | DT_VCENTER);

                    EndPaint(hWnd, ref ps);
                    return IntPtr.Zero;
                case WM.WM_DESTROY:
                    PostQuitMessage(0);
                    return IntPtr.Zero;
                default:
                    Debug.WriteLine(msg);
                    return DefWindowProc(hWnd, msg, wParam, lParam);
            }
        }
    }
}

