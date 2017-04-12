using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ato.FormViewer.Web.Models
{
    public class Form
    {
        public int Year { get; set; }
        public int[] AvailablePages { get; set; }
    }
}
