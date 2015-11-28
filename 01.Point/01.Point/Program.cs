namespace Point
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            string startingPoint = ">>><<<~>>>~^^^";
            char[] chars = startingPoint.ToLower().ToCharArray();
            bool reverse = false;

            int x = 0;
            int y = 0;

            foreach (var ch in chars)
            {
                if (reverse == false)
                {
                    switch (ch)
                    {
                        case 'v':
                            y++;
                            break;
                        case '^':
                            y--;
                            break;
                        case '<':
                            x--;
                            break;
                        case '>':
                            x++;
                            break;
                        case '~':
                            reverse = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (ch)
                    {
                        case 'v':
                            y--;
                            break;
                        case '^':
                            y++;
                            break;
                        case '<':
                            x++;
                            break;
                        case '>':
                            x--;
                            break;
                        case '~':
                            reverse = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("The result is: (x= {0} ; y= {1})", x, y);
        }
    }
}
