using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinBingAutoSuggest
{
    public partial class MainPage : ContentPage
	{
        private string AutoSuggestionEndPoint = "https://api.cognitive.microsoft.com/bing/v7.0/suggestions";
        public HttpClient AutoSuggestionClient
        {
            get;
            set;
        }
        public MainPage()
		{
			InitializeComponent();
            AutoSuggestionClient = new HttpClient();
            AutoSuggestionClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "<Key>");
        }
     
       private async void OnTextChangesEvent(object sender, TextChangedEventArgs e)
        {
            try
            {
                if(entrysearch!=null)
                lstautosug.ItemsSource = await GetAutoSuggestResults(this.entrysearch.Text);
            }
            catch (HttpRequestException)
            {
                
            }

        }
        public async  Task<List<string>> GetAutoSuggestResults(string query)
        {
            List<string> suggestions = new List<string>();
            string market = "en-US";
            var result = await AutoSuggestionClient.GetAsync(string.Format("{0}/?q={1}&mkt={2}", AutoSuggestionEndPoint, WebUtility.UrlEncode(query), market));
            result.EnsureSuccessStatusCode();
            var json = await result.Content.ReadAsStringAsync();
            dynamic data = JObject.Parse(json);
            if (data.suggestionGroups != null && data.suggestionGroups.Count > 0 && data.suggestionGroups[0].searchSuggestions != null)
            {
                for (int i = 0; i < data.suggestionGroups[0].searchSuggestions.Count; i++)
                {
                    suggestions.Add(data.suggestionGroups[0].searchSuggestions[i].displayText.Value);
                }
            }
            return suggestions;
        }
    }
  
}
