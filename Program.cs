// Välkomnande meddelande
// En lista för att spara historik för räkningar
// Användaren matar in tal och matematiska operation
//OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
// Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
// Lägga resultat till listan
//Visa resultat
//Fråga användaren om den vill visa tidigare resultat.
//Visa tidigare resultat
//Fråga användaren om den vill avsluta eller fortsätta.



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
        //var choice = Console.ReadKey();


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
    char operate;
	bool calculating = true;
	Console.Clear();
	Console.Write("Mata in ditt första tal: ");
    while (!double.TryParse(Console.ReadLine(), out number1))
    {
        Console.Write("En siffra behövs: ");
    }
    Console.Write("\nVälj operator ( * , / , + , - ) : ");
    while (!char.TryParse(Console.ReadLine(), out operate))
    {
        Console.Write("Välj mellan  * , / , + , - : ");
    }
    Console.Write("\nNästa tal tack: ");
    while (!double.TryParse(Console.ReadLine(), out number2))
    {
        Console.Write("En siffra behövs: ");
    }

    while (calculating)
	{
        switch (operate)
        {
            case '*':
                Multiplication();
                break;
            case '/':
                Division();
                break;
            case '+':
                Addition();
                break;
            case '-':
                Subtraction();
                break;
            default:
                Console.WriteLine("Felaktig inmatning.\n");
                break;
        }
        Console.WriteLine("Vill du göra en ny uträkning? (Y/N): ");
        var goAgain = Console.ReadLine().ToLower();
        if (goAgain == "y")
        {
            Console.Clear();
            Uträkning();
        }
        else
            Console.Clear();
            calculating = false;
            return;
    }
}


void Uträkningslista()
{
	Console.Clear();
    if(calculations.Count == 0)
        Console.WriteLine("Du har inte gjort några uträkningar än.");

    else
    {
        Console.WriteLine("Nedanför står en lista på alla utförda uträkningar: ");
        foreach (var calculation in calculations)
        {
            Console.WriteLine($"\n{calculation}");
        }
    }
    Console.WriteLine("\nTryck på en knapp för att återvända till menyn");
    Console.ReadKey();
    Console.Clear();
}

void Multiplication()
{
    sum = number1 * number2;
    Console.WriteLine($"{number1} * {number2} = {sum}");
    calculations.Add($"{number1} * {number2} = {sum}");
}

void Addition()
{
    sum = number1 + number2;
    Console.WriteLine($"{number1} + {number2} = {sum}");
    calculations.Add($"{number1} + {number2} = {sum}");
}

void Subtraction()
{
    sum = number1 - number2;
    Console.WriteLine($"{number1} - {number2} = {sum}");
    calculations.Add($"{number1} - {number2} = {sum}");
}

void Division()
{
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
    sum = number1 / number2;
    Console.WriteLine($"{number1} / {number2} = {sum}");
    calculations.Add($"{number1} / {number2} = {sum}");
}