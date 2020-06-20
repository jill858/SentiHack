using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using SentiHackMVC.Models;

namespace SentiHackMVC.Controllers
{
    public class IndexController : Controller
    {
        public async Task<IActionResult> Index()
        {
            News n = new News();

            n.NewsList = await GetNewsListAsync();

            return View(n);
        }

        public async Task<List<News>> GetNewsListAsync()
        {
            // newsapi key
            string key = "3aee38715cf44b978724217b5905702a";
            string url = "http://newsapi.org/v2/top-headlines?country=sg&apiKey=" + key;

            List<News> newsList = new List<News>();

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                JObject obj = JObject.Parse(result);
                JArray allNews = (JArray)obj["articles"];

                newsList = ((JArray)allNews).Select(x => new News
                {
                    SourceType = (string)x["source"]["name"],
                    Author = (string)x["author"],
                    Title = (string)x["title"],
                    Description = (string)x["description"],
                    Words = FirstXWords((string)x["description"], 15),
                    Link = (string)x["url"],
                    PublishDate = ConvertToDateTime((string)x["publishedAt"]),
                    Content = (string)x["content"]
                }).ToList();
            }

            List<News> cnaList = (from news in newsList
                                  where news.SourceType == "CNA"
                                  select news).ToList();

            return cnaList;

        }

        public DateTime ConvertToDateTime(string dateString)
        {
            // 06/19/2020 10:24:28
            char delimiter = ' ';

            string[] dateTime;

            dateTime = dateString.Split(delimiter);

            string d = dateTime[0];
            string t = dateTime[1];

            char dateDelimiter = '/';
            char timeDelimiter = ':';

            string[] tArr = t.Split(timeDelimiter);
            string[] dArr = d.Split(dateDelimiter);

            int year = Int32.Parse(dArr[2]);
            int month = Int32.Parse(dArr[0]);
            int date = Int32.Parse(dArr[1]);

            int hour = Int32.Parse(tArr[0]);
            int min = Int32.Parse(tArr[1]);
            int sec = Int32.Parse(tArr[2]);


            DateTime dt = new DateTime(year, month, date, hour, min, sec);

            return dt;
        }
        public string FirstXWords(string text, int num)
        {
            string firstTenWords = String.Join(" ", text.Split().Take(num).ToArray());
            return firstTenWords + " ...";

        }

        public async Task<byte[]> GetNewsAudio(string audioText)
        {
            // Text-To-Speech ENG key
            string key = "AEF4404077714656A317";
            string url = "https://api.sentient.io/tts/prod/ttseng";

            JObject payLoad = new JObject(
                new JProperty("text", audioText)
            );

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("x-api-key", key);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"text\": \"I like to eat.\"\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string stringResponse = response.Content;
            string first64 = response.Content.Substring(0, 64);

            byte[] audioByteArr = Convert.FromBase64String(first64);            

            return audioByteArr;
        }
    }
}
