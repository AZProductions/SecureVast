using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Cocona;
using Spectre.Console;
using KKB = Kookaburra.SDK;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SV
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cocona parses command-line and executes a command.
            CoconaApp.Run<Program>(args);
        }

        [Command(Description = "Generate QR Codes and save them to file or display them in the Terminal.")]
        public void qr([Argument] string data, bool output = true, int px = 50)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            string temp = System.IO.Path.GetTempFileName().Replace(".tmp", ".png");
            Console.WriteLine(temp);
            Console.ReadKey();
            qrCodeImage.Save(temp, ImageFormat.Png);
            // Load an image
            var image = new CanvasImage(temp);

            // Set the max width of the image.
            // If no max width is set, the image will take
            // up as much space as there is available.
            image.MaxWidth(px);

            // Render the image to the console
            AnsiConsole.Render(image);

        }

        [Command(Description = "The test command.")]
        public void test([Argument] string name)
        {
        }
    }
}
