using System;
using System.Collections.Generic;

// ReSharper disable All

namespace HangMan {
    public class Input {
        private static String word = Game.GetWord();
        private static bool win = false;
        private static ISet<char> inputSet = new SortedSet<char>();
        private static IList<char> wordList = new List<char>();
        private static int situationCount = 0;

        public static void PopulateWordList() {
            wordList.Add('_');
        }        

        public static void InputCheck() {
            char input;
            PrintInputs();
            while (!win || situationCount != 6) {
                input = Console.ReadKey().KeyChar;
                inputSet.Add(input);

                if (word.Contains(input.ToString())) {
                    Console.SetCursorPosition(15, 20);
                    for (int i = 0; i < Game.GetWord().Length; i++) {
                        if (word[i].Equals(input)) {
                            Console.SetCursorPosition(15, 20);
                            wordList[i] = input;
                        }
                    }
                    foreach (var c in wordList) {
                        Console.Write("{0} ", c);
                    }
                }
                else if (situationCount < 6) {
                    Game.SetSituation(++situationCount);
                    Game.DrawMan();
                }
                else if (situationCount == 6) {
                    checkWin();
                }
                PrintInputs();
                checkWin();
            }
        }

        public static void WordResults() {
            foreach (var c in wordList) {
                Console.Write("{0} ", c);
            }
        }

        private static void PrintInputs() {
            Console.SetCursorPosition(32, 7);
            Console.WriteLine("Lives left : {0} ", 6 - situationCount);
            int topCounter = 0;
            int leftCounter = 0;
            foreach (char c in inputSet) {
                if (topCounter < 13) {
                    Console.SetCursorPosition(32 + leftCounter, 8 + topCounter++);
                    Console.WriteLine("{0}", c);
                }
                else {
                    leftCounter += 2;
                    Console.SetCursorPosition(32 + leftCounter, 8);
                    Console.WriteLine("{0}", c);
                    topCounter = 0;
                }

            }
            Console.SetCursorPosition(38, 8);
        }

        private static void checkWin() {
            int count = 0;
            for (int i = 0; i < wordList.Count; i++) {
                if (wordList[i].Equals(word[i])) {
                    count++;
                }
            }
            if (count == wordList.Count) {
                win = true;
                Console.Clear();
                Game.DrawBackground();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(10, 3);
                Console.WriteLine("A winner is you! :)");
                Console.CursorLeft = 10;
                Console.WriteLine("The word was {0}", word);
                EndPrompt(10);
            }
            else if (situationCount == 6) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(10, 3);
                Console.WriteLine("A winner is not you :(  ");
                Console.CursorLeft = 10;
                Console.WriteLine("The word was {0}", word);
                Console.SetCursorPosition(32, 7);
                Console.WriteLine("Lives left : 0 ");
                EndPrompt(32);
            }
        }

        private static void EndPrompt(int c) {
            Console.CursorLeft = c;
            Console.WriteLine("Escape to quit");

            ConsoleKeyInfo cursor = Console.ReadKey();
            if (cursor.Key == ConsoleKey.Escape) {
                Environment.Exit(0);
            }
        }
    }
}