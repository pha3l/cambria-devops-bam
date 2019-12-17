using Amazon.CDK;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.Lambda;

namespace CambriaBamDevOpsTalkApi
{
    public class CambriaBamDevOpsTalkApiStack : Stack
    {
        internal CambriaBamDevOpsTalkApiStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            RestApi api = new RestApi(this, "HelloWorldAPI", new RestApiProps 
            {
                RestApiName = "Hello World API",
                Description = "This API says hello!"
            });

            Function helloWorldFunction = new Function(this, "hello-world", new FunctionProps
            {
                Runtime = Runtime.DOTNET_CORE_2_1,
                Code = Code.FromAsset("./lambda-src/Cambria.BAM.DevOpsTalk.Api.Lambda/bin/Release/netcoreapp2.1/Cambria.BAM.DevOpsTalk.Api.Lambda.zip"),
                Handler = "Cambria.BAM.DevOpsTalk.Api.Lambda::Cambria.BAM.DevOpsTalk.Api.Lambda.Function::Get",
                Timeout = Duration.Seconds(15)
            });

            api.Root.AddMethod("GET", new LambdaIntegration(helloWorldFunction));

            var output = new CfnOutput(this, "RootUri", new CfnOutputProps
            {
                Description = "The root URI of the API",
                Value = api.Url
            });
        }
    }
}
