using Dapper;
using Domain.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StudentService
    {
        string connectionString = "Server=localhost; Port=5432; Database=Dapper2; User Id=postgres; Password=233223;";
        public StudentService()
        {
            
        }
        public List<StudentDto>GetStudents()
        {
            using(var conn = new NpgsqlConnection(connectionString))
            {
                var sql = $"select id, first_name as FirstName, last_name as LastName," +
                    $" Age, email from Students";
                var result = conn.Query<StudentDto>(sql);  return result.ToList(); 
            } 
        }
        //GetById
        public StudentDto GetById(int id)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                var sql = $"select id, first_name as FirstName, last_name as LastName, Age, email from Students " +
                    $"where id = {id}";
                var result = conn.QuerySingle<StudentDto>(sql);
                return result; 
            }
        }
        // insert
        public StudentDto GetIdAddStudent(StudentDto student)  
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                var sql = $"insert into Students(first_name, last_name, Age, email)values(@FirstName,@FirstName, @Age, @email)returning id;";
                var result = conn.ExecuteScalar<int>(sql,student);
                student.Id = result;
                return student;   
            }
        }
        // Update   
        public int UpdateStudent(StudentDto student)
        {
            using(var conn = new NpgsqlConnection(connectionString))
            {
                var sql = $"update students set " +
                $"first_name = '{student.FirstName}'," +
                $"last_name = '{student.LastName}'," +
                $"Age = {student.Age}, " +
                $"email = '{student.email}'" +
                $"where id = {student.Id}";
                var result = conn.Execute(sql);      
                return result;
            }
        }

        public int DeleteStudent(int id)
        {
            using(var conn = new NpgsqlConnection(connectionString))
            {
                var sql = $"delete from Students where id = {id}";
                var result = conn.Execute(sql);
                return result; 
            }
        }
    }
}
