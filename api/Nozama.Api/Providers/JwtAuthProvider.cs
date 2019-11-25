using System.Text;
using Nozama.Core.Providers;

namespace Nozama.Api.Providers
{
    public class JwtAuthProvider : ISecretKeyProvider
    {
        public string SecretKey { get; set; }
        public byte[] KeyBytes => Encoding.ASCII.GetBytes(SecretKey);
    }
}