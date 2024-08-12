using StudentApp.Context;
using StudentApp.Models;

namespace StudentApp
{
    internal class Program
    {
        static StudentDbContext db = new StudentDbContext();
        static void Main(string[] args)
        {
            string choice = "y";
            while (choice == "y")
            {
                switch (Menu())
                {
                    case 1:
                        {
                            List<Student> students = new List<Student>();
                            students = GetStudents();
                            if (students.Count == 0)
                            {
                                Console.WriteLine("no records");
                            }
                            else
                            {
                                foreach (var temp in students)
                                {
                                    Console.WriteLine(temp.Name + "  " + temp.Id);
                                }
                                // 
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Add record");
                            //Console.WriteLine("enter id");
                            //int id = byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter name");
                            string name = Console.ReadLine();
                            Console.WriteLine("entre score");
                            int score = byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter doj");
                            string doj = Console.ReadLine();
                            Student student = new Student
                            {
                                //Id = id,
                                Name = name,
                                Score = score,
                                DateOfJoining = doj
                            };
                            InsertStudent(student);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("enter id to search");

                            int id = byte.Parse(Console.ReadLine());
                            Student student = SearchStudent(id);
                            if (student != null)
                                Console.WriteLine(student.Name + "  " + student.DateOfJoining + " " + student.Id + " "+ student.Score);
                            else
                                Console.WriteLine("no studnet with this id");


                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("enter id to delete");

                            int id = byte.Parse(Console.ReadLine());
                            DeleteStudent(id);



                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("enter id to edit");

                            int id = byte.Parse(Console.ReadLine());
                            Console.WriteLine("enter new score");
                            int score = byte.Parse(Console.ReadLine());


                            EditStudent(id, score);



                            break;
                        }
                    default: Console.WriteLine("invalid choice"); break;
                }

            }
            static int Menu()
            {
                Console.WriteLine("1. Get Records");
                Console.WriteLine("2. Add Record");
                Console.WriteLine("3. Search Record");
                Console.WriteLine("4. Edit Record");
                Console.WriteLine("5. Delete Record");
                Console.WriteLine("enter choice");
                int ch = byte.Parse(Console.ReadLine());
                return ch;

            }
            static List<Student> GetStudents()


            {
                List<Student> students = new List<Student>();
                Console.WriteLine("Dispaly students");
                StudentDbContext db = new StudentDbContext();
                students = db.Students.ToList();

                return students;
            }

            static void InsertStudent(Student student)
            {
                db.Students.Add(student);
                db.SaveChanges();
            }

            static Student SearchStudent(int id)
            {
                Student student = null;
                foreach (var i in db.Students)
                {
                    if (i.Id == id)
                    {
                        return i;
                        break;
                    }
                }
                return student;

            }
            static void DeleteStudent(int id)
            {
                Student student = null;
                foreach (var i in db.Students)
                {
                    if (i.Id == id)
                    {
                        db.Students.Remove(i);
                       
                        break;
                    }
                    //db.SaveChanges();
                }
                db.SaveChanges();


            }

            static void EditStudent(int id, int score)
            {
                Student temp = null;
                foreach (var i in db.Students)
                {
                    if (i.Id == id)
                    {
                        i.Score = score;
                     
                        break;
                    }
                   
                }
                db.SaveChanges();


            }

            //



        }


    }
}
