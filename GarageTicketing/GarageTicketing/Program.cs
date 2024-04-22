using GarageTicketing.Controller;

namespace GarageTicketing
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            StartController.Initialize(); 
        }
    }
}