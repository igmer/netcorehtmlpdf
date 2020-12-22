using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestPdf.Models;

namespace TestPdf.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            string html = "<!DOCTYPE html>" +
                                    "<html>" +
                                    "<body>" +
                                    "<h2>HTML Forms</h2>" +
                                    "<p style='color: red; '>This is a paragraph.</p>"+
                                    "<form>" +
                                    "  <label for=\"fname\">First name:</label><br>" +
                                    "  <input type =\"text\" id=\"fname\" name=\"fname\"><br>" +
                                    "  <label for=\"lname\">Last name:</label><br>" +
                                    "  <input type =\"text\" id=\"lname\" name=\"lname\"><br><br>" +
                                    "</form> " +
                                    "</body>" +
                                    "</html>";
            HtmlToPdf ohtml = new HtmlToPdf();
            PdfDocument pdfDo = ohtml.ConvertHtmlString(html);
            byte[] pdf = pdfDo.Save();
            pdfDo.Close();
            return File(
                pdf, "application/pdf","reporte.pdf"
                );
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
