
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace HangMan {
    public class Game {
        private static IList<String> words = new List<string>();
        private static Random rand = new Random();
        private static String randomWord;
        
        /// <summary>
        /// Displays introduction text and calls Generate method
        /// </summary>
        public static void Introduction() {
            DrawBackground();
            Console.SetCursorPosition(19, 4);
            Console.WriteLine("Welcome to hangman!");
            Console.CursorLeft = 19;
            Console.WriteLine("Press Enter to play.");

            ConsoleKeyInfo cursor = Console.ReadKey();
            if (cursor.Key == ConsoleKey.Enter) {
                words = Generate();
                int temp = rand.Next(words.Count);
                randomWord = words[temp];
                DrawMan(0);
            }
        }

        private static void DrawBackground() {
            Console.SetCursorPosition(7, 3);
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < 19; i++) {
                Console.CursorLeft = 7;
                Console.WriteLine("                                             ");
            }
            Console.ForegroundColor = ConsoleColor.Red;
        }

        /// <summary>
        /// Generates a IList of words that are greater than 3 and less than 8
        /// characters in length. All words are letters only, no symbols or numbers.
        /// </summary>a
        /// <returns>IList of type String</returns>
        private static IList<String> Generate() {
            IList<String> wordList = new List<string>();
            try {
                using (StreamReader reader = new StreamReader(
                    Directory.GetCurrentDirectory() + "/words.txt")) {
                    while (!reader.EndOfStream) {
                        string temp = reader.ReadLine();
                        if (temp != null && temp.Length > 2 && temp.Length < 8) {
                            wordList.Add(temp);
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("Could not load words.");
                Console.WriteLine(e);
                throw;
            }
            return wordList;
        }

        public static void DrawMan(int situation) {
            DrawBackground();
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("Enter a letter to guess.");
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("You have TODO guesses left.\n");
            Console.SetCursorPosition(20, 6);
            if (situation == 0) {
                HangTop();
                for (int i = 0; i < 8; i++) {
                    Console.CursorLeft = 15;
                    Console.WriteLine("|           ");
                }
                HangBase();
            }
            else if (situation == 1) {
                
            }

            while (true) {
                Thread.Sleep(100);
            }
        }

        private static void HangTop() {
            Console.CursorLeft = 15;
            Console.WriteLine("____________");
            Console.CursorLeft = 15;
            Console.WriteLine("| /        |");
            Console.CursorLeft = 15;
            Console.WriteLine("|/         |");
        }

        private static void HangBase() {
            Console.CursorLeft = 15;
            Console.WriteLine("|\\         ");
            Console.CursorLeft = 13;
            Console.WriteLine("__|_\\____________");
            Console.CursorLeft = 13;
            Console.WriteLine("- - - - - - - - -");
        }
    }
}