using BglReader;

var p3dPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Lockheed Martin", "Prepar3D v5");
var sceneryPath = Path.Combine(p3dPath, "Scenery");

var atxFiles = Directory.GetFiles(sceneryPath, "ATX*.bgl", SearchOption.AllDirectories);
var apxFiles = Directory.GetFiles(sceneryPath, "APX*.bgl", SearchOption.AllDirectories);
var nvxFiles = Directory.GetFiles(sceneryPath, "NVX*.bgl", SearchOption.AllDirectories);

Console.WriteLine($"Found {atxFiles.Length} ATX files");
Console.WriteLine($"Found {apxFiles.Length} APX files");
Console.WriteLine($"Found {nvxFiles.Length} NVX files");

var parsedAtx = atxFiles.Select(x => new BglFile(x, File.OpenRead(x))).ToList();
var parsedApx = apxFiles.Select(x => new BglFile(x, File.OpenRead(x))).ToList();
var parsedNvx = nvxFiles.Select(x => new BglFile(x, File.OpenRead(x))).ToList();

Console.ReadKey();