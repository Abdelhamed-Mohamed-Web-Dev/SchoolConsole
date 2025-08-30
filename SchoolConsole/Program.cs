namespace SchoolConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository studentRepository = new StudentRepository();
            ITeacherRepository teacherRepository = new TeacherRepository();
            IExamRepository examRepository = new ExamRepository();
            IResultRepository resultRepository = new ResultRepository();
            ICSVRepository csvRepository = new CSVRepository();


            while (true)
            {
                Console.WriteLine("\n----- Main Menu ----- \n");
                Console.WriteLine("1- Add Student"); // ✔️
                Console.WriteLine("2- Show Students"); // ✔️
                Console.WriteLine("3- Add Teacher"); // ✔️
                Console.WriteLine("4- Show Teachers"); // ✔️
                Console.WriteLine("5- Add Exam"); // ✔️
                Console.WriteLine("6- Show Exams"); // ✔️
                Console.WriteLine("7- Add Student Result"); // ✔️
                Console.WriteLine("8- Show All Exam Results"); // ✔️
                Console.WriteLine("9- Show Student Result"); // ✔️
                Console.WriteLine("10- Show Top 3 Students Results"); // ✔️
                Console.WriteLine("11- Export Data (CSV)"); // ✔️
                Console.WriteLine("0- Exit\n"); // ✔️

                switch ((int)Helper.ReadNumber())
                {
                    case 1:
                        studentRepository.AddStudent();
                        break;
                    case 2:
                        studentRepository.ShowStudents();
                        break;
                    case 3:
                        teacherRepository.AddTeacher();
                        break;
                    case 4:
                        teacherRepository.ShowTeachers();
                        break;
                    case 5:
                        examRepository.AddExam();
                        break;
                    case 6:
                        examRepository.ShowExams();
                        break;
                    case 7:
                        resultRepository.AddResult();
                        break;
                    case 8:
                        resultRepository.ShowAllExamResults();
                        break;
                    case 9:
                        resultRepository.ShowStudentResult();
                        break;
                    case 10:
                        resultRepository.ShowTop3Results();
                        break;
                    case 11:
                        csvRepository.ExportCSV();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
