using Designbotic.JSON.Core.Models;
using Designbotic.JSON.Core.Models.Enums;
using Designbotic.JSON.Core.ViewModels.Base;

namespace Designbotic.JSON.Core.ViewModels
{
    public class DElementVM : VMBase
    {
        private DesignboticElement _element;

        public int Id => _element.Id;

        public string Name
        {
            get => _element.Name;
            set
            {
                if (_element.Name == value) return;
                OnPropertyChanged();
            }
        }

        public CategoryEnum Category => _element.Category;

        public List<MaterialEnum> Materials => _element.Materials;

        public DElementVM(DesignboticElement element)
        {
            _element = element;
        }
    }
}
