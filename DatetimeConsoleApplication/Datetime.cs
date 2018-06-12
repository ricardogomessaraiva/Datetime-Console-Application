using System;
using System.Linq;

namespace DatetimeConsoleApplication.Datetime
{
    public class Datetime
    {        
        private string Name;
        private int Number;
        private int LastDay;
        private Datetime date;

        public string ApplyChanges(Values values)
        {
            string datetime = string.Empty;

            if (values.AddingHours)
            {
                datetime = AddHours(values.Datetime, values.Quantity);
                return Format(datetime, values.Format);
            }

            if (values.AddingMinutes)
            {
                datetime = AddMinutes(values.Datetime, values.Quantity);
                return Format(datetime, values.Format);
            }

            if (values.RemovingHours)
            {
                datetime = SubtractHours(values.Datetime, values.Quantity);
                return Format(datetime, values.Format);
            }

            if (values.RemovingMinutes)
            {
                datetime = SubtractMinutes(values.Datetime, values.Quantity);
                return Format(datetime, values.Format);
            }

            return datetime;
        }

        public string AddHours(string datetime, long value)
        {
            date = new Datetime();

            int day = date.GetDay(datetime);

            int month = date.GetMonth(datetime);

            int year = date.GetYear(datetime);

            int hour = date.GetHours(datetime);

            int minute = date.GetMinutes(datetime);

            //Variavel de saída
            string datimeOutup = string.Empty;

            while (value != 0)
            {
                date = new Datetime().Month(month, year);

                hour++;

                if (hour == 24)
                {
                    //Mudou o dia
                    day++;
                    hour = 0;
                }

                if (day > date.LastDay)
                {
                    //Mudou o mes
                    day = 1;
                    month++;
                    hour = 0;
                }

                if (month == 13)
                {
                    //Mudou o ano
                    year++;
                    month = 1;
                    day = 1;
                    hour = 0;
                }

                value--;

                if (value == 0)
                    return string.Format("{0}/{1}/{2} {3}:{4}",
                            day.ToString(), month.ToString(), year.ToString(), hour.ToString(), minute.ToString());
            }

            return datetime;
        }

        public string AddMinutes(string datetime, long value)
        {
            //Add = 4000 (minutes)
            //Input = "01/03/2010 23:00"
            //Output = "04/03/2010 17:40"

            date = new Datetime();

            int day = date.GetDay(datetime);

            int month = date.GetMonth(datetime);

            int year = date.GetYear(datetime);

            int hour = date.GetHours(datetime);

            int minute = date.GetMinutes(datetime);

            //Variavel de saída
            string datimeOutup = datetime;

            while (value != 0)
            {
                date = new Datetime().Month(month, year);
                minute++;

                if (minute == 60)
                {
                    //Mudou a hora
                    hour++;
                    minute = 0;
                }

                if (hour == 24)
                {
                    //Mudou o dia
                    day++;
                    hour = 0;
                    minute = 0;
                }

                if (day > date.LastDay)
                {
                    //Mudou o mes
                    day = 1;
                    month++;
                    hour = 0;
                    minute = 0;
                }

                if (month == 13)
                {
                    //Mudou o ano
                    year++;
                    month = 1;
                    day = 1;
                    hour = 0;
                    minute = 0;
                }

                value--;

                if (value == 0)
                    return string.Format("{0}/{1}/{2} {3}:{4}",
                            day.ToString(), month.ToString(), year.ToString(), hour.ToString(), minute.ToString());
            }

            return datimeOutup;
        }

        public string SubtractHours(string datetime, long value)
        {
            //Subtract = 4000 (minutes)
            //Input = "04/03/2010 17:40"
            //Output = "01/03/2010 23:00"                       
            Datetime date = new Datetime();

            int day = date.GetDay(datetime);

            int month = date.GetMonth(datetime);

            int year = date.GetYear(datetime);

            int hour = date.GetHours(datetime);

            int minute = date.GetMinutes(datetime);

            //Variavel de saída
            string datimeOutup = string.Empty;

            while (value != 0)
            {
                date = new Datetime().Month(month, year);

                hour--;

                if (hour < 0)
                {
                    hour = 23;
                    //Mudou o dia
                    day--;
                }

                if (day == 0)
                {
                    //Mudou o mês
                    month--;

                    if (day == 0)
                        //Pegar último dia do mês
                        day = date.Month(month, year).LastDay;
                }

                if (month == 0)
                {
                    //Último dia do ano
                    year--;
                    month = 12;
                    day = date.Month(month, year).LastDay;
                }

                value--;
                if (value == 0)
                    return datimeOutup = string.Format("{0}/{1}/{2} {3}:{4}",
                            day.ToString(), month.ToString(), year.ToString(), hour.ToString(), minute.ToString());
            }

            //Retornando string vazia caso nao existe incremento
            return datimeOutup;
        }

        public string SubtractMinutes(string datetime, long value)
        {
            //Subtract = 4000 (minutes)
            //Input = "04/03/2010 17:40"
            //Output = "01/03/2010 23:00"                       
            Datetime date = new Datetime();

            int day = date.GetDay(datetime);

            int month = date.GetMonth(datetime);

            int year = date.GetYear(datetime);

            int hour = date.GetHours(datetime);

            int minute = date.GetMinutes(datetime);

            //Variavel de saída
            string datimeOutup = string.Empty;

            while (value != 0)
            {
                date = new Datetime().Month(month, year);

                minute--;

                if (minute < 0)
                {
                    //último minuto
                    minute = 59;
                    if (hour == 0)
                        //última hora
                        hour = 23;
                    else
                        //Subtrair hora
                        hour--;
                }

                if (hour == 23 && minute == 59)
                {
                    //Mudou o dia
                    day--;
                }

                if (day == 0)
                {
                    //Mudou o mês
                    month--;

                    if (day == 0)
                        //Pegar último dia do mês
                        day = date.LastDay;
                }

                if (month == 0)
                {
                    //Último dia do ano
                    year--;
                    month = 12;
                    day = date.LastDay;
                }

                value--;

                if (value == 0)
                    return datimeOutup = string.Format("{0}/{1}/{2} {3}:{4}",
                            day.ToString(), month.ToString(), year.ToString(), hour.ToString(), minute.ToString());
            }

            //Retornando string vazia caso nao existe incremento
            return datimeOutup;
        }

        public string Format(string datetime, int format_type)
        {
            date = new Datetime();
            //Obter dia usando método da classe
            int day = date.GetDay(datetime);

            //Obter mês usando método da classe
            int month = date.GetMonth(datetime);

            //Obter ano usando método da classe
            int year = date.GetYear(datetime);

            //Obter hora usando método da classe
            int hour = date.GetHours(datetime);

            //Obter minutos usando método da classe
            int minutes = date.GetMinutes(datetime);

            //Testes usando ternários para determinar a formatação da string de retorno.
            //Dia e mês
            string dayStr = day < 10 ? "0" + day.ToString() : day.ToString();
            string monthStr = month < 10 ? "0" + month.ToString() : month.ToString();

            //Hora e minuto
            string hoursStr = hour < 10 ? "0" + hour.ToString() : hour.ToString();
            string minutesStr = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();

            string monthName = date.Month(month, year).Name;

            //Formatar a data.
            if (format_type == 2)
            {
                //2 -> dd-mm-yyyy hh:mm                                 
                return string.Format("{0}-{1}-{2} {3}:{4}",
                    dayStr, monthStr, year.ToString(), hoursStr, minutesStr).ToUpper();
            }

            if (format_type == 3)
            {
                //3 -> dd-Mes-yyyy hh:mm                
                return string.Format("{0}-{1}-{2} {3}:{4}",
                    dayStr, monthName, year.ToString(), hoursStr, minutesStr).ToUpper();
            }

            if (format_type == 4)
            {
                // 4 -> dd de Mes de yyyy, hh hora(s) e mm minuto(s)");                
                return string.Format("{0} de {1} de {2}, {3} hora(s) e {4} minuto(s)",
                    dayStr, monthName, year.ToString(), hoursStr, minutesStr).ToUpper();
            }

            //1 -> dd/mm/yyyy hh:mm                                      
            //Tipo 1 é formato default
            return string.Format("{0}/{1}/{2} {3}:{4}", dayStr, monthStr, year.ToString(), hoursStr, minutesStr);
        }
        
        private Datetime Month(int month, int year)
        {
            if (month == 1)
                return new Datetime() { LastDay = 31, Number = 1, Name = "Janeiro" };

            if (month == 2)
            {
                if (IsBissextYear(year))
                    return new Datetime() { LastDay = 29, Number = 2, Name = "Fevereiro" };

                return new Datetime() { LastDay = 28, Number = 2, Name = "Fevereiro" };
            }

            if (month == 3)
                return new Datetime() { LastDay = 31, Number = 3, Name = "Março" };

            if (month == 4)
                return new Datetime() { LastDay = 30, Number = 4, Name = "Abril" };

            if (month == 5)
                return new Datetime() { LastDay = 31, Number = 5, Name = "Maio" };

            if (month == 6)
                return new Datetime() { LastDay = 30, Number = 6, Name = "Junho" };

            if (month == 7)
                return new Datetime() { LastDay = 31, Number = 7, Name = "Julho" };

            if (month == 8)
                return new Datetime() { LastDay = 31, Number = 8, Name = "Agosto" };

            if (month == 9)
                return new Datetime() { LastDay = 30, Number = 9, Name = "Setembro" };

            if (month == 10)
                return new Datetime() { LastDay = 31, Number = 10, Name = "Outubro" };

            if (month == 11)
                return new Datetime() { LastDay = 30, Number = 11, Name = "Novembro" };

            return new Datetime() { LastDay = 31, Number = 12, Name = "Dezembro" };

        }        

        private int GetDay(string _datetime)
        {
            //Quebrar a string por Espaço para ter um array com 2 elementos - [0] => data; [1] tempo            
            string datetime = _datetime.Split(' ').First();

            //Quebrar a string por / para ter um array com 3 elementos - [0] => dia; [1] => mês; [2] => ano
            //Retornando dia = posição 0 do array convertido em Int16
            return Convert.ToInt16(datetime.Split('/').First());
        }

        private int GetMonth(string _datetime)
        {
            //Quebrar a string por Espaço para ter um array com 2 elementos - [0] => data; [1] tempo
            string datetime = _datetime.Split(' ').First();

            //Quebrar a string por / para ter um array com 3 elementos - [0] => dia; [1] => mês; [2] => ano
            //Retornando mês = posição 1 do array convertido em Int16
            return Convert.ToInt16(datetime.Split('/').GetValue(1).ToString());
        }

        private int GetYear(string _datetime)
        {
            //Quebrar a string por Espaço para ter um array com 2 elementos - [0] => data; [1] tempo
            string datetime = _datetime.Split(' ').First();

            //Quebrar a string por / para ter um array com 3 elementos - [0] => dia; [1] => mês; [2] => ano
            //Retornando ano = posição 2 do array (último) convertido em Int16
            return Convert.ToInt16(datetime.Split('/').Last());
        }

        private int GetHours(string _datetime)
        {
            //Quebrar a string por Espaço para ter um array com 2 elementos - [0] => data; [1] tempo
            string time = _datetime.Split(' ').Last();

            //Quebrar a string por : para ter um array com 2 elementos - [0] => hora; [1] => minuto
            //Retornando hora = posição 0 do array (primeiro) convertido em Int16
            return Convert.ToInt16(time.Split(':').First());
        }

        private int GetMinutes(string _datetime)
        {
            //Quebrar a string por Espaço para ter um array com 2 elementos - [0] => data; [1] tempo
            string time = _datetime.Split(' ').Last();

            //Quebrar a string por : para ter um array com 2 elementos - [0] => hora; [1] => minuto
            //Retornando hora = posição 1 do array (último) convertido em Int16
            return Convert.ToInt16(time.Split(':').Last());
        }

        private bool IsBissextYear(int year)
        {
            if (year % 4 == 0)
                return true;
            

            if (year % 400 == 0)
                return true;

            return false;
        }



    }
}
