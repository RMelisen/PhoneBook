using Spectre.Console;
using PhoneBook.UI.Commons;
using PhoneBook.Commons.Enums;

namespace PhoneBook.UI
{
    internal class MainUI
    {
        internal static void WelcomeUser()
        {
            AnsiConsole.MarkupLine($"[{UIStyles.NEUTRAL_INDICATOR_COLOR} Bold]Welcome to PhoneBook console app ![/]\n");
            AnsiConsole.MarkupLine("");

            PressKeyToContinue();
        }

        internal static void ShowMainMenu()
        {
            bool shouldLoopMainMenu = true;
            MainMenuOption mainMenuChoice;

            while (shouldLoopMainMenu)
            {
                mainMenuChoice = AnsiConsole.Prompt(new SelectionPrompt<MainMenuOption>().Title($"What do you want to do ?").AddChoices(Enum.GetValues<MainMenuOption>()));

                switch (mainMenuChoice)
                {
                    case MainMenuOption.AddContact:
                        AddContact();
                        break;
                    case MainMenuOption.ShowContacts:
                        ShowContacts();
                        break;
                    case MainMenuOption.UpdateContact:
                        UpdateContact();
                        break;
                    case MainMenuOption.DeleteContact:
                        DeleteContact();
                        break;
                    case MainMenuOption.Quit:
                        shouldLoopMainMenu = false;
                        break;
                }
                AnsiConsole.Clear();
            }
            AnsiConsole.MarkupLine($"[Bold]See you soon ![/]");
        }


        #region Utils

        internal static void PressKeyToContinue()
        {
            AnsiConsole.MarkupLine($"Press any key to [{UIStyles.NEUTRAL_INDICATOR_COLOR}]continue[/]...");
            Console.ReadKey();
            AnsiConsole.Clear();
        }

        #endregion
    }
}
