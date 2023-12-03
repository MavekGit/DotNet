using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using static Program;
using static Program.Students;

class Program
{
    static void Main()
    {


        //-------------------Zad-1-----------------//
        int[] n1 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

        var result1 = n1.Where(x => x % 2 == 0);

        Console.WriteLine("Wartości podzielne przez 2:");
        foreach (var value in result1)
        {
            Console.WriteLine(value);
        }

        //-------------------Zad-2-----------------//

        var result2 = n1.Where(x => x % 2 != 0);

        Console.WriteLine("Wartości nie podzielne przez 2:");
        foreach (var value in result2)
        {
            Console.WriteLine(value);
        }

        //-------------------Zad-3-----------------//

        var arr1 = new[] { 3, -1, -3, 6, 9, 2, -7, 0, 8, 14, 13, 24, 12, 6, 5 };

        var result3 = arr1.Where(x => x > 0 && x < 12);

        Console.WriteLine("Wartości  z przedziału >0 i <12: ");
        foreach (var value in result3)
        {
            Console.WriteLine(value);
        }

        //-------------------Zad-4-----------------//

        var arr2 = new[] { 3, 9, 2, 8, 6, 5 };

        var result4 = arr2.Where(x => Math.Pow(x,2) > 20);

        Console.WriteLine("Wartości  które podniesione do drugiej potęgi dają wartość >20 ");
        foreach (var value in result4)
        {
            Console.WriteLine(value);
        }

        //-------------------Zad-5-----------------//

        int[] arr3 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4,9, 6, 2 };

        var result5 = arr3.GroupBy(x => x).Select(group => new { Number = group.Key, Frequency = group.Count() });

        Console.WriteLine("wszystkie liczby oraz częstotliwość ich występowania ");
        foreach (var value in result5)
        {
            Console.WriteLine(value);
        }

        //-------------------Zad-6-----------------//

        var str1 = "abeddwkkecjjeksoiekcllkenndkwel";

        var result6 = str1.GroupBy(x => x).Select(group => new { Letter = group.Key, Frequency = group.Count() });

        Console.WriteLine("wszystkie litery występujące w tekście oraz częstotliwość ich występowania ");
        foreach (var value in result6)
        {
            Console.WriteLine(value);
        }

        //-------------------Zad-7-----------------//

        string[] months = { "January", "February", "March", "April", "May","June", "July", "August", "September", "October", "November","December" };

        var result7 = months.Select(group => group);

        Console.WriteLine("wszystkie miesiące ");
        foreach (var value in result7)
        {
            Console.WriteLine(value);
        }

        //-------------------Zad-8-----------------//

        int[] nums = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5,2 };

        var result8 = nums.GroupBy(x=>x).Select(group => new { Number = group.Key, Frequency = group.Count(), Unique = group.Count() == 1, Ratio = Math.Pow(group.Key,group.Count())/group.Count() });

        Console.WriteLine("wszystkie unikalne wartości, sumę poszczególnych wartości ");
        foreach (var value in result8)
        {
            Console.WriteLine(value);
        }

        Console.WriteLine("Które zadanie chcesz uruchomić 9-21, kliknij odpowiedni numer ");
        int.TryParse(Console.ReadLine(), out int TaskNumber);

        int console;
        do
        {
            switch (TaskNumber)
            {
                case 9:
                    //-------------------Zad-9-----------------//

                   

                    Console.WriteLine("Zadanie 9");
                    do
                    {

                        Console.WriteLine("Początek łańcucha ");
                        string startChar = Console.ReadLine();

                        Console.WriteLine("Koniec łańcucha");
                        string endChar = Console.ReadLine();

                        string[] cities = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };

                        var result9 = cities.Where(x => x.StartsWith(startChar, StringComparison.OrdinalIgnoreCase) && x.EndsWith(endChar, StringComparison.OrdinalIgnoreCase)).ToArray();

                        Console.WriteLine("łańcuchy znaków rozpoczynające się i kończące zadanymi przez użytkownika znakami ");
                        foreach (var value in result9)
                        {
                            Console.WriteLine(value);
                        }

                        Console.WriteLine("Jeszcze raz, przyciśnij 0, koniec coś innego");
                    } while (int.TryParse(Console.ReadLine(), out console) && console == 0);

                    break;
                case 10:
                    //-------------------Zad-10----------------//

                    Console.WriteLine("Zadanie 10");
                    do
                    {


                        Console.WriteLine("Wpisz listę liczb z spacją jako separatorem ");
                        string NumberList = Console.ReadLine();

                        Console.WriteLine("Wpisz od jakiej liczby ma znaleźć większe wartości");
                        string biggerNumber = Console.ReadLine();
                        double.TryParse(biggerNumber, out double DbiggerNumber);

                        try
                        {
                            string[] SplitNumberList = NumberList.Split(' ');

                            List<double> IntList = new List<double>();

                            foreach (string number in SplitNumberList)
                            {
                                IntList.Add(double.Parse(number));
                            }
                            var result10 = IntList.FindAll(x => x > DbiggerNumber);



                            Console.WriteLine("elementy większe od wartości zadanej przez użytkownika ");
                            foreach (var value in result10)
                            {
                                Console.WriteLine(value);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Nieprawidłowy format liczby. Spróbuj ponownie.");
                        }



                        Console.WriteLine("Jeszcze raz, przyciśnij 0, koniec coś innego");
                    } while (int.TryParse(Console.ReadLine(), out console) && console == 0);

                    break;
                case 11:
                    //-------------------Zad-11----------------//

                    Console.WriteLine("Zadanie 11");
                    do
                    {


                        Console.WriteLine("Wpisz listę liczb z spacją jako separatorem ");
                        string NumberList = Console.ReadLine();

                        Console.WriteLine("Wpisz ile ostatnich liczb ma wypisać ");
                        string NoNumbers = Console.ReadLine();
                        int.TryParse(NoNumbers, out int IntNoNumbers);

                        try
                        {
                            string[] SplitNumberList = NumberList.Split(' ');

                            List<int> IntList = new List<int>();

                            foreach (string number in SplitNumberList)
                            {
                                IntList.Add(int.Parse(number));
                            }
                            IntList.Reverse();
                            var result11 = IntList.Take(IntNoNumbers);



                            Console.WriteLine("elementy większe od wartości zadanej przez użytkownika ");
                            foreach (var value in result11)
                            {
                                Console.WriteLine(value);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Nieprawidłowy format liczby. Spróbuj ponownie.");
                        }



                        Console.WriteLine("Jeszcze raz, przyciśnij 0, koniec coś innego");
                    } while (int.TryParse(Console.ReadLine(), out console) && console == 0);

                    break;
                case 12:
                    //-------------------Zad-12----------------//

                    Console.WriteLine("Zadanie 12");
                    do
                    {


                        Console.WriteLine("Wpisz listę liczb z spacją jako separatorem ");
                        string NumberList = Console.ReadLine();

                        Console.WriteLine("Wpisz ile największych liczb ma wypisać ");
                        string NoNumbers = Console.ReadLine();
                        int.TryParse(NoNumbers, out int IntNoNumbers);

                        try
                        {
                            string[] SplitNumberList = NumberList.Split(' ');

                            List<int> IntList = new List<int>();

                            foreach (string number in SplitNumberList)
                            {
                                IntList.Add(int.Parse(number));
                            }
                            IntList.Sort();
                            IntList.Reverse();
                            var result12 = IntList.Take(IntNoNumbers);



                            Console.WriteLine("elementy większe od wartości zadanej przez użytkownika ");
                            foreach (var value in result12)
                            {
                                Console.WriteLine(value);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Nieprawidłowy format liczby. Spróbuj ponownie.");
                        }



                        Console.WriteLine("Jeszcze raz, przyciśnij 0, koniec coś innego");
                    } while (int.TryParse(Console.ReadLine(), out console) && console == 0);

                    break;
                case 13:
                    //-------------------Zad-13----------------//

                    Console.WriteLine("Zadanie 13");
                    do
                    {


                        Console.WriteLine("Wpisz zdanie");
                        string Sentence = Console.ReadLine();

                        
                        try
                        {
                            string[] SplitSentence = Sentence.Split(' ');


                            var result13 = SplitSentence.Where(x => x.Equals(x.ToUpper()));


                            Console.WriteLine("Slowa zaczynające się wielkimi literami ");
                            foreach (var value in result13)
                            {
                                Console.WriteLine(value);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Nieprawidłowy format liczby. Spróbuj ponownie.");
                        }



                        Console.WriteLine("Jeszcze raz, przyciśnij 0, koniec coś innego");
                    } while (int.TryParse(Console.ReadLine(), out console) && console == 0);

                    break;
                case 14:
                    //-------------------Zad-14----------------//

                    Console.WriteLine("Zadanie 14");
                    do
                    {

                        Console.WriteLine("wpisz ile słów chcesz wpisać do tablicy");
                        int.TryParse(Console.ReadLine(), out int NoStrings);
                        string[] tabStrings = new string[NoStrings];

                        Console.WriteLine("Zacznij wpisywać elementy do tablicy");

                        for(int i = 0;i<NoStrings;i++)
                        {
                            tabStrings[i] = Console.ReadLine();
                        }


                        try
                        {
                            
                            var result14 = string.Join("",tabStrings);

                            
                            Console.WriteLine("Poloczona tablica ");
                            //foreach (var value in result14)
                            {
                                Console.WriteLine(result14);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Nieprawidłowy format liczby. Spróbuj ponownie.");
                        }



                        Console.WriteLine("Jeszcze raz, przyciśnij 0, koniec coś innego");
                    } while (int.TryParse(Console.ReadLine(), out console) && console == 0);

                    break;

                    case 15:

                    //-------------------Zad-15----------------//
                        Students students = new Students();
                        List<Students> studentsList = students.GtStuRec();

                        Console.WriteLine("Wpisz ile najlepszych studentów znaleźć");
                        int.TryParse(Console.ReadLine(), out int n);

                    
                    var result15 = studentsList.OrderByDescending(x => x.GroupPoint).Take(n);


                    foreach (var value in result15)
                        {
                                //Console.WriteLine(value);
                            Console.WriteLine($" ID: {value.StudentId}, imie: {value.StudentName}, punkty: {value.GroupPoint}");
                        }
                    break;

                case 16:

                    //-------------------Zad-16----------------//
                    string[] arr16 = { "a.erc", "b.txt", "c.ldd", "d.pdf", "e.PDF", "a.pdf", "b.xml", "z.txt", "zzz.doc" };

                    var result16 = arr16
                        .Select(file => System.IO.Path.GetExtension(file).ToLower()).GroupBy(x => x).Select(group => new { Extension = group.Key, Count = group.Count() });

                    foreach (var values in result16)
                    {
                        Console.WriteLine($"Extension {values.Extension}, Frequency: {values.Count}");
                    }
                    break;

                case 17:

                    //-------------------Zad-17----------------//

                    List<int> ints = new List<int> { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };

                    do
                    {
                        Console.WriteLine("Co chcesz usunać");
                        int.TryParse(Console.ReadLine(), out int NumberToRemove);

                        var result17 = ints.RemoveAll(x => x == NumberToRemove);
                        Console.WriteLine("Elementy usunięte");
                        foreach (var value in ints)
                        {

                            Console.WriteLine(value);
                        }

                        Console.WriteLine("Co chcesz coś jeszcze usunać, wciśnij 0, koniec wciśnij coś innego");
                    } while (int.TryParse(Console.ReadLine(), out console) && console == 0);
                    
                    
                    break;

                    case 18:

                    //-------------------Zad-18----------------//
                    char[] charset1 = { 'A', 'B', 'C', 'D' };
                    int[] numset1 = { 1, 2, 3, 4 };

                    var result18 = from charS in charset1 from numS in numset1 select $"{charS}{numS}";

                    foreach (var value in result18)
                    {
                        Console.WriteLine(value);
                    }

                    break;

                case 19:

                    //-------------------Zad-19----------------//

                    Item_mast item_Mast = new Item_mast();
                    List<Item_mast> item_MastsList = item_Mast.GtItMa();

                    Purchase purchase = new Purchase();
                    List<Purchase> purchaseList = purchase.GtPur();

                    var result19 = from item in item_MastsList
                                   join pur in purchaseList on item.Id equals pur.Id
                                   select new { item.Id, item.Descr, pur.No, pur.Qty };

                    foreach (var value in result19)
                    {
                        Console.WriteLine($"Item ID: {value.Id}, Description: {value.Descr}, Purchase No: {value.No}, Quantity: {value.Qty}");
                    }


                    break;

                    case 20:
                    Item_mast Litem_Mast = new Item_mast();
                    List<Item_mast> Litem_MastsList = Litem_Mast.GtItMa();

                    Purchase Lpurchase = new Purchase();
                    List<Purchase> LpurchaseList = Lpurchase.GtPur();

                    var result20 = from item in Litem_MastsList join pur in LpurchaseList on item.Id equals pur.Id into lj from leftJoin in lj.DefaultIfEmpty() select new { item.Id, item.Descr, PurchaseNo = leftJoin?.No, Quantity = leftJoin?.Qty };

                    foreach (var value in result20)
                    {
                        Console.WriteLine($"Item ID: {value.Id}, Description: {value.Descr}, Purchase No: {value.PurchaseNo}, Quantity: {value.Quantity}");
                    }


                    break;

                case 21:

                    Item_mast Ritem_Mast = new Item_mast();
                    List<Item_mast> Ritem_MastsList = Ritem_Mast.GtItMa();

                    Purchase Rpurchase = new Purchase();
                    List<Purchase> RpurchaseList = Rpurchase.GtPur();

                    var result21 = from pur in RpurchaseList join item in Ritem_MastsList on pur.Id equals item.Id into rj from rightJoin in rj.DefaultIfEmpty() select new { ItemID = rightJoin?.Id, Descr = rightJoin?.Descr, pur.No, pur.Qty };

                    
                    foreach (var value in result21)
                    {
                        Console.WriteLine($"Item ID: {value.ItemID}, Description: {value.Descr}, Purchase No: {value.No}, Quantity: {value.Qty}");
                    }

                    break;

            }
            Console.WriteLine("Jeśli chcesz kontynuować wybierz numer zadania 9-21, koniec coś innego");
        } while (int.TryParse(Console.ReadLine(), out TaskNumber) && TaskNumber >= 9 && TaskNumber <= 21);


       




    }

    public class Students 
         { 
             public string StudentName { get; set; } 
             public int GroupPoint { get; set; } 
             public int StudentId { get; set; } 
 
             public List<Students> GtStuRec() 
             { 
                 List<Students> stulist = new List<Students>();
                    stulist.Add(new Students { StudentId = 1, StudentName = 
                        "A ", GroupPoint = 800 }); 
                         stulist.Add(new Students { StudentId = 2, StudentName =
                        "B", GroupPoint = 458 }); 
                         stulist.Add(new Students { StudentId = 3, StudentName =
                        "C", GroupPoint = 900 }); 
                         stulist.Add(new Students { StudentId = 4, StudentName =
                        "D", GroupPoint = 900 }); 
                         stulist.Add(new Students { StudentId = 5, StudentName =
                        "E", GroupPoint = 458 }); 
                         stulist.Add(new Students { StudentId = 6, StudentName =
                        "F", GroupPoint = 700 }); 
                         stulist.Add(new Students { StudentId = 7, StudentName =
                        "G", GroupPoint = 750 }); 
                         stulist.Add(new Students { StudentId = 8, StudentName =
                        "H", GroupPoint = 700 }); 
                         stulist.Add(new Students { StudentId = 9, StudentName =
                        "I", GroupPoint = 597 }); 
                         stulist.Add(new Students { StudentId = 10, StudentName =
                        "J", GroupPoint = 750 }); 
                 return stulist; 
             }

        public class Item_mast
        {
            public int Id { get; set; }
            public string Descr { get; set; }

            

            public List<Item_mast> GtItMa()
            {
                List<Item_mast> itemlist = new List<Item_mast>
                    {
                        new Item_mast { Id = 1, Descr = "A" },
                        new Item_mast { Id = 2, Descr = "B" },
                        new Item_mast { Id = 3, Descr = "C" },
                        new Item_mast { Id = 4, Descr = "D" },
                        new Item_mast { Id = 5, Descr = "E" }
                    };
                return itemlist;
            }

        }

        public class Purchase
        {
            public int No { get; set; }
            public int Id { get; set; }
            public int Qty { get; set; }


            public List<Purchase> GtPur()
            {
                List<Purchase> purchlist = new List<Purchase>
                    {
                        new Purchase { No=100, Id = 3, Qty = 55 },
                        new Purchase { No =101, Id = 2, Qty = 44 },
                        new Purchase { No =102, Id = 3, Qty = 555 },
                        new Purchase { No =103, Id = 4, Qty = 33 },
                        new Purchase { No =104, Id = 3, Qty = 33 },
                        new Purchase { No =105, Id = 4, Qty = 44 },
                        new Purchase { No =106, Id = 1, Qty = 343 }
                    };

                return purchlist;
            }


        }
    } 

}
