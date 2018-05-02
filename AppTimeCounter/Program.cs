using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace AppTimeCounter {
    class Program {
        //winapi
        [DllImport("user32.dll")]
        //retrieves a handle to the foreground window
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        //retrieves the identifier of the thread that created the specified window
        public static extern UInt32 GetWindowThreadProcessId(IntPtr hwnd, ref Int32 pid);

        public static Dictionary<string, DateTime> AppDictionary = new Dictionary<string, DateTime>();

        public static void Work() {
            while (true) {
                IntPtr h = GetForegroundWindow();
                int pid = 0;
                GetWindowThreadProcessId(h, ref pid);
                Process p = Process.GetProcessById(pid);

                if (AppDictionary.ContainsKey(p.ProcessName)) {

                }

                Console.WriteLine("pid: {0}; window: {1}", pid, p.ProcessName);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args) {
            ConsoleKeyInfo cki;

            Thread thread = new Thread(Work) {
                IsBackground = true
            };
            thread.Start();

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
