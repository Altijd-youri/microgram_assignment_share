using FileSystemCleaner;

FileCleaner fileCleaner = new ();

Console.Write("Enter path to clean:");
string? path = Console.ReadLine();

Console.WriteLine();
if (!string.IsNullOrWhiteSpace(path))
{
    Console.WriteLine("Found the following files and directories:");
    foreach (CleanerListing item in fileCleaner.Report(path))
    {
        Console.WriteLine($"{item.pathName} | {item.sizeInBytes} bytes");
    }
}
else
{
    Console.WriteLine("Path was not found. Exiting application.");
}
