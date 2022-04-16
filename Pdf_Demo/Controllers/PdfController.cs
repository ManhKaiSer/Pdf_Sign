using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pdf_Demo.Models;
using Spire.Pdf;
using Spire.Pdf.Annotations.Appearance;
using Spire.Pdf.Fields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pdf_Demo.Controllers
{
    /// <inheritdoc />
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : Controller
    {
        [HttpPost("a")]
        public Task GetPdf()
        {
            //sign();
            return Task.CompletedTask;
        }

        [HttpPost("sign")]
        public Task Post()
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

            //using (var stream = new FileStream(fullPath, FileMode.Create))
            //{
            //    file.CopyTo(stream);
            //}
            //X509Certificate cert = new X509Certificate(Path.Combine(fullPath, file.Name));
            X509Certificate cert = X509Certificate.CreateFromCertFile(Path.Combine(fullPath,"mobi.cer"));
            //sign1(cert);
            sign();
            return Task.CompletedTask;
        }

        [HttpPost("sign-field")]
        public Task Post_Field()
        {
            signField();
            return Task.CompletedTask;
        }
        [HttpPost("Flat")]
        public Task Flat()
        {
            flat();
            return Task.CompletedTask;
        }
        private void sign1(X509Certificate file)
        {
            //Create a PdfDocument object
            PdfDocument doc = new PdfDocument();

            //Load a sample PDF file
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            var pdfFile = Path.Combine(folder, "test.pdf");
            doc.LoadFromFile(pdfFile);

            //Load the certificate 
            var fileCertificate = $"D:{Path.DirectorySeparatorChar}Demo{Path.DirectorySeparatorChar}MyCertificate.pfx";
            //PdfCertificate cert = new PdfCertificate(file);
            PdfCertificate cert = new PdfCertificate(fileCertificate, "123456");
            //Create a PdfSignature object and specify its position and size 
            //var companyInfo = JsonSerializer.Deserialize<SubjectModel>(cert.Subject);
            PdfSignature signature = new PdfSignature(doc, doc.Pages[doc.Pages.Count - 1], cert, "MySignature");
            RectangleF rectangleF = new RectangleF(doc.Pages[0].ActualSize.Width - 500, 580, 180, 70);
            signature.GraphicsMode = GraphicMode.SignDetail;
            signature.Bounds = rectangleF;
            signature.Certificated = true;
            signature.NameLabel = "Được ký bởi ";
            signature.Name = "Manh Kaiser"; //cert.GetNameInfo(X509NameType.SimpleName, false)
            signature.DateLabel = "Ký ngày: ";
            signature.Date = DateTime.Now;
            
            //Set the sign image source
            //Image img = Image.FromFile($"D:{Path.DirectorySeparatorChar}Demo{Path.DirectorySeparatorChar}digital_image.png");
            //Image image_resize = resizeImage(img, new Size(180, 80));
            //signature.SignImageSource = PdfImage.FromImage(image_resize);

            //Set the signature font 
            signature.SignDetailsFont = new PdfTrueTypeFont(new Font("Times New Roman", 7f, FontStyle.Regular), true);
            signature.SignFontColor = Color.Red;

            //Set the document permission to forbid changes but allow form fill
            signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges;

            //Save to file 
            doc.SaveToFile(Path.Combine(folder, "TextSignature1.pdf"));
            doc.Close();
        }

        private void signField()
        {
            PdfDocument pdfdoc = new PdfDocument();
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            var pdfFile = Path.Combine(folder, "test.pdf");
            pdfdoc.LoadFromFile(pdfFile);
            //PdfPageBase page = pdfdoc.Pages.Add();
            if (pdfdoc.Form == null)
            {
                pdfdoc.AllowCreateForm = true;
            };
            //var signature = new PdfSignature();

            PdfSignatureField signaturefield = new PdfSignatureField(pdfdoc.Pages[0], "Signature");
            signaturefield.Bounds = new RectangleF(pdfdoc.Pages[0].ActualSize.Width - 500, 580, 160, 60);
            signaturefield.BorderWidth = 3.0f;
            signaturefield.BorderStyle = PdfBorderStyle.Solid;
            signaturefield.BorderColor = new PdfRGBColor(Color.Red);
            //signaturefield.HighlightMode = PdfHighlightMode.Outline;
            signaturefield.Actions.MouseEnter = sign();
            pdfdoc.Form.Fields.Add(signaturefield);
            pdfdoc.SaveToFile("AddSignFieldCustom2.pdf", FileFormat.PDF);
        }

        private void flat() 
        {
            PdfDocument pdfdoc = new PdfDocument();
            var folder = Path.Combine(Directory.GetCurrentDirectory());
            var pdfFile = Path.Combine(folder, "AddSignField.pdf");
            pdfdoc.LoadFromFile(pdfFile);
            pdfdoc.Form.IsFlatten = true;
            pdfdoc.SaveToFile("FlattenSign.pdf");
        }

        private void sign()
        {
            //Create a PdfDocument object
            PdfDocument doc = new PdfDocument();

            //Load a sample PDF file
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            var pdfFile = Path.Combine(folder, "test.pdf");
            doc.LoadFromFile(pdfFile);

            //Load the certificate 
            var fileCertificate = $"D:{Path.DirectorySeparatorChar}Demo{Path.DirectorySeparatorChar}MyCertificate.pfx";
            PdfCertificate cert = new PdfCertificate(fileCertificate, "123456");

            //Create a PdfSignature object and specify its position and size 
            PdfSignature signature = new PdfSignature(doc, doc.Pages[doc.Pages.Count - 1], cert, "MySignature");
            RectangleF rectangleF = new RectangleF(doc.Pages[0].ActualSize.Width - 500, 580, 180, 70);
            signature.Bounds = rectangleF;
            signature.Certificated = true;
            signature.NameLabel = "Singer";
            signature.Name = "Manh Kaiser";
            signature.ContactInfoLabel = "Phone:";
            signature.ContactInfo = "0123456";
            signature.ReasonLabel = "Reason:";
            signature.Reason = "I am the author";
            signature.DistinguishedNameLabel = "DN:";
            signature.DistinguishedName = signature.Certificate.IssuerName.Name;
            signature.LocationInfoLabel = "Location:";
            signature.LocationInfo = "Viet Nam";

            //Set the graphics mode to image only
            signature.GraphicsMode = GraphicMode.SignImageOnly;
            //Set the sign image source
            Image img = Image.FromFile($"D:{Path.DirectorySeparatorChar}Demo{Path.DirectorySeparatorChar}digital_image.png");
            Image image_resize = resizeImage(img, new Size(180, 80));
            signature.SignImageSource = PdfImage.FromImage(image_resize);

            //Set the signature font 
            signature.SignDetailsFont = new PdfTrueTypeFont(new Font("Arial Unicode MS", 12f, FontStyle.Regular));

            //Set the document permission to forbid changes but allow form fill
            signature.DocumentPermissions = PdfCertificationFlags.ForbidChanges | PdfCertificationFlags.AllowFormFill;

            //Save to file 
            doc.SaveToFile(Path.Combine(folder, "ImageSignature.pdf"));
            doc.Close();
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }
    }
}
