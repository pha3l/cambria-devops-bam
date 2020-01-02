using System.Net;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cambria.BAM.DevOpsTalk.Api.Lambda
{
    public class Function
    {
        public Function()
        {
        }

        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var firstName = request.QueryStringParameters["firstName"];
            var lastName = request.QueryStringParameters["lastName"];

            return new APIGatewayProxyResponse
            {
                Body = JsonConvert.SerializeObject($"Hello {firstName} {lastName} from Lambda!!!"),
                StatusCode = (int) HttpStatusCode.OK,
                Headers = new Dictionary<string,string>
                {
                    ["Access-Control-Allow-Origin"] = "*",
                    ["X-Requested-With"]= "*",
                    ["Access-Control-Allow-Headers"]= "Content-Type,X-Amz-Date,Authorization,X-Api-Key,x-requested-with",
                    ["Access-Control-Allow-Methods"]= "POST,GET,OPTIONS"
                }
            };
        }
    }
}
