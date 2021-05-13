using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIGateway
{
    public class FakeDefinedAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var contentBuilder = new StringBuilder();
            contentBuilder.Append(responses);

            var stringContent = new StringContent(contentBuilder.ToString())
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            return new DownstreamResponse(stringContent, HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "OK");
        }

        //public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        //{
        //    List<Header> header = new List<Header>();
        //    try
        //    {
        //        var headers = responses.SelectMany(x => x.Items.DownstreamResponse().Headers).ToList();

        //        var oneByteArray = await responses[0].Items.DownstreamResponse().Content.ReadAsByteArrayAsync();
        //        var oneData = Decompress(oneByteArray);
        //        var oneObj = ConvertToJson(oneData);
        //        var oneContent = new StringContent(JsonConvert.SerializeObject(oneObj), Encoding.UTF8, "application/json");

        //        return new DownstreamResponse(oneContent, HttpStatusCode.OK, headers, "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new DownstreamResponse(null, System.Net.HttpStatusCode.InternalServerError, header, null);
        //    }
        //}

        //private static byte[] Decompress(byte[] data)
        //{
        //    using (var compressedStream = new MemoryStream(data))
        //    using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
        //    using (var resultStream = new MemoryStream())
        //    {
        //        zipStream.CopyTo(resultStream);
        //        return resultStream.ToArray();
        //    }
        //}

        //private static JObject ConvertToJson(byte[] data)
        //{
        //    JObject jObj;
        //    using (var ms = new MemoryStream(data))
        //    using (var streamReader = new StreamReader(ms))
        //    using (var jsonReader = new JsonTextReader(streamReader))
        //    {
        //        jObj = (JObject)JToken.ReadFrom(jsonReader);
        //    }
        //    return jObj;
        //}
    }
}
