using BookWriter.src;
using Microsoft.Extensions.Configuration;
using Xceed.Words.NET;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var chatGPTController = new ChatGPTController(config["ChatGPTKey"]);



string scenesFileName = @".\scenes.doc";
string responseFileName = @".\response.doc";

var scenesFile = DocX.Load(scenesFileName);
var responseFile = DocX.Create(responseFileName);

foreach (var scene in scenesFile.Paragraphs)
{
    string response = await chatGPTController.SendMessage(scene.Text);
    responseFile.InsertParagraph(response);
}

responseFile.Save();
