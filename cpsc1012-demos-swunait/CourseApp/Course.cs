using System;
namespace CourseApp
{
	public class Course
	{
		private string _courseNo;
		// When you have a property that is a list, you need to create a new list either when you declare the field or in the constructor
		private List<string> _studentNames = new List<string>();

		// Add method to manage the contents of the list
		public void AddStudent(string newStudentName)
		{
			StudentNames.Add(newStudentName);
		}
		public void RemoveStudent(string existingStudentName)
		{
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
 
		public Course(string courseNo)
		{
			CourseNo = courseNo;
			// As an alternative to create a new list is in the constructor as follows
			//_studentNames = new List<string>();
		}
	}
}

