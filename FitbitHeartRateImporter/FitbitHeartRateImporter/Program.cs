using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace FitbitHeartRateImporter
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test1");
            
        }

        private static void Test()
        {
            try
            {
                var userToken =
                  "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiI1SEJKQlMiLCJhdWQiOiIyMkNIN0MiLCJpc3MiOiJGaXRiaXQiLCJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJzY29wZXMiOiJ3aHIgd251dCB3cHJvIHdzbGUgd3dlaSB3c29jIHdhY3Qgd3NldCB3bG9jIiwiZXhwIjoxNTQ1NzU4NDEwLCJpYXQiOjE1MTQyNDU0MTZ9.HkrczPIxD1GdzdC4L-LZ1jd42O1MA6RYE8G8iF1ykiQ";

                var urlworkout = @"https://api.fitbit.com/1/user/-/activities/heart/date/2017-12-26/1d/1min/time/08:45/10:15.json";

                var request = (HttpWebRequest)WebRequest.Create(urlworkout);
                request.Method = "GET";
                request.Headers["Authorization"] = "Bearer " + userToken;
                request.Accept = "application / json";

                WebResponse myResponse;

                myResponse = request.GetResponse();

                var httpwebStreamReader = new StreamReader(myResponse.GetResponseStream());
                var results = httpwebStreamReader.ReadToEnd();

                myResponse.Close();
                httpwebStreamReader.Close();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
