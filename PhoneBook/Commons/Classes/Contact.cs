namespace PhoneBook.Commons.Classes
{
    internal class Contact
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        #endregion

        #region Constructors

        public Contact(string name, string phoneNumber, string email, string address)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public Contact(int id, string name, string phoneNumber, string email, string address)
            : this(name, phoneNumber, email, address)
        {
            Id = id;
        }

        #endregion

        public override string ToString()
        {
            return $"{Name} - {PhoneNumber} - {Email} - {Address}";
        }
    }
}
