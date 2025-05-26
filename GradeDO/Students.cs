using GradeDO.Exceptions;
using System.Diagnostics;
using System;
using System.Reflection.Metadata.Ecma335;


namespace GradeDO
{
    public class Students : IStudents
    {
        DataSource studentsList ;

        
        public Students()
        {
            studentsList = new DataSource();
            studentsList.Initialize();
        }

       
        public void AddStudent(Student student)
        {
            if (studentsList.Students.Any(stu => stu.ID == student.ID))
                throw new StudentAlradyExsistException(student.ID);
            student.Password = student.ID;
            studentsList.Students.Add(student);

        }

        public void AddGradeToStudent(string StudentId, Grade grade)
        {
            Student student =FindStudent(StudentId);
            grade.Date = DateTime.Today;
            student.ExeList.Add(grade);
        }
        public void EreaseStudent(string StudentId)
        {
            Student student = FindStudent(StudentId);
            studentsList.Students.Remove(student);
        }
        public void EditPassword(string StudentId, string NewPass)
        {
            Student student = FindStudent(StudentId);
            student.Password = NewPass;
        }
        public void EditName(string StudentId, string newName, string CurrPass)
        {
            Student student = FindStudent(StudentId);
            student.Name = newName;
        }
        public Student ViewStudent(string StudentId)
        {
            Student student = FindStudent(StudentId);
            return student;
        }
        public List<Student> ViewStudents()
        {
            return studentsList.Students;
        }
        public void InsertGrades(List<string> IDs, List<int> grades,int exeNum)
        {
            for (int i = 0; i < IDs.Count(); i++)
            {
                EditGrade(IDs[i],grades[i],exeNum);
            }
 
        }
        public void EditGrade(string StudentId, int grade,int exeNum)
        {
            Student student = FindStudent(StudentId);
            Grade g=student.ExeList.FirstOrDefault(e => e.ExeNumber == exeNum);
            if (g == null) 
            { 
                Grade grade1 = new Grade();
                grade1.Date = DateTime.Now;
                grade1.GradeNumber = grade;
                grade1.ExeNumber = exeNum;
                AddGradeToStudent(StudentId , grade1);
                
            }
            else
            {
                g.GradeNumber = grade;
             }
                

        }
        public Grade ReturnGrade(string StudentId, int exeNumber)
        {
            Student student = FindStudent(StudentId) ;
            if (exeNumber == 99&& student.TestGrade!=null)
                return student.TestGrade;
            Grade grade=student.ExeList.FirstOrDefault(e => e.ExeNumber == exeNumber);
            if (grade != null)
            {
                return grade;
            }
            return null;
            
            
        }
        public List<int> ReturnGrades(int exeNum)
        {
            List<int> Grades = new List<int>();
            foreach (Student student in studentsList.Students)
            {
                if (ReturnGrade(student.ID, exeNum) != null)
                    Grades.Add(ReturnGrade(student.ID, exeNum).GradeNumber);
                else Grades.Add(-1);
            }
            return Grades;
        }
        public Dictionary<int , List<int>> ReturnAllGrades(int num)
        {
            Dictionary<int, List<int>> AllGrades= new Dictionary<int , List<int>>();
            for (int i = 1; i <=num; i++)
            {
                AllGrades.Add(i, ReturnGrades(i));
            }
            AllGrades.Add(99, ReturnGrades(99));
            return AllGrades;
        }
        public Student FindStudent(string StudentId)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == StudentId);
            if (student == null)
                throw new StudentNotExsistException(StudentId);
            return student;
        }
        public Grade LastSubmit(string StudentId ,string Pass)
        {
            Student student = FindStudent(StudentId);
            if (student.ExeList.Count()>0)
                return student.ExeList[student.ExeList.Count()-1];
            throw new EmptyExeList();
        }
        public Grade SpecificExercise(string StudentId,int exeNum)
        {
            
            return ReturnGrade(StudentId,exeNum);
        }
 
       


    }
}

