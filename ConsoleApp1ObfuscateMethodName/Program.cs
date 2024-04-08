using ClassLibrary1GenerateObfuscateCodeForAI;
using System.Text;

namespace ConsoleApp1ReplaceMethodName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ConsoleApp1ObfuscateMethodName.exe "01_ophuscate_data"
            // ConsoleApp1ObfuscateMethodName.exe "02_create_class_from_AI"

            //args = new string[] { "01_ophuscate_data", "inputText.txt", "inputTextTags.txt" };
            //args = new string[] { "02_create_class_from_AI" };

            var p = new Program();
            p.DoStuff(args);

            // ConsoleApp1ObfuscateMethodName.exe "01_ophuscate_data" "inputText.txt" "inputTextTags.txt"
            // ConsoleApp1ObfuscateMethodName.exe "02_create_class_from_AI" "inputTextTags.txt" "UnitTest1GeneratedByAI.txt"
        }

        private void DoStuff(string[] args)
        {
            if(args is null || args.Length == 0)
            {
                Console.WriteLine("Please provide arguments");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine(args[0]);
            Console.WriteLine("current directory: " + Environment.CurrentDirectory);

            if (args[0] == "01_ophuscate_data")
            {
                var inputFile = args[1]; // "inputText_for_unittest.txt";
                string inputFileTagsName = args[2]; // "inputTextTagNames_for_unittest.txt";

                var (message, path) = new GenerateOphuscatedData().OphuscateData(inputFile, inputFileTagsName);
                Console.WriteLine("");
                Console.WriteLine(message);
            }

            if (args[0] == "02_create_class_from_AI")
            {
                var (message, path) = new CreateClassFromAIResponse().CreateClassFrom();
                Console.WriteLine("");
                Console.WriteLine("message: " + message);
                Console.WriteLine("filepath: " + path);
            }
        }
    }
}
