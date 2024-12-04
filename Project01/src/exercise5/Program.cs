using System.Linq.Expressions;

class MyProgram {
    static void Main(){
        Console.WriteLine("Enter a file name :");
        string ? filename = Console.ReadLine();
        if(filename != null) {
            var word = new WordFrequency();
            if(word.ReadFile(filename)) {
                word.OutputConsole();
                word.OutputFile();
            }
        }
    }
}

class WordFrequency {
    List<string> input = new List<string>();
    int result = 0;
    public bool ReadFile(string filename) {
        if(!File.Exists(filename)){
            Error.ErrorFilename();
            return false;
        }
        string [] DataFile = File.ReadAllLines(filename);
        foreach(var item in DataFile) {
            input.Add(item);
        }
        return true;
    }

    public void OutputConsole(){
        int countStrings = int.Parse(input[0]);
        if(countStrings <= 0){
            Error.ErrorSize();
            return;
        } 

        if(input.Count - 2 < countStrings){
            Error.ErrorCountStrings();
            return;
        }
       
        for(int i = 1; i <= countStrings + 1; i++) {
            Console.WriteLine(input[i]);
        }
        string word = input[countStrings + 1];
        for(int i = 1; i <= countStrings; i++) {
            string [] buffer = input[i].Split(word);
            if(buffer.Length == 0) {
                result++;
            } else if( buffer.Length > 1) {
                result += buffer.Length - 1;
            }
        }
        Console.WriteLine(result);
    }

    public void OutputFile() {
        string filename = "result.txt";
        if(!File.Exists(filename)){
             using (FileStream fs = File.Create(filename)) {}
        }
        string result_string = $"{result}";
        File.WriteAllText(filename, result_string);
       
    }
}

class Error {
    public static void ErrorSize() => Console.WriteLine("Input error. Size <= 0");
    public static void ErrorCountStrings() => Console.WriteLine("Input error. Insufficient number of elements");
    public static void ErrorFilename() => Console.WriteLine("Input error. File isn't exist");
}