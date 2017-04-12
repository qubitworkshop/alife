using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ato.FormViewer.Web.Models;

namespace Ato.FormViewer.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/forms")]
    public class FormsSerrviceController : Controller
    {
        [HttpGet("{year}/{page}")]
        public async Task<IActionResult> GetPage(int year, int page)
        {
            var image = System.IO.File.OpenRead($@"C:\Users\arunm\Source\Repos\ALife\Forms\{year}\{page}.svg");
            return File(image, "image/svg+xml");
        }

        [HttpGet("manifest")]
        public async Task<FormsManifest> GetManifest()
        {
            string root = @"C:\Users\arunm\Source\Repos\ALife\Forms";

            var forms = new List<Form>();

            var manifest = new FormsManifest
            {
                AvailableForms = forms
            };

            foreach (string directory in Directory.GetDirectories(root))
            {
                Form form = new Form
                {
                    Year = Int32.Parse(Path.GetFileName(directory))
                };

                List<int> pages = new List<int>();

                foreach (string file in Directory.GetFiles(directory, "*.svg"))
                {
                    int page = Int32.Parse(Path.GetFileNameWithoutExtension(file));
                    pages.Add(page);
                }

                form.AvailablePages = pages.ToArray();
                forms.Add(form);
            }

            return manifest;
        }
    }
}