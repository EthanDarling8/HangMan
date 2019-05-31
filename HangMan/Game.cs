using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace HangMan {
    public class Game {
        private static IList<String> words = new List<string>();
        private static Random rand = new Random();

        public static void Introduction() {
            Console.SetCursorPosition(7, 3);
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < 19; i++) {
                Console.CursorLeft = 7;
                Console.WriteLine("                                             ");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(19, 4);
            Console.WriteLine("Welcome to hangman!");
            Console.CursorLeft = 19;
            Console.WriteLine("Press Enter to play.");

            ConsoleKeyInfo cursor = Console.ReadKey();
            if (cursor.Key == ConsoleKey.Enter) {
                words = Generate();
                int randomWord = rand.Next(words.Count);
                Console.WriteLine(words[randomWord]);
                while (true) {
                    Thread.Sleep(100);
                }
            }
            else {
                Thread.Sleep(100);
            }
        }

        public static IList<String> Generate() {
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
    }
}