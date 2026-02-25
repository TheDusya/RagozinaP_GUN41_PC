using System.IO;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task.SaveLoadService
{
    internal class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _path;
        public string PathToFile(string filename) => Path.Combine(_path, filename) + ".txt";
        public bool DoesFileExist(string filename) => File.Exists(PathToFile(filename));

        public FileSystemSaveLoadService(string path)
        { 
            _path = path;
            try
            {
                if (!Path.Exists(_path))
                    Directory.CreateDirectory(_path);
            }
            catch 
            {
                throw new SaveLoadServiceException($"Something went wrong with path {_path}");
            }
        }

        public void Save(string data, string filename)
        {
            using (StreamWriter file = File.CreateText(PathToFile(filename)))
            {
                file.WriteLine(data);
            }
        }

        public string Load(string filename)
        {
            string fullPath = PathToFile(filename);
            if (!File.Exists(fullPath))
                throw new SaveLoadServiceException($"File {fullPath} was not found");
            using (StreamReader file = File.OpenText(fullPath))
            {
                return file.ReadToEnd();
            }
        }
    }
}
