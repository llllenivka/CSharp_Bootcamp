static class FindStudents
{
    public static List<string> Find(List<Student> students, int group)
    {
        List<string> result = new();

        foreach(var student in students)
        {
            if(student.Group == group)
            {
                result.Add(student.Name);
            }
        }

        return result;
    }
}