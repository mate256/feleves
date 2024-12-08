using KK12FG_HSZF_2024251.Application;
using KK12FG_HSZF_2024251.Model;
using KK12FG_HSZF_2024251.Persistence.MsSql;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using Microsoft.Extensions.DependencyInjection.Extensions;

#region IoC Container
//IoC container
var host = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        //add services
        services.AddScoped<PetRegistrationDbContext>();
        services.AddSingleton<IAnimalDataProvider, AnimalDataProvider>();
        services.AddSingleton<IAnimalService, AnimalService>();
        services.AddSingleton<IActivityDataProvider, ActivityDataProvider>();
        services.AddSingleton<IActivityService, ActivityService>();
        services.AddSingleton<IFoodDataProvider, FoodDataProvider>();
        services.AddSingleton<IFoodService, FoodService>();
    })
    .Build();
host.Start();
#endregion
//Call FilmService
using IServiceScope serviceScope = host.Services.CreateScope();
IAnimalService animalService = host.Services.GetRequiredService<IAnimalService>();
IActivityService activityService = host.Services.GetRequiredService<IActivityService>();
IFoodService foodService = host.Services.GetRequiredService<IFoodService>();
Console.Clear();
//testdata

var json = new Json(animalService, activityService, foodService);
json.AddDataFromJson();
/* Ha beolvasós kell
Console.WriteLine("Json file name: (Press Enter For Default File)");
var fileName = Console.ReadLine();
if (!string.IsNullOrEmpty(fileName))
{
    var path = @$"{fileName}.json";
    json.AddDataFromJson(path);
}
else
    json.AddDataFromJson();
*/

void FoMenuKiir()
{
    for (int i = 0; i < 6; i++) Console.Write("---");
    Console.WriteLine();
    Console.WriteLine("Válassz műveletet: ");
    Console.WriteLine("1. Listázás");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("2. létrehozás");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("3. Frissítés");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("4. Törlés");
    Console.ResetColor();
    for (int i = 0; i < 6; i++) Console.Write("---");
    Console.WriteLine();
    Console.Write("Művelet: ");
    Console.WriteLine();
    for (int i = 0; i < 6; i++) Console.Write("---");
    Console.WriteLine();
}

FoMenuKiir();


void MenuSwitch(IAnimalService animalService)
{
    ConsoleKey key = Console.ReadKey(intercept: true).Key;

    switch (key)
    {

        case ConsoleKey.D1:
            Kiir(animalService.GetAnimals());
            break;
        case ConsoleKey.D2:
            AddAnimal();
            break;
        case ConsoleKey.D3:
            break;
        case ConsoleKey.D4:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Melyiket szertnéd törölni?");
            Console.ResetColor();
            break;
        default:
            break;
    }
}
MenuSwitch(animalService);

Console.ReadLine();
static void Kiir(IEnumerable<Animal> animals)
{
    var items = animals.ToList();
    bool exit = false;
    int pageSize = 0;
    int optionKey = 0;
    int currentPage = 1;
    while (!exit)
    {
        Console.Clear();
        for (int i = pageSize; i < pageSize + 10; i++)
        {
            if (i < animals.Count())
                Console.WriteLine(optionKey + ". " + items?[i].Name);
            if (optionKey < 9)
                optionKey++;
            else
                optionKey = 0;
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Oldal: {currentPage}");
        Console.ResetColor();

        var key = Console.ReadKey(intercept: true).Key;
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (pageSize - 10 >= 0)
                {
                    pageSize -= 10;
                    currentPage--;
                }
                break;
            case ConsoleKey.RightArrow:
                if (pageSize + 10 < animals.Count() + animals.Count() % 10)
                {
                    pageSize += 10;
                    currentPage++;
                }
                break;
            case ConsoleKey.D0:
                if (pageSize < items.Count())
                    ShowDetails(items[pageSize]);
                break;
            case ConsoleKey.D1:
                if (pageSize + 1 < items.Count())
                    ShowDetails(items[pageSize + 1]);
                break;
            case ConsoleKey.D2:
                if (pageSize + 2 < items.Count())
                    ShowDetails(items[pageSize + 2]);
                break;
            case ConsoleKey.D3:
                if (pageSize + 3 < items.Count())
                    ShowDetails(items[pageSize + 3]);
                break;
            case ConsoleKey.D4:
                if (pageSize + 4 < items.Count())
                    ShowDetails(items[pageSize + 4]);
                break;
            case ConsoleKey.D5:
                if (pageSize + 5 < items.Count())
                    ShowDetails(items[pageSize + 5]);
                break;
            case ConsoleKey.D6:
                if (pageSize + 6 < items.Count())
                    ShowDetails(items[pageSize + 6]);
                break;
            case ConsoleKey.D7:
                if (pageSize + 7 < items.Count())
                    ShowDetails(items[pageSize + 7]);
                break;
            case ConsoleKey.D8:
                if (pageSize + 8 < items.Count())
                    ShowDetails(items[pageSize + 8]);
                break;
            case ConsoleKey.D9:
                if (pageSize + 9 < items.Count())
                    ShowDetails(items[pageSize + 9]);
                break;
            case ConsoleKey.Escape:
                exit = !exit;
                break;
            default:
                break;
        }
    }
    Console.WriteLine("kileptel");


}

static void ShowDetails(Animal animal)
{
    bool exit = false;
    int pageSize = 0;
    int currentPage = 1;
    while (!exit)
    {
        Console.Clear();
        Console.WriteLine("Name: " + animal.Name);
        Console.WriteLine("Gender: " + animal.Gender);
        Console.WriteLine("Species: " + animal.Species);
        Console.WriteLine("Age: " + animal.Age);
        Console.WriteLine("Activities:");
        Console.WriteLine();
        for (int i = pageSize; i < pageSize + 9; i++)
        {
            if (i < animal.Activities.Count())
                Console.WriteLine(animal.Activities.ToList()[i].Type);
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Oldal: {currentPage}");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Foods:");
        foreach(var food in animal.Foods)
        {
            Console.WriteLine(food.Name);
        }

        var key = Console.ReadKey(intercept: true).Key;
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (pageSize - 10 >= 0)
                {
                    pageSize -= 10;
                    currentPage--;
                }
                break;
            case ConsoleKey.RightArrow:
                if (pageSize + 10 < animal.Activities.Count() + animal.Activities.Count() % 10)
                {
                    pageSize += 10;
                    currentPage++;
                }
                break;
            case ConsoleKey.Escape:
                exit = !exit;
                break;
            default:
                break;
        }
    }
}

void AddAnimal()
{
    Console.WriteLine("Enter animal name:");
    string name = Console.ReadLine();
    Console.WriteLine("Enter animal gender:");
    string gender = Console.ReadLine();
    Console.WriteLine("Enter animal species:");
    string species = Console.ReadLine();
    Console.WriteLine("Enter animal age:");
    string ageString = Console.ReadLine();
    int age;
    while (!int.TryParse(ageString, out age))
    {
        Console.WriteLine("Age has to be a digit!");
        Console.WriteLine("Enter animal age:");
        ageString = Console.ReadLine();
    }


    Animal animal = animalService.AddAnimal(new Animal(name, gender, species, age));

    AddActivity(animal);


    Console.WriteLine("For return press any key");

    ConsoleKey key = Console.ReadKey(intercept: true).Key;
    Console.Clear();
    FoMenuKiir();
    MenuSwitch(animalService);

}

void AddActivity(Animal animal)
{
    Console.WriteLine("Enter Date (2024-10-15):");
    DateTime date = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Enter Type:");
    string type = Console.ReadLine();
    Console.WriteLine("Enter Description:");
    string description = Console.ReadLine();
    Console.WriteLine("Enter Foodname:");
    string foodName = Console.ReadLine();

    int descriptionint;
    while (!int.TryParse(description, out descriptionint))
    {
        Console.WriteLine("description has to be a digit!");
        Console.WriteLine("Enter Description:");
        description = Console.ReadLine();
    }
    //foodService.UpdateFood();
    
    if (type == "feeding")
    {
        if (animal.Foods.Any(a => a.Name == foodName))
        {
            Food updatedFood = animal.Foods.First(f => f.Name == foodName);
            updatedFood.Quantity -= descriptionint;
        }
        else
        {
            animal.Foods.Add(new Food(foodName, descriptionint));
        }
        animalService.UpdateAnimal(animal);

        
    }
    activityService.AddActivity(new Activity(date, type, description, animal.AnimalId));
   

}