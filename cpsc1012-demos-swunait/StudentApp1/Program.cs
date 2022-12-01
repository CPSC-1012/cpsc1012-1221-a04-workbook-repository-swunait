using StudentApp1;

const string DataFilePath = @"..\..\..\students.csv";
List<Student> students = new List<Student>();

//AddStudent(students);
//AddStudent(students);
//AddStudent(students);
//DisplayStudents(students);
//if (SaveToFile(students, DataFilePath) == true )
{
    int studentCount = ReadFromFile(students, DataFilePath);
    Console.WriteLine($"Read from file was successful with {studentCount} records.");
    DisplayStudents(students);
}


static void AddStudent(List<Student> studentList)
{
    // Create a new Student object
    Student newStudent = new Student();

    // Prompt and set the FirstName, LastName, and IdNumber of the new Student object
    Console.Write("Enter the student's first name: ");
    newStudent.FirstName = Console.ReadLine();
    Console.Write("Enter the student's last name: ");
    newStudent.LastName = Console.ReadLine();
    Console.Write("Enter the student's ID: ");
    newStudent.IdNumber = int.Parse(Console.ReadLine());

    // Add the new student to studentList
    studentList.Add(newStudent);
}

static void DisplayStudents(List<Student> studentList)
{
    Console.WriteLine($"{"Id",-10} {"Last Name",-15} {"First Name",-15}");
    Console.WriteLine($"{"--",-10} {"---------",-15} {"----------",-15}");

    foreach(Student currentStudent in studentList)
    {
        Console.WriteLine($"{currentStudent.IdNumber,-10} {currentStudent.LastName,-15} {currentStudent.FirstName,-15}");
    }

    Console.WriteLine($"Total Students: {studentList.Count}");
}

static bool SaveToFile(List<Student> studentList, string filePath)
{
    bool success = false;
    const char Delimiter = ',';
    try
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (Student currentStudent in studentList)
            {
                writer.Write(currentStudent.IdNumber);
                writer.Write(Delimiter);
                writer.Write(currentStudent.LastName);
                writer.Write(Delimiter);
                writer.Write(currentStudent.FirstName);
                writer.WriteLine();
            }
            success = true;
        }
    }
    catch(Exception)
    {
        success = false;
    }
    return success;
}

static int ReadFromFile(List<Student> studentList, string filePath)
{
    int studentCount = 0;   // number of students in the file

    try
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            studentList.Clear();
            string lineText;
            const char Delimiter = ',';
            while (reader.EndOfStream == false)
            {
                lineText = reader.ReadLine();
                string[] tokens = lineText.Split(Delimiter);
                // line format: idNumber, lastName, firstName
                // Create a new Student object
                if (tokens.Length == 3)
                {
                    Student currentStud = new Student();
                    currentStud.IdNumber = int.Parse(tokens[0]);
                    currentStud.LastName = tokens[1];
                    currentStud.FirstName = tokens[2];
                    studentList.Add(currentStud);
                    studentCount += 1;
                }
            }
        }   
    }
    catch(Exception ex)
    {
        studentCount = 0;
        Console.WriteLine($"Failed to read from {filePath} with exception {ex.Message}");
    }

    return studentCount;
}