using System;
namespace CourseApp
{
	public class Course
	{
		private string _courseNo;

		// When you have a property that is a list, you need to create a new list either when you declare the field or in the constructor
		private List<string> _studentNames;// = new List<string>();
		// If you want to create an array instead of a list
		//private string[] _studentNames;

		public readonly int MaxStudents;

		// Add method to manage the contents of the list
		public void AddStudent(string newStudentName)
		{
			if (StudentNames.Count >= MaxStudents)
			{
				throw new ArgumentException("The course is full, no more students allowed");
			}
			StudentNames.Add(newStudentName);
		}
		public void RemoveStudent(string existingStudentName)
		{
			if (StudentNames.Contains(existingStudentName) == false )
			{
				throw new ArgumentException($"There are no student with the name {existingStudentName}");
			}
			StudentNames.Remove(existingStudentName);
		}
		public int StudentCount
		{
			get => StudentNames.Count;
		}

		public string CourseNo
		{
			get => _courseNo;
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("CourseNo cannot be blank");
				}
				_courseNo = value.Trim();
			}
		}

		public List<string> StudentNames
		{
			get => _studentNames;
		}
 
		public Course(string courseNo, int maxStudents)
		{
			CourseNo = courseNo;

			// As an alternative to create a new list is in the constructor as follows
			_studentNames = new List<string>();

			// If you are using a array then you have to create the list here
			//_studentNames = new string[MaxStudents];

            MaxStudents = maxStudents;
		}
	}
}

