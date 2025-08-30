namespace C_Task01.Repositories
{
	internal class ResultRepository : IResultRepository
	{
		#region Global Vars
		Dictionary<int, Result> DicResults = LoadDictionaryResult();
		List<Result> Results = LoadListResult();
		string Path = Helper.GetFileDirectory("results.json");
		public static Dictionary<int, Result> LoadDictionaryResult()
		{
			Dictionary<int, Result> dic = new();

			var results = LoadListResult();

			foreach (var result in results)
			{
				dic.Add(result.StudentId, result);
			}

			return dic;
		}
		public static List<Result> LoadListResult()
		{
			string path = Helper.GetFileDirectory("results.json");
			var results = Helper.Load<Result>(path);
			return results;
		} 
		#endregion
		public void AddResult()
		{
			int next = Results.Count();

			Console.Write("Enter Result StudentId...");
			int studentId = (int)Helper.ReadNumber();
			Console.Write("Enter Result ExamId...");
			int examId = (int)Helper.ReadNumber();
			Console.Write("Enter Result Score...");
			decimal score = Helper.ReadNumber();

			var result = new Result()
			{
				Id = next++,
				StudentId = studentId,
				ExamId = examId,
				Score = score,
			};

			Results.Add(result);
			DicResults.Add(studentId, result);
			Helper.Save<Result>(Results, Path);
			Console.WriteLine("Result Added Successfully...");
		}

		public void ShowAllExamResults()
		{
			Console.WriteLine("Enter Exam Id...");
			int examId = (int)Helper.ReadNumber();
			var results = Results.Where(r => r.ExamId == examId);

			if (results.Count() <= 0)
				Console.WriteLine("No Results!");

			foreach (var result in Results)
			{
				Console.WriteLine($"Id: ({result.Id}) || StudentId: ({result.StudentId}) || ExamId: ({result.ExamId}) || Score: ({result.Score})");
			}
		}

		public void ShowStudentResult()
		{
			Console.Write("Enter Student Id...");
			int id = (int)Helper.ReadNumber();
			if (DicResults.ContainsKey(id))
			{
				Console.WriteLine($"Id: ({DicResults[id].Id}) || StudentId: ({DicResults[id].StudentId}) || ExamId: ({DicResults[id].ExamId}) || Score: ({DicResults[id].Score})");
			}
			else
				Console.WriteLine("Student Not Found!");
		}

		public void ShowTop3Results()
		{
			Console.WriteLine("Enter Exam Id...");
			int examId = (int)Helper.ReadNumber();
			var results = Results.Where(r => r.ExamId == examId).OrderByDescending(x => x.Score).ToList();

			if (results.Count() <= 0)
				Console.WriteLine("No Results!");

			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine($"Id: ({results[i].Id}) || StudentId: ({results[i].StudentId} ) || ExamId: ( {results[i].ExamId}) || Score: ({results[i].Score})");
			}
		}

	}
}
