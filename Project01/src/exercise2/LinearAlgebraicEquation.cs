public class LinearAlgebraicEquation {
    public string ? filename { get; set; } 
    List<List<double>> matrix = new List<List<double>>();
    public int SizeMatrix { get; set; }

    public void Calculation() {
        Console.WriteLine("Уnter a file name : ");
        filename = Console.ReadLine();
        if(!ReadMatrixFromFile.IsCorrectFile(filename)) return;
        matrix = ReadMatrixFromFile.ReadMatrix(filename!);
        if(!IsCorrectMatrix()) {
            OutputUser.ErrorCalculation();
            return;
        }

        List<double> result = GaussMethod.Calculation(matrix, SizeMatrix);
        OutputUser.ResultEquation(result);

    }

    private bool IsCorrectMatrix() {
        bool code = true;
        int prev_i = 0;
        for(int i = 1; i < matrix.Count; i++) {
            if(matrix[prev_i].Count != matrix[i].Count || matrix[prev_i].Count == 0) {
                code = false;
                break;
            }
        }
        if(matrix.Count != (matrix[0].Count - 1)) {
            code = false;
        }
        SizeMatrix = matrix.Count;
        return code;
    }

}