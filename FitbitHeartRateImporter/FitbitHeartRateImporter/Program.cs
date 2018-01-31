using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FitbitHeartRateImporter
{
    class Program
    {
        public static void Main(string[] args)
        {   
            Console.WriteLine($"Application starting.{Environment.NewLine}");

            RunDownloadHeartRateData();

            Console.WriteLine($"{Environment.NewLine}Application ended.");
        }

        private static void RunDownloadHeartRateData()
        {
            var resourceUrl = "https://api.fitbit.com/1/user/-/activities/heart/date/[date]/1d/[detail-level].json";

            var dates = GetDatesToDownload();

            resourceUrl = resourceUrl.Replace("[detail-level]", "1sec");

            const string folderPath = @"C:\temp\heartrate\";
            
            foreach (var date in dates)
            {
                //Note that the fitbit api will not accept date 1 but 01 for the month and day
                Console.WriteLine($"Downloading heart rate data for {date.Year}-{date.Month}-{date.Day.ToString().PadLeft(2, '0')}...");

                resourceUrl = resourceUrl.Replace("[date]", $"{date.Year}-{date.Month}-{date.Day.ToString().PadLeft(2, '0')}");

                var filePath = Path.Combine(folderPath, $"{date.Year}-{date.Month}-{date.Day.ToString().PadLeft(2, '0')}.txt");

                DownloadHeartRateDataAsync(resourceUrl, filePath);
            }
        }

        private static IEnumerable<DateTime> GetDatesToDownload()
        {
            return new List<DateTime>
            {
                new DateTime(2017, 12, 24),
                new DateTime(2017, 12, 25),
                new DateTime(2017, 12, 26),
                new DateTime(2017, 12, 27),
                new DateTime(2017, 12, 28),
                new DateTime(2017, 12, 29),
                new DateTime(2017, 12, 30),
                new DateTime(2017, 12, 31),
                new DateTime(2018, 01, 01),
                new DateTime(2018, 01, 02),
                new DateTime(2018, 01, 03),
                new DateTime(2018, 01, 04),
                new DateTime(2018, 01, 05),
            };
        }

        private static async void DownloadHeartRateDataAsync(string resourceUrl, string filePath)
        {
            try
            {
                var userToken =
                  "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiI1SEJKQlMiLCJhdWQiOiIyMkNIN0MiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJ3aHIgd251dCB3cHJvIHdzbGUgd3dlaSB3c29jIHdhY3Qgd3NldCB3bG9jIiwiZXhwIjoxNTQ1NzU4NDEwLCJpYXQiOjE1MTQyNDU0MTZ9.HkrczPIxD1GdzdC4L-LZ1jd42O1MA6RYE8G8iF1ykiQ";
                 
                var httpClient = new HttpClient();
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourceUrl);
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
                  
                var response = await httpClient.SendAsync(requestMessage);
                
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        var heartRateData = streamReader.ReadToEnd();

                        File.WriteAllText(filePath, heartRateData);
                    }                        
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //private static void DownloadHeartRateData(string resourceUrl, string filePath)
        //{
        //    try
        //    {
        //        var userToken =
        //          "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiI1SEJKQlMiLCJhdWQiOiIyMkNIN0MiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJ3aHIgd251dCB3cHJvIHdzbGUgd3dlaSB3c29jIHdhY3Qgd3NldCB3bG9jIiwiZXhwIjoxNTQ1NzU4NDEwLCJpYXQiOjE1MTQyNDU0MTZ9.HkrczPIxD1GdzdC4L-LZ1jd42O1MA6RYE8G8iF1ykiQ";

        //        var request = (HttpWebRequest)WebRequest.Create(resourceUrl);
        //        request.Method = "GET";
        //        request.Headers["Authorization"] = "Bearer " + userToken;
        //        request.Accept = "application / json";

        //        WebResponse myResponse;

        //        myResponse = request.GetResponse();

        //        var httpwebStreamReader = new StreamReader(myResponse.GetResponseStream());
        //        var results = httpwebStreamReader.ReadToEnd();
                
        //        File.WriteAllText(filePath, results);

        //        myResponse.Close();
        //        httpwebStreamReader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //}

    }
}
