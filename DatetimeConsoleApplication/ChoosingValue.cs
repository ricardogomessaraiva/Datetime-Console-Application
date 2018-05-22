using System;

namespace DatetimeConsoleApplication
{
    public class ChoosingValue
    {
        public Values Choose(string chosen, Values values)
        {
            Validate validate = new Validate();

            while (validate.ConvertToInt(chosen) == -1)
            {
                Console.WriteLine("Valor inválido.");
                Console.WriteLine();
                Console.WriteLine("Digite um valor: ");
                chosen = Console.ReadLine();
            }            

            values.Quantity = Int64.Parse(chosen);
            if (values.Quantity < 0)
            {
                Console.WriteLine("Valores negativos são considerados positivos!");
                values.Quantity = Math.Abs(values.Quantity);                
            }

            string message = string.Empty;

            if (values.AddingHours)
                message = "Certo! Adicionar " + values.Quantity + " hora(s).";
            else if (values.AddingMinutes)
                message = "Certo! Adicionar " + values.Quantity + " minuto(s).";
            else if (values.RemovingHours)
                message = "Certo! Remover " + values.Quantity + " hora(s).";
            else
                message = "Certo! Remover " + values.Quantity + " minuto(s).";

            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();

            return values;
        }
    }
}
