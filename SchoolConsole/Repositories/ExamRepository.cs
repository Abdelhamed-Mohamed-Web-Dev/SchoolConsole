namespace SchoolConsole.Repositories
{
	internal class ExamRepository : IExamRepository
	{
		#region Global Vars

		string Path = Helper.GetFileDirectory("exams.json");
		List<Exam> Exams = LoadListExams();
		public static List<Exam> LoadListExams()
		{
			string path = Helper.GetFileDirectory("exams.json");
			var results = Helper.Load<Exam>(path);
			return results;
		} 
		#endregion

		public void AddExam()
		{
			int next = Exams.Count();

			Console.Write("Enter Exam Subject...");
			string subject = Console.ReadLine().Trim();

			DateTime date;
			while (true)
			{
				Console.Write("Enter Exam Date...");
				Console.Write("\nDay...");
				int day = 0;
				do day = (int)Helper.ReadNumber();
				while (day < 1 || day > 31);
				Console.Write("Month...");
				int month = 0;
				do month = (int)Helper.ReadNumber();
				while (month < 1 || month > 12);
				Console.Write("Year...");
				int year = 0;
				do year = (int)Helper.ReadNumber();
				while (year < DateTime.UtcNow.Year);
				Console.Write("Hour...");
				int hour = 0;
				do hour = (int)Helper.ReadNumber();
				while (hour < 0 || hour > 23);
				Console.Write("Minute...");
				int minute = 0;
				do minute = (int)Helper.ReadNumber();
				while (minute < 0 || minute > 59);
				try
				{
					date = new DateTime(year, month, day, hour, minute, 0);
					Console.WriteLine($"Exam Date: {date:dddd, dd MMM yyyy HH:mm}");
					break;
				}
				catch (Exception ex)
				{
					Console.WriteLine("Invalid date, please try again...");
					continue;
				}
			}
			var exam = new Exam()
			{
				Id = next++,
				Subject = subject,
				Date = date,
			};

			Exams.Add(exam);
			Helper.Save<Exam>(Exams, Path);
			Console.WriteLine("Exam Added Successfully...");
		}

		public void ShowExams()
		{
			if (Exams.Count() <= 0)
				Console.WriteLine("No Exams!");

			foreach (var exam in Exams)
			{
				Console.WriteLine($"Id: ({exam.Id}) || Subject: ({exam.Subject}) || Date: ({exam.Date})");
			}
		}
	}
}
