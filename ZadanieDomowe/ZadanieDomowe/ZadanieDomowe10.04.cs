using System;
using System.Text;

namespace ZadanieDomowe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char key = ' ';
            Console.Clear();
            do
            {
                Console.WriteLine("Wybierz ćwiczenie które chcesz uruchomić.");
                Console.WriteLine("Wciśnij 1 aby uruchomić Konwerter cyfr na słowa.");
                Console.WriteLine("Wciśnij 2 aby uruchomić Interpreter klawiszy.");
                Console.WriteLine("Aby zamknąć program wciśnij q");

                key = Console.ReadKey(true).KeyChar;

                if (key == '1')
                {
                    Console.Clear();
                    DigitsConverter.ShowDigitsAsWords();
                    Console.WriteLine("\t");
                }
                else if (key == '2')
                {
                    Console.Clear();
                    KeyInterpreter.PressKeyApp();
                    Console.WriteLine("\t");
                }
                else if (char.ToLower(key) != 'q')
                {
                    Console.Clear();
                    Console.WriteLine("Wybrano niewłaściwy klawisz. Spróbuj jeszcze raz!\n");
                }

            } while (char.ToLower(key) != 'q');
        }
    }


    public static class DigitsConverter
    {
        public static void ShowDigitsAsWords()
        {
            Console.Write("Zmiana cyfr na słowa. Wprowadź liczbę całkowitą: ");
            string text = Console.ReadLine();

            char[] digits = text.ToCharArray();

            StringBuilder textOut = new StringBuilder();

            foreach (char digit in digits)
            {
                textOut.Append($"{(DigitsInWords)digit} ");
            }

            Console.Write(textOut.ToString());
        }

        enum DigitsInWords
        {
            zero = 48,
            one,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine
        }
    }

    public static class KeyInterpreter
    {
        public static void PressKeyApp()
        {
            char character = ' ';

            while (char.ToLower(character) != 'q')
            {
                Console.Write("Press any key: ");
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                character = consoleKey.KeyChar;

                Console.Clear();

                if (char.IsControl(character))
                {
                    Console.WriteLine($"Wciśnięto klawisz funkcyjny: {consoleKey.Key}.");
                }
                else if (char.IsDigit(character))
                {
                    Console.WriteLine($"Wciśnięto klawisz z cyfrą '{character.ToString()}' o numerze ASCII: {(int)character}.");
                }
                else
                {
                    Console.WriteLine($"kliknięto klawisz ze znakiem tekstowym '{character.ToString()}' o numerze ASCII: {(int)character}.");
                }
            }

            Console.WriteLine($"Został kliknięty klawisz '{character.ToString()}'. Program zostanie zakończony.");
        }
    }
}
