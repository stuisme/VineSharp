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

            //var result = vineClient.MyProfile().Result;
            //Console.Write(JsonConvert.SerializeObject(result, Formatting.Indented));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result2 = vineClient.Profile(1118680983320059904).Result;
            //Console.Write(JsonConvert.SerializeObject(result2, Formatting.Indented));

            //var options = new VinePagingOptions
            //{
            //    Size = 5
            //};

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result3 = vineClient.UserTimeline(1100682554694316032).Result;
            //Console.Write(JsonConvert.SerializeObject(result3, Formatting.Indented));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            
            //var result4 = vineClient.TagTimeline("test", options).Result;
            //Console.Write(JsonConvert.SerializeObject(result4, Formatting.Indented));
            
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result5 = vineClient.Post(1118756259315761152).Result;
            //Console.Write(JsonConvert.SerializeObject(result5, Formatting.Indented));
            
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result6 = vineClient.Likes(1118756259315761152).Result;
            //Console.Write(JsonConvert.SerializeObject(result6, Formatting.Indented));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result7 = vineClient.PopularTimeline().Result;
            //Console.Write(JsonConvert.SerializeObject(result7, Formatting.Indented));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result8 = vineClient.Comments(1102011480238436352).Result;
            //Console.Write(JsonConvert.SerializeObject(result8, Formatting.Indented));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result9 = vineClient.MyFollowers().Result;
            //Console.Write(JsonConvert.SerializeObject(result9, Formatting.Indented));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result10 = vineClient.UserFollowers(1100682554694316032).Result;
            //Console.Write(JsonConvert.SerializeObject(result10, Formatting.Indented));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //var result11 = vineClient.UserFollowing(1100682554694316032).Result;
            //Console.Write(JsonConvert.SerializeObject(result11, Formatting.Indented));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            var result12 = vineClient.MyFollowing().Result;
            Console.Write(JsonConvert.SerializeObject(result12, Formatting.Indented));

            Console.ReadLine();
        }
    }
}
