using System;
using PersonExampleDB.Data;
using PersonExampleDB.Repositories;
using PersonExampleDB.Views;

namespace PersonExampleDB
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();
        static void Main(string[] args)
        {
            string userInput = null;
            UIModel uiModel = new UIModel();
            string msg = "";
            do
            {
                userInput = Choise();
                switch (userInput.ToUpper())
                {
                    case "C":
                        uiModel.CreatePerson();
                        msg = "---------------------------------";
                        break;
                    case "R":
                        uiModel.ReadById(5004);
                        msg = "---------------------------------";
                        break;
                    case "U":
                        uiModel.UpdatePerson();
                        msg = "---------------------------------";
                        break;
                    case "D":
                        uiModel.DeletePerson(5005);
                        msg = "---------------------------------";
                        break;
                    case "K":
                        uiModel.ReadByCity();
                        break;
                    case "X":
                        msg = "Lopetetaan...";
                        break;
                    default:
                        msg = "Yritä uudestaan oikealla näppäimellä";
                        break;
                }
                Console.WriteLine(msg);
            } while (userInput.ToUpper() != "X");
        }
        static string Choise()
        {
            Console.WriteLine("[C] Lisää tietokantaan uusi henkilö\n[R] Haetaan henkilö tietokannasta" +
                "\n[U] Päivitä henkilön tiedot\n[D] Poista henkilö tietokannasta\n[K] Hae tiedot kaupungista\n[X] Lopeta ohjelmansuoritus");
            Console.Write("Valitse mitä tehään: ");
            string choise = Console.ReadLine();
            return choise;
        }
    }
}
