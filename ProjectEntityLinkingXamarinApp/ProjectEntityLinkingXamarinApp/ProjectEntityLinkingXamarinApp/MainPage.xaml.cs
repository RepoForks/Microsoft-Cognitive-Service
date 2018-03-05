
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Microsoft.ProjectOxford.EntityLinking;

namespace ProjectEntityLinkingXamarinApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void OnButtonClickedAsync(object sender, EventArgs e)
        {
            var text = txtvalue.Text;
            EntityLinkingServiceClient client = new EntityLinkingServiceClient("e52917bb34d1426f80ac816dc818e8de","https://api.labs.cognitive.microsoft.com");


            var linkResponse = await client.LinkAsync(text);
            var result = string.Join(", ", linkResponse.Select(i => i.WikipediaID).ToList());
            this.outputBlock.Text = result;
            //await MakeRequest();
        }

         async Task MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "6a15dbc029324c9caefcaece90863e28");

            // Request parameters
            queryString["selection"] = txtvalue.Text;
            //queryString["offset"] = "{string}";
            var uri = "https://api.labs.cognitive.microsoft.com/entitylinking/v1.0/link?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
            }


        }
    }
}
