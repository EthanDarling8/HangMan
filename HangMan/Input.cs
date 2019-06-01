using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

// ReSharper disable All

namespace HangMan {
    public class Input {
        private static char input;
        private static String word = Game.GetWord();
        private static bool win = false;
        private static ISet<char> inputSet = new SortedSet<char>();
        private static IList<char> wordList = new List<char>();
        private static int situationCount = 0;

        public static void PopulateWordList() {
            wordList.Add('_');
        }        

        public static void InputCheck() {
            PrintInputs();

            while (!win) {
                input = Console.ReadKey().KeyChar;
                inputSet.Add(input);
                
                if (input != null && word.Contains(input)) {
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
                else {
                    Game.SetSituation(++situationCount);
                    Game.DrawMan();
                }
                PrintInputs();
                checkWin();
            }

            Console.WriteLine("A winner is you!");
            while (true) {
                Thread.Sleep(100);
            }
        }

        public static void WordResults() {
            foreach (var c in wordList) {
                Console.Write("{0} ", c);
            }
        }

        private static void PrintInputs() {
            Console.SetCursorPosition(38, 8);
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
            }
        }
    }
}