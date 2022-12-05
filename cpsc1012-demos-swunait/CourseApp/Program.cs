using CourseApp;

try
{
    // Create a new Course for CPSC1012
    Course currentCourse = new Course("", 25);
    // Add three students to CPSC1012
    currentCourse.AddStudent("Larry");
    currentCourse.AddStudent("Curly");
    currentCourse.AddStudent("Moe");
    // Print properties of the currentCourse
    PrintCourseInfo(currentCourse);

    // Remove Moe from CPSC1012
    currentCourse.RemoveStudent("Moe");
    // Add Shemp to CPSC1012
    currentCourse.AddStudent("Shemp");

    // Print properties of the currentCourse
    PrintCourseInfo(currentCourse);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

static void PrintCourseInfo(Course currentCourse)
{
    Console.WriteLine($"There are {currentCourse.StudentCount} students in {currentCourse.CourseNo}");
    Console.WriteLine($"The students in {currentCourse.CourseNo} are: ");
    foreach(string currentStudentName in currentCourse.StudentNames)
    {
        Console.WriteLine($"\t{currentStudentName}");
    }
}
