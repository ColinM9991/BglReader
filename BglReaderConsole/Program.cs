// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using BglReader;

var stopwatch = Stopwatch.StartNew();
// var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
// var airportFiles = ProcessFiles("APX*.bgl");
// var routingFiles = ProcessFiles("ATX*.bgl");
// var navigationFiles = ProcessFiles("NVX*.bgl");

stopwatch.Stop();

var file = new FileStream(@"C:\MSFS\FS Design Tools\Airport Design Editor 179 Test\P35\Projects\KTST_ADEP5_ADE.bgl", FileMode.Open);

var bglFile = new BglFile(file.Name, file);

Console.WriteLine($"Elapsed time: {stopwatch.Elapsed}");

return;

// ICollection<BglFile> ProcessFiles(string pattern) => Directory
//         .EnumerateFiles(Path.Combine(programFiles, "Lockheed Martin", "Prepar3D v5", "Scenery"), pattern,
//             SearchOption.AllDirectories).Select(ReadBglFile).ToList();
//
// BglFile ReadBglFile(string filePath)
// {
//     using var fileStream = new FileStream(filePath, FileMode.Open);
//
//     try
//     {
//         return new BglFile(Path.GetFileName(filePath), fileStream);
//     }
//     catch
//     {
//         Console.WriteLine(fileStream.Name);
//         throw;
//     }
// }