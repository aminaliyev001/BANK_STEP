using clientSpace;
using cardNameSpace;
using System.Data.Common;
namespace bankSpace;
public class Bank
{   private string name_bank;
    private string NameOfBank { get => name_bank; set {if(value.Length>=3) name_bank = value;else throw new Exception("Min 3 simvol");} }
    public List<Client> Clients { get; set; }
    public Bank(string name)
    {
        NameOfBank = name;
        Clients = new List<Client>();
    }
    public void AddClient(Client client)
    {
        Clients.Add(client);
    }
    public double ShowCardBalance(Card card)
    {
        return card.Balance;
    }
    public override string ToString()
    {
        return $"Bankin adi: {NameOfBank}, Klientlerin sayi: {Clients.Count}";
    }
    public void DisplayClients()
    {
        Console.WriteLine($"Klientler {NameOfBank}:");
        foreach (var client in Clients)
        {
            Console.WriteLine($"Ad: {client.Name + " " + client.Surname}, Kart nomresi: {client.BankAccount.CardNumber}, Balance: {client.BankAccount.Balance}$");
        }
    }
    public Client findClient(string pin) {
        foreach(var client in Clients) {
            if(client.BankAccount.Pin == Convert.ToInt32(pin))
                return client;
        }
        throw new Exception("Client tapilmadi...");
    }
    public Client checkClient(string card_number) {
        foreach(var client in Clients) {
            if(client.BankAccount.CardNumber == card_number)
                return client;
        }
        throw new Exception("Bele bir hesab tapilmadi");
    }
}