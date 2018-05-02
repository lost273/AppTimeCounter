using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AppTimeCounter {
    class Program {
        //winapi
        [DllImport("user32.dll")]
        //retrieves a handle to the foreground window
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        //retrieves the identifier of the thread that created the specified window
        public static extern UInt32 GetWindowThreadProcessId(IntPtr hwnd, ref Int32 pid);

        static void Main(string[] args) {
            IntPtr h = GetForegroundWindow();
            int pid = 0;
            GetWindowThreadProcessId(h, ref pid);
            Process p = Process.GetProcessById(pid);
            Console.Write("pid: {0}; window: {1}", pid, p.ProcessName);

            ConsoleKeyInfo cki;
            do {
                cki = Console.ReadKey();
                Console.Clear();
                switch (cki.Key) {
                    case ConsoleKey.Escape:
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
