class MyProgram
{
    public static void Main()
    {
        int numberStudent = 0;
        while(!InputUser.NumberStudents(out numberStudent)) {}

        List<Student> students;
        if(!InputUser.Students(numberStudent, out students))
        {
            InputUser.Message("Incorrect input. Students <= 0", ConsoleColor.Red);
        }
        else
        {
            int group = 0;
            while(!InputUser.NumberGroup(out group)) {}
            List<String> result = FindStudents.Find(students, group);

            if(result.Count == 0) InputUser.Message("There are no students from such a group", ConsoleColor.Green);   
            else
            {
                InputUser.Message(string.Join(", ", result), ConsoleColor.Green);
            }
        }
    }
}