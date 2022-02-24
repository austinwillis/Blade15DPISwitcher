using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ResolutionScaleSwitcher
{
    public partial class ContextMenu : ApplicationContext
    {

        public enum DMDO
        {
            DEFAULT = 0,
            D90 = 1,
            D180 = 2,
            D270 = 3
        }
        public ContextMenu()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct DEVMODE
        {
            public const int DM_PELSWIDTH = 0x80000;
            public const int DM_PELSHEIGHT = 0x100000;
            private const int CCHDEVICENAME = 32;
            private const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;

            public int dmPositionX;
            public int dmPositionY;
            public DMDO dmDisplayOrientation;
            public int dmDisplayFixedOutput;

            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);

        private void set_dpi_175(object sender, EventArgs e)
        {
            ChangeDPI(unchecked((int)4294967295));
        }

        private void set_dpi_200(object sender, EventArgs e)
        {
            ChangeDPI(0);
        }

        void ChangeDPI(int dpi)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel", true);

            key = key.OpenSubKey("Desktop", true);
            key = key.OpenSubKey("PerMonitorSettings", true);
            key = key.OpenSubKey("SDCA0290_08_07E3_49^DAC5CA7C91D1CAE19578119E99FB61AB", true); // my second monitor here

            key.SetValue("DpiValue", dpi);

            SetResolution(2560, 1440); // this sets the resolution on primary screen
            SetResolution(3840, 2160); // returning back to my primary screens default resolution
        }

        private static void SetResolution(int w, int h)
        {
            long RetVal = 0;

            DEVMODE dm = new DEVMODE();

            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));

            dm.dmPelsWidth = w;
            dm.dmPelsHeight = h;

            dm.dmFields = DEVMODE.DM_PELSWIDTH | DEVMODE.DM_PELSHEIGHT;


            ChangeDisplaySettings(ref dm, 0);
        }
    }
}