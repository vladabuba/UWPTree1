using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace uwpApp1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = new MySampleViewModel();
        }

        private async void Aaaa_Click(object sender, RoutedEventArgs e)
        {
            var messageDialog = new MessageDialog("Hello Windows Store App.");
            await messageDialog.ShowAsync();
        }

        private void Treeview_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void TreeView_DragEnter_1(object sender, DragEventArgs e)
        {

        }

        private void TreeView_DragOver(object sender, DragEventArgs e)
        {

        }
    }
}
