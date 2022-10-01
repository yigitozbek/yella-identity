using System.Text.RegularExpressions;

namespace Yella.WebAPI.Routing;

public class CamelCaseParameterTransformer : IOutboundParameterTransformer, IParameterPolicy
{
    public string? TransformOutbound(object? value) => value != null ? Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLower() : (string)null;
}