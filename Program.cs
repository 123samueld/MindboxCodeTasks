using System;

namespace MindboxCodeTask_GeometryCalc
{
    class GeometryCalc
    {

        int numberOfSidesOfShape = 0;
        decimal areaOfShape = 0;
        decimal lengthOfSide1 = 0;
        decimal lengthOfSide2 = 0;
        decimal lengthOfSide3 = 0;
        bool illegalTriangle = true;
        bool isRightAngleTriangle = false;

        string answerForUser = "";
        
        public static void Main()
        {
            GeometryCalc geoCalc = new GeometryCalc();
            geoCalc.HowManySides();
        }

        public int HowManySides()
        {
            Console.WriteLine("Welcome to the shape calculator");
            while(numberOfSidesOfShape==0)
            {
                Console.WriteLine("Please choose how many sides your shape has: (Circle has 1, Triangle has 3 etc)");
                numberOfSidesOfShape = Int32.Parse(Console.ReadLine());
                if(numberOfSidesOfShape == 0 || numberOfSidesOfShape == 2)
                {
                    Console.WriteLine("Sorry, no geometric shapes have "+ numberOfSidesOfShape+ " sides.");
                    numberOfSidesOfShape = 0;
                }
            }
            switch (numberOfSidesOfShape)
            {
                case 1:
                    Console.WriteLine("You choose 1 side so the shape is a cirle.");
                    Console.WriteLine("What is the radius of the circle? ");
                    decimal circleRadius = Int32.Parse(Console.ReadLine());
                    areaOfShape = AreaOfCircle(circleRadius);
                    answerForUser = "The area of the circle is " + areaOfShape;                     
                    GiveUserAnswer(answerForUser);
                    break;
                case 3:
                    Console.WriteLine("You choose 3 sides so the shape is a triangle.");
                    string equilateral = "";
                    while(equilateral != "y" && equilateral != "n")
                    {
                        Console.WriteLine("Is the triangle equilateral (all sides equal length)? (y/n)");
                        equilateral = Console.ReadLine().ToLower();
                    }
                    if(equilateral == "y")
                    {
                        Console.WriteLine("What length are the sides? ");
                        lengthOfSide1 = Int32.Parse(Console.ReadLine());
                        lengthOfSide2 = lengthOfSide1;
                        lengthOfSide3 = lengthOfSide2;
                    }
                    else if(equilateral == "n")
                    {
                        while(illegalTriangle)
                        {
                            Console.WriteLine("Please enter the lengths of all the sides. ");
                            Console.WriteLine("Side 1?");
                            lengthOfSide1 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Side 2?");
                            lengthOfSide2 = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Side 3?");
                            lengthOfSide3 = Int32.Parse(Console.ReadLine());
                            decimal[] arrayOfSideLengths = { lengthOfSide1, lengthOfSide2, lengthOfSide3 };
                            Array.Sort(arrayOfSideLengths);
                            if (arrayOfSideLengths[0] + arrayOfSideLengths[1] > arrayOfSideLengths[2])
                            {
                                illegalTriangle = false;
                            }else
                            {
                                Console.WriteLine("Sorry, that's not a legitimate triangle.");
                                Console.WriteLine("The sum of the 2 shortest sides must be greater than the longest side");
                                Console.WriteLine("Please try again.");
                            }
                        }

                        isRightAngleTriangle = TriangleIsRightAngled(lengthOfSide1, lengthOfSide2, lengthOfSide3);
                    }
                    

                    areaOfShape = AreaOfTriangle(lengthOfSide1, lengthOfSide2, lengthOfSide3);
                    answerForUser = "The area of the triangle is " + areaOfShape;
                    GiveUserAnswer(answerForUser);

                    if (isRightAngleTriangle) 
                    {
                        answerForUser = "The triangle is rectangular (right angled).";
                    }
                    else
                    {
                        answerForUser = "The triangle is not rectangular (right angled).";
                    }
                    GiveUserAnswer(answerForUser);
                    break;
                default:
                    Console.WriteLine("Sorry, a shapes with "+numberOfSidesOfShape+ " sides haven't been programmed yet.");
                    break;
            }
            return 0;
        }
        public decimal AreaOfCircle(decimal radius)
        {
            decimal area = (decimal)Math.Pow((double)radius, 2);
            return area;
        }

        public decimal AreaOfTriangle(decimal side1, decimal side2, decimal side3)
        {
            double s, area = 0;         

            s = ((double)side1 + (double)side2 + (double)side3) / 2;
            area = Math.Sqrt(s * (s - (double)side1) * (s - (double)side2) * (s - (double)side3));

            return Convert.ToDecimal(area);
        }
        public bool TriangleIsRightAngled(decimal side1, decimal side2, decimal side3)
        {
            bool isRightAngleTriangle = false;
            decimal[] squaresOfSides = { side1 * side1, side2 * side2, side3 * side3 };
            Array.Sort(squaresOfSides);
            if (squaresOfSides[0] + squaresOfSides[1] == squaresOfSides[2]) { isRightAngleTriangle = true; }
            return isRightAngleTriangle;
        }
        public string GiveUserAnswer(string answer)
        {
            Console.WriteLine(answer);
            return answer;
        }
    }
}
