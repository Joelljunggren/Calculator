﻿// Välkomnande meddelande
// En lista för att spara historik för räkningar
// Användaren matar in tal och matematiska operation
//OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
// Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
// Lägga resultat till listan
//Visa resultat
//Fråga användaren om den vill visa tidigare resultat.
//Visa tidigare resultat
//Fråga användaren om den vill avsluta eller fortsätta.


//SKIT LIGGER PÅ FEL STÄLLE.
//BEHÖVER FÅ TILL SÅ ATT PROGRAMMET FRÅGAR OM MAN VILL GÖRA EN NY UTRÄKNING
//DELA 0 MED 0 CATCH

bool keepAlive = true;
double number1 = 0;
double number2 = 0;
double sum = 0;
List<string> calculations = new List<string>();

while (keepAlive)
{
	try
	{
        Console.WriteLine("\nVälkommen till miniräknaren!\n");
        Console.WriteLine("1: Vill du börja göra uträkningar?");
        Console.WriteLine("2. Vill du visa alla gjorda uträkningar?");
        Console.WriteLine("3: Avsluta programmet.");
        var choice = int.Parse(Console.ReadLine() ?? "");


        switch (choice)
        {
            case 1:
                Uträkning();
                break;
            case 2:
                Uträkningslista();
                break;
			case 3:
				keepAlive = false;
				Console.Clear();
				Console.WriteLine("Avslutar programmet...");
				break;
            default:
				Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Välj ett annat nummer.");
                Console.ResetColor();
                break;
        }
    }
	catch
	{
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine("Felaktig inmatning.");
		Console.ResetColor();
	}
}

void Uträkning()
{
	bool calculating = true;
	Console.Clear();
	Console.Write("Mata in ditt första tal: ");
	var number1 = double.Parse(Console.ReadLine());
	//TRY CATCH HÄR FÖR FELHANTERING
	Console.Write("\nVälj operator ( * , / , + , - ) : ");
	var operate = char.Parse(Console.ReadLine());
    //TRY CATCH HÄR FÖR FELHANTERING
    Console.Write("\nNästa tal tack: ");
	var number2 = double.Parse(Console.ReadLine());
	//TRY CATCH HÄR FÖR FELHANTERING

	while (calculating)
	{
        switch (operate)
        {
            //ALLA CASES KAN VARA METODER FÖR TYDLIGHET AV KOD
            case '*':
                var sum = number1 * number2;
                Console.WriteLine($"{number1} * {number2} = {sum}");
                calculations.Add($"{number1} * {number2} = {sum}");
                break;
            case '/':
                //IF DELA MED 0, SÄG IFRÅN, LADDA OM
                //GÖR OM DETTA TILL EN METOD
                sum = number1 / number2;
                Console.WriteLine($"{number1} / {number2} = {sum}");
                calculations.Add($"{number1} / {number2} = {sum}");

                if (number1 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du kan inte dela med 0.");
                    Console.ResetColor();
                    Console.Write("Ändra siffra 1: ");
                    number1 = double.Parse(Console.ReadLine());
                }
                if (number2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du kan inte dela med 0.");
                    Console.ResetColor();
                    Console.Write("Ändra siffra två: ");
                    number2 = double.Parse(Console.ReadLine());
                }
                break;
            case '+':
                sum = number1 + number2;
                Console.WriteLine($"{number1} + {number2} = {sum}");
                calculations.Add($"{number1} + {number2} = {sum}");
                break;
            case '-':
                sum = number1 - number2;
                Console.WriteLine($"{number1} - {number2} = {sum}");
                calculations.Add($"{number1} - {number2} = {sum}");
                break;
            default:
                Console.WriteLine("Felaktig inmatning.\n");
                break;
        }
        Console.WriteLine("Vill du göra en ny uträkning? (Y/N): ");
        var goAgain = Console.ReadLine().ToLower();
        if(goAgain == "n")
        {
            Console.Clear();
            calculating = false;
        }
        if(goAgain == "y")
        {
            Uträkning();
        }
        //Fråga om att göra ny uträkning eller gå till menyn.

    }
}


void Uträkningslista()
{
	Console.Clear();
	Console.WriteLine("Nedanför står en lista på svaren av utförda uträkningar: ");
	foreach (var calculation in calculations)
	{
		Console.WriteLine($"\n{calculation}");
	}

	//TRYCK PÅ EN KNAPP FÖR ATT ÅTERGÅ TILL MENYN
}

void Divide()
{

}