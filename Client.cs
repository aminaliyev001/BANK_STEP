using System.Data.Common;
using cardNameSpace;
namespace clientSpace;

public class Emeliyyat {
    public string ID {get;set;}
    public string type {get;set;}
    private double Mebleg {get;set;}
    public DateTime tarix {get;set;}
    public override string ToString()
    {
        return $"Emeliyyat nomresi: {ID}\nEmeliyyat novu: {type}\nMebleg: {Mebleg}\nTarix: {tarix.ToString("dd-MM-yy HH:mm:ss")}";
    }
    public void Display() {
        Console.WriteLine(ToString());
    }

    public Emeliyyat(string type_, double mebleg_) {
        ID = Guid.NewGuid().ToString();
        type = type_;
        Mebleg = mebleg_;
        tarix = DateTime.Now;
    }
}
public class Client
{
    public List<Emeliyyat> emeliyyatlar {get;set;}
    public string Id { get; set; }
    private string name ;
    public string Name{get { return name; }set{if (value.Length >= 3)name = value;else throw new ArgumentException("Ad minimum 3 simvoldan ibaret olmalidir");}}
    private string surname ;
    public string Surname{get { return surname; }set{if (value.Length >= 3)surname = value;else throw new Exception("Soyad minimum 3 simvoldan ibaret olmalidir");}}
    private int age;
    public int Age { set {if(value >= 18) age = value; else throw new Exception("Min 18 yas olmalidir");} }
    public Card BankAccount { get; set; }
    public Client(string name, string surname, int age, Card bankAccount)
    {
        emeliyyatlar = new List<Emeliyyat>();
        Id = Guid.NewGuid().ToString();
        Name = name;
        Surname = surname;
        Age = age;
        BankAccount = bankAccount;
    }
    public void MoneyOut(double value) {
        if(BankAccount.Balance >= value) {
            BankAccount.Balance -= value;
            return;
        }
        throw new Exception("Balansda yeterli qeder mebleg yoxdur");
    }
    public void MoneyIN(double value) {
        BankAccount.Balance += value;
        return;
    }
    public override string ToString()
    {
        return $"Id: {Id}\nFull name: {name + " "+ surname}\nYas: {age}\nKart nomresi: {BankAccount.CardNumber}";
    }
    public void Display() {
        Console.WriteLine(ToString());
    }
    public void displayEmeliyyatlar() {
        if(emeliyyatlar != null) {
        foreach(var em in emeliyyatlar) {
            em.Display();
        }
        } else Console.WriteLine("Bosdur");
    }
    public void addEmeliyyat(string type, double mebleg, bool send = true) {
        if(send == true)
            emeliyyatlar.Add(new Emeliyyat(type,-mebleg));
        else  emeliyyatlar.Add(new Emeliyyat(type,mebleg));
        Console.WriteLine();
    }
}