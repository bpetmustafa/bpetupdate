using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using BPET_PORTAL.yukleme_ekrani;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace BPET_PORTAL.profilsayfasi
{
    public partial class profilanasayfa : Form
    {
        private mainpage mainForm;
        private DatabaseManager dbManager = new DatabaseManager();
        private FtpManager ftpManager = new FtpManager();
        private ik_class ikManager = new ik_class();

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;

        public profilanasayfa(string eposta, mainpage mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            epostalabel.Text = eposta;
            LoadUserData(eposta);
            LoadUserProfileImage(eposta); // Profil resmini yükler
            //InitializeCamera();
        }

        private void InitializeCamera()
        {
            // Kamera cihazlarını bul
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            
            if (videoDevices.Count == 0) 
                throw new Exception("Kamera bulunamadı!");
                btnkamerayakala.Visible = false;
                btnKameraKapa.Visible = false;

            // İlk kamerayı seç (varsayılan)
            userProfilePictureBox.BackgroundImage = null;
            userProfilePictureBox.Dock = DockStyle.Fill;
            btnkamerayakala.Visible = true;
            btnKameraKapa.Visible = true;
            videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoDevice.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoDevice.Start();
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Her kareyi hemen işleme yerine, belirli bir zaman aralığında işle
            if (DateTime.Now.Millisecond % 3 == 0) // Örneğin, her 100 ms'de bir
            {
                if (userProfilePictureBox.Image != null)
                {
                    userProfilePictureBox.Image.Dispose();
                }

                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                userProfilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // veya Normal

                Invoke(new MethodInvoker(delegate
                {
                    userProfilePictureBox.Image = bitmap;
                }));
            }
        }

        private async void CaptureImage()
        {
            if (videoDevice != null && videoDevice.IsRunning)
            {
                Bitmap currentFrame = userProfilePictureBox.Image as Bitmap;
                if (currentFrame != null)
                {
                    // Resmi kaydet
                    string filePath = Path.Combine(Application.StartupPath, "capturedImage.jpg");
                    currentFrame.Save(filePath);
                    userProfilePictureBox.Dock = DockStyle.None;
                    btnkamerayakala.Visible = false;
                    btnKameraKapa.Visible = false;
                    await StopCamera();

                    // FTP'ye yükle
                    string remoteFileName = epostalabel.Text + ".jpg";
                    await ftpManager.UploadFileAsync(filePath, remoteFileName);
                    LoadUserProfileImage(epostalabel.Text);
                    
                }
            }
        }
        private async Task StopCamera()
        {
            if (videoDevice != null && videoDevice.IsRunning)
            {
                try
                {
                    videoDevice.SignalToStop();
                    videoDevice.WaitForStop();
                    btnkamerayakala.Visible = false;
                    btnKameraKapa.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("CAMERA ERROR: " + ex);
                }
            }
        }
        private void LoadUserData(string email)
        {
            DataTable userDetails = dbManager.GetUserDetails(email);
            if (userDetails.Rows.Count > 0)
            {
                nameTextBox.Text = userDetails.Rows[0]["Isim_Soyisim"].ToString();
                emailTextBox.Text = userDetails.Rows[0]["E_Posta"].ToString().Trim();
                phoneTextBox.Text = userDetails.Rows[0]["Telefon"].ToString();
                object mfaStatusObj = userDetails.Rows[0]["MFA_Durumu"];
                bool mfa_durumu = false; // Varsayılan olarak false olarak ayarla
                if (mfaStatusObj != DBNull.Value)
                {
                    mfa_durumu = Convert.ToBoolean(mfaStatusObj);
                }

                if (mfa_durumu)
                {
                    MFAlabel.Text = "2 Adımlı Doğrulama Açık";
                    MFAPictureBox.Image = Properties.Resources.icons8_verified_account_96;
                    MFAuyarilabel.Visible = false;

                }
                else
                {
                    MFAlabel.Text = "2 Adımlı Doğrulama KAPALI";
                    MFAPictureBox.Image = Properties.Resources.icons8_access_denied_96;
                    MFAuyarilabel.Visible = true;
                }
            }
            else
            {
                //MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
            }

            DataTable userikdetails = ikManager.GetUserİkDetails(nameTextBox.Text);
            if (userikdetails.Rows.Count > 0)
            {
                birimiTextBox.Text = userikdetails.Rows[0]["birim"].ToString();
                string tc = userikdetails.Rows[0]["tc"].ToString();
                string maskedTc = tc.Substring(0, 2) + new string('*', tc.Length - 4) + tc.Substring(tc.Length - 2, 2);
                tcTextBox.Text = maskedTc;
                KanGrubuTextBox.Text = userikdetails.Rows[0]["kan_grubu"].ToString();
                dogumTarihiTextBox.Text = Convert.ToDateTime(userikdetails.Rows[0]["dogum_tarihi"]).ToShortDateString();
                pozisyonunuzTextBox.Text = userikdetails.Rows[0]["pozisyon"].ToString();
            }
            else
            {
                //
            }
        }

        private async void btnUploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            userProfilePictureBox.Image = null;
            openFileDialog.Filter = "Image Files(*.jpg;)|*.jpg;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string remoteFileName = epostalabel.Text + Path.GetExtension(openFileDialog.FileName);

                // Yükleme ekranını göster
                LoadingScreen.ShowLoadingScreen();

                try
                {
                    await ftpManager.UploadFileAsync(openFileDialog.FileName, remoteFileName);
                    LoadUserProfileImage(epostalabel.Text); // Profil resmini günceller
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message);
                }

                // Yükleme ekranını gizle
                LoadingScreen.HideLoadingScreen();
            }
        }

        private async void LoadUserProfileImage(string email)
        {
            try
            {
                LoadingScreen.ShowLoadingScreen(); // Yükleme ekranını göster

                string remoteFileUri = ftpManager.GetFileUri(email + ".jpg"); // E-posta adresine göre resmi bulur
                WebClient wc = new WebClient();
                byte[] bytes = await wc.DownloadDataTaskAsync(remoteFileUri); // Asenkron indirme
                MemoryStream ms = new MemoryStream(bytes);
                Image img = Image.FromStream(ms);

                userProfilePictureBox.BackgroundImage = img; // PictureBox'ta resmi BackgroundImage olarak ayarlar
                userProfilePictureBox.BackgroundImageLayout = ImageLayout.Zoom; // Resmi ölçeklendirir
            }
            catch (Exception)
            {
                // Varsayılan resmi yükleyin
                string defaultImageUri = ftpManager.GetFileUri("varsayilan.jpg");
                LoadImageToPictureBox(defaultImageUri);
            }
            finally
            {
                LoadingScreen.HideLoadingScreen(); // Yükleme ekranını gizle
                mainForm.LoadUserProfileImage(email);
            }
        }

        private void LoadImageToPictureBox(string imageUrl)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(imageUrl);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);

            userProfilePictureBox.BackgroundImage = img; // PictureBox'ta resmi BackgroundImage olarak ayarlar
            userProfilePictureBox.BackgroundImageLayout = ImageLayout.Zoom; // Resmi ölçeklendirir
        }

        private void profilanasayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();

        }

        private void btnKameraAc_Click(object sender, EventArgs e)
        {
            InitializeCamera();
        }

        private void btnkamerayakala_Click(object sender, EventArgs e)
        {
            CaptureImage();
        }

        private void btnKameraKapa_Click(object sender, EventArgs e)
        {
            StopCamera();
            userProfilePictureBox.Image = null;
            userProfilePictureBox.Dock = DockStyle.None;
            LoadUserProfileImage(epostalabel.Text); // Profil resmini günceller

        }
        private void MFAuyarilabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dbManager.UpdateMFAStatus(epostalabel.Text,1);
            LoadUserData(epostalabel.Text);
        }

        private void MFAPictureBox_Click(object sender, EventArgs e)
        {
            if (MFAuyarilabel.Visible == false)
            {
                dbManager.UpdateMFAStatus(epostalabel.Text, 0);
                LoadUserData(epostalabel.Text);

            }
            else if (MFAuyarilabel.Visible == true)
            {
                dbManager.UpdateMFAStatus(epostalabel.Text, 1);
                LoadUserData(epostalabel.Text);

            }
        }
    }
}
