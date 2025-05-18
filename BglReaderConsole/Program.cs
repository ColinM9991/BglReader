// See https://aka.ms/new-console-template for more information


using BglReader;

const string fileName = "APX28170.bgl";

using var fileStream =
    new FileStream(fileName, FileMode.Open);
using var binaryReader = new BinaryReader(fileStream);

var bglFile = new BglFile(fileName, binaryReader);

Console.ReadLine();