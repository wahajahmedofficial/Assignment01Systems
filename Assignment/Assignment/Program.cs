using Assignment;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

string codeToAnalyze = File.ReadAllText(Path.Join(Environment.CurrentDirectory, "CodeToBeAnalyzed.txt"));
Console.WriteLine("by using the potential of csharp scripting");

#region USE OF CSHARP SCRIPTING TECHNIQUE (SELF LEARNED KNOWLEDGE)

try
{
    var compiledCode = CSharpScript.RunAsync(codeToAnalyze).Result;

}
catch (CompilationErrorException ex)
{
    Console.WriteLine($"Script compilation error: {string.Join(Environment.NewLine, ex.Diagnostics)}");
}
catch (Exception ex)
{
    Console.WriteLine($"Script execution error: {ex.Message}");
}

#endregion

Console.WriteLine(Environment.NewLine);

Console.WriteLine("by creating a custom parsing function limited to the assignment");

#region CUSTOM PARSING JUST FOR THE SPECIFIC ASSIGNMENT CODE AS MENTIONED(WRITTEN WITH HELP OF CHATGPT
CustomCodeParser customCodeParser = new CustomCodeParser();
var errors = customCodeParser.ParseCode(codeToAnalyze);
Console.WriteLine(string.Join(Environment.NewLine, errors));
#endregion