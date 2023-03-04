using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace BookWriter.src
{
    class ChatGPTController : IChatGPTController
    {
        private OpenAIService _sOpenAiService;

        public ChatGPTController(string userSecretKey)
        {
            var openAiOptions = new OpenAiOptions();
            openAiOptions.ApiKey = userSecretKey;

            _sOpenAiService = new OpenAIService(openAiOptions);
            _sOpenAiService.SetDefaultModelId(Models.ChatGpt3_5Turbo0301);
        }

        public async Task<string> SendMessage(string message)
        {
            var completionResult = await _sOpenAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromUser(message),
                },
                Model = Models.ChatGpt3_5Turbo
            });

            if (completionResult.Successful)
            {
                return completionResult.Choices.First().Message.Content;
            } else
            {
                throw new Exception("Some error Occured");
            }
        }
    }
}
