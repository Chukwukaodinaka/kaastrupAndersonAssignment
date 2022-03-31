using System;
using System.Runtime.CompilerServices;

namespace SalaryHours
{
    class Program 
    {
        static void Main(string[] args)
        {
            IFacade facade = new Facade() ;
            Reader reader = new Reader();

            while (true)
            {
                reader.ManageWorkerInput(facade);
            }
        } 
    } 

}