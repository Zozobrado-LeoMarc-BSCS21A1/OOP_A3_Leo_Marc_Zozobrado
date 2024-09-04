using System;
using System.Collections.Generic;

enum PetKind
{
    Dog,
    Cat,
    Lizard,
    Bird
}

enum Gender
{
    Male,
    Female
}

interface IPet
{
    PetKind Kind { get; set; }
    string Name { get; set; }
    Gender Gender { get; set; }
    string Owner { get; set; }
    void DisplayInfo();
}

class Dog : IPet
{
    public PetKind Kind { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Owner { get; set; }
    public string Breed { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Kind} - {Name} ({Gender}), Owner: {Owner}, Breed: {Breed}");
    }
}

class Cat : IPet
{
    public PetKind Kind { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Owner { get; set; }
    public bool IsLonghaired { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Kind} - {Name} ({Gender}), Owner: {Owner}, Hair Type: {(IsLonghaired ? "Longhaired" : "Shorthaired")}");
    }
}

class Lizard : IPet
{
    public PetKind Kind { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Owner { get; set; }
    public bool CanFly { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Kind} - {Name} ({Gender}), Owner: {Owner}, Can fly: {(CanFly ? "Yes" : "No")}");
        Console.WriteLine("Has 4 legs, Is cold-blooded");
    }
}

class Bird : IPet
{
    public PetKind Kind { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Owner { get; set; }
    public bool CanFly { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Kind} - {Name} ({Gender}), Owner: {Owner}, Can fly: {(CanFly ? "Yes" : "No")}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IPet> pets = new List<IPet>();
        string addMorePets = null;

        Console.WriteLine("Welcome to the Pet Inventory!");

        do
        {
            Console.WriteLine("\nEnter details for the new pet:");
            Console.Write("Kind (Dog, Cat, Lizard, Bird): ");
            string kindInput = Console.ReadLine()?.Trim();
            PetKind kind;
            if (!Enum.TryParse(kindInput, true, out kind))
            {
                Console.WriteLine("Invalid kind of pet.");
                continue;
            }

            Console.Write("Name: ");
            string name = Console.ReadLine()?.Trim();
            Console.Write("Gender (M/F): ");
            string genderInput = Console.ReadLine()?.Trim().ToUpper();
            Gender gender;
            if (genderInput == "M")
            {
                gender = Gender.Male;
            }
            else if (genderInput == "F")
            {
                gender = Gender.Female;
            }
            else
            {
                Console.WriteLine("Invalid gender input.");
                continue;
            }
            Console.Write("Owner: ");
            string owner = Console.ReadLine()?.Trim();

            IPet pet = null;

            switch (kind)
            {
                case PetKind.Dog:
                    Dog dog = new Dog();
                    dog.Kind = PetKind.Dog;
                    dog.Name = name;
                    dog.Gender = gender;
                    dog.Owner = owner;
                    Console.Write("Breed: ");
                    dog.Breed = Console.ReadLine()?.Trim();
                    pet = dog;
                    break;

                case PetKind.Cat:
                    Cat cat = new Cat();
                    cat.Kind = PetKind.Cat;
                    cat.Name = name;
                    cat.Gender = gender;
                    cat.Owner = owner;
                    Console.Write("Is Longhaired? (y/n): ");
                    cat.IsLonghaired = Console.ReadLine()?.Trim().ToLower() == "y";
                    pet = cat;
                    break;

                case PetKind.Lizard:
                    Lizard lizard = new Lizard();
                    lizard.Kind = PetKind.Lizard;
                    lizard.Name = name;
                    lizard.Gender = gender;
                    lizard.Owner = owner;
                    Console.Write("Can Fly? (y/n): ");
                    lizard.CanFly = Console.ReadLine()?.Trim().ToLower() == "y";
                    pet = lizard;
                    break;

                case PetKind.Bird:
                    Bird bird = new Bird();
                    bird.Kind = PetKind.Bird;
                    bird.Name = name;
                    bird.Gender = gender;
                    bird.Owner = owner;
                    Console.Write("Can Fly? (y/n): ");
                    bird.CanFly = Console.ReadLine()?.Trim().ToLower() == "y";
                    pet = bird;
                    break;

                default:
                    Console.WriteLine("Invalid kind of pet.");
                    continue;
            }

            pets.Add(pet);

            Console.Write("Do you want to add another pet? (y/n): ");
            addMorePets = Console.ReadLine()?.Trim().ToLower();
        } while (addMorePets == "y");

        Console.Write("\nWhich type of animal would you like to list? (Dog, Cat, Lizard, Bird, or 'All'): ");
        string listTypeInput = Console.ReadLine()?.Trim().ToLower();

        Console.WriteLine("\nAll pets in the inventory:");
        foreach (var p in pets)
        {
            if (listTypeInput == "all" || p.Kind.ToString().ToLower() == listTypeInput)
            {
                p.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}