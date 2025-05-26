using GradeDO;
using GradingSystem.Configurations;
using GradingSystem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using GradeDO.Exceptions;


namespace GradingSystem.Services
{

    public class GradeManagement : IGradeManagement
    {
         IStudents students;
         Percents percents;
        public GradeManagement(IStudents _students,  IOptions<Percents> _percents)
        {
            
            students = _students;
            percents = _percents.Value;

        }
        public float FinalGrade(string Id)
        {
            float grade = 0;
            bool found = false;
            
            foreach (Student student in students.ViewStudents())
            {

                if (student.ID == Id)
                {
                    found = true;

                    for (int i = 0; i < student.ExeList.Count() - 1; i++)
                    {
                     grade += student.ExeList[i].GradeNumber * percents.Exepercents[i];

                    }
                    grade += student.TestGrade.GradeNumber * percents.Test;
                }
                
            }
            if (found)
            {
                return grade;
            }
            throw new StudentNotExsistException(Id);
           
        }
            public Dictionary<string ,float> FinalGrades()
            {
                Dictionary<string, float> result = new Dictionary<string, float>();
                foreach (Student student in students.ViewStudents())
                {
                    result.Add(student.ID, FinalGrade(student.ID));
                }
                return result;
            }
            public float ExerciseAverage(int exeNumber)
            {
                int avarage = 0;
                int count = 0;
            foreach (Student student in students.ViewStudents())
            {
                if (exeNumber == 99)
                {
                    if (student.TestGrade != null)
                        avarage += student.TestGrade.GradeNumber;
                    count++;
                }
                else
                {
                    Grade g = student.ExeList.FirstOrDefault(g => g.ExeNumber.Equals(exeNumber));
                    if (g != null)
                        avarage += g.GradeNumber;
                    count++;
                }
            }
                return (avarage / count);
            }
        }
    }
