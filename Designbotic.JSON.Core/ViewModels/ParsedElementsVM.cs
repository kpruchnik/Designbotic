using Designbotic.JSON.Core.Utilities;
using Designbotic.JSON.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Designbotic.JSON.Core.ViewModels
{
    public class ParsedElementsVM : VMBase
    {
        public ObservableCollection<DElementVM> ParsedElements { get; }

        public ParsedElementsVM()
        {
            ParsedElements = new ObservableCollection<DElementVM>();
        }

        public void LoadJson(string json)
        {
            var parsedElements = DElementSerializers.DeserializeArray(json);
            ParsedElements.Clear();
            foreach (var element in parsedElements)
                ParsedElements.Add(new DElementVM(element));
        }
    }
}
