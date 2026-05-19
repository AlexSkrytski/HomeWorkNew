namespace HomeWork3
{
    class Program
    {
        static void Main()
        {
           // LoginPasswordVerification();
            VowelsCounter();
           // ScoresGrateCheck();
        }
        static void LoginPasswordVerification()
        {
            string correctLogin = "Alex";
            string correctPassword = "qwerty";
            int i = 3; // amounts number
            bool correctData = false;

            do
            {
                Console.WriteLine("Input Login:");
                Console.WriteLine($"{i} attempts left.");
                string login = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Input Password:");
                string password = Console.ReadLine() ?? string.Empty;

                if (correctLogin == login && correctPassword == password)
                {
                    correctData = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Login or Password!");
                    i--;
                }
            } while (i != 0);

            if (correctData)
            {
                Console.WriteLine("Success sign in!");
            }
            else
            {
                Console.WriteLine("No more attempts left!");
            }
        }
        static void VowelsCounter()
        {

            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine() ?? string.Empty; ;
            string lowerText = text.ToLower();

            int vowelsCount = 0;

            char[] vawelsArray = { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'з', 'ю', 'я' };

            foreach (char stringItem in lowerText)
            {
                for (int i = 0; i < vawelsArray.Length - 1; i++)
                {
                    if (stringItem == vawelsArray[i])
                    {
                        vowelsCount++;
                    }
                }
            }

            Console.WriteLine($"Всего гласных: {vowelsCount}.");

        }
        static void ScoresGrateCheck()
        {
            int score = 80;

            string grade = score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };

            Console.WriteLine(grade);

        }
    }
}
