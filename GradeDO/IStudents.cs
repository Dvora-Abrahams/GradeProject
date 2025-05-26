
namespace GradeDO
{
    public interface IStudents
    {
        void AddGradeToStudent(string StudentId, Grade grade);
        void AddStudent(Student student);
        void EditGrade(string StudentId, int grade, int exeNum);
        void EditName(string StudentId, string newName, string CurrPass);
        void EditPassword(string StudentId, string NewPass);
        void EreaseStudent(string StudentId);
        void InsertGrades(List<string> IDs, List<int> grades, int exeNum);
        Grade ReturnGrade(string StudentId, int exeNumber);
        Student ViewStudent(string StudentId);
        List<Student> ViewStudents();
        List<int> ReturnGrades(int exeNum);
        Dictionary<int, List<int>> ReturnAllGrades(int num);
        Student FindStudent(string StudentId);

       
        Grade LastSubmit(string StudentId, string Pass);
        Grade SpecificExercise(string StudentId,  int exeNum);
       
    }
}