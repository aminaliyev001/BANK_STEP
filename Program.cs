//     4. Kartdan karta kocurme
//       4.1. Bu bolmenin secdiyiniz zaman hansi karta kocurme etmek istediyinizi sorusacaq (PIN i sorusaraq)
//    Eger daxil etdiyiniz PIN yoxdursa o zaman "bu PIN koda aid kart tapilmadi" yazilmalidir. Ve yeniden basa qayitmali ve sizden PIN kod daxil etmeyinizi istemelidir.
using clientSpace;
using cardNameSpace;
using bankSpace;
var card1 = new Card("Uni Bank","Amin Aliyev Elshan",3232);
Console.WriteLine();
Client Amin = new Client("Amin","Aliyev",18,card1);

var card2 = new Card("RabiteBank","Maga Aliyev Kerim",1234);
Console.WriteLine();
Client Maga = new Client("Maga","Aliyev",18,card2);

var card3 = new Card("Kapital Bank","Ali Sariyev Asif",5454);
Console.WriteLine();
Client Ali = new Client("Ali","Sariyev",18,card3);

Bank bank1 = new Bank("MERKEZI BANK");
bank1.AddClient(Amin);
bank1.AddClient(Maga);
bank1.AddClient(Ali);

bank1.DisplayClients();
void cash_menu(ref Client c) {
    int sel = 1;
    while(true) {
        Console.Clear();
        Console.WriteLine($"Balansiniz: {c.BankAccount.Balance}$\n");
        if(sel == 1) {
        Console.WriteLine("10 $ << ");
        Console.WriteLine("20 $");
        Console.WriteLine("50 $");
        Console.WriteLine("100 $");
        Console.WriteLine("Diger");
        Console.WriteLine("Geri");
        } else if(sel == 2) {
        Console.WriteLine("10 $");
        Console.WriteLine("20 $ << ");
        Console.WriteLine("50 $");
        Console.WriteLine("100 $");
        Console.WriteLine("Diger");
        Console.WriteLine("Geri");
        }
        else if(sel == 3) {
        Console.WriteLine("10 $");
        Console.WriteLine("20 $");
        Console.WriteLine("50 $ << ");
        Console.WriteLine("100 $");
        Console.WriteLine("Diger");
        Console.WriteLine("Geri");
        }
        else if(sel == 4) {
        Console.WriteLine("10 $");
        Console.WriteLine("20 $");
        Console.WriteLine("50 $");
        Console.WriteLine("100 $ << ");
        Console.WriteLine("Diger");
        Console.WriteLine("Geri");
        }
        else if(sel == 5) {
        Console.WriteLine("10 $");
        Console.WriteLine("20 $");
        Console.WriteLine("50 $");
        Console.WriteLine("100 $");
        Console.WriteLine("Diger << ");
        Console.WriteLine("Geri");
        } else if(sel == 6) {
        Console.WriteLine("10 $");
        Console.WriteLine("20 $");
        Console.WriteLine("50 $");
        Console.WriteLine("100 $");
        Console.WriteLine("Diger");
        Console.WriteLine("Geri << ");
        }
        ConsoleKeyInfo key = Console.ReadKey();
        if(key.Key == ConsoleKey.DownArrow && sel <= 5)
            sel+=1;
        else if(key.Key == ConsoleKey.UpArrow && sel > 1)
            sel-=1;
        else if(key.Key == ConsoleKey.Enter) {
            try {
            if(sel == 1) {
                    c.MoneyOut(10);
                    Console.WriteLine("Emeliyyat ugurlu sekilde tamamlandi");
                    c.addEmeliyyat("Nagdlasdirma",10);
                    Thread.Sleep(3000);
                    break;
            } else if(sel == 2) {
                c.MoneyOut(20);
                Console.WriteLine("Emeliyyat ugurlu sekilde tamamlandi");
                c.addEmeliyyat("Nagdlasdirma",20);
                Thread.Sleep(3000);
                break;
            } else if(sel == 3) {
                    c.MoneyOut(50);
                    Console.WriteLine("Emeliyyat ugurlu sekilde tamamlandi");
                    c.addEmeliyyat("Nagdlasdirma",50);
                    Thread.Sleep(3000);
                    break;
            } else if(sel == 4) {
                    c.MoneyOut(100);
                    Console.WriteLine("Emeliyyat ugurlu sekilde tamamlandi");
                    c.addEmeliyyat("Nagdlasdirma",100);
                    Thread.Sleep(3000);
                    break;
            } else if(sel == 5) {
                bool op = true;
                while(op) {
                Console.Clear();
                Console.WriteLine("Mebleg daxil edin: ");
                string ? custom_m = Console.ReadLine();
                if(double.TryParse(custom_m,out _) == true) {
                    if(Convert.ToDouble(custom_m) >= 1) {
                        c.MoneyOut(Convert.ToDouble(custom_m));
                        op = false;
                        Console.WriteLine("Emeliyyat ugurlu sekilde tamamlandi");
                        c.addEmeliyyat("Nagdlasdirma",Convert.ToDouble(custom_m));
                        Thread.Sleep(3000);
                    } else {Console.WriteLine("Min 1 $ cixarda bilersiniz");Thread.Sleep(1500);};
                 }
                }
                break;
            } else if(sel == 6) {
                break;
            }
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(3000);
                    continue;
                }
        }
    }
}
void menu(int sel) {
    switch(sel) {
        case 1:
            Console.WriteLine("Balans << ");
            Console.WriteLine("Nagd pul ");
            Console.WriteLine("Tarixce ");
            Console.WriteLine("Card to card ");
            Console.WriteLine("Exit");
            break;
        case 2:
            Console.WriteLine("Balans");
            Console.WriteLine("Nagd pul << ");
            Console.WriteLine("Tarixce ");
            Console.WriteLine("Card to card ");
            Console.WriteLine("Exit");
            break;
        case 3:
            Console.WriteLine("Balans ");
            Console.WriteLine("Nagd pul ");
            Console.WriteLine("Tarixce << ");
            Console.WriteLine("Card to card ");
            Console.WriteLine("Exit");
            break;
        case 4:
            Console.WriteLine("Balans ");
            Console.WriteLine("Nagd pul ");
            Console.WriteLine("Tarixce ");
            Console.WriteLine("Card to card << ");
            Console.WriteLine("Exit");
            break;
        case 5:
            Console.WriteLine("Balans ");
            Console.WriteLine("Nagd pul ");
            Console.WriteLine("Tarixce ");
            Console.WriteLine("Card to card ");
            Console.WriteLine("Exit << ");
            break;
    }

}
void menu_balans(ref Client c) {
    Console.Clear();
    Console.WriteLine($"Balansiniz: {c.BankAccount.Balance}$");
    Console.WriteLine("ESC basin geri qayitmag ucun ");
    while(true) {
        ConsoleKeyInfo pressed = Console.ReadKey();
        if(pressed.Key == ConsoleKey.Escape) {
            break;
        }
    }

}
void tarixce_menu(ref Client c) {
    Console.Clear();
    c.displayEmeliyyatlar();
    Console.WriteLine("ESC basin geri qayitmag ucun ");
    while(true) {
        ConsoleKeyInfo pressed = Console.ReadKey();
        if(pressed.Key == ConsoleKey.Escape) {
            break;
        }
    }
}
void card_to_card_menu(ref Client c, ref Bank b) {
    while(true) {
        Console.Clear();
        Console.WriteLine("16 reqemli kodu daxil edin: ");
        try {
        string ? card_number = Console.ReadLine();
        if(card_number?.Length == 16 && Int64.TryParse(card_number, out _)) {
            Client client_2 = b.checkClient(card_number);
            Console.WriteLine("Gondermek istediyiniz meblegi daxil edin: ");
            string ? _mebleg = Console.ReadLine();
            if(double.TryParse(_mebleg,out _) == true) {
                    if(Convert.ToDouble(_mebleg) >= 1) {
                        c.MoneyOut(Convert.ToDouble(_mebleg));
                        Console.WriteLine("Emeliyyat ugurlu sekilde tamamlandi");
                        c.addEmeliyyat("Card to card",Convert.ToDouble(_mebleg));
                        client_2.MoneyIN(Convert.ToDouble(_mebleg));
                        client_2.addEmeliyyat("Card to card",Convert.ToDouble(_mebleg),false);
                        Thread.Sleep(3000);
                        break;
                    } else {throw new Exception("Min 1 $ gondere bilersiniz");};
                 }
        } else throw new Exception("Duzgun kart nomresi daxil edin");
        } catch(Exception e) {
            Console.WriteLine(e.Message);
            Thread.Sleep(2000);
            continue;
        }
    }
}
void start(ref Bank bank) {
    Console.WriteLine("====XOS GELMISINZ ====\n\n");
    Client? client_logged;
    while(true) {
        Console.WriteLine("PIN DAXIL EDIN: ");
        string ? enter_pin = Console.ReadLine();
        if(enter_pin?.Length != 4 || !int.TryParse(enter_pin, out _)) {
            Console.WriteLine("Duzgun pin(4 reqem) daxil edin...");
            continue;
        }
        else {
            try {
            client_logged = bank.findClient(enter_pin);
            }catch(Exception e) {
                Console.WriteLine(e.Message);
                continue;
            }
        }
        Console.WriteLine($"{client_logged.Name + " " + client_logged.Surname} xos gelmisiniz zehmet olmasa asagidakilardan birini secerdiniz");
        int sel = 1;
        while(true) {
            menu(sel);
            ConsoleKeyInfo press = Console.ReadKey();
            Console.Clear();
            if(press.Key == ConsoleKey.UpArrow) {
                if(sel >= 2)
                    sel-=1;
            } else if(press.Key == ConsoleKey.DownArrow) {
                if(sel <= 4)
                    sel+=1;
            } else if(press.Key == ConsoleKey.Enter) {
                Console.Clear();
                if(sel == 1)
                    menu_balans(ref client_logged);
                else if(sel == 2)
                    cash_menu(ref client_logged);
                else if(sel == 3)
                    tarixce_menu(ref client_logged);
                else if(sel == 4)
                    card_to_card_menu(ref client_logged, ref bank);
                else if(sel == 5) {
                    if(client_logged != null) client_logged = null;
                    break;
                }
            }
        }
    }
}
Console.WriteLine("\n");
start(ref bank1);