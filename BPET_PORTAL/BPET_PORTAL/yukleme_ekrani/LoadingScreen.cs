using System;
using System.Windows.Forms;

namespace BPET_PORTAL.yukleme_ekrani
{
    public partial class LoadingScreen : Form
    {
        private static LoadingScreen _instance;

        // Singleton deseni için özel instance oluşturma metodu
        public static LoadingScreen Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new LoadingScreen();
                }
                return _instance;
            }
        }

        private LoadingScreen()
        {
            InitializeComponent();
        }

        public static void ShowLoadingScreen()
        {
            var screen = Instance;
            screen.Show();
            // Animasyonları burada başlat
        }

        public static void HideLoadingScreen()
        {
            var screen = Instance;
            screen.Hide();
            // Animasyonları burada durdur
        }
    }
}
