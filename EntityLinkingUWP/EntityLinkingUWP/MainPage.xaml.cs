using Microsoft.ProjectOxford.EntityLinking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EntityLinkingUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var text = this.inputBox.Text;
            var client = new EntityLinkingServiceClient("6a15dbc029324c9caefcaece90863e28");
            var linkResponse = await client.LinkAsync(text);
            var result = string.Join(", ", linkResponse.Select(i => i.WikipediaID).ToList());
            this.outputBlock.Text = result;
        }
    }
}
