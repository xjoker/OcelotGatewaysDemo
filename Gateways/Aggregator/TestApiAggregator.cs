using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Gateways.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace Gateways.Aggregator
{
    public class TestApiAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var testapia = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var testapib = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var resultObj = new JObject {{"testapia", JObject.Parse(testapia)}, {"testapib", JObject.Parse(testapib)}};


            var result = JsonConvert.SerializeObject(new BaseResultModel(resultObj));

            var stringContent = new StringContent(result)
            {
                Headers = {ContentType = new MediaTypeHeaderValue("application/json")}
            };

            return new DownstreamResponse(
                stringContent,
                HttpStatusCode.OK,
                new List<KeyValuePair<string, IEnumerable<string>>>(),
                "OK");
        }
    }
}