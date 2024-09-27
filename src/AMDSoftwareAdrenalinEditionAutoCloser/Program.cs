using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadeonSoftwareTerm
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            var count = 0;
            await Task.Delay(200); // 0.2秒待つ
            count = KillTargetProcess();
        }

        private static int KillTargetProcess()
        {
            // RadeonSoftware.exe というプログラムがあったら、それを終了する
            var processes = System.Diagnostics.Process.GetProcessesByName("RadeonSoftware");

            if (processes.Length > 0)
            {
                foreach (var process in processes)
                {
                    process.Kill();
                }
            }

            return processes.Length;
        }

        private static void OnSessionEnding(object sender, SessionEndingEventArgs e)
        {
            // ログアウトまたはシャットダウンの処理
            if (e.Reason == SessionEndReasons.Logoff)
            {

            }
            else if (e.Reason == SessionEndReasons.SystemShutdown)
            {
            }
        }
    }
}
