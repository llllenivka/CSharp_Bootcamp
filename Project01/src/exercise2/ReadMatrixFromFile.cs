public class ReadMatrixFromFile {
    public static bool  IsCorrectFile(string ? filename) {
        bool code = true;
        // filename = Console.ReadLine(); ПОТОМ ДОБАВЬ!!!!!!!!!!!!
        if(!File.Exists(filename)) {
            OutputUser.ErrorFile();
            code = false;
        }
        
        return code;
    }

    public static string[] ReadString(string filename) {
        return File.ReadAllLines(filename);
    }

    public static List<List<int>> ReadMatrix(string filename) {
        List<List<int>> matrix = new List<List<int>>();
        string[] matrixString = ReadString(filename);

        foreach(var line in matrixString) {
            matrix.Add(PushMatrix(line));
        }
        return matrix;
    }

    private static List<int> PushMatrix(string line) {
        List<int> lineOfMatrix = new List<int>();
        string[] splitLine = line.Split(" ");

        foreach(var numberString in splitLine) {
            int number;
            if(!int.TryParse(numberString, out  number)) {
                OutputUser.ErrorNumber();
            } else {
                lineOfMatrix.Add(number);
            }
        }

        return lineOfMatrix;
    }
}