using System.Diagnostics;
using System.Runtime.InteropServices;
using System;
using System.Windows.Forms.Integration;
using System.Windows.Forms;

public class DeviceControlService : System.Windows.Controls.UserControl
{

    [DllImport("user32.dll")]
    static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll")]
    static extern bool UpdateWindow(IntPtr hWnd);

    const int SW_SHOW = 5;

    public static async Task StartScrcpy(string ip, string modelo, WindowsFormsHost host)
    {
        var adbConnect = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "adb",
                Arguments = $"connect {ip}",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            }
        };

        adbConnect.Start();
        await adbConnect.WaitForExitAsync();

        var scrypcy = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "scrcpy",
                Arguments = $"--tcpip={ip} --window-title=\"{modelo}\"",
                UseShellExecute = false,
                CreateNoWindow = false
            }
        };

        scrypcy.Start();

        var panel = new Panel();
        await host.Dispatcher.InvokeAsync(()=> host.Child = panel);
        panel.Dock = DockStyle.Fill;
        var panelHandle = panel.Handle;

        IntPtr scrcpyWindow = IntPtr.Zero;
        int retries = 0;
        int maxretries = 90;

        while(scrcpyWindow == IntPtr.Zero && retries < maxretries)
        {
            scrcpyWindow = FindWindow(null, modelo);

            if(scrcpyWindow == IntPtr.Zero)
            {
                Application.DoEvents();
                Thread.Sleep(500);
                retries ++;
            }

            if (scrcpyWindow != IntPtr.Zero)
            {
                SetParent(scrcpyWindow, panelHandle);
                MoveWindow(scrcpyWindow, 0, 0, panel.Width, panel.Height, true);
                ShowWindow(scrcpyWindow, SW_SHOW);
                UpdateWindow(scrcpyWindow);
                panel.Resize += (s, e) =>
                {
                 MoveWindow(scrcpyWindow, 0, 0, panel.Width, panel.Height, true);
                };
                return;
            }
            else
            {
                Debug.WriteLine("❌ No se encontró la ventana de scrcpy o se agotó el tiempo de espera");
            }
        }
        
    }
}