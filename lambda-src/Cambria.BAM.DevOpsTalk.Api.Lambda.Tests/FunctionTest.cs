using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;

using Cambria.BAM.DevOpsTalk.Api.Lambda;
using System.Net;

namespace Cambria.BAM.DevOpsTalk.Api.Lambda.Tests
{
    public class FunctionTest
    {
        public FunctionTest()
        {
        }

        [Fact]
        public void TestGetMethod()
        {
            var func = new Function();

            var response = func.Get(new APIGatewayProxyRequest(), new TestLambdaContext());

            Assert.Equal((int) HttpStatusCode.OK, response.StatusCode);
            Assert.StartsWith("Hello", response.Body);
        }
    }
}
