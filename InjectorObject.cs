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
            exploitModule.ExecuteScript(@"while wait() do 
                if _G.GayAPIScreen then return end; --Lovely name by the EE developers.
                local allowedGUIs = {
                    ['CoreScriptLocalization'] = true,
                    ['RobloxGui'] = true,
                    ['RobloxPromptGui'] = true,
                    ['PurchasePromptApp'] = true,
                    ['RobloxLoadingGui'] = true,
                    ['RobloxNetworkPauseNotification'] = true,
                    ['DevConsoleMaster'] = true,
                    ['Chat'] = true,
                    ['BubbleChat'] = true
                }
                for k,v in pairs(game:GetService('CoreGui'):GetChildren()) do 
                    if not allowedGUIs[v.Name] then 
                        v:Destroy()
                    end 
                end 
            end");
            await Task.Delay(2000);
            exploitModule.ExecuteScript("_G.GayAPIScreen = true");
        }
    }
}
