using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.IO;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

namespace SharpVersion
{
    class Image
    {
        public Image(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
        public string Id { get; set; }
    }

    class Azure
    {
        const string Key = "02e0a76b4d34478097024cc40513d546";
        const string Location = "westcentralus";
        static readonly string DetectApi = $"https://{Location}.api.cognitive.microsoft.com/face/v1.0/detect";
        static readonly string VerifyApi = $"https://{Location}.api.cognitive.microsoft.com/face/v1.0/verify";
        List<Image> images = new List<Image>
        {
            new Image("https://pp.userapi.com/c856136/v856136735/2fc05/eGPqLoK76m0.jpg"),
            new Image("https://pp.userapi.com/c855328/v855328735/30391/bn20Eb-MT0w.jpg")
        };

        public Azure(string im1, string im2)
        {
            images[0].Url = im1;
            images[1].Url = im2;
        }

        public Azure()
        { }

        public Azure(string im1)
        {
            images[0].Url = im1;
        }

        public async Task<bool> f()
        {
            foreach (var image in images)
            {
                var data = new { url = image.Url };
                var result = await SendRequest(DetectApi, data);
                var json = JArray.Parse(result);
                image.Id = (string)json[0]["faceId"];
            }
            var verify = await Verify(images[0].Id, images[1].Id);
            string s = verify["isIdentical"].ToString();
            string s1 = verify["confidence"].ToString();
            return Convert.ToBoolean(s);
        }

        private static async Task<string> SendRequest(string url, object data)
        {
            string result;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Key);

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");


                var response = await client.PostAsync(url, content);
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        private static async Task<JObject> Verify(string faceId1, string faceId2)
        {
            var data = new { faceId1, faceId2 };
            var result = await SendRequest(VerifyApi, data);
            return JObject.Parse(result);
        }
    }

    class Azure2
    {
        public async void Azure()
        {
            FaceServiceClient face = new FaceServiceClient("02e0a76b4d34478097024cc40513d546");
            var s = File.ReadAllBytes("21.png");
            Face[] c = await face.DetectAsync(new MemoryStream(s));
            VerifyResult vr = await face.VerifyAsync(c[0].FaceId, c[0].FaceId);
            
        }
    }

}
