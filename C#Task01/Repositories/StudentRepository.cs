namespace C_Task01.Repositories
{
	internal class StudentRepository : IStudentRepository
	{
		#region Global Vars

		string Path = Helper.GetFileDirectory("students.json");
		List<Student> Students = LoadListStudents();
		public static List<Student> LoadListStudents()
		{
			string path = Helper.GetFileDirectory("students.json");
			var results = Helper.Load<Student>(path);
			return results;
		}
		#endregion
		public void AddStudent()
		{
			int next = Students.Count();
			Console.Write("Enter Student Name...");
			string name = Console.ReadLine().Trim();
			Console.Write("Enter Student Email...");
			string email = Console.ReadLine().Trim();
			Console.Write("Enter Student Level...");
			int level = (int)Helper.ReadNumber();
			Console.Write("Enter Student GPA...");
			decimal gpa = Helper.ReadNumber();
			var student = new Student()
			{
				Id = next++,
				Name = name,
				Email = email,
				Level = level,
				GPA = gpa
			};
			Students.Add(student);
			Helper.Save<Student>(Students, Path);
			Console.WriteLine("Student Added Successfully...");
		}
		public void ShowStudents()
		{
			GetStudents(null);
			while (true)
			{
				Console.WriteLine("\n--- Options --- \n");
				Console.WriteLine("1- Search");
				Console.WriteLine("2- Sort");
				Console.WriteLine("0- Exit\n");

				switch ((int)Helper.ReadNumber())
				{
					case 1:
						Console.Write("Enter Student Name... ");
						string name = Console.ReadLine().Trim();
						GetStudents(s => s.Name.ToUpper().Contains(name.ToUpper()));
						break;
					case 2:
						Console.WriteLine("\n--- Sort By --- \n");
						Console.WriteLine("1- Name");
						Console.WriteLine("2- Level");
						Console.WriteLine("3- GPA");
						Console.WriteLine("0- Exit\n");

						switch ((int)Helper.ReadNumber())
						{
							case 1:
								GetStudents(null, 1);
								break;
							case 2:
								GetStudents(null, 2);
								break;
							case 3:
								GetStudents(null, 3);
								break;
							default:
								continue;
						}
						break;
					default:
						return;
				}
			}
		}
		void GetStudents(Func<Student, bool>? criteria, int? sortOpt = 0)
		{
			if (criteria is not null)
				Students = Students.Where(criteria).ToList();

			Students = sortOpt switch
			{
				1 => Students.OrderBy(s => s.Name).ToList(),
				2 => Students.OrderBy(s => s.Level).ToList(),
				3 => Students.OrderBy(s => s.GPA).ToList(),
				_ => Students
			};

			if (Students.Count() <= 0)
				Console.WriteLine("No Students!");

			foreach (var student in Students)
			{
				Console.WriteLine($"Id: ({student.Id}) || Name: ({student.Name}) || Email: ({student.Email}) || Level: ({student.Level}) || GPA: ({student.GPA})");
			}
		}
	}
}
