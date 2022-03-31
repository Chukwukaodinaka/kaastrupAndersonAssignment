namespace SalaryHours
{
    
    public interface IStateHandler 
    { 
        void AddToDatabase(double workedHours, double salary);
    }
    public class StateHandler : IStateHandler
    {
        public async void AddToDatabase(double workedHours,double salary)
        {
            await using var ctx = new SalaryContext();
            await ctx.Database.EnsureCreatedAsync();
            ctx.salaries.Add(new() { TotalHour = workedHours,TotalSalary = salary});
            await ctx.SaveChangesAsync();
        }
    }
}