using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPMNEditor.ViewModels;

namespace BPMNEditor.Models.Elements
{
    public class Document
    {
        protected Document() { }

        public static Document FromViewModel(DocumentViewModel viewModel)
        {
            return new Document();
        }
    }
}
