using Microsoft.Extensions.Configuration;

namespace silverkissen.Utilities
{
    public interface ITokenIssuer
    {
        IConfiguration Configuration { get; }

        string GetToken();
    }
}