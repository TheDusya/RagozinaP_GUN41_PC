namespace Task.SaveLoadService
{
    internal class FileSystemSaveLoadService : ISaveLoadService<string>
    {
        private readonly string _path;
        public FileSystemSaveLoadService(string path)
        { 
            _path = path;
        }
        public void Save(string data, string filename)
        {
            throw new NotImplementedException();
        }
        public string Load(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
