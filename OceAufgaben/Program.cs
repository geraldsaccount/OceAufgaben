using System;

namespace OceAufgaben {
    internal class Program {
        private static void Main(string[] args) {
            ConsoleKey confirmKey;
            do {
                Console.Clear();
                int player1 = 0;
                int player2 = 0;

                Console.WriteLine("Spieler 1 bitte gib deine Zahl ein.");
                while (!int.TryParse(Console.ReadLine(), out player1)) {
                    Console.WriteLine($"Das war keine Zahl.");
                }
                
                Console.Clear();
                Console.WriteLine("Spieler 2 bitte gib deine Zahl ein.");
                while (!int.TryParse(Console.ReadLine(), out player2)) {
                    Console.WriteLine($"Das war keine Zahl.");
                }

                if (player1 > player2) {
                    Console.WriteLine("Spieler 1 hat gewonnen.");
                } else if(player2 > player1) {
                    Console.WriteLine("Spieler 2 hat gewonnen.");
                } else {
                    Console.WriteLine("Gleichstand, wie langweilig.");
                }
                
                Console.WriteLine("Wollt ihr nochmal spielen. Y/N");
                confirmKey = Console.ReadKey(true).Key;
                
            } while (confirmKey == ConsoleKey.Y);
            
            //
            // if (int.TryParse(input, out result)) { // 2. Wenn die Eingabe eine ganze Zahl ist
            //     // 2.1. Console sagt war ne Zahl und gibt sie aus
            //     Console.WriteLine($"{result} ist eine Zahl. Klasse!");
            //     
            //     if (result >= 1 && result <= 100) {
            //         Random rand = new Random();
            //         int randomNumber = rand.Next(1, 101);
            //         
            //         if (randomNumber > result) {
            //             Console.WriteLine($"{randomNumber} ist größer als {result}, du hast verloren.");
            //         } else {
            //             Console.WriteLine($"{result} ist größer als {randomNumber}, du hast gewonnen.");
            //         }
            //         
            //     } else {
            //         Console.WriteLine("Die Zahl darfst du nicht nehmen,du Schummler.");
            //     }
            // } else { // 3. Wenn die Eingabe keine Zahl ist
            //     Console.WriteLine($"{input} ist keine Zahl. Du Dummkopf!"); // 3.1. Console sagt war keine Zahl
            // }
        }
    }
}
