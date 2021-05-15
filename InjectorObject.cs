using EasyExploits;
using System;
using System.Threading.Tasks;
using System.IO;

namespace Injector
{
    class InjectorObject
    {
        public static void Main(string[] args = null)
        {
            try
            {
                if (args.Length == 0 || args == null)
                    throw new Exception("No argument specified");
                switch (args?[0])
                {
                    case "inject":
                        Inject();
                        System.Threading.Thread.Sleep(5000+2000);
                        break;
                    case "run":
                        Module exploitModule = new Module();
                        exploitModule.ExecuteScript(args[1]);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("error_injector.txt", $"[{DateTime.Now}]{Environment.NewLine}{ex}{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}");
                throw;
            }
        }

        public static async void Inject()
        {
            Module exploitModule = new Module();
            exploitModule.LaunchExploit();
            // Surpress the on-screen loading animation
            await Task.Delay(5000);
            exploitModule.ExecuteScript("while wait()do if _G.GayAPIScreen then return end;for a,b in pairs(game:GetService('CoreGui'):GetChildren())do if b.Name=='CoreScriptLocalization'or b.Name=='RobloxGui'or b.Name=='RobloxPromptGui'or b.Name=='PurchasePromptApp'or b.Name=='RobloxLoadingGui'or b.Name=='RobloxNetworkPauseNotification'or b.Name=='DevConsoleMaster'or b.Name=='Chat'or b.Name=='BubbleChat'then else b:Destroy()end end end");
            await Task.Delay(2000);
            exploitModule.ExecuteScript("_G.GayAPIScreen = true");
        }
    }
}
