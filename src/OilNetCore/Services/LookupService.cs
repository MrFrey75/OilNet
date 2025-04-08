using OilNetCore.Data;
using OilNetCore.Models;

namespace OilNetCore.Services;

/// <summary>
/// var titles = lookupService.GetLookupList<AssetType>("Title");
/// var codes = lookupService.GetLookupList<AssetType>("Code");
/// var descriptions = lookupService.GetLookupList<AssetType>("Description");
/// </summary>





public class LookupService
{
    private readonly CoreDbContext _context;

    public LookupService(CoreDbContext context)
    {
        _context = context;
    }

    public List<KeyValuePair<int, string>> GetLookupList<T>(string returnProperty = "Title") where T : LookupBase
    {
        var dbSet = _context.Set<T>();
        var list = new List<KeyValuePair<int, string>>();

        foreach (var item in dbSet.Where(x => !x.IsDeleted))
        {
            var property = typeof(T).GetProperty(returnProperty);
            if (property != null)
            {
                var value = property.GetValue(item)?.ToString() ?? string.Empty;
                list.Add(new KeyValuePair<int, string>(item.Oid, value));
            }
        }

        return list;
    }
}
