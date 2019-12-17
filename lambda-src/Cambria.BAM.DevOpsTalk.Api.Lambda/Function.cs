using System.Net;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

namespace Cambria.BAM.DevOpsTalk.Api.Lambda
{
    public class Function
    {
        public Function()
        {
        }

        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var req = JsonConvert.DeserializeObject<Request>(request.Body);

            return new APIGatewayProxyResponse
            {
                Body = $"Hello {req.Name}!",
                StatusCode = (int) HttpStatusCode.OK
            };
        }

        internal class Request 
        {
            public string Name { get; set; } = "World";
        }
    }
}
