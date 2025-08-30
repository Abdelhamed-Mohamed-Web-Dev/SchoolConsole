namespace C_Task01.Repositories
{
	internal class CSVRepository : ICSVRepository
	{
		public void ExportCSV()
		{
			while (true)
			{
				Console.WriteLine("\n--- Select File --- \n");
				Console.WriteLine("1- Students");
				Console.WriteLine("2- Teachers");
				Console.WriteLine("3- Exams");
				Console.WriteLine("4- Results");
				Console.WriteLine("0- Exit\n");

				switch ((int)Helper.ReadNumber())
				{
					case 1:
						string studentJsonPath = Helper.GetFileDirectory("students.json");
						var students = Helper.Load<Student>(studentJsonPath);
						string studentCsvPath = Helper.GetFileDirectory("students.csv");
						using (var writer = new StreamWriter(studentCsvPath))
						{
							writer.WriteLine("Id,Name,Email,Level,GPA");
							foreach (var s in students)
							{
								writer.WriteLine($"{s.Id},{s.Name},{s.Email},{s.Level},{s.GPA}");
							}
						}
						Console.WriteLine($"Students exported to CSV successfully at: {studentCsvPath}");
						break;
					case 2:
						string teacherJsonPath = Helper.GetFileDirectory("teachers.json");
						var teachers = Helper.Load<Teacher>(teacherJsonPath);
						string teacherCsvPath = Helper.GetFileDirectory("teachers.csv");
						using (var writer = new StreamWriter(teacherCsvPath))
						{
							writer.WriteLine("Id,Name,Email,Subject");
							foreach (var s in teachers)
							{
								writer.WriteLine($"{s.Id},\"{s.Name}\",{s.Email},{s.Subject}");
							}
						}
						Console.WriteLine($"Teachers exported to CSV successfully at: {teacherCsvPath}");
						break;
					case 3:
						string examJsonPath = Helper.GetFileDirectory("exams.json");
						var exams = Helper.Load<Exam>(examJsonPath);
						string examCsvPath = Helper.GetFileDirectory("exams.csv");
						using (var writer = new StreamWriter(examCsvPath))
						{
							writer.WriteLine("Id,Subject,Date");
							foreach (var s in exams)
							{
								writer.WriteLine($"{s.Id},{s.Subject},{s.Date}");
							}
						}
						Console.WriteLine($"Exams exported to CSV successfully at: {examCsvPath}");
						break;
					case 4:
						string resultJsonPath = Helper.GetFileDirectory("results.json");
						var results = Helper.Load<Result>(resultJsonPath);
						string resultCsvPath = Helper.GetFileDirectory("results.csv");
						using (var writer = new StreamWriter(resultCsvPath))
						{
							writer.WriteLine("Id,StudentId,ExamId,Score");
							foreach (var result in results)
							{
								writer.WriteLine($"{result.Id},{result.StudentId},{result.ExamId},{result.Score}");
							}
						}
						Console.WriteLine($"Results exported to CSV successfully at: {resultCsvPath}");
						break;
					default:
						return;
				}
			}
		}
	}
}
