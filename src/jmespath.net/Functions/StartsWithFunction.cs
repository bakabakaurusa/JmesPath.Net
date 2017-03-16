using System;
using DevLab.JmesPath.Expressions;
using Newtonsoft.Json.Linq;
using JmesPathFunction = DevLab.JmesPath.Interop.JmesPathFunction;

namespace DevLab.JmesPath.Functions
{
    public class StartsWithFunction : JmesPathFunction
    {
        public StartsWithFunction()
            : base("starts_with", 2)
        {

        }
        public override bool Validate(params JmesPathArgument[] args)
        {
            if (args[0].Token.Type != JTokenType.String
                || args[1].Token.Type != JTokenType.String)
                throw new Exception("invalid-type");

            return true;
        }

        public override JToken Execute(params JmesPathArgument[] args)
        {
            var subject = args[0].Token.Value<String>();
            var prefix = args[1].Token.Value<String>();

            return subject.StartsWith(prefix);
        }
    }
}