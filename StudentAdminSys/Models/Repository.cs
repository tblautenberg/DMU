namespace StudentAdminSys.Models {
    public static class Repository {
        private static List<Student> students = new();

        public static IEnumerable<Student> Students => students;
        public static void AddStudent(Student student) {
            students.Add(student);
        }

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
    }
}