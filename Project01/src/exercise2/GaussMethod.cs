public class GaussMethod {
    public static List<double> Calculation(List<List<double>> matrix, int sizeMatrix) {
        var result = new List<double>();

        for(int i = 0; i < sizeMatrix; i++) {
            double temp = matrix[i][i];
            matrix[i] = DivideLine(matrix[i], temp);

            for(int j = i + 1; j < sizeMatrix; j++) {
                var subtracted = new List<double>(matrix[i]);
                subtracted = MultiLine(subtracted, matrix[j][i]);
                matrix[j] = SubFromLine(matrix[j], subtracted);
            }

        }

        for(int i = sizeMatrix - 1; i >= 0; i--) {
            for(int j = i - 1; j >= 0; j--) {
                var subtracted = new List<double>(matrix[i]);
                subtracted = MultiLine(subtracted, matrix[j][i]);
                matrix[j] = SubFromLine(matrix[j], subtracted);
            }

        }
        for(int i = 0; i < sizeMatrix; i++) {
            result.Add(matrix[i][sizeMatrix]);
        }
        
        return result;
    }

    private static List<double> DivideLine(List<double> line, double divider) {
            for(int i = 0; i < line.Count; i++) line[i] /= divider;
        return line;
    }

    private static List<double> SubFromLine(List<double> line, List<double> subtracted) {
            for(int i = 0; i < line.Count; i++) line[i] -= subtracted[i];
        return line;
    }

    private static List<double> MultiLine(List<double> line, double multiplier) {
            for(int i = 0; i < line.Count; i++) line[i] *= multiplier;
        return line;
    }


}