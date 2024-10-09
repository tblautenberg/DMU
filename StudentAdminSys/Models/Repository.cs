namespace StudentAdminSys.Models {
    public class Repository {
        private static List<Student> students = new();

        public static IEnumerable<Student> Students => students;
        public static void AddStudent(Student student) {
            students.Add(student);
        }
    }
}