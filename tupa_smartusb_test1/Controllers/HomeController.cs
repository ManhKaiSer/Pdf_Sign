using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using tupa_smartusb_test1.Models;

namespace tupa_smartusb_test1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var st = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            st.Open(OpenFlags.OpenExistingOnly | OpenFlags.MaxAllowed);
            var collection = Filter(st.Certificates);

            foreach (var cert in collection)
            {
                _logger.LogInformation($"Subject: {cert.Subject}");
                _logger.LogInformation($"FriendlyName: {cert.FriendlyName}");
                _logger.LogInformation($"Version: {cert.Version}");
                _logger.LogInformation($"Thumbprint: {cert.Thumbprint}");
            }
            st.Close();

            return View();
        }

        private static IEnumerable<X509Certificate2> Filter(X509Certificate2Collection collection)
        {
            var t0 = collection
                .Find(X509FindType.FindByKeyUsage,
                    X509KeyUsageFlags.DigitalSignature |
                    X509KeyUsageFlags.DataEncipherment |
                    X509KeyUsageFlags.KeyEncipherment |
                    X509KeyUsageFlags.NonRepudiation
                    , true);

            var result = new List<X509Certificate2>();
            foreach (var cert in t0)
            {
                var x0 = new List<Oid>();
                foreach (var col in cert.Extensions)
                {
                    if (!(col is X509EnhancedKeyUsageExtension t1))
                        continue;
                    foreach (var t2 in t1.EnhancedKeyUsages)
                        x0.Add(t2);
                }
                if (x0.Any(x => x.FriendlyName.Equals("Document Signing", StringComparison.OrdinalIgnoreCase)))
                    result.Add(cert);
            }

            return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
