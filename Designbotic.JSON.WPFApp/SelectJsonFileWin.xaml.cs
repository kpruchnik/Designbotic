using Designbotic.JSON.Core.ViewModels;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Shapes;

namespace Designbotic.JSON.WPFApp
{
    public partial class SelectJsonFileWin : Window
    {
        public ParsedElementsVM ParsedElements { get; set; }

        public SelectJsonFileWin()
        {
            InitializeComponent();
            ParsedElements = new ParsedElementsVM();
        }

        private void OnSelectJsonFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                var viewModel = (ParsedElementsVM)DataContext;
                viewModel.LoadJson(System.IO.File.ReadAllText(filePath));
            }
        }
    }
}
