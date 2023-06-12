using StudentsCatalog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentCatalog
{
    /// <summary>
    /// Reprezinta un program care gestioneaza un catalog de studenti.
    /// </summary>
    class Program
    {
        static void Main()
        {
            var catalog = new Catalog();
            catalog.GenerateDefaultStudents();
            string menu = "Alege o optiune:\n" +
                          "1. Afiseaza toti studentii\n" +
                          "2. Afiseaza un student dupa ID\n" +
                          "3. Adauga un student\n" +
                          "4. Sterge un student\n" +
                          "5. Modifica informatii student\n" +
                          "6. Modifica adresa unui student\n" +
                          "7. Atribuie nota unui student\n" +
                          "8. Afiseaza media generala a unui student\n" +
                          "9. Afiseaza media pe materie a unui student\n" +
                          "10. Afiseaza studentii in ordine descrescatoare a mediei generale\n" +
                          "11. Iesire\n" +
                          "Optiuni = ";

            while (true)
            {
                Console.WriteLine(menu);
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        catalog.DisplayAllStudents();
                        break;
                    case "2":
                        Console.Write("Introdu ID student: ");
                        int studentId = int.Parse(Console.ReadLine());
                        catalog.DisplayStudentById(studentId);
                        break;
                    case "3":
                        catalog.AddStudentFromConsole();
                        break;
                    case "4":
                        Console.Write("Introdu ID student care va fi sters: ");
                        int removeId = int.Parse(Console.ReadLine());
                        catalog.RemoveStudentById(removeId);
                        break;
                    case "5":
                        Console.Write("Introdu ID student care va fi modificat: ");
                        int modifyId = int.Parse(Console.ReadLine());
                        catalog.UpdateStudentData(modifyId);
                        break;
                    case "6":
                        Console.Write("Introdu ID student a carui adresa va fi modificata: ");
                        int modifyAddressId = int.Parse(Console.ReadLine());
                        catalog.UpdateStudentAddress(modifyAddressId);
                        break;
                    case "7":
                        Console.Write("Introdu ID student care va primi nota: ");
                        int assignGradeId = int.Parse(Console.ReadLine());
                        catalog.AssignGradeToStudent(assignGradeId);
                        break;
                    case "8":
                        Console.Write("Introdu ID student a carui medie generala va fi afisata: ");
                        int overallAverageId = int.Parse(Console.ReadLine());
                        catalog.DisplayOverallAverage(overallAverageId);
                        break;
                    case "9":
                        Console.Write("Introdu ID student a carui medie pe materie va fi afisata: ");
                        int subjectAverageId = int.Parse(Console.ReadLine());
                        catalog.DisplaySubjectWiseAverage(subjectAverageId);
                        break;
                    case "10":
                        catalog.DisplayStudentsInDescendingOrder();
                        break;
                    case "11":
                        return;
                    default:
                        Console.WriteLine("\nOptiunea aleasa este invalida. Te rugam incearca din nou.\n");
                        break;
                }
            }
        }
    }
}