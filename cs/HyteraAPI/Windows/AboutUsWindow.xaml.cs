using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HyteraAPI.Windows
{
    /// <summary>
    /// About Us
    /// </summary>
    public partial class AboutUsWindow : Window
    {
        public AboutUsWindow()
        {
            InitializeComponent();
        }

        private void RootWindow_Deactivated(object sender, EventArgs e)
        {
            this.Close();
        }


        #region 暂时不用

        private void AboutUsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (Environment.OSVersion.Version.Major == 10)
            {
                Win10BlurHelper.EnableBlur(this);
            }
            else
            {
                this.BorderThickness = new Thickness(0.5);
                this.BorderBrush = Brushes.DarkGray;
                Win7BlurHelper.EnableAeroGlass(this);
            }
        }


        //==================================================
        static class Win10BlurHelper

        {

            [DllImport("user32.dll")]

            internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);



            internal enum AccentState

            {

                ACCENT_DISABLED = 0,

                ACCENT_ENABLE_GRADIENT = 1,

                ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,

                ACCENT_ENABLE_BLURBEHIND = 3,

                ACCENT_INVALID_STATE = 4

            }



            [StructLayout(LayoutKind.Sequential)]

            internal struct AccentPolicy

            {

                public AccentState AccentState;

                public int AccentFlags;

                public int GradientColor;

                public int AnimationId;

            }



            [StructLayout(LayoutKind.Sequential)]

            internal struct WindowCompositionAttributeData

            {

                public WindowCompositionAttribute Attribute;

                public IntPtr Data;

                public int SizeOfData;

            }



            internal enum WindowCompositionAttribute

            {

                // ...

                WCA_ACCENT_POLICY = 19

                // ...

            }



            public static void EnableBlur(Window _window)

            {

                var WindowPtr = new WindowInteropHelper(_window).Handle;



                var accent = new AccentPolicy()

                {

                    AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND,

                    AccentFlags = 0x20 | 0x40 | 0x80 | 0x100,

                    //GradientColor = 0x000000FF,

                    //AnimationId = 

                };

                var accentStructSize = Marshal.SizeOf(accent);



                var accentPtr = Marshal.AllocHGlobal(accentStructSize);

                Marshal.StructureToPtr(accent, accentPtr, false);



                var data = new WindowCompositionAttributeData()

                {

                    Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,

                    SizeOfData = accentStructSize,

                    Data = accentPtr

                };

                SetWindowCompositionAttribute(WindowPtr, ref data);



                Marshal.FreeHGlobal(accentPtr);

            }

        }



        static class Win7BlurHelper

        {

            [DllImport("dwmapi.dll")]

            static extern void DwmEnableBlurBehindWindow(IntPtr hwnd, ref DWM_BLURBEHIND blurBehind);



            struct DWM_BLURBEHIND

            {

                public uint dwFlags;

                public bool fEnable;

                public IntPtr hRgnBlur;

                public bool fTransitionOnMaximized;

            }



            public static void EnableAeroGlass(Window _window)

            {

                var WindowPtr = new WindowInteropHelper(_window).Handle;



                var Blur = new DWM_BLURBEHIND()

                {

                    dwFlags = 0x00000001 | 0x00000002,

                    fEnable = true

                };



                DwmEnableBlurBehindWindow(WindowPtr, ref Blur);

            }

        }
#endregion 
    }

}
