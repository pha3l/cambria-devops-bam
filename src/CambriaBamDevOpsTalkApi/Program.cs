using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CambriaBamDevOpsTalkApi
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CambriaBamDevOpsTalkApiStack(app, "CambriaBamDevOpsTalkApiStack");
            app.Synth();
        }
    }
}
