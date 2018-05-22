using System;

namespace DatetimeConsoleApplication
{
    public class ChoosingFormat
    {
        public Values Choose(string format, Values values)
        {
            Validate validate = new Validate();                        

            while (validate.ConvertToInt(format) == -1)
            {
                Console.WriteLine("Escolha inválida.");
                Console.WriteLine();
                Console.WriteLine("Escolha abaixo qual formato deseja visualizar a nova data.");
                Console.WriteLine(" 1 -> dd/mm/yyyy hh:mm \n 2 -> dd-mm-yyyy hh:mm \n 3 -> dd-Mes-yyyy hh:mm \n 4 -> dd de mm de yyyy, hh hora(s) e mm minuto(s)");
                format = Console.ReadLine();
                validate.ConvertToInt(format);
            }

            int format_type = validate.ConvertToInt(format);
            while (format_type > 4)
            {
                Console.WriteLine("Escolha inválida.");
                Console.WriteLine();
                Console.WriteLine("Escolha abaixo qual formato deseja visualizar a nova data.");
                Console.WriteLine(" 1 -> dd/mm/yyyy hh:mm \n 2 -> dd-mm-yyyy hh:mm \n 3 -> dd-Mes-yyyy hh:mm \n 4 -> dd de mm de yyyy, hh hora(s) e mm minuto(s)");
                format = Console.ReadLine();
                format_type = validate.ConvertToInt(format);
            }            

            Console.WriteLine();
            Console.WriteLine("Feito! Calculando...");
            Console.WriteLine();

            values.Format = format_type;

            return values;
            ////fim

            //     10/10/2000 11:00
        }

    }
}
