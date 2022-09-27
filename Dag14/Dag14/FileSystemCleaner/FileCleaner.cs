namespace FileSystemCleaner;

public class FileCleaner
{
    public List<CleanerListing> Report(string path)
    {
        List<CleanerListing> report = new List<CleanerListing>();
        foreach (var item in Directory.GetFileSystemEntries(path, ".suo" ,SearchOption.TopDirectoryOnly))
        {
            FileInfo info = new FileInfo(item);

            report.Add(new CleanerListing(info.Name, info.Length));
        }
        return report;
    }
}