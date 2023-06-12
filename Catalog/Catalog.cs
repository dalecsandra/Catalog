using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsCatalog
{
    /// <summary>
    /// Reprezinta un catalog de studenti.
    /// </summary>
    class Catalog
    {
        private List<Student> students = new List<Student>();
        /// <summary>
        /// Genereaza o lista implicita.
        /// </summary>
        public void GenerateDefaultStudents()
        {
            students = new List<Student>
            {
                new Student(1, "John", "Doe", 20, new Address("City1", "Street1", "1")),
                new Student(2, "Jane", "Smith", 22, new Address("City2", "Street2", "2")),
                new Student(3, "Michael", "Johnson", 21, new Address("City3", "Street3", "3")),
                new Student(4, "Emily", "Williams", 19, new Address("City4", "Street4", "4")),
                new Student(5, "Daniel", "Brown", 23, new Address("City5", "Street5", "5"))
            };

            Console.WriteLine("\nLista de studenti generata cu succes.\n");
        }
        /// <summary>
        /// Afiseaza toti studentii din catalog.
        /// </summary>
        public void DisplayAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNu s-a gasit niciun student.\n");
                return;
            }

            Console.WriteLine("\nLista studenti:\n");
            foreach (Student student in students)
            {
                student.DisplayStudent();
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Afiseaza detaliile unui student dupa id.
        /// </summary>
        /// <param name="id">ID-ul studentului.</param>
        public void DisplayStudentById(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("\nDetaliile studentului:\n");
                student.DisplayStudent();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"\nStudentul cu id-ul {id} nu a fost gasit.\n");
            }
        }
        /// <summary>
        /// Adauga un student nou in catalog bazat pe ce citim de la tastatura.
        /// </summary>
        public void AddStudentFromConsole()
        {
            Console.WriteLine("\nIntrodu detaliile studentului:");
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Prenume: ");
            string firstName = Console.ReadLine();
            Console.Write("Nume: ");
            string lastName = Console.ReadLine();
            Console.Write("Varsta: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("\nIntrodu adresa:");
            Console.Write("Oras: ");
            string city = Console.ReadLine();
            Console.Write("Strada: ");
            string street = Console.ReadLine();
            Console.Write("Numar: ");
            string number = Console.ReadLine();

            Address address = new Address(city, street, number);
            Student student = new Student(id, firstName, lastName, age, address);
            students.Add(student);

            Console.WriteLine("\nStudentul a fost adaugat cu succes.\n");
        }
        /// <summary>
        /// Sterge un student din catalog dupa ID.
        /// </summary>
        /// <param name="id">ID-ul sudentului care sa fie sters.</param>
        public void RemoveStudentById(int id)
        {
            int index = students.FindIndex(s => s.Id == id);
            if (index != -1)
            {
                students.RemoveAt(index);
                Console.WriteLine($"\nStudentul cu id-ul {id} a fost sters cu succes.\n");
            }
            else
            {
                Console.WriteLine($"\nStudentul cu ID-ul {id} nu a fost gasit.\n");
            }
        }
        /// <summary>
        /// Actualizeaza detaliile unui student bazat pe ID-ul lui.
        /// </summary>
        /// <param name="id">ID-ul studentului care sa fie modificat.</param>
        public void UpdateStudentData(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("\nIntrodu detaliile care sa fie modificate:");
                Console.Write("Prenume: ");
                string firstName = Console.ReadLine();
                Console.Write("Nume: ");
                string lastName = Console.ReadLine();
                Console.Write("Varsta: ");
                int age = int.Parse(Console.ReadLine());

                student.FirstName = firstName;
                student.LastName = lastName;
                student.Age = age;

                Console.WriteLine("\nInformatiile studentului au fost salvate cu succes.\n");
            }
            else
            {
                Console.WriteLine($"\nStudentul cu ID-ul {id} Nu a fost gasit.\n");
            }
        }
        /// <summary>
        /// Actualizeaza adresa unui student dupa ID.
        /// </summary>
        /// <param name="id">ID-ul studentului care urmeaza sa fie actualizat.</param>
        public void UpdateStudentAddress(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("\nIntrodu detaliile adresei:");
                Console.Write("Oras: ");
                string city = Console.ReadLine();
                Console.Write("Strada: ");
                string street = Console.ReadLine();
                Console.Write("Numar: ");
                string number = Console.ReadLine();

                Address address = new Address(city, street, number);
                student.Address = address;

                Console.WriteLine("\nAdresa studentului a fost salvata cu succes.\n");
            }
            else
            {
                Console.WriteLine($"\nStudentul cu ID-ul {id} nu a fost gasit.\n");
            }
        }
        /// <summary>
        /// Atribuie o nota unui student.
        /// </summary>
        /// <param name="id">ID-ul studentului.</param>
        public void AssignGradeToStudent(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("\nIntrodu detaliile:");
                Console.Write("Materie: ");
                string subject = Console.ReadLine();
                Console.Write("Nota: ");
                double value = double.Parse(Console.ReadLine());

                Grade grade = new Grade(value, subject);
                student.AddGrade(grade);

                Console.WriteLine("\nNota atribuita cu succes.\n");
            }
            else
            {
                Console.WriteLine($"\nStudentul cu ID-ul {id} nu a fost gasit.\n");
            }
        }
        /// <summary>
        /// Afiseaza media generala a unui student bazata pe ID-ul lui.
        /// </summary>
        /// <param name="id">ID-ul studentului.</param>
        public void DisplayOverallAverage(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                double average = student.GetAverageGrade();
                Console.WriteLine($"\nMedia generala a studentului cu ID-ul {id}: {average}\n");
            }
            else
            {
                Console.WriteLine($"\nStudentul cu ID-ul {id} nu a fost gasit.\n");
            }
        }
        /// <summary>
        /// Afiseaza media pe materii a unui student bazat pe ID.
        /// </summary>
        /// <param name="id">ID-ul studentului.</param>
        public void DisplaySubjectWiseAverage(int id)
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Dictionary<string, double> subjectAverages = student.GetSubjectWiseAverages();
                Console.WriteLine($"\nMedia pe materii a studentului cu ID-ul {id}:");
                foreach (var subjectAverage in subjectAverages)
                {
                    Console.WriteLine($"{subjectAverage.Key}: {subjectAverage.Value}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"\nStudentul cu ID-ul {id} nu a fost gasit.\n");
            }
        }
        /// <summary>
        /// Afiseaza toti studentii in ordine descrescatoare in functie de media generala.
        /// </summary>
        public void DisplayStudentsInDescendingOrder()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNu s-a gasit niciun student.\n");
                return;
            }

            List<Student> sortedStudents = students.OrderByDescending(s => s.GetAverageGrade()).ToList();
            Console.WriteLine("\nStudentii in ordine descrescatoare bazat pe media generala:\n");
            foreach (Student student in sortedStudents)
            {
                student.DisplayStudent();
                Console.WriteLine();
            }
        }
    }
}