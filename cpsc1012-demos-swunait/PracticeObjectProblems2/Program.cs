using PracticeObjectProblems2;


// Create a new List of CD
List<CD> cdList = new List<CD>();

// Load a list of CD from a CSV text file
const string DataFilePath = @"../../../myCdCollection.csv";
const int MaxCdAllowed = 25;

try
{
    int recordsRead = ReadFromFile(cdList, DataFilePath, MaxCdAllowed);
    if (recordsRead > 0)
    {
        Console.WriteLine($"Successfully read {recordsRead} CDs from {DataFilePath}");
        Console.WriteLine("The following records were read: ");
        PrintCds(cdList);
    }
}
catch(Exception ex)
{
    Console.WriteLine($"Error reading from file with exception: {ex.Message}");
}


int menuOption = 0;
const string MenuOptions = @"
1. Add new CD
2. Remove a CD
3. List CDs
0. Exit program
Your choice: ";

do
{
    // Display menu of choices
    Console.Write(MenuOptions);
    menuOption = int.Parse(Console.ReadLine());

    // Process menu option
    switch(menuOption)
    {
        case 1: // add new CD
            {
                int cdCount = EnterNewCds(cdList);
                Console.WriteLine($"Successfully added {cdCount} CDs");
            }
            break;
        case 2: // remove a CD
            {
                RemoveCd(cdList);
            }
            break;
        case 3: // list CDs
            {
                PrintCds(cdList);
            }
            break;
        case 0: // Exit program
            break;
        default: // invalid menu option
            break;
    }

} while (menuOption != 0);




try
{
    int recordsWritten = SaveToFile(cdList, DataFilePath);
    Console.WriteLine($"Successfully wrote {recordsWritten} records to {DataFilePath}");
}
catch(Exception ex)
{
    Console.WriteLine($"Error writing to file with exception: {ex.Message}");
}

static void RemoveCd(List<CD> cdList)
{
    PrintCds(cdList);

    Console.WriteLine("Enter the id of CD to delete: ");
    int cdId = int.Parse(Console.ReadLine());
    int index = cdId - 1;
    if (index >= 0 && index < cdList.Count)
    {
        cdList.RemoveAt(index);
        //PrintCds(cdList);
    }
    else
    {
        Console.WriteLine($"Invalid CD id of {cdId}");
    }
}

static int EnterNewCds(List<CD> cdList)
{
    int newCdCount = 0;

    char addAnotherCd = 'y';
    string title;
    string artistFirstName;
    string artistLastName;
    int tracks;
    double price;

    do
    {
        // Prompt for CD title
        Console.Write($"{"Enter CD title: ",30}");
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
        newCdCount += 1;

        // Ask if user wants to add another CD
        Console.Write("Add another CD (Y/N): ");
        addAnotherCd = Console.ReadKey().KeyChar;
        addAnotherCd = char.ToLower(addAnotherCd);
        Console.WriteLine();


    } while (addAnotherCd == 'y');


    return newCdCount;
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
static int ReadFromFile(List<CD> cdList, string dataFilePath, int maxCdAllowed)
{
    int recordsRead = 0;

    if (cdList != null && File.Exists(DataFilePath))
    {
        using (StreamReader reader = new StreamReader(dataFilePath))
        {
            cdList.Clear();
            const char Delimiter = ',';
            string lineText;
            while (reader.EndOfStream == false && recordsRead < maxCdAllowed)
            {
                lineText = reader.ReadLine();
                string[] tokens = lineText.Split(Delimiter);
                // Verify there are 5 values in the array                
                if (tokens.Length == 5)
                {
                    // The order of the values are:
                    // 0 - Title
                    // 1 - Artist First Name
                    // 2 - Artist Last Name
                    // 3 - Tracks
                    // 4 - Price
                    string title = tokens[0];
                    string artistFirstName = tokens[1];
                    string artistLastName = tokens[2];
                    int tracks = int.Parse(tokens[3]);
                    double price = double.Parse(tokens[4]);
                    // Create a new Artist instance
                    Artist currentArtist = new Artist(artistFirstName, artistLastName);
                    // Create a new CD instance
                    CD currentCD = new CD(title, currentArtist, tracks, price);
                    // Add the currentCD to cdList
                    cdList.Add(currentCD);

                    recordsRead += 1;
                }

            }
        }
    }
    return recordsRead;
}

static int SaveToFile(List<CD> cdList, string dataFilePath)
{
    int recordsWritten = 0;

    if (cdList != null && cdList.Count > 0)
    {
        const char Delimiter = ',';
        using (StreamWriter writer = new StreamWriter(dataFilePath))
        {
            foreach(CD currentCD in cdList)
            {
                // Write the Title, Artist FirstName, Artist LastName, Tracks, Price to each line
                writer.Write(currentCD.Title);
                writer.Write(Delimiter);
                writer.Write(currentCD.Artist.FirstName);
                writer.Write(Delimiter);
                writer.Write(currentCD.Artist.LastName);
                writer.Write(Delimiter);
                writer.Write(currentCD.Tracks);
                writer.Write(Delimiter);
                writer.WriteLine(currentCD.Price);

                recordsWritten += 1;
            }
        }
    }
    return recordsWritten;
}