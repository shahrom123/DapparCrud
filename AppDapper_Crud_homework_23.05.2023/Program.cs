


using Domain.Dtos;
using Infrastructure.Services;

var studentSerice = new StudentService();
//Show();
void Show()
{
    var students = studentSerice.GetStudents();
    Console.WriteLine("Id-------FirstName----------LastName------Age------email");
    foreach (var student in students)
    {
        Console.WriteLine($"{student.Id}-------{student.FirstName}----------" +
            $" {student.LastName}------{student.Age}------ {student.email}");
    }
     
}

//GetById(7);
//void GetById(int id)
//{
//    var student = studentSerice.GetById(id);
//    Console.WriteLine("GetById");
//    Console.WriteLine($" Id: {student.Id}\n" +
//        $" FirstName: {student.FirstName} \n" +
//        $" LastName: {student.LastName} \n" +
//        $" Age:{student.Age} \n" +
//        $" Email: {student.email}");  
//}

//var student = new StudentDto()
//{
//    FirstName = "Shahzod",
//    LastName = "Shahzod",
//    Age = 20,
//    email = "Shahzod@gmail.com",
//};
//GetIdAddStudent(student); 

//void GetIdAddStudent(StudentDto studentDto)
//{
//    var result = studentSerice.GetIdAddStudent(studentDto);
//    Console.WriteLine(result.Id);
//}


//var s = new StudentDto()
//{
//    Id = 9,
//    FirstName = "Test",
//    LastName = "Test",
//    Age = 30,
//    email = "test@gmail.com"

//};
//Update(s);
//void Update(StudentDto studentDto)
//{
//    var student = studentSerice.UpdateStudent(studentDto);
//    Console.WriteLine(student);

//}

//DeleteStudent(11);

void DeleteStudent(int id)
{
    var student = studentSerice.DeleteStudent(id);
    Console.WriteLine(student);

}
