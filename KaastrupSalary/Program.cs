namespace SalaryHours
{
    class Program 
    {
        static void Main(string[] args)
        {
            IStateHandler stateHandler = new StateHandler();
            IFacade facade = new Facade(stateHandler) ;
            Reader reader = new Reader();

            while (true)
            {
                reader.ManageWorkerInput(facade);
            }
        } 
    } 

}