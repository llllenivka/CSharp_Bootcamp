class Student
{
    public string Name { get; private set; }
    public int Group  { get; private set; }

    public Student(string name, int group)
    {
        Name = name;
        Group = group;
    }
}