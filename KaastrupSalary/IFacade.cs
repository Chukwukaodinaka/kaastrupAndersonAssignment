namespace SalaryHours
{
    public interface IFacade 
    { 
        string GenerateSalaryMessage(System.DateTime startedWork);
        double CalculateSalary(double workHours, bool isWeekend);
    }
}