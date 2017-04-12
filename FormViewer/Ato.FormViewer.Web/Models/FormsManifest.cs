using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ato.FormViewer.Web.Models
{
    public class FormsManifest
    {
        public IEnumerable<Form> AvailableForms { get; set; }
    }
}
