using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace GenerateAvatarWithName
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var email = Console.ReadLine();
            var path = GenerateCircle(email);
            Console.WriteLine(path);
            return 0;


        }

        private static List<string> _BackgroundColours = new List<string> { "339966", "3366CC", "CC33FF", "FF5050" };
        public static string GenerateCircle(string UserMail)
        {
            var avatarString = string.Format("{0}", UserMail[0]).ToUpper();

            var randomIndex = new Random().Next(0, _BackgroundColours.Count - 1);
            var bgColour = _BackgroundColours[randomIndex];

            var bmp = new Bitmap(192, 192);
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            var font = new Font("Arial", 72, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(bmp);

            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#" + bgColour)))
            {
                graphics.FillEllipse(b, new Rectangle(0, 0, 192, 192));
            }
            graphics.DrawString(avatarString, font, new SolidBrush(Color.WhiteSmoke), 95, 100, sf);
            graphics.Flush();

            string saveTo = Path.Combine(Environment.CurrentDirectory, UserMail + ".png");
            //var ms = new MemoryStream();
            bmp.Save(saveTo, ImageFormat.Png);
            return saveTo;
        }




    }

}