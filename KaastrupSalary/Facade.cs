using System;

namespace SalaryHours
{
    public class Facade : IFacade
    {
        private IStateHandler _handler = new StateHandler();
        public string GenerateSalaryMessage(DateTime startedWork)
        {
            if (startedWork.Date == DateTime.Now.Date && startedWork < DateTime.Now)
            {
                double workedHours = Math.Round((DateTime.Now - startedWork).TotalHours,2);
                bool isWeekend = CheckIfWeekend(startedWork);
                double workedSalary = Math.Round(CalculateSalary(workedHours, isWeekend),2);
                _handler.AddToDatabase(workedHours,workedSalary);
                return "You worked " + workedHours + " hours and salary is " + workedSalary;
            }
            return "none for you";
        }

        public double CalculateSalary(double workHours, bool isWeekend)
        {
            double totalWorkHours = workHours;
            double totalSalary = 0;
            
            if (workHours > 3)
            {
                totalWorkHours ++;
            }
            if (isWeekend)
            {
                totalWorkHours = 2*totalWorkHours;
            }
            if (totalWorkHours > 7)
            {
                //is this if statement correct or is it without weekend bonus hours
                totalSalary += 200;
            }

            totalSalary += totalWorkHours * 130;

            return totalSalary;
        }

         bool CheckIfWeekend(DateTime startWork)
        {
            if (startWork.DayOfWeek.ToString() == "Saturday" || startWork.DayOfWeek.ToString() == "Sunday")
            {
                return true;

            }

            return false;
        }
    }
}