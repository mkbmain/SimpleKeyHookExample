using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {

        private static bool Enabled = true;
        [STAThread]
        static void Main()
        {
            var kh = new KeyboardHook(Kh_KeyDown);
            Application.Run();
        }

        private static int  Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt, int defaultResponse)
        {
       

            if (Enabled)
            {
                switch (key)
                {
                    // you could make this load in from a file for keymaps
                    case Keys.A:
                        SendKeys.Send("😂");
                        return -1;
                    case Keys.B:
                        SendKeys.Send("😊");
                        return -1;
                    case Keys.C:
                        SendKeys.Send("❤");
                        return -1; // this will return a -1 whQich will not send
                    case Keys.D:
                        SendKeys.Send("😒");
                        return -1;
                }
            }

            if (Shift && key == Keys.M)
            {
                Enabled = !Enabled;
                return -1;
            }

            if (Shift && key == Keys.Q)
            {
                Application.Exit();
            }

            return defaultResponse;         // if you look in keyboardhook.cs the default response is  CallNextHookEx(HookID, Code, W, L) which will send it to next window i.e the window your on 

            // so for example if we don't handle the button press will send to visual studio code but if we handle it we return -1 so won't send the real key to visual studio code
        }

    }
}
