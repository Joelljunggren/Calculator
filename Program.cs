
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
        var choice = Console.ReadKey();

        switch (choice.KeyChar)
        {
            case '1':
                Uträkning();
                break;
            case '2':
                Uträkningslista();
                break;
			case '3':
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
        Console.WriteLine("\nVill du göra en ny uträkning?");
        Console.WriteLine("(Y) För att göra en ny, (N) för att återgå till startmenyn");
        var goAgain = Console.ReadKey();
        if (goAgain.KeyChar == 'y')
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
    Console.WriteLine($"\n{number1} * {number2} = {sum}");
    calculations.Add($"{number1} * {number2} = {sum}");
}

void Addition()
{
    sum = number1 + number2;
    Console.WriteLine($"\n{number1} + {number2} = {sum}");
    calculations.Add($"{number1} + {number2} = {sum}");
}

void Subtraction()
{
    sum = number1 - number2;
    Console.WriteLine($"{number1} - {number2} = {sum}");
    calculations.Add($"\n{number1} - {number2} = {sum}");
}

void Division()
{
    if (number1 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Du kan inte dela med 0.\n");
        Console.ResetColor();
        Console.Write("Ändra siffra 1: ");
        number1 = double.Parse(Console.ReadLine());
        Console.Clear();
    }
    if (number2 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Du kan inte dela med 0.\n");
        Console.ResetColor();
        Console.Write("Ändra siffra två: ");
        number2 = double.Parse(Console.ReadLine());
        Console.Clear();
    }
    sum = number1 / number2;
    Console.WriteLine($"\n{number1} / {number2} = {sum}");
    calculations.Add($"{number1} / {number2} = {sum}");
}


//Jag valde att lägga nästan allting i metoder för att kunna ha en lite bättre överblick på koden.

//Till startmenyn valde jag en switch, då det för mig är tydligare än om man använder många olika if statements. Switchen aktiveras genom en readkey så att det inte krävs
//att man trycker på enter efter att man har valt vad man vill gå in på.

//Uträkningsmetoden är ganska krånglig, den går säkerligen att förenkla.
//Valde att köra en liknande switch case som för startmenyn, men istället för att använda keyChar vid val så använde jag en char så att du kan sudda och ändra dig om du råkar trycka på fel knapp.
//Placerade tryParse som argument i en while loop vid varje input, så varje gång den får "fel" sorts input ställer den samma fråga igen, tills det blir rätt.

//Förbättringar
//Jag skulle gärna ha implementerat ett sätt där man kan skriva in hela talet på en rad. Men jag kände mig inte tillräckligt säker på hur jag skulle använda indexOf för att göra det.
//Samt att man kunde ha flera olika operatorer på samma rad, i stil med 25*2+3.
//Metoden för division kan nog göras på ett annat sätt än att placera in den i två olika if-satser, men var osäker på vad jag skulle kunna använda istället, så den fick vara kvar.
//Ville dock se till så att man inte behövde skriva om hela uträkningen, utan bara ett av talen. Det är därför den ser ut som den gör just nu istället för if (number1 && number2 == 0).
//Sista förbättringen jag kan komma på är väl att den inte är så speciellt estetiskt tilltalande.
