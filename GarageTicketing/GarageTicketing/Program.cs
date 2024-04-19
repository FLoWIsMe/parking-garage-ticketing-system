using GoodsAuctionSystem.Controller;

namespace GoodsAuctionSystem
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