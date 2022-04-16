using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdfsyncfusion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       [HttpPost("sendpdf")]
       public Task Test()
       {
            //Load existing PDF document.
            PdfLoadedDocument document = new PdfLoadedDocument("PDF_Succinctly.pdf");

            //Load digital ID with password.
            PdfCertificate certificate = new PdfCertificate(@"DigitalSignatureTest.pfx", "DigitalPass123");

            //Create a signature with loaded digital ID.
            PdfSignature signature = new PdfSignature(document, document.Pages[0], certificate, "DigitalSignature");

            //Save the PDF document.
            document.Save("SignedDocument.pdf");

            //Close the document.
            document.Close(true);
            return Task.CompletedTask;
       }
    }
}
