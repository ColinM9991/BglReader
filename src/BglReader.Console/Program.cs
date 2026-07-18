using BglReader;

var p3dPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Lockheed Martin", "Prepar3D v5");
var sceneryPath = Path.Combine(p3dPath, "Scenery");

var atxFiles = Directory.GetFiles(sceneryPath, "ATX*.bgl", SearchOption.AllDirectories).Select(x => new BglFile(File.OpenRead(x))).ToList();
var apxFiles = Directory.GetFiles(sceneryPath, "APX*.bgl", SearchOption.AllDirectories).Select(x => new BglFile(File.OpenRead(x))).ToList();
var nvxFiles = Directory.GetFiles(sceneryPath, "NVX*.bgl", SearchOption.AllDirectories).Select(x => new BglFile(File.OpenRead(x))).ToList();

Console.WriteLine($"Found {atxFiles.Count} ATX files");
Console.WriteLine($"Found {apxFiles.Count} APX files");
Console.WriteLine($"Found {nvxFiles.Count} NVX files");

Console.ReadKey();