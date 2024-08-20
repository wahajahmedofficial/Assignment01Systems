using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

try
{
    string codeToAnalyze = File.ReadAllText(Path.Join(Environment.CurrentDirectory, "CodeToBeAnalyzed.txt"));
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


