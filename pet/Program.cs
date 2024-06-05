using System;

class Program
{
    static void Main(string[] args)
    {
        // Display pet type options
        Console.WriteLine("Please choose a type of pet: ");
        Console.WriteLine("1. Cat");
        Console.WriteLine("2. Dog");
        Console.WriteLine("3. Rabbit");

        // Get the user's choice
        Console.Write("Enter the number corresponding to your choice: ");
        int petChoice = int.Parse(Console.ReadLine());

        // Determine the pet type based on user's choice
        string petType;
        switch (petChoice)
        {
            case 1:
                petType = "cat";
                break;
            case 2:
                petType = "dog";
                break;
            case 3:
                petType = "rabbit";
                break;
            default:
                Console.WriteLine("Invalid choice. Please restart the program and choose a valid option.");
                return;
        }

        // Inform the user of their choice
        Console.WriteLine($"You've chosen a {petType}.");

        // Ask for the pet's name
        Console.Write("What would you like to name your pet? ");
        string petName = Console.ReadLine();

        // Display the welcome message
        Console.WriteLine($"Welcome, {petName}! Let's take good care of {(petType == "cat" || petType == "rabbit" ? "her" : "him")}.");

        Pet pet = new Pet(petName);
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Feed Honey");
            Console.WriteLine("2. Play with Honey");
            Console.WriteLine("3. Let Honey Rest");
            Console.WriteLine("4. Check Honey's Status");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    pet.Feed();
                    break;
                case "2":
                    pet.Play();
                    break;
                case "3":
                    pet.Rest();
                    break;
                case "4":
                    pet.CheckStatus();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select again.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}

class Pet
{
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Health { get; set; }

    public Pet(string name)
    {
        Name = name;
        Hunger = 5; // Hunger level from 1 to 10 (1 is starving, 10 is full)
        Happiness = 5; // Happiness level from 1 to 10 (1 is sad, 10 is happy)
        Health = 5; // Health level from 1 to 10 (1 is very sick, 10 is very healthy)
    }

    public void Feed()
    {
        Hunger = Math.Min(10, Hunger + 2);
        Health = Math.Min(10, Health + 1);
        Console.WriteLine($"{Name} has been fed. Hunger increased, Health slightly increased.");
    }

    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        Hunger = Math.Max(1, Hunger - 1);
        Console.WriteLine($"{Name} has played. Happiness increased, Hunger slightly decreased.");
    }

    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(1, Happiness - 1);
        Console.WriteLine($"{Name} has rested. Health improved, Happiness slightly decreased.");
    }

    public void CheckStatus()
    {
        Console.WriteLine($"\n{Name}'s Status:");
        Console.WriteLine($"Hunger: {Hunger}/10");
        Console.WriteLine($"Happiness: {Happiness}/10");
        Console.WriteLine($"Health: {Health}/10");

        if (Hunger <= 2)
        {
            Console.WriteLine("Warning: Hunger is critically low!");
        }
        if (Hunger >= 9)
        {
            Console.WriteLine("Warning: Hunger is critically high!");
        }
        if (Happiness <= 2)
        {
            Console.WriteLine("Warning: Happiness is critically low!");
        }
        if (Happiness >= 9)
        {
            Console.WriteLine("Warning: Happiness is critically high!");
        }
        if (Health <= 2)
        {
            Console.WriteLine("Warning: Health is critically low!");
        }
        if (Health >= 9)
        {
            Console.WriteLine("Warning: Health is critically high!");
        }
    }
}
