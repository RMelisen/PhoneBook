using System.ComponentModel;
using System.Reflection;

namespace PhoneBook.Commons.Enums
{
    internal enum MainMenuOption
    {
        [Description("Add Contact")]
        AddContact,
        [Description("Show Contact List")]
        ShowContacts,
        [Description("Update Contact")]
        UpdateContact,
        [Description("Delete Contact")]
        DeleteContact,
        Quit
    }

    #region Utils

    internal static class EnumUtils
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return value.ToString();
        }
    }

    #endregion
}
