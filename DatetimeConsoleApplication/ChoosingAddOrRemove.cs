using System;

namespace DatetimeConsoleApplication
{
    public class ChoosingAddOrRemove
    {
        public Values Choose(string choose, Values values)
        {            
            Validate validate = new Validate();

            while (validate.ConvertToInt(choose) == -1)
            {
                Console.WriteLine("Escolha inválida.");
                Console.WriteLine();
                Console.WriteLine("Escolha:\n 1 -> Adicionar em Hora(s) \n 2 -> Adicionar em Minuto(s) \n 3 -> Remover em Hora(s) \n 4 -> Remover em Minuto(s)");
                choose = Console.ReadLine();
            }

            int num = validate.ConvertToInt(choose);
            while (num  < 1 || num > 4)
            {
                Console.WriteLine("Escolha inválida.");
                Console.WriteLine();
                Console.WriteLine("Escolha:\n 1 -> Adicionar em Hora(s) \n 2 -> Adicionar em Minuto(s) \n 3 -> Remover em Hora(s) \n 4 -> Remover em Minuto(s)");
                choose = Console.ReadLine();
                num = validate.ConvertToInt(choose);
            }

            string message = "Certo!";
            if (num == 1)
            {
                values.AddingHours = true;
                message += " Adicionar em horas.";
            }
            else if (num == 2)
            {
                values.AddingMinutes = true;
                message += " Adicionar em minutos.";
            }

            else if (num == 3)
            {
                values.RemovingHours = true;
                message = "Certo! Remover em horas.";
            }
            else
            {
                values.RemovingMinutes = true;
                message = "Certo! Remover em minutos.";
            }             

            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();

            return values;

            ////fim

            //     10/10/2000 11:00
            //     ||
        }
    }
}
