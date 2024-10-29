using System;


class Program
{
    static void Main() {
        ConvexQuadrilateral quadrilateral = new ConvexQuadrilateral
        {
            A = new Coordinate(),
            B = new Coordinate(),
            C = new Coordinate(),
            D = new Coordinate()
        };

        quadrilateral.A.x = UserInput.ReadNumber();
        quadrilateral.A.y = UserInput.ReadNumber();
        quadrilateral.B.x = UserInput.ReadNumber();
        quadrilateral.B.y = UserInput.ReadNumber();
        quadrilateral.C.x = UserInput.ReadNumber();
        quadrilateral.C.y = UserInput.ReadNumber();
        quadrilateral.D.x = UserInput.ReadNumber();
        quadrilateral.D.y = UserInput.ReadNumber();

        UserOutput.ResultSquare(quadrilateral.GetSquare());
    }
}




public class UserInput {
    public static double ReadNumber() {
        double number;
        string numberString = Console.ReadLine();
        while(!double.TryParse(numberString, out number)) {
            UserOutput.ErrorNumber();
        }
        return number;
    }

}

public class UserOutput {
    public static void ErrorNumber() {
        Console.WriteLine("Couldn't parse a number. Please, try again ");
    }

    public static void ResultSquare(double square) {
        Console.WriteLine($"Square = {square}");
    }
    
}

public class ConvexQuadrilateral {
    public Coordinate A { get; set; }
    public Coordinate B { get; set; }
    public Coordinate C { get; set; }
    public Coordinate D { get; set; }

    public double GetSquare() {
        double square = SquareTriangel.GetSquareTriangel(A, B, D) + SquareTriangel.GetSquareTriangel(C, B, D);
        return square;
    }
}

public class Coordinate {
    public double x { get; set; }
    public double y { get; set; }
}


public class SquareTriangel {
    public static double GetSquareTriangel(Coordinate A, Coordinate B, Coordinate C) {
        double square = 0.5 * Math.Abs(A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.x - B.y));
        return square;
    }
}


