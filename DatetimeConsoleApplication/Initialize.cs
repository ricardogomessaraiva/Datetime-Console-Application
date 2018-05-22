using System;

namespace DatetimeConsoleApplication
{
    public class Initialize
    {
        public Initialize()
        {
            string s = "************************ Sistema para consulta de datas ************************ ";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);

            Console.WriteLine("");
            Console.WriteLine();
            Console.WriteLine("Ao final do ciclo, se desejar sair digite S e tecle Enter.");
            Console.WriteLine();

            Start();
        }

        public void Start()
        {            
            string datetime = string.Empty;

            while (datetime.ToLower() != "s")
            {
                Values values = new Values();

                if (string.IsNullOrEmpty(datetime))
                {
                    Console.WriteLine("Digite a data desejada abaixo no formato dd/mm/yyyy hh:mm");
                    datetime = Console.ReadLine();
                }

                //Inicio -> Validando data enviada pelo console
                values = new Datetime().Validation(datetime);

                ////Inicio -> Validando hora ou minutos                
                Console.WriteLine("Escolha:\n 1 -> Adicionar em Hora(s) \n 2 -> Adicionar em Minuto(s) \n 3 -> Remover em Hora(s) \n 4 -> Remover em Minuto(s)");
                values = new ChoosingAddOrRemove().Choose(Console.ReadLine(), values);

                ////Inicio -> Validando quantidade a adicionar ou remover
                Console.WriteLine("Digite um valor: ");
                values = new ChoosingValue().Choose(Console.ReadLine(), values);                

                ////Inicio -> Validando escolha do formato.                
                Console.WriteLine("Escolha abaixo qual formato deseja visualizar a nova data.");
                Console.WriteLine(" 1 -> dd/mm/yyyy hh:mm \n 2 -> dd-mm-yyyy hh:mm \n 3 -> dd-Mes-yyyy hh:mm \n 4 -> dd de mm de yyyy, hh hora(s) e mm minuto(s)");
                values = new ChoosingFormat().Choose(Console.ReadLine(), values);

                ////Tudo certo e validado chamar metodo pra impressão               
                string newDatetime = new Datetime().ApplyChanges(values);
                
                Console.WriteLine("Data informada --> " + datetime);
                Console.WriteLine("Data atualizada --> " + newDatetime);

                Console.WriteLine();
                Console.WriteLine("#### Fim");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Digite a data desejada abaixo no formato dd/mm/yyyy hh:mm");
                datetime = Console.ReadLine();                
                //// FIM
            }

        }
    }
}
