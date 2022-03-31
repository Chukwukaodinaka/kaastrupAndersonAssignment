using System;
using NUnit.Framework;
using SalaryHours;

namespace KaastrupSalaryTest
{
    public class FacadeTests
    {
       private IFacade facade = new Facade(new StateHandler());


        [Test]
        public void Validate_Message_DateLessThanToday()
        {
            DateTime dateTime = new DateTime(2020,12,3);
            String message =facade.GenerateSalaryMessage(dateTime);
            Assert.AreEqual(message,"none for you");
        }
        
        [Test]
        public void Validate_Message_DateGreaterThanToday()
        {
            DateTime dateTime = new DateTime(2022,12,3);
            String message =facade.GenerateSalaryMessage(dateTime);
            
            Assert.AreEqual(message,"none for you");
        }

        [Test]
        public void Validate_Message_FirstTimeOfDay()
        {
            DateTime dateTime = DateTime.Today;
            String message =facade.GenerateSalaryMessage(dateTime);
            Assert.AreNotEqual(message,"none for you");
        }
        
        [Test]
        public void Validate_Message_ASecondBefore()
        {
            DateTime now = DateTime.Now;
            DateTime dt1 = now.AddSeconds(-1);
            
            String message =facade.GenerateSalaryMessage(dt1);
            Assert.AreNotEqual(message,"none for you");
        }
        
        [Test]
        public void Check_Salary_WhenMaxNumber()
        {
            double workHours = 1.7976931348623157E+308;
            
            double TotSalary = facade.CalculateSalary(workHours,false);
            
            Assert.AreEqual(true,Double.IsInfinity(TotSalary));
        }
        
        [Test]
        public void Check_Salary_WhenIsWeekend()
        {
            double workHours = 9;
            
            double TotSalary = facade.CalculateSalary(workHours,false);
            
            Assert.AreEqual(1500,TotSalary);
        }
        
        [Test]
        public void Check_Salary_WhenIsNotWeekend()
        {
            double workHours = 9;
            
            double TotSalary = facade.CalculateSalary(workHours,true);
            
            Assert.AreEqual(2800,TotSalary);
        }
        
        [Test]
        public void Check_Salary_WhenIsGreaterThan3()
        {
            double workHours = 4;
            
            double TotSalary = facade.CalculateSalary(workHours,false);
            
            Assert.AreEqual(650,TotSalary);
        }
        
        [Test]
        public void Check_Salary_WhenIsNotGreaterThan3()
        {
            double workHours = 3;
            
            double TotSalary = facade.CalculateSalary(workHours,false);
            
            Assert.AreEqual(390,TotSalary);
        }
        
        [Test]
        public void Check_Salary_WhenTotalWorkHourIsGreaterThan7()
        {
            double workHours = 8;
            
            double TotSalary = facade.CalculateSalary(workHours,false);
            
            Assert.AreEqual(1370,TotSalary);
        }
        
        [Test]
        public void Check_Salary_WhenTotalWorkHourIsNotGreaterThan7()
        {
            double workHours = 6;
            
            double TotSalary = facade.CalculateSalary(workHours,false);
            
            Assert.AreEqual(910,TotSalary);
        }
    }
}