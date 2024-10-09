namespace StudentAdminSys.Models {
<<<<<<< HEAD
    public class Repository {
=======
    public static class Repository {
>>>>>>> b8d6ad93f106d28c774d696e444a3f7f0d9c8791
        private static List<Student> students = new();

        public static IEnumerable<Student> Students => students;
        public static void AddStudent(Student student) {
            students.Add(student);
        }
<<<<<<< HEAD
=======

        public static bool RemoveStudent(Student student) {

            if (student != null) {
                if (students.Remove(student)) {
                    Console.WriteLine("Student deleted");
                    return true;
                }
                else
                {
                    return false;
                }
            } else throw new ArgumentException($"Student {student} was not found.");
        }

        public static Student Find(int studentId) {
            Student student = students.Find(s => s.StudentId == studentId);

            return student;
        }

        public static int GetNextStudentId() {
            return students.Count + 99;
        }
>>>>>>> b8d6ad93f106d28c774d696e444a3f7f0d9c8791
    }
}