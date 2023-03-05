using BookWriter.src;
using Xceed.Words.NET;

var configManager = new ConfigManager();
var chatGPTController = new ChatGPTController(configManager.SChatGPTKey);

var scenesFile = DocX.Load(configManager.SScenesFilePath);
var responseFile = DocX.Create(configManager.SResponseFilePath);

foreach (var scene in scenesFile.Paragraphs)
{
    string response = await chatGPTController.SendMessage(scene.Text);
    responseFile.InsertParagraph(response);
}

responseFile.Save();
