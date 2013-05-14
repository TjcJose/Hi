using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

using Hi.Common;

namespace Hi.Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。

        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThreadExceptionHandler handler = new ThreadExceptionHandler();
            Application.ThreadException += new ThreadExceptionEventHandler(handler.Application_ThreadException);
            AppSetting.SkinName = AppSetting.ConfigGetValue("SkinName");

            //FrmTrail app = new FrmTrail();
            //Application.Run(app);
            FrmMain app = new FrmMain();
            if (app.mutex != null)
            {
                Hi.UserControlEx.UcSplash.ShowFrmSplashScreen();

                Hi.UserControlEx.UcSplash.SetStatus("正在启动主窗口...");
                Thread.Sleep(1000);

                Application.Run(app);
            }
            else
            {
                MsgBox.ShowInformation("已经有一个实例在运行！");
            }
        }
        
    }

    /// 
    /// Handles a thread (unhandled) exception.
    /// 
    internal class ThreadExceptionHandler
    {
        // Handles the thread exception. 
        public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                // Exit the program if the user clicks Abort.
                DialogResult result = ShowThreadExceptionDialog(e.Exception);
                if (result == DialogResult.Abort)
                    Application.Exit();
            }
            catch
            {
                try
                {
                    MessageBox.Show("异常错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
        private DialogResult ShowThreadExceptionDialog(Exception ex)
        {
            string errorMessage = "异常：\r\r" + ex.Message + "\r\n\n" + ex.GetType() + "\r\nStack Trace:\n" +
                ex.StackTrace;
            Hi.UserControlEx.UcError f= new Hi.UserControlEx.UcError(errorMessage);
            f.Text = "异常错误";
           
            return f.ShowDialog();
        }
    }
}