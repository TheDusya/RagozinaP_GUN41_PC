namespace Task.SaveLoadService
{
    internal class SaveLoadServiceException : Exception
    {
        public SaveLoadServiceException() : base() { }
        public SaveLoadServiceException(string message) : base(message) { }
        public SaveLoadServiceException(string message, Exception inner) : base(message, inner) { }
    }
}
