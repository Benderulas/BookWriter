using BookWriter.src;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var test = new ChatGPTController(config["ChatGPTKey"]);

Console.WriteLine(await test.SendMessage("hi there, what is your name?"));