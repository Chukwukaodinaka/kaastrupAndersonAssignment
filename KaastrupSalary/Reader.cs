using System;

namespace SalaryHours
{
    public class Reader
    {
        public void ManageWorkerInput(IFacade facade)
            {
                Console.WriteLine("Hello Dear Developer!"); 
                Console.WriteLine($"Please tell when you started working Format 'Month Day Hour Minutes' fx {DateTime.Now.Month} {DateTime.Now.Day} {DateTime.Now.Hour} {DateTime.Now.Minute} "); 
                var input = Console.ReadLine(); 
                var parts = input.Split(' '); 
                try 
                { 
                    var startedWorking = new DateTime(System.DateTime.Now.Year,
                        int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), 0); 
                    string messageToDeveloper = 
                        facade.GenerateSalaryMessage(startedWorking); 
                    Console.WriteLine(messageToDeveloper); 
                } 
                catch (Exception) 
                { 
                    Console.WriteLine($"{input} is not an accepted format"); 
                }
            }
        }
    }