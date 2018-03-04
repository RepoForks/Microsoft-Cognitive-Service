using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VideoIndexer
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            // var browser = new WebView();
            // var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = @"<html><head><script src='https://breakdown.blob.core.windows.net/public/vb.widgets.mediator.js'></script></head>
<body><iframe width='1280' height='720' src='https://www.videoindexer.ai/embed/player/9123e16b12' frameborder='0' allowfullscreen></iframe>
<iframe width = '1280' height = '780' src = 'https://www.videoindexer.ai/embed/insights/9123e16b12/?widgets=people&title=myInsights' frameborder = '0' allowfullscreen ></iframe > 
</body></html> ";
            browser.Source = htmlSource;
        }
	}
}
