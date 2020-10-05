using System;
using System.Collections.Generic;
using System.IO;

namespace myapp
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
                ANSWERS
                    Q1: 138
                    Q2: 2565
                    Q3: 164
                    Q4: 3176
            **/

            Console.WriteLine("Q1. " + Q1());
            Console.WriteLine("Q2. " + Q2());
            Console.WriteLine("Q3. " + Q3());
            Console.WriteLine("Q4. a = " + Q4());
            
        }

        static int Q1()
        {
            StreamReader reader = File.OpenText("question01_input.txt");
            string line = reader.ReadLine();

            if (line.Length == 0) return 0;

            int upCount = line.Replace(")", "").Length;
            int downCount = line.Length - upCount;
            return upCount - downCount;
        }

        static int Q2()
        {
            StreamReader reader = File.OpenText("question02_input.txt");
            string moves = reader.ReadLine();

            if (moves.Length == 0) return 1;

            HashSet<string> visited = new HashSet<string>();
            int xPos = 0;
            int yPos = 0;

            visited.Add(xPos+","+yPos);

            foreach (char move in moves)
            {
                switch(move)
                {
                    case '>':
                        yPos++;
                        break;
                    case '<':
                        yPos--;
                        break;
                    case '^':
                        xPos++;
                        break;
                    case 'v':
                        xPos--;
                        break;
                    default:
                        break;
                }
                
                visited.Add(xPos+","+yPos);
            }

            return visited.Count;
        }

        static int Q3() {
            StreamReader reader = File.OpenText("question03_input.txt");
            string line;
            int goodStrings = 0;

            while ((line = reader.ReadLine()) != null) 
            {
                bool noConseq = true;
                bool isDouble = false;
                int vowelCount = 0;
                int prev = -1;

                foreach (char c in line)
                {
                    int curr = (int) c;

                    // check if one set of two identical characters 
                    if (prev == curr)
                    {
                        isDouble = true;
                    }

                    // check if containing consecutive characters
                    if (prev == curr-1)
                    {
                        noConseq = false;
                        break;
                    }

                    // count vowels
                    if ("AEIOUaeiou".IndexOf(c) != -1)
                    {
                        vowelCount++;
                    }

                    prev = curr;
                }

                if (noConseq && isDouble && vowelCount >= 3) 
                {
                    goodStrings++;
                }

            }
            return goodStrings;
        }

        static int Q4() {
            StreamReader reader = File.OpenText("question04_input.txt");
            string line;

            var signals = new Dictionary<string, int>();
            Queue<string> instructions = new Queue<string>();

            while ((line = reader.ReadLine()) != null) 
            {
                string[] requests = line.Split(" ");
                int i;

                if (int.TryParse(requests[0], out i) && requests.Length == 3)
                {
                    signals.Add(requests[2], i);
                }
                else 
                {
                    instructions.Enqueue(line);
                }
            }

            while (instructions.Count > 0)
            {
                string currReq = instructions.Dequeue();
                string[] requests = currReq.Split(" ");

                if (requests[0].Equals("NOT")) 
                {
                    int value;
                    if (signals.TryGetValue(requests[1], out value)) 
                    {
                        string not = Convert.ToString(~value, 2).Substring(16,16);
                        signals.Add(requests[3], Convert.ToInt32(not, 2));
                    }
                    else
                    {
                        instructions.Enqueue(currReq);
                    }
                }
                else
                {
                    int var1;
                    int var2;
                    int int1;
                    int calculated = -1;
                    Boolean enqueued = false;

                    switch(requests[1])
                    {
                        case "AND":
                            if (signals.TryGetValue(requests[0], out var1) &&
                            signals.TryGetValue(requests[2], out var2))
                            {
                                calculated = var1 & var2;
                                break;
                            }
                            if (int.TryParse(requests[0], out int1) &&
                            signals.TryGetValue(requests[2], out var2))
                            {
                                calculated = int1 & var2;
                                break;
                            }
                            else {
                                instructions.Enqueue(currReq);
                                enqueued = true;
                            }
                            break;

                        case "OR":
                            if (signals.TryGetValue(requests[0], out var1) &&
                            signals.TryGetValue(requests[2], out var2))
                            {
                                calculated = var1 | var2;
                            }
                            else
                            {
                                instructions.Enqueue(currReq);
                                enqueued = true;
                            }
                            break;

                        case "LSHIFT":
                            if (signals.TryGetValue(requests[0], out var1) && 
                            int.TryParse(requests[2], out int1))
                            {
                                //Console.WriteLine("Binary "+Convert.ToString(var1,2));
                                //string ls = Convert.ToString(var1, 2).Substring(16,16);
                                //Console.WriteLine(Convert.ToString(var1));
                                calculated = var1 << int1;
                                string ls = Convert.ToString(calculated, 2);
                                if (ls.Length > 16) {
                                    Console.WriteLine(ls);
                                    ls = ls.Substring(ls.Length-16, 16);
                                    Console.WriteLine(ls);
                                }
                                calculated = Convert.ToInt32(ls, 2);
                                //Console.WriteLine("Calculated "+calculated+ " "+ls);
                            }
                            else
                            {
                                instructions.Enqueue(currReq);
                                enqueued = true;
                            }
                            break;
                        case "RSHIFT":
                            if (signals.TryGetValue(requests[0], out var1) && 
                            int.TryParse(requests[2], out int1))
                            {
                                calculated = var1 >> int1;
                            }
                            else
                            {
                                instructions.Enqueue(currReq);
                                enqueued = true;
                            }
                            break;
                        case "->":
                            if (signals.TryGetValue(requests[0], out var1))
                                {
                                    calculated = var1;
                                    signals.Add(requests[2], calculated);
                                }
                            else
                            {
                                instructions.Enqueue(currReq);
                                enqueued = true;
                            }
                            break;
                        default:
                            break;
                    }
                    if (!enqueued && requests[1] != "->") {
                        signals.Add(requests[4], calculated);
                    }
                }

            }

            int a;
            if (!signals.TryGetValue("a", out a))
            {
                Console.WriteLine("Cannot Find a");
            }

            return a;
        }
    }
}
