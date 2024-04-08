using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1GenerateObfuscateCodeForAI
{
    public class GenerateOphuscatedData
    {
        private const string _destinationTagsUsed = "outputTextTags.txt";
        private const string _outputTextForAI = "outputText.txt";

        public (string, string) OphuscateData(string inputFile, string inputFileTagsName)
        {
            StringBuilder message = new StringBuilder();

            //1) read data that needs to be replaced
            var inputData = ReadInputFile(inputFile);
            var inputFileTags = ReadInputFile(inputFileTagsName);

            //2) get input tags with their ophuscated strings
            //also save tags
            var inputDataOphuscatedTags = GenerateOphuscateOutputData(inputFileTags);
            var mappedTagsUsed = SaveMappedTags(inputDataOphuscatedTags);
            message.AppendLine("File tags saved to path: " + mappedTagsUsed);

            //3) replace data
            var outputData = ReplaceData(inputData, inputDataOphuscatedTags);
            // "this is my method var_1 that needs to be replaced. And this is my variable var_2 that needs to be replaced"

            //4) save output data
            var savedPath = SaveOutPutdata(outputData);

            message.AppendLine("File saved to path: " + savedPath);

            return (message.ToString(), savedPath);
        }



        private string SaveMappedTags(Dictionary<string, string> inputDataOphuscatedTags)
        {
            var outputData = new StringBuilder();

            outputData.AppendLine("[");

            foreach (var tag in inputDataOphuscatedTags)
            {
                //outputData.AppendLine("Tag: '" + tag.Key + "' mapped to '" + tag.Value + "'");
                var d = "{\"key\": \""+ tag.Key +"\", \"value\": \""+ tag.Value+"\"},";
                outputData.AppendLine(d);
            }
            outputData.AppendLine("]");

            var destination = _destinationTagsUsed;
            //var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(destination));
            //if (!destinationDirectory.Exists)
            //    destinationDirectory.Create();

            System.IO.File.WriteAllText(destination, outputData.ToString());

            return destination;
        }

        private string SaveOutPutdata(string content)
        {
            var destination = _outputTextForAI;
            //var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(destination));
            //if (!destinationDirectory.Exists)
            //    destinationDirectory.Create();

            System.IO.File.WriteAllText(destination, content);

            return destination;
        }

        private string ReadInputFile(string fileName)
        {
            DisplayMessage("Read data from file " + fileName);

            //return "this is my method methodName01 that needs to be replaced. And this is my variable variableName01 that needs to be replaced";
            var data = System.IO.File.ReadAllText(fileName);
            return data;
        }

        private Dictionary<string, string> GenerateOphuscateOutputData(string inputFileTags)
        {
            var tagsWithOphuscatedData = new Dictionary<string, string>();

            var idx = 1;
            foreach (var inputVal in inputFileTags.Split(";", StringSplitOptions.RemoveEmptyEntries))
            {
                //var ophuscateVal = GenerateOphuscatedVal(inputVal.Trim());

                var idxZero = idx.ToString().PadLeft(5, '0');
                var ophuscateVal = "var_" + idxZero.ToString();

                tagsWithOphuscatedData.Add(inputVal.Trim(), ophuscateVal);

                idx += 1;
            }

            return tagsWithOphuscatedData;
        }

        private string OphuscateData(string input)
        {
            //TODO - generate Ophuscate string for input
            return "abc";
        }

        private string ReplaceData(string inputData, Dictionary<string, string> inputDataOphuscatedTags)
        {
            // inputData = "this is my methodName01 that needs to be replaced. And this is my variableName01 that needs to be replaced";
            // outputData = "methodName01" -> "1", "variableName01" -> "2"
            string outputData = inputData;
            foreach (var tag in inputDataOphuscatedTags)
            {
                outputData = outputData.Replace(tag.Key, tag.Value);
            }

            return outputData;
        }

        private void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
