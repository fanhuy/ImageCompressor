using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Encoder = System.Drawing.Imaging.Encoder;
using File = System.IO.File;
using Image = System.Drawing.Image;
using TextBox = System.Windows.Forms.TextBox;
using ToolTip = System.Windows.Forms.ToolTip;
namespace VssImageCompress__VIC_
{
    public partial class frm_compress : Form
    {
        int formheight;
        public frm_compress()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Continuous; // Thiết lập kiểu ProgressBar
            this.Height = this.MinimumSize.Height;
            this.gb2.Height = this.gb2.MinimumSize.Height;
        }

        private async void btn_compress_Click(object sender, EventArgs e)
        {
            if (ck_folder.Checked == true)
            {
                compressfolder();
            }
            else
            {
                compressimage();
            }
        }
        private void fixheight()
        {
            foreach (Control ctl in gb2.Controls)
            {
                if (ctl.Visible == false)
                {
                    ctl.Visible = true;
                }
            }
            this.Height = this.MaximumSize.Height;
            this.gb2.Height = this.gb2.MaximumSize.Height;
        }
        private async void compressimage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            ofd.Multiselect = true;
            ofd.Title = "Vui lòng chọn ảnh cần nén";


            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fixheight();
                //pictureBox1.Image = Image.FromFile(ofd.FileName);
                //txt_source.Text = Path.GetDirectoryName(ofd.FileName);
                txt_source.Text = Path.GetDirectoryName(ofd.FileName);

                if (txt_destination.Text.Length == 0)
                {
                    txt_destination.Text = txt_source.Text;
                    //txt_destination.Text = Path.GetDirectoryName(ofd.FileName) + @"\" + txt_imgsize.Text + "KB";
                }

                string compressedfolder = txt_destination.Text;
                
                int soluong = ofd.FileNames.Count();

                if (ofd.FileNames.Count() > 0)
                {

                    if (!Directory.Exists(compressedfolder))
                    {
                        Directory.CreateDirectory(compressedfolder);
                    }

                    progressBar1.Maximum = soluong; // Cập nhật giá trị tối đa của ProgressBar
                    progressBar1.Value = 0; // Đặt giá trị ban đầu là 0

                    foreach (var file in ofd.FileNames)
                    {
                        await Task.Run(() =>
                        {
                            CompressImageToSize(file, Path.Combine(compressedfolder, Path.GetFileName(file)), int.Parse(txt_imgsize.Text));
                        });

                        progressBar1.Visible = true;
                        progressBar1.Invoke((Action)(() =>
                        {
                            progressBar1.Value++; // Cập nhật giá trị ProgressBar sau mỗi ảnh
                            int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                            progressBar1.Refresh();
                            progressBar1.CreateGraphics().DrawString(percent.ToString() + "%",
                                new Font("Arial", (float)8.25, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                        }));
                    }
                }

                DialogResult dialogResult = MessageBox.Show("Đã hoàn thành nén " + soluong + " ảnh.\r\nBạn có muốn mở thư mục ảnh sau khi nén?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(txt_destination.Text);
                    }
                    catch (Win32Exception win32Exception)
                    {
                        //The system cannot find the file specified...
                        Console.WriteLine(win32Exception.Message);
                    }
                }
            }
        }

        private async void compressfolder()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            ofd.Multiselect = false;
            ofd.Title = "Vui lòng chọn thư mục cần nén ảnh";


            ofd.ValidateNames = false;
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;
            ofd.RestoreDirectory = true;

            ofd.FileName = "Chọn thư mục chứa ảnh";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fixheight();
                //pictureBox1.Image = Image.FromFile(ofd.FileName);
                txt_source.Text = Path.GetDirectoryName(ofd.FileName);
                
                if (txt_destination.Text.Length == 0)
                {
                    txt_destination.Text = txt_source.Text;
                    //txt_destination.Text = Path.GetDirectoryName(ofd.FileName) + @"\" + txt_imgsize.Text + "KB";
                }

                var imageFiles = Directory.GetFiles(Path.GetDirectoryName(ofd.FileName), "*.*", SearchOption.TopDirectoryOnly)
                                  .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                                              f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                              f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                                              f.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                                  .ToList();
                int soluong = 0;
                string compressedfolder = txt_destination.Text;
                if (imageFiles.Count > 0)
                {
                    if (!Directory.Exists(compressedfolder))
                    {
                        Directory.CreateDirectory(compressedfolder);
                    }

                    progressBar1.Maximum = imageFiles.Count; // Cập nhật giá trị tối đa của ProgressBar
                    progressBar1.Value = 0; // Đặt giá trị ban đầu là 0

                    foreach (var file in imageFiles)
                    {
                        await Task.Run(() =>
                        {
                            CompressImageToSize(file, Path.Combine(compressedfolder, Path.GetFileName(file)), int.Parse(txt_imgsize.Text));
                            soluong++;
                        });

                        progressBar1.Visible = true;
                        progressBar1.Invoke((Action)(() =>
                        {
                            progressBar1.Value++; // Cập nhật giá trị ProgressBar sau mỗi ảnh
                            int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                            progressBar1.Refresh();
                            progressBar1.CreateGraphics().DrawString(percent.ToString() + "%",
                                new Font("Arial", (float)8.25, FontStyle.Regular),
                                Brushes.Black,
                                new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                        }));
                    }
                }

                DialogResult dialogResult = MessageBox.Show("Đã hoàn thành nén " + soluong + " ảnh.\r\nBạn có muốn mở thư mục ảnh sau khi nén?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Process.Start(txt_destination.Text);
                    }
                    catch (Win32Exception win32Exception)
                    {
                        //The system cannot find the file specified...
                        Console.WriteLine(win32Exception.Message);
                    }
                }
            }
        }
        private void CompressImageToSize(string inputPath, string outputPath, int targetSizeKB)
        {
            // Kiểm tra kích thước ảnh trước khi thực hiện nén
            FileInfo fileInfo = new FileInfo(inputPath);
            if (fileInfo.Length <= targetSizeKB * 1024)
            {
                //MessageBox.Show($"Ảnh đã nhỏ hơn {targetSizeKB}KB, không cần nén.");
                ///Console.WriteLine($"Ảnh đã nhỏ hơn {targetSizeKB}KB, không cần nén.");
                if (!File.Exists(outputPath))
                {
                    File.Copy(inputPath, outputPath); // Sao chép ảnh gốc vào ảnh đầu ra
                };
                return;
            }

            string tempJpgPath = null;

            // Nếu ảnh không phải là JPG, chuyển đổi sang JPG
            if (Path.GetExtension(inputPath).ToLower() != ".jpg" && Path.GetExtension(inputPath).ToLower() != ".jpeg")
            {
                tempJpgPath = Path.Combine(Path.GetDirectoryName(inputPath), "temp.jpg");
                ConvertToJpg(inputPath, tempJpgPath);
                inputPath = tempJpgPath; // Cập nhật đường dẫn ảnh đầu vào
            }

            using (Image image = Image.FromFile(inputPath))
            {
                // Resize nếu cần thiết
                Image resizedImage = ResizeImageToTargetSize(image, 1000, 1000); // Giữ ảnh trong kích thước 1000x1000

                long quality = 100; // Bắt đầu từ chất lượng cao nhất
                bool isCompressed = false;

                // Lặp để giảm chất lượng ảnh cho đến khi đạt dung lượng yêu cầu
                while (!isCompressed && quality > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ImageCodecInfo jpegCodec = GetEncoder(ImageFormat.Jpeg);
                        if (jpegCodec == null) throw new Exception("JPEG codec not found");

                        EncoderParameters encoderParams = new EncoderParameters(1);
                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);

                        resizedImage.Save(ms, jpegCodec, encoderParams);

                        if (ms.Length < targetSizeKB * 1024)
                        {
                            // Lưu ảnh khi đạt yêu cầu, nếu tồn tại thì tăng thứ tự file lên
                            File.WriteAllBytes(GetUniqueFilePath(outputPath), ms.ToArray());
                            isCompressed = true;
                        }
                    }

                    quality -= 5; // Giảm chất lượng theo từng bước
                }

                if (!isCompressed)
                {
                    Console.WriteLine("Không thể nén ảnh về dung lượng yêu cầu.");
                    //MessageBox.Show("Không thể nén ảnh về dung lượng yêu cầu.");
                }
                else
                {
                    Console.WriteLine($"Ảnh đã được nén và lưu tại {outputPath}");
                    //pictureBox2.Image = resizedImage;
                    // image.Save(outputPath);
                    //MessageBox.Show("Ảnh đã được nén !");
                }

                resizedImage.Dispose(); // Giải phóng tài nguyên
            }

            // Xóa file tạm nếu đã chuyển đổi định dạng
            if (tempJpgPath != null && File.Exists(tempJpgPath))
            {
                File.Delete(tempJpgPath);
            }
        }
        static string GetUniqueFilePath(string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
            string extension = Path.GetExtension(filePath);

            int counter = 1;
            string newFilePath = filePath;

            while (File.Exists(newFilePath))
            {
                newFilePath = Path.Combine(directory, $"{fileNameWithoutExtension}_giamdungluong_{counter}{extension}");
                counter++;
            }

            return newFilePath;
        }
        static void ConvertToJpg(string inputPath, string outputPath)
        {
            using (Image image = Image.FromFile(inputPath))
            {
                // Lưu ảnh dưới dạng JPG
                image.Save(outputPath, ImageFormat.Jpeg);
            }

            Console.WriteLine($"Ảnh đã được chuyển đổi sang JPG tại {outputPath}");
        }

        static Image ResizeImageToTargetSize(Image image, int maxWidth, int maxHeight)
        {
            image = FixImageOrientation(image);
            // Trả về ngay nếu không cần thay đổi kích thước
            if (image.Width <= maxWidth && image.Height <= maxHeight)
            {
                return (Image)image.Clone();
            }

            // Tính toán kích thước mới
            double widthRatio = (double)maxWidth / image.Width;
            double heightRatio = (double)maxHeight / image.Height;
            double scale = Math.Min(widthRatio, heightRatio);

            int newWidth = (int)(image.Width * scale);
            int newHeight = (int)(image.Height * scale);

            // Tạo ảnh mới
            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        static Image FixImageOrientation(Image image)
        {
            if (image.PropertyIdList.Contains(0x0112)) // 0x0112 là ID của thuộc tính Orientation
            {
                int orientation = image.GetPropertyItem(0x0112).Value[0];
                RotateFlipType rotateFlip = RotateFlipType.RotateNoneFlipNone;

                switch (orientation)
                {
                    case 2: rotateFlip = RotateFlipType.RotateNoneFlipX; break; // Lật ngang
                    case 3: rotateFlip = RotateFlipType.Rotate180FlipNone; break; // Xoay 180
                    case 4: rotateFlip = RotateFlipType.Rotate180FlipX; break; // Xoay 180 và lật ngang
                    case 5: rotateFlip = RotateFlipType.Rotate90FlipX; break; // Xoay 90 và lật ngang
                    case 6: rotateFlip = RotateFlipType.Rotate90FlipNone; break; // Xoay 90
                    case 7: rotateFlip = RotateFlipType.Rotate270FlipX; break; // Xoay 270 và lật ngang
                    case 8: rotateFlip = RotateFlipType.Rotate270FlipNone; break; // Xoay 270
                }

                if (rotateFlip != RotateFlipType.RotateNoneFlipNone)
                {
                    image.RotateFlip(rotateFlip);
                }

                // Loại bỏ metadata Orientation để tránh vấn đề khi lưu lại
                image.RemovePropertyItem(0x0112);
            }

            return image;
        }

        static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void txt_imgsize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void ck_file_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_file.Checked)
            {
                ck_folder.Checked = false;
            }
            else
            {
                ck_folder.Checked = true;
            }
        }

        private void ck_folder_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_folder.Checked)
            {
                ck_file.Checked = false;
            }
            else
            {
                ck_file.Checked = true;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Height = MinimumSize.Height;
        }

        private void txt_imgsize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                e.Handled = true;
        }

        private void txt_imgsize_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Length == 0 || txt.Text == "0")
            {
                txt.Text = "95";
                MessageBox.Show("Không thể để trống dung lượng cần nén\r\nKích thước tự động đặt về mặc định 95KB", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            ofd.Multiselect = false;
            ofd.Title = "Vui lòng chọn thư mục cần nén ảnh";


            ofd.ValidateNames = false;
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;
            ofd.RestoreDirectory = true;

            ofd.FileName = "Chọn thư mục chứa ảnh";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_destination.Text = Path.GetDirectoryName(ofd.FileName);
            }
        }
        // ToolTip
        ToolTip toolTip = new ToolTip
        {
            IsBalloon = true,
            ToolTipTitle = "Thông báo",
            ToolTipIcon = ToolTipIcon.Warning
        };

        private void frm_compress_Load(object sender, EventArgs e)
        {
            
        }

        private void txt_source_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_source.Text))
            {
                toolTip.Show("Vui lòng bấm nút Nén ảnh để chọn ảnh/thư mục chứa ảnh !", txt_source, txt_source.Location.Y, -60, 2000); // Hiển thị tooltip trong 2 giây
            }
        }
    }
}
