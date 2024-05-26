namespace DeLijn.Net.App.Api.Helpers.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
internal sealed class UselessAttribute(string reason) : Attribute
{
    public string Reason { get; } = reason;
}