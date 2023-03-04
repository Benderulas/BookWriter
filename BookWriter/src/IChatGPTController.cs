namespace BookWriter.src
{
    interface IChatGPTController
    {
        public Task<string> SendMessage(string message);
    }
}
