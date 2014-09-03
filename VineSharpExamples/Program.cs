using System;
using Newtonsoft.Json;
using VineSharp;
using VineSharp.Requests;

namespace VineSharpExamples
{
    class Program
    {
        private const string Username = "your@email.com";
        private const string Password = "your-password";
        static void Main(string[] args)
        {
            var vineClient = new VineClient();
            vineClient.SetCredentials(Username, Password);

            var result = vineClient.MyProfile().Result;
            Console.Write(JsonConvert.SerializeObject(result, Formatting.Indented));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var result2 = vineClient.Profile(1118680983320059904).Result;
            Console.Write(JsonConvert.SerializeObject(result2, Formatting.Indented));

            var options = new VinePagingOptions
            {
                Size = 5
            };

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var result3 = vineClient.UserTimeline(931301056128897024, options).Result;
            Console.Write(JsonConvert.SerializeObject(result3, Formatting.Indented));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            
            var result4 = vineClient.TagTimeline("test", options).Result;
            Console.Write(JsonConvert.SerializeObject(result4, Formatting.Indented));

            Console.ReadLine();
        }
    }
}
