using SchoolConsole.Models;
using System.Text.Json;

namespace SchoolConsole
{
	internal static class Helper
	{
		public static List<T> Load<T>(string path)
		{
			if (!File.Exists(path))
				return new List<T>();

			var json = File.ReadAllText(path);

			if (string.IsNullOrWhiteSpace(json))
				return new List<T>();

			return JsonSerializer.Deserialize<List<T>>(json) ?? new();
		}
		public static void Save<T>(List<T> list, string path)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			string json = JsonSerializer.Serialize(list);
			File.WriteAllText(path, json);
		}
		public static decimal ReadNumber()
		{
			decimal num = 0;
			bool text = true;
			while (text)
			{
				Console.Write("Enter Invalid Number...");
				text = !decimal.TryParse(Console.ReadLine(), out num);
			}
			return num;
		}
		public static string GetFileDirectory(string fileName)
		{
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));
			string filesPath = Path.Combine(projectPath, "Files", fileName);
			if (!File.Exists(filesPath))
				Directory.CreateDirectory(filesPath);
			return filesPath;
		}
	}
}
