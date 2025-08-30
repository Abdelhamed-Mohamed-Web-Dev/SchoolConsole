namespace SchoolConsole.Repositories
{
	internal class TeacherRepository : ITeacherRepository
	{

		#region Global Vars
		string Path = Helper.GetFileDirectory("teachers.json");
		List<Teacher> Teachers = LoadListTeachers();
		public static List<Teacher> LoadListTeachers()
		{
			string path = Helper.GetFileDirectory("teachers.json");
			var results = Helper.Load<Teacher>(path);
			return results;
		}
		#endregion
		public void AddTeacher()
		{
			int next = Teachers.Count();
			Console.Write("Enter Teacher Name...");
			string name = Console.ReadLine().Trim();
			Console.Write("Enter Teacher Email...");
			string email = Console.ReadLine().Trim();
			Console.Write("Enter Teacher Subject...");
			string subject = Console.ReadLine().Trim();

			var teacher = new Teacher()
			{
				Id = next++,
				Name = name,
				Email = email,
				Subject = subject,
			};

			Teachers.Add(teacher);
			Helper.Save<Teacher>(Teachers, Path);
			Console.WriteLine("Teacher Added Successfully...");
		}

		public void ShowTeachers()
		{
			if (Teachers.Count() <= 0)
				Console.WriteLine("No Teachers!");

			foreach (var teacher in Teachers)
			{
				Console.WriteLine($"Id: ({teacher.Id}) || Name: ({teacher.Name}) || Email: ({teacher.Email}) || Subject: ({teacher.Subject})");
			}
		}
	}
}
