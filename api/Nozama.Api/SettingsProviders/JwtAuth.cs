using System.Text;

namespace Nozama.Api.SettingsProviders
{
    public class JwtAuth
    {
        public string SecretKey { get; set; }
        public byte[] KeyBytes => Encoding.ASCII.GetBytes(SecretKey);
    }
}