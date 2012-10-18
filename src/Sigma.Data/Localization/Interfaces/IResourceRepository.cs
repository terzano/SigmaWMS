
namespace Sigma.Data.Localization
{
    public interface IResourceRepository
    {
        string GetResourceByCultureAndKey(string cultureCode, string resourceKey);
    }
}
