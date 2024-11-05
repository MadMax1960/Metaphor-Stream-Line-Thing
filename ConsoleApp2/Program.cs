using System.Text.RegularExpressions;

class Program
{
	static void Main(string[] args)
	{
		if (args.Length == 0)
		{
			Console.WriteLine("Please drag a file onto the program or pass a file path as an argument.");
			return;
		}

		string filePath = args[0];

		if (!File.Exists(filePath))
		{
			Console.WriteLine("The file does not exist: " + filePath);
			return;
		}

		try
		{
			string text = File.ReadAllText(filePath);

			text = Regex.Replace(text, @"\bColor0\b", "Color1");
			text = Regex.Replace(text, @"\bColorChannel0\b", "ColorChannel05");
			text = Regex.Replace(text, @"\bColorChannel1\b", "ColorChannel0");
			text = Regex.Replace(text, @"\bColorChannel05\b", "ColorChannel1");
			text = Regex.Replace(text, ", Bit7", ""); 

			File.WriteAllText(filePath, text);

			Console.WriteLine("Replacements completed successfully.");
		}
		catch (Exception ex)
		{
			Console.WriteLine("An error occurred: " + ex.Message);
		}
	}
}
