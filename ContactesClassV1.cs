  Console.WriteLine("Welcome to my Contact List");

bool running = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

while (running)
{
    Console.WriteLine(@"1. Add Contact   2. View Contacts   3. Search Contacts   4. Modify Contact   5. Delete Contact   6. Exit");
    Console.WriteLine("Enter the number of the option you want:");

    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 2:
            Console.WriteLine($"Name           Lastname          Address           Phone          Email          Age          Best Friend?");
            Console.WriteLine($"____________________________________________________________________________________________________________________");

            foreach (var id in ids)
            {
                string bf = bestFriends[id] ? "Yes" : "No";

                Console.WriteLine($"{names[id]}        {lastnames[id]}        {addresses[id]}        {telephones[id]}          {emails[id]}         {ages[id]}         {bf}");
            }
            break;

        case 3:
            SearchContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 4:
            ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 5:
            DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            break;

        case 6:
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}



static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                       Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                       Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Enter the person's first name:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter the person's last name:");
    string lastname = Console.ReadLine();

    Console.WriteLine("Enter the address:");
    string address = Console.ReadLine();

    Console.WriteLine("Enter the phone number:");
    string phone = Console.ReadLine();

    Console.WriteLine("Enter the email:");
    string email = Console.ReadLine();

    Console.WriteLine("Enter the age:");
    int age = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Is this person a best friend? 1 = Yes, 2 = No");
    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    int id = ids.Count + 1;

    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);

    Console.WriteLine("Contact added successfully.");
}

static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                          Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                          Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Type a name, lastname or phone number to search:");
    string search = Console.ReadLine().ToLower();

    bool found = false;

    foreach (var id in ids)
    {
        if (names[id].ToLower().Contains(search) ||
            lastnames[id].ToLower().Contains(search) ||
            telephones[id].Contains(search))
        {
            found = true;

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine($"ID: {id}");
            Console.WriteLine($"Name: {names[id]}");
            Console.WriteLine($"Lastname: {lastnames[id]}");
            Console.WriteLine($"Address: {addresses[id]}");
            Console.WriteLine($"Phone: {telephones[id]}");
            Console.WriteLine($"Email: {emails[id]}");
            Console.WriteLine($"Age: {ages[id]}");
            Console.WriteLine($"Best Friend: {(bestFriends[id] ? "Yes" : "No")}");
            Console.WriteLine("------------------------------------------------------");
        }
    }

    if (!found)
    {
        Console.WriteLine("No contacts found.");
    }
}

static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                          Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                          Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Enter the ID of the contact to modify:");
    int id = Convert.ToInt32(Console.ReadLine());

    if (!ids.Contains(id))
    {
        Console.WriteLine("This ID does not exist.");
        return;
    }

    Console.WriteLine("New name (press Enter to keep the same):");
    string newName = Console.ReadLine();
    if (newName != "") names[id] = newName;

    Console.WriteLine("New lastname:");
    string newLast = Console.ReadLine();
    if (newLast != "") lastnames[id] = newLast;

    Console.WriteLine("New address:");
    string newAddress = Console.ReadLine();
    if (newAddress != "") addresses[id] = newAddress;

    Console.WriteLine("New phone:");
    string newPhone = Console.ReadLine();
    if (newPhone != "") telephones[id] = newPhone;

    Console.WriteLine("New email:");
    string newEmail = Console.ReadLine();
    if (newEmail != "") emails[id] = newEmail;

    Console.WriteLine("New age (press Enter to skip):");
    string newAge = Console.ReadLine();
    if (newAge != "") ages[id] = Convert.ToInt32(newAge);

    Console.WriteLine("Is this a best friend? 1 = Yes, 2 = No (press Enter to skip):");
    string bf = Console.ReadLine();
    if (bf != "") bestFriends[id] = Convert.ToInt32(bf) == 1;

    Console.WriteLine("Contact updated successfully.");
}

static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                          Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                          Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Enter the ID of the contact you want to delete:");
    int id = Convert.ToInt32(Console.ReadLine());

    if (!ids.Contains(id))
    {
        Console.WriteLine("This ID does not exist.");
        return;
    }

    ids.Remove(id);
    names.Remove(id);
    lastnames.Remove(id);
    addresses.Remove(id);
    telephones.Remove(id);
    emails.Remove(id);
    ages.Remove(id);
    bestFriends.Remove(id);

    Console.WriteLine("Contact deleted successfully.");
}
