using Algebra;
using Exceptions;

namespace Geometry
{
    internal class GeometricShape
    {
        private short cornersAmount;
        private const short Height = 25;

        public short CornersAmount
        {
            get { return cornersAmount; }
            set { cornersAmount = value; }
        }

        public GeometricShape()
        {
            CornersAmount = 3;
        }
        public GeometricShape(short cornersAmount)
        {
            if (cornersAmount > 5)
                this.CornersAmount = 5;
            else
                this.CornersAmount = cornersAmount;
        }

        public void Show()
        {
            short[,] cornersPositions = new short[2, CornersAmount];
            cornersPositions[0, 0] = Height / 2;
            cornersPositions[1, 0] = 0;
            if (CornersAmount % 2 == 0)
            {
                cornersPositions[0, CornersAmount / 2] = Height / 2;
                cornersPositions[1, CornersAmount / 2] = Height - 1;
            }
            NumberWithSquareRoot side = new NumberWithSquareRoot(Height, (float)Math.Pow(Math.Sin(Math.PI / CornersAmount), 2));
            //Console.WriteLine($"{side.BeforeRoot}*({side.UnderRoot}) has to be: {Math.Pow(Math.Sin(Math.PI / CornersAmount), 2)}\tside: {side.BeforeRoot * side.BeforeRoot * side.UnderRoot}");
            //float side = (float)(Height * Math.Sin(Math.PI / CornersAmount));
            short currentCorner = 1;
            for (short i = 0; i < Height; i++)
            {
                int temp = CornersAmount % 2 == 0 ? 1 : 0;
                if (currentCorner - 1 == CornersAmount / 2 - temp)
                    break;
                for (short j = 0; j < Height; j++)
                {
                    //float potentialSide = (float)Math.Sqrt(Math.Pow(j - cornersPositions[0, currentCorner - 1], 2) + Math.Pow(i - cornersPositions[1, currentCorner - 1], 2));
                    //float distanceToCenter = (float)Math.Sqrt(Math.Pow(j - Height / 2, 2) + Math.Pow(i - Height / 2, 2));
                    NumberWithSquareRoot potentialSide = new NumberWithSquareRoot(1, (float)(Math.Pow(j - cornersPositions[0, currentCorner - 1], 2) + Math.Pow(i - cornersPositions[1, currentCorner - 1], 2)));
                    NumberWithSquareRoot distanceToCenter = new NumberWithSquareRoot(1, (float)(Math.Pow(j - Height / 2, 2) + Math.Pow(i - Height / 2, 2)));
                    //if (distanceToCenter.Equals(new NumberWithSquareRoot(Height / 2, 1)) && potentialSide.Equals(side))/*distanceToCenter >= 11.97 && distanceToCenter <= 12.03*//*(potentialSide - side >= -0.1 && potentialSide - side <= 0.1) || distanceToCenter == (float)12*/
                    if (distanceToCenter.Equals(new NumberWithSquareRoot(Height / 2, 1)) && potentialSide.Equals(side))
                    {
                        //Console.WriteLine($"p: {potentialSide.BeforeRoot}*{potentialSide.UnderRoot}\t\td: {distanceToCenter.BeforeRoot}*{distanceToCenter.UnderRoot}\txy: ({j},{i})\t\tps: {potentialSide.BeforeRoot * potentialSide.BeforeRoot * potentialSide.UnderRoot}\tdtc: {distanceToCenter.BeforeRoot * distanceToCenter.BeforeRoot * distanceToCenter.UnderRoot}");
                        cornersPositions[0, currentCorner] = j;
                        cornersPositions[1, currentCorner] = i;
                        cornersPositions[0, CornersAmount - currentCorner] = Convert.ToInt16(Height - j - 1);
                        cornersPositions[1, CornersAmount - currentCorner] = i;
                        currentCorner++;
                        break;
                    }
                }
            }

            //for (int i = 0; i < CornersAmount; i++)
            //    Console.Write($"({cornersPositions[0, i]}, {cornersPositions[1, i]}) ");
            //Console.WriteLine();

            //short tmp = 0;
            //for (int i = 0; i < Height; i++)
            //{
            //    for (int j = 0; j < Height; j++)
            //    {
            //        if (cornersPositions[0, tmp] == j && cornersPositions[1, tmp] == i)
            //        {
            //            if (i == 0 || i == Height - 1)
            //                Console.WriteLine("**");
            //            else
            //            {
            //                string spaces = new string(' ', 2 * (cornersPositions[0, CornersAmount - tmp] - cornersPositions[0, tmp]));
            //                Console.Write($"**{spaces}**");
            //            }
            //            tmp++;
            //            break;
            //        }
            //        else
            //        {
            //            Console.Write("  ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

            short tmp = 0;
            for (int i = 0; i < Height; i++)
            {
                int left_border = -1;
                int right_border = -1;
                if (CornersAmount == 2)
                {
                    left_border = Height / 2;
                    right_border = Height / 2;
                }
                else if (tmp == CornersAmount - 1)
                {
                    left_border *= 1;
                    right_border *= 1;
                }
                else
                {
                    short X_corner_1 = 0;
                    short X_corner_2 = 0;
                    int X_distance = 0;
                    short Y_corner_1 = 0;
                    short Y_corner_2 = 0;
                    int Y_distance = 0;
                    if (CornersAmount % 2 == 0 || tmp == 0)
                    {
                        X_corner_1 = cornersPositions[0, tmp];
                        X_corner_2 = cornersPositions[0, tmp + 1];
                        Y_corner_1 = cornersPositions[1, tmp];
                        Y_corner_2 = cornersPositions[1, tmp + 1];
                    }
                    else
                    {
                        X_corner_1 = cornersPositions[0, tmp - 1];
                        X_corner_2 = cornersPositions[0, tmp];
                        Y_corner_1 = cornersPositions[1, tmp - 1];
                        Y_corner_2 = cornersPositions[1, tmp];
                    }
                    X_distance = X_corner_2 - X_corner_1;
                    Y_distance = Y_corner_2 - Y_corner_1;
                    if (Y_distance != 0)
                    {
                        float step = (float)X_distance / Y_distance;
                        if (step == 0)
                            step += 1;
                        left_border = Convert.ToInt32(X_corner_1 - step * (i - Y_corner_1));
                        if (left_border < 0)
                            left_border *= -1;
                        if (left_border > Height / 2)
                        {
                            right_border = left_border;
                            left_border = Height - right_border - 1;
                        }
                        else
                            right_border = Height - left_border - 1;
                        //Console.WriteLine($"xd: {X_distance} yd: {Y_distance}");
                    }
                }
                //Console.WriteLine($"lb: {left_border} rb: {right_border} ca: {CornersAmount}");
                for (int j = 0; j < Height; j++)
                {
                    if (cornersPositions[0, tmp] == j && cornersPositions[1, tmp] == i)
                    {
                        if (i == 0 || i == Height - 1)
                            Console.Write("**");
                        else
                        {
                            string stars = new string('*', 4 + 2 * (cornersPositions[0, CornersAmount - tmp] - cornersPositions[0, tmp]));
                            Console.Write(stars);
                        }
                        tmp++;
                        break;
                    }
                    else
                    {
                        if (left_border <= j && j <= right_border)
                            Console.Write("**");
                        else
                            Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }
        public void HowManyCorners()
        {
            Console.WriteLine("How many corners does this geometric figure have? ");
            short corners = 0;
            do
            {
                corners = short.Parse(Console.ReadLine());
                if (corners != CornersAmount)
                {
                    try
                    {
                        throw new WrongCornersAmountException();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.Message} Try again");
                    }
                }
            } while (corners != CornersAmount);
            Console.WriteLine("You are right! Well done!");
        }
    }
}
