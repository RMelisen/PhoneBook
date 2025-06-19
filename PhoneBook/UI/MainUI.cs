using Spectre.Console;
using PhoneBook.UI.Commons;
using PhoneBook.Commons.Enums;
using PhoneBook.Commons.Classes;

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

        internal static void AddContact()
        {

        }

        internal static void ShowContacts()
        {
            List<Contact> contactList = GetAllContacts();

            Table contactTable = new Table();
            contactTable.Border(TableBorder.Rounded);

            contactTable.Title($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}Bold]Contacts: [/]");

            contactTable.AddColumn($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Name[/]");
            contactTable.AddColumn($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Email[/]");
            contactTable.AddColumn($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Phone Number[/]");
            contactTable.AddColumn($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}]Address[/]");

            foreach (Contact contact in contactList)
            {
                contactTable.AddRow(
                    contact.Name,
                    contact.Email,
                    contact.PhoneNumber,
                    contact.Address
                );
            }

            AnsiConsole.MarkupLine($"[{UIStyles.NEUTRAL_INDICATOR_COLOR}Bold]Contacts: [/]");
            AnsiConsole.Write(contactTable);

            PressKeyToContinue();
        }

        internal static void UpdateContact()
        {

        }

        internal static void DeleteContact()
        {

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
