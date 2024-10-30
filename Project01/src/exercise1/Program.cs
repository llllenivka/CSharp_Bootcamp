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

        quadrilateral = UserInput.ReadCoordinates(quadrilateral);

        UserOutput.ResultSquare(quadrilateral.GetSquare());
    }
}




public class UserInput {
    public static ConvexQuadrilateral ReadCoordinates(ConvexQuadrilateral quadrilateral) {
        quadrilateral.A = ReadCoordinate(quadrilateral.A);
        quadrilateral.B = ReadCoordinate(quadrilateral.B);
        quadrilateral.C = ReadCoordinate(quadrilateral.C);
        quadrilateral.D = ReadCoordinate(quadrilateral.D);

        return quadrilateral;
    }

    public static Coordinate ReadCoordinate(Coordinate coordinate) {
        coordinate.x = ReadNumber(coordinate.x);
        coordinate.y = ReadNumber(coordinate.y);
        return coordinate;
    }
    public static double ReadNumber(double number) {
        while(true) {
            string numberString = Console.ReadLine();
            if(double.TryParse(numberString, out number)) {
                return number;
            } else {
                UserOutput.ErrorNumber();
            }
        }
    }

}

public class UserOutput {
    public static void ErrorNumber() {
        Console.WriteLine("Couldn't parse a number. Please, try again");
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
        double square = 0.5 * Math.Abs(A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.y - B.y));
        return square;
    }
}