using GradeDO;

namespace GradingSystem.Services
{
    public interface IGradeManagement
    {
        float ExerciseAverage(int exeNumber);
        float FinalGrade(string Id);
        Dictionary<string, float> FinalGrades();
    }
}