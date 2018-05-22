using System.Linq;

namespace DatetimeConsoleApplication
{
    public class Validate
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        private bool ValidateDate(string datetime)
        {
            string date = GetDateString(datetime);

            //Seperando dia/mes/ano
            string[] dateTokens = date.Split('/');

            if (dateTokens.Length < 2)
                //Não há elementos necessários para uma data válida.
                return false;

            int i = 0;
            foreach (string item in dateTokens)
            {                
                if (i == 0)
                {
                    if (item.Length != 2)
                        //Elemento possui menos ou mais caracteres para um dia válido.
                        return false;

                    //validando dia                    
                    int day = ConvertToInt(item);
                    if (day == -1)
                        //Não foi possível converter para Int
                        return false;

                    if (day < 1 || day > 31)
                        //Maior do que possível
                        return false;
                }

                if (i == 1)
                {
                    if (item.Length != 2)
                        //Elemento possui menos ou mais caracteres para um dia válido.
                        return false;

                    //validando mês                    
                    int month = ConvertToInt(item);
                    if (month == -1)
                        //Não foi possível converter para Int
                        return false;
                    if (month < 1 || month > 12)
                        //Maior do que possível
                        return false;
                }

                if (i == 2)
                {
                    //validando ano
                    if (item.Length != 4)
                        //Elemento possui menos ou mais caracteres para um ano válido.
                        return false;

                    int year = ConvertToInt(item);
                    if (year == -1)
                        //Não foi possível converter para Int
                        return false;

                    if (year < 1800)
                        //Menor ano possível
                        return false;
                }

                i++;
            }

            //Retorno quando for valido.
            return true;
        }

        private bool ValidateTime(string datetime)
        {
            string time = datetime.Split(' ').Last();
            string[] timeTokens = time.Split(':');

            /******* Validações para a hora e minuto ********/
            if (timeTokens.Length < 2)
                return false;

            int i = 0;
            foreach (var item in timeTokens)
            {
                if (item.Length < 2)
                    //Não há elementos necessários para uma hora válida.
                    return false;

                if (i == 0)
                {
                    //hora                   
                    int hour = ConvertToInt(item);
                    if (hour == -1)
                        //Não foi possível converter para Int
                        return false;

                    if (hour < 0 || hour > 23)
                        //Hora maior ou menor para ser válida.
                        return false;
                }

                if (i > 0)
                {
                    //minuto                   
                    int minute = ConvertToInt(item);
                    if (minute == -1)
                        //Não foi possível converter para Int
                        return false;

                    if (minute < 0 || minute > 59)
                        //Hora maior ou menor para ser válida.
                        return false;
                }
                i++;
            }

            return true;
            /******* FIM ********/
        }

        private string GetDateString(string datetime)
        {
            return datetime.Split(' ').First();
        }

        private string GetTimeString(string datetime)
        {
            return datetime.Split(' ').Last();
        }

        public int ConvertToInt(string value)
        {
            int _out = -1;
            bool ret = int.TryParse(value, out _out);

            if (!ret)
                //Conversão falhou.
                return -1;

            //Conversão efetuada.
            return _out;
        }

        public Validate ValidateDatetimeString(string datetime)
        {
            if (!ValidateDate(datetime))
                return new Validate { IsValid = false, Message = "Data inválida." };

            if (!ValidateTime(datetime))
                return new Validate { IsValid = false, Message = "Tempo inválido." };

            return new Validate { IsValid = true, Message = "Data e hora validados com sucesso." };
        }        
    }
}
