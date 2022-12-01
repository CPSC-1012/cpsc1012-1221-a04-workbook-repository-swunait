using PracticeObjectProblems2;
using System.Diagnostics;

char addAnotherCd = 'y';
string title;
string artistFirstName;
string artistLastName;
int tracks;
double price;

// Create a new List of CD
List<CD> cdList = new List<CD>();

do
{
    // Prompt for CD title
    Console.Write($"{"Enter CD title: ", 30}");
    title = Console.ReadLine();

    // Prompt for Artist first name
    Console.Write($"{"Enter Artist's first name: ",30}");
    artistFirstName = Console.ReadLine();
    // Prompt for Artist last name
    Console.Write($"{"Enter Artist's last name: ",30}");
    artistLastName = Console.ReadLine();

    // Create a new Artist with artistFirstName and artistLastName
    Artist currentArtist = new Artist(artistFirstName, artistLastName);

    // Prompt for tracks
    Console.Write($"{"Enter # of tracks: ",30}");
    tracks = int.Parse(Console.ReadLine());
    // Prompt for price
    Console.Write($"{"Enter CD price: ",30}");
    price = double.Parse(Console.ReadLine());

    // Create a new CD 
    CD currentCD = new CD(title, currentArtist, tracks, price);

    // Add the CD to the list
    cdList.Add(currentCD);

    // Ask if user wants to add another CD
    Console.Write("Add another CD (Y/N): ");
    addAnotherCd = Console.ReadKey().KeyChar;
    addAnotherCd = char.ToLower(addAnotherCd);
    Console.WriteLine();


} while (addAnotherCd == 'y');

PrintCds(cdList);

Console.WriteLine("Enter the id of CD to delete: ");
int cdId = int.Parse(Console.ReadLine());
int index = cdId - 1;
if (index >= 0 && index < cdList.Count)
{
    cdList.RemoveAt(index);
    PrintCds(cdList);
}
else
{
    Console.WriteLine($"Invalid CD id of {cdId}");
}


static void PrintCds(List<CD> cdList)
{
    Console.WriteLine($"{"ID", -5} {"Title",-20} {"Artist",-20} {"Price",8}");

    int count = 1;
    foreach (CD currentCd in cdList)
    {
        Console.Write($"{count, -5}");
        Console.WriteLine(currentCd.CDInfo());
        count += 1;
    }
}


// Create a new Artist
//Artist currentArtist = new Artist("  Bon", "Jovi   ");
// Display the Artist info
//Console.WriteLine(currentArtist);
//Console.WriteLine(currentArtist.ToString());
//Console.WriteLine($"{currentArtist.LastName}, {currentArtist.FirstName}");
