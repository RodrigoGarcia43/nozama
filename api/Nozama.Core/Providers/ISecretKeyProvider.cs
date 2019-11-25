namespace Nozama.Core.Providers
{
    public interface ISecretKeyProvider
    {
        string SecretKey { get; }
        byte[] KeyBytes { get; }
    }
}