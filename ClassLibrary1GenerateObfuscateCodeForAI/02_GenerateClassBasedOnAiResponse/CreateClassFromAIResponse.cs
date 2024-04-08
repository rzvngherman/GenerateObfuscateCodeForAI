using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassLibrary1GenerateObfuscateCodeForAI
{
    public class CreateClassFromAIResponse
    {
        private const string _inputFile = "02_GenerateClassBasedOnAiResponse/InputData/01_unittest_generated_by_AI.txt";
        private const string _tagsUsedFile = "01_GenerateOphuscatedData/OutputData/tags_used.txt";

        private const string _outClassFile = "02_GenerateClassBasedOnAiResponse/OutputData/generated_class.cs";

        public (string,string) CreateClassFrom()
        {
            var message = new StringBuilder();

            //1) read data that needs to be replaced
            var inputData = Read_unittest_generated_by_AI();
            var tagsUsed = Read_TagsUsedFile();
            foreach (var tag in tagsUsed)
            {
                inputData = inputData.Replace(tag.Value, tag.Key);
            }

            //save data to _outClassFile
            var savedPath = SaveOutPutdata(inputData, _outClassFile);

            return ("File saved to path: " + savedPath, savedPath);
        }

        private string SaveOutPutdata(string content, string destination)
        {
            var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(destination));
            if (!destinationDirectory.Exists)
                destinationDirectory.Create();
            System.IO.File.WriteAllText(destination, content);

            return destination;
        }

        private string Read_unittest_generated_by_AI()
        {
            var data = System.IO.File.ReadAllText(_inputFile);
            return data;
        }

        private List<TagsUsed> Read_TagsUsedFile()
        {
            var data = System.IO.File.ReadAllText(_tagsUsedFile);
            var results = JsonConvert.DeserializeObject<List<TagsUsed>>(data);
            return results;
        }
    }
    public class TagsUsed
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
