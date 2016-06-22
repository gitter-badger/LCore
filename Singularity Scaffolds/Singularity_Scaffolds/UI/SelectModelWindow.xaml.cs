using System;
using System.Windows;

namespace Singularity_Scaffolds.UI
    {
    /// <summary>
    /// Interaction logic for SelectModelWindow.xaml
    /// </summary>
    public partial class SelectModelWindow
        {
        public SelectModelWindow(CustomViewModel viewModel)
            {
            this.InitializeComponent();

            this.DataContext = viewModel;
            }

        private void Button_Click(object sender, RoutedEventArgs e)
            {
            this.DialogResult = true;
            }
        }
    }
