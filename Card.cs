namespace cardNameSpace;
public class Card {
    private static Random _random = new Random();
    private static string cardNumberGenerator() {
        int randomNumber = _random.Next(10000000, 99999999); 
        return "40985844" + randomNumber.ToString();
    }
    private static int CvvGenerator()
        {
            return _random.Next(100, 1000);
        }
    private string bank_name;
    public string bankName {get=>bank_name; set {if(value.Length>2) bank_name = value;else throw new Exception("Bankin adi minimum 3 simvoldan ibaret olmalidir");} }
    private string full_name;
    public string fullName {get => full_name; set{if(value.Length>7) full_name = value;else throw new Exception("Full name minimum 3 simvoldan ibaret olmalidir");}}
    public  string CardNumber {get;set;}
    private int pin;
    public int Pin {get => pin; set {if((value / 1000) >= 1 && (value / 1000) < 10) pin = value; else throw new Exception("Pin 4 reqemli olmalidir"); }}
    public int Cvc {get;set;}
    public double Balance {get;set;}
    public DateTime ExpiryDate { get; set; } 
    public Card(string bank_n, string fullN, int pin) {
        bankName = bank_n;
        fullName = fullN;
        Pin = pin;
        CardNumber = cardNumberGenerator();
        Cvc = CvvGenerator();
        Balance = 1500;
        ExpiryDate = DateTime.Now.AddYears(3);
    }
    public override string ToString()
    {
        return $"Kart sahibinin adi: {full_name}\nBankin adi: {bank_name}\nKartin nomresi: {CardNumber}\nPin: {Pin}\nCVC:{Cvc}\nBitme tarixi: {ExpiryDate.ToString("dd-MM-yyyy")}\nBalance: {Balance}$";
    }
    public void Display() {
        Console.WriteLine(ToString());
    }
};