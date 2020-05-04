using System;
using System.Collections.Generic;
using Bankdb.Views;

namespace Bankdb
{
    class Program
    {
        static string Choise()
        {
            Console.WriteLine("[1] Lisää pankki\n[2] Päivitä pankki\n[3] Poista pankki\n[4] Lisää pankkiin asiakas ja tili\n[5] Hae pankin tilit" +
                              "\n[6] Hae pankin asiakkaat\n[7] Päivitä asiakastiedot\n[8] Poista asiakas tiedot ja asiakkaan tilit\n[9] Hae asiakkaan tilitapahtumia");
            Console.Write("Valitse mitä tehdään: ");
            string choise = Console.ReadLine();
            return choise;
        }

        static void Main(string[] args)
        {
            string userInput = null;
            UIModels uiModels = new UIModels();
            string msg = "";

            do
            {
                userInput = Choise();
                switch (userInput.ToUpper())
                {
                    case "1":
                        uiModels.CreateBank();
                        msg = "Uusi pankki luotu";
                        break;
                    case "2":
                        uiModels.UpdateBank();
                        msg = "Pankin tiedot päivitetty";
                        break;
                    case "3":
                        uiModels.DeleteBank(9);
                        msg = "Pankki poistettu";
                        break;
                    case "4":
                        uiModels.CreateCustomerAccount();
                        msg = "Asiakas ja tili luotu";
                        break;
                    case "5":
                        uiModels.ReadAccountsByBankId(7);
                        break;
                    case "6":
                        uiModels.ReadCustomerByBankId(6);
                        msg = "Pankin asiakkaat tulostettu";
                        break;
                    case "7":
                        uiModels.UpdateCustomer();
                        msg = "Asiakkaan tiedot päivitetty";
                        break;
                    case "8":
                        uiModels.DeleteCustomer(30);
                        msg = "Asiakas poistettu";
                        break;
                    case "9":
                        uiModels.ReadTransactionById(15);
                        msg = "Tilitapahtumat tulostettu";
                        break;
                    default:
                        msg = "Yritä uudestaan oikealla näppäimellä";
                        break;
                }
                Console.WriteLine(msg);
            } while (userInput.ToUpper() != "" + "");
        }
    }
}
