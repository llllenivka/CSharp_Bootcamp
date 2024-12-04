static class InputUser
{
    public static bool NumberStudents(out int count)
    {
        count = 0;
        Message("Enter the number of students :", ConsoleColor.Yellow);
        string ? input = Console.ReadLine();

        if(string.IsNullOrEmpty(input) || !int.TryParse(input, out count) || count <= 0)
        {
            Message("Couldn't parse a number. Please, try again", ConsoleColor.Red);
            return false;
        }

        return true;
    }

    public static bool Students(int studentNumber, out List<Student> students)
    {
        students = new();

        for(int iter = 0; iter < studentNumber; iter++)
        {
            Message("Enter student and group number :", ConsoleColor.Yellow);
            string ? input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                Message("Couldn't parse a word or number. Please, try again", ConsoleColor.Red);
                iter--;
                continue;
            }

            string[] splitInput = input.Split(" ");
            
            string name = splitInput[0];
            int group = 0;

            if(!int.TryParse(splitInput[1], out group))
            {
                Message("Couldn't parse a word or number. Please, try again", ConsoleColor.Red);
                iter--;
                continue;
            }
            
            if(group <= 0) 
            {
                Message("Incorrect input. Group <= 0", ConsoleColor.Red);
                continue;
            }

            students.Add(new Student(name, group));
        }

        return students.Count != 0 ? true : false ;
    }
    public static bool NumberGroup(out int group)
    {
        group = 0;
        Message("Enter the number of students :", ConsoleColor.Yellow);
        string ? input = Console.ReadLine();

        if(string.IsNullOrEmpty(input) || !int.TryParse(input, out group) || group <= 0)
        {
            Message("Incorrect input. Group <= 0. Please, try again", ConsoleColor.Red);
            return false;
        }

        return true;
    }

    

    public static void Message(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}