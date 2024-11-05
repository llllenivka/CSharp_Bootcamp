public class LinearAlgebraicEquation {
    public string filename = "1.txt";  // public string filename { get; set; } ПОМЕНЯЯЯТЬ!!!!!!!!
    List<List<int>> matrix = new List<List<int>>();
    public int rows { get; set; }
    public int cols { get; set; }

    public void Calculation() {
        if(!ReadMatrixFromFile.IsCorrectFile(filename)) return;
        matrix = ReadMatrixFromFile.ReadMatrix(filename);
        if(!IsCorrectMatrix()) {
            OutputUser.ErrorCalculation();
            return;
        }
    }

    private bool IsCorrectMatrix() {
        bool code = true;
        int prev_i = 0;
        for(int i = 1; i < matrix.Count; i++) {
            if(matrix[prev_i].Count != matrix[i].Count) {
                code = false;
                break;
            }
        }
        return code;
    }
}