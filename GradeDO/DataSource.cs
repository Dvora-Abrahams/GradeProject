using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public class DataSource
    {
        public List<Student> Students;
        public void Initialize()
        {
            Students = new List<Student>();
            Students.Add(new Student() { ID = "111", Name = "Yam", Password = "111" ,ExeList=new List<Grade>()});
            Students.Add(new Student() { ID = "222", Name = "Agam", Password = "222", ExeList = new List<Grade>() });
            Students.Add(new Student() { ID = "333", Name = "Maayan", Password = "333", ExeList = new List<Grade>() });

            Students[0].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, GradeNumber = 100, Comment = "Great" });
            Students[1].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, GradeNumber = 90, Comment = "Great" });
            Students[2].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, GradeNumber = 80, Comment = "You can do better" });

            Students[0].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, GradeNumber = 99, Comment = "Great" });
            Students[1].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, GradeNumber = 76, Comment = ":(" });
            Students[2].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, GradeNumber = 90, Comment = "Good" });

            Students[0].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, GradeNumber = 92, Comment = "Nice" });
            Students[1].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, GradeNumber = 80, Comment = ":(" });
            Students[2].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, GradeNumber = 100, Comment = "!!!" });

            Students[0].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, GradeNumber = 45, Comment = "Very bad" };
            Students[1].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, GradeNumber = 89, Comment = "Good" };
            Students[2].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, GradeNumber = 99, Comment = "Very good :)" };
        }
    }
}
