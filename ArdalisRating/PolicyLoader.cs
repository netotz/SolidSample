using System.IO;

namespace ArdalisRating;

public class PolicyLoader
{
    public string LoadFrom(string path)
    {
        return File.ReadAllText(path);
    }
}
