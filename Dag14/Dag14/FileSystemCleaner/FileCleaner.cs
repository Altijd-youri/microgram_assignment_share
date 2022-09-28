using System.Text.RegularExpressions;

namespace FileSystemCleaner;

public class FileCleaner
{
    public List<CleanerListing> Report(string path)
    {
        // List<CleanerListing> report = new List<CleanerListing>();
        var directory = Directory.EnumerateFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly);
        var regex = new Regex(@"^(bin|obj|.suo|node_modules)$");
        IEnumerable<CleanerListing> result = directory
            .Select(item =>
            {
                return (FileSystemInfo)(File.Exists(item) ? new FileInfo(item) : new DirectoryInfo(item));
            })
            .Where(fsi => regex.IsMatch(fsi.Name))
            .Select(fsi =>
            {
                if ((fsi.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    return new CleanerListing(fsi.Name, 0);
                }
                return new CleanerListing(fsi.Name, ((FileInfo)fsi).Length);
            });
            
        
        // foreach (var item in Directory.GetFileSystemEntries(path, ".suo" ,SearchOption.TopDirectoryOnly))
        // {
        //     FileInfo info = new FileInfo(item);
        //
        //     report.Add();
        // }
        return result.ToList();
    }
}