using System;
using DatetimeConsoleApplication;
using DatetimeConsoleApplication.Datetime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidateClass;

namespace DatetimeConsoleApplication_UnitTests
{
    /*
     * Please read file the README.txt to know how datetime format works.
    */

    [TestClass]
    public class UnitTestDatetimeMethods
    {
        Validate validate;
        DateTime datetime;
        Datetime my_datetime;

        [TestInitialize]
        public void Init()
        {
            validate = new Validate();
            my_datetime = new Datetime();
        }

        //Begin -> validing DATETIME possibilities
        [TestMethod]
        public void MustBeFalseWhenDatetimeIsEmpty()
        {
            Validate result = validate.ValidateDatetimeString("");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenDatetimeIsInvalid()
        {
            Validate result = validate.ValidateDatetimeString("xxx");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenDatetimeFormatIsWrong()
        {
            Validate result = validate.ValidateDatetimeString("01-03-2010 17:00");
            Assert.IsFalse(result.IsValid);
        }
        ///End

        //Validated bissext year
        [TestMethod]
        public void ValidatedBissextYear()
        {
            //Output 29/02/2016 17:00
            datetime = DateTime.Parse("28/02/2016 17:00");
            string microsoft_result = datetime.AddHours(24).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddHours("28/02/2016 17:00", 24);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        //Begin -> validing DAY possibilities
        [TestMethod]
        public void MustBeFalseWhenDayIsHigherThanPossible()
        {
            Validate result = validate.ValidateDatetimeString("60/03/2010 17:00");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenDayIsLesserThanPossible()
        {
            Validate result = validate.ValidateDatetimeString("00/03/2010 17:00");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenDayIsInvalid()
        {
            Validate result = validate.ValidateDatetimeString("1x/03/2010 17:00");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenDayIsInvalid_2()
        {
            Validate result = validate.ValidateDatetimeString("2x/03/2010 17:00");
            Assert.IsFalse(result.IsValid);
        }
        //End


        //Begin -> validing MONTH possibilities
        [TestMethod]
        public void MustBeFalseWhenMonthIsHigherThanPossible()
        {
            Validate result = validate.ValidateDatetimeString("15/13/2018 03:38");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenMonthIsLesserThanPossible()
        {
            Validate result = validate.ValidateDatetimeString("15/00/2018 03:38");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenMonthIsInvalid()
        {
            Validate result = validate.ValidateDatetimeString("15/1x/2018 03:38");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenMonthIsInvalid_2()
        {
            Validate result = validate.ValidateDatetimeString("15/x2/2018 03:38");
            Assert.IsFalse(result.IsValid);
        }
        ///End


        //Begin -> validing YEAR possibilities        
        [TestMethod]
        public void MustBeFalseWhenYearIsLesserThanPossible()
        {
            Validate result = validate.ValidateDatetimeString("15/00/1799 03:38");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenYearIsInvalid()
        {
            Validate result = validate.ValidateDatetimeString("16/06/x005 12:17");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenYearIsInvalid_2()
        {
            Validate result = validate.ValidateDatetimeString("16/06/2x05 12:17");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenYearIsInvalid_3()
        {
            Validate result = validate.ValidateDatetimeString("16/06/20x5 12:17");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenYearIsInvalid_4()
        {
            Validate result = validate.ValidateDatetimeString("16/06/200x 12:17");
            Assert.IsFalse(result.IsValid);
        }
        ///End


        //Begin -> validing HOUR possibilities        
        [TestMethod]
        public void MustBeFalseWhenHourIsHigherThanPossible()
        {
            Validate result = validate.ValidateDatetimeString("14/12/1982 24:02");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenHourIsInvalid()
        {
            Validate result = validate.ValidateDatetimeString("14/12/1982 x4:02");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenHourIsInvalid_2()
        {
            Validate result = validate.ValidateDatetimeString("14/12/1982 1x:02");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenHourIsInvalid_3()
        {
            Validate result = validate.ValidateDatetimeString("14/12/1982 14!02");
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void MustBeFalseWhenHourIsInvalid_4()
        {
            Validate result = validate.ValidateDatetimeString("14/12/1982 -14:02");
            Assert.IsFalse(result.IsValid);
        }
        ///End


        //Begin -> validing MINUTES possibilities        
        [TestMethod]
        public void MustBeFalseWhenMinuteIsHigherThanPossible()
        {
            Validate result = validate.ValidateDatetimeString("23/07/2006 12:60");
            Assert.IsFalse(result.IsValid);
        }


        [TestMethod]
        public void MustBeFalseWhenMinuteIsInvalid()
        {
            Validate result = validate.ValidateDatetimeString("23/07/2006 12:-38");
            Assert.IsFalse(result.IsValid);
        }
        ///End


        //Begin -> Validing Adding Hours
        [TestMethod]
        public void AddHourShouldByEqualsTrue()
        {
            //Output 04/03/2010 17:00            
            datetime = DateTime.Parse("04/03/2010 17:00");
            string microsoft_result = datetime.AddHours(2).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddHours("04/03/2010 17:00", 2);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void AddHourToChangeDay()
        {
            //Output 02/03/2017 22:30            
            datetime = DateTime.Parse("01/03/2017 22:30");
            string microsoft_result = datetime.AddHours(24).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddHours("01/03/2017 22:30", 24);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void AddHourToChangeMonth()
        {
            //Output 02/03/2005 06:15           
            datetime = DateTime.Parse("28/02/2005 06:15");
            string microsoft_result = datetime.AddHours(48).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddHours("28/02/2005 06:15", 48);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void AddHourToChangeYear()
        {
            //Output 01/01/2010 21:48
            datetime = DateTime.Parse("22/12/2009 21:48");
            string microsoft_result = datetime.AddHours(240).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddHours("22/12/2009 21:48", 240);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }
        //End



        //Begin -> Validing Adding Minutes
        [TestMethod]
        public void AddMinuteShouldByEqualsTrue()
        {
            //Output 04/03/2010 17:02           
            datetime = DateTime.Parse("04/03/2010 17:00");
            string microsoft_result = datetime.AddMinutes(2).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddMinutes("04/03/2010 17:00", 2);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void AddMinutesToChangeHour()
        {
            //Output 02/03/2017 00:15
            datetime = DateTime.Parse("01/03/2017 23:00");
            string microsoft_result = datetime.AddMinutes(75).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddMinutes("01/03/2017 23:00", 75);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void AddMinutesToChangeMonth()
        {
            //Output 01/03/2005 00:30           
            datetime = DateTime.Parse("28/02/2005 22:15");
            string microsoft_result = datetime.AddMinutes(135).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddMinutes("28/02/2005 22:15", 135);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void AddMinutesToChangeSomeDays()
        {
            ////Output 05/03/2005 19:46          
            datetime = DateTime.Parse("28/02/2005 19:30");
            string microsoft_result = datetime.AddMinutes(7216).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.AddMinutes("28/02/2005 19:30", 7216);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }
        //End


        //Begin -> Validing Removing Hours
        [TestMethod]
        public void RemoveHourShouldByEqualsTrue()
        {
            //Output 04/03/2010 16:02           
            datetime = DateTime.Parse("04/03/2010 17:00");
            string microsoft_result = datetime.AddHours(-2).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractHours("04/03/2010 17:00", 2);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void RemoveHourToChangeDayAndMonth()
        {
            //Output 28/02/2010 17:00           
            datetime = DateTime.Parse("01/03/2010 17:00");
            string microsoft_result = datetime.AddHours(-24).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractHours("01/03/2010 17:00", 24);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void RemoveHourToChangeYear()
        {
            //Output 31/12/2017 17:00           
            datetime = DateTime.Parse("02/01/2018 17:00");
            string microsoft_result = datetime.AddHours(-48).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractHours("02/01/2018 17:00", 48);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void RemoveHourToChangeSomeDays()
        {
            //Output 21/12/2017 17:00
            datetime = DateTime.Parse("02/01/2018 17:00");
            string microsoft_result = datetime.AddHours(-288).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractHours("02/01/2018 17:00", 288);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }
        //End



        //Begin -> Validing Removing Minutes
        [TestMethod]
        public void RemoveMinutesShouldByEqualsTrue()
        {
            //Output 04/03/2010 16:12
            datetime = DateTime.Parse("04/03/2010 17:00");
            string microsoft_result = datetime.AddMinutes(-48).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractMinutes("04/03/2010 17:00", 48);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void RemoveMinutesToChangeDayAndMonth()
        {
            //Output 04/03/2010 16:12
            datetime = DateTime.Parse("04/03/2010 17:00");
            string microsoft_result = datetime.AddMinutes(-48).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractMinutes("04/03/2010 17:00", 48);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void RemoveMinutesToChangeYear()
        {
            //Output 30/12/2000 01:34
            datetime = DateTime.Parse("04/01/2001 01:34");
            string microsoft_result = datetime.AddMinutes(-7200).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractMinutes("04/01/2001 01:34", 7200);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void RemoveMinutesToChangeSomeDays()
        {
            //Output 30/12/2000 01:34
            datetime = DateTime.Parse("04/01/2001 01:34");
            string microsoft_result = datetime.AddMinutes(-12326).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractMinutes("04/01/2001 01:34", 12326);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }

        [TestMethod]
        public void RemoveMinutesToChangeToAnotherMonth()
        {
            //Output 04/12/2000 15:34
            datetime = DateTime.Parse("04/01/2001 01:34");
            string microsoft_result = datetime.AddMinutes(-43800).ToString("dd/MM/yyyy HH:mm");
            string new_datetime = my_datetime.SubtractMinutes("04/01/2001 01:34", 43800);
            string my_result = my_datetime.Format(new_datetime, 1);

            Assert.AreEqual(microsoft_result, my_result);
        }
        //End

    }
}
