using System;
using System.Collections.Generic;

class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Item(int id, string name, double price, int quantity)
    {
        ID = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {ID}, Name: {Name}, Price: {Price:C}, Quantity: {Quantity}");
    }
}

class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void DisplayAllItems()
    {
        Console.WriteLine("All items:");
        foreach (var item in items)
        {
            item.Display();
        }
    }

    public Item FindItemByID(int id)
    {
        return items.Find(item => item.ID == id);
    }

    public void UpdateItem(int id, string name, double price, int quantity)
    {
        Item itemToUpdate = FindItemByID(id);
        if (itemToUpdate != null)
        {
            itemToUpdate.Name = name;
            itemToUpdate.Price = price;
            itemToUpdate.Quantity = quantity;
            Console.WriteLine("Item updated successfully.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }

    public void DeleteItem(int id)
    {
        Item itemToDelete = FindItemByID(id);
        if (itemToDelete != null)
        {
            items.Remove(itemToDelete);
            Console.WriteLine("Item deleted successfully.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. Display all items");
            Console.WriteLine("3. Find item by ID");
            Console.WriteLine("4. Update item");
            Console.WriteLine("5. Delete item");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("Enter Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    inventory.AddItem(new Item(id, name, price, quantity));
                    Console.WriteLine("Item added successfully.");
                    break;
                case 2:
                    inventory.DisplayAllItems();
                    break;
                case 3:
                    Console.Write("Enter ID to find: ");
                    int findId = int.Parse(Console.ReadLine());
                    Item foundItem = inventory.FindItemByID(findId);
                    if (foundItem != null)
                    {
                        foundItem.Display();
                    }
                    else
                    {
                        Console.WriteLine("Item not found.");
                    }
                    break;
                case 4:
                    Console.Write("Enter ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter new Price: ");
                    double newPrice = double.Parse(Console.ReadLine());
                    Console.Write("Enter new Quantity: ");
                    int newQuantity = int.Parse(Console.ReadLine());
                    inventory.UpdateItem(updateId, newName, newPrice, newQuantity);
                    break;
                case 5:
                    Console.Write("Enter ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    inventory.DeleteItem(deleteId);
                    break;
                case 6:
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }
}



