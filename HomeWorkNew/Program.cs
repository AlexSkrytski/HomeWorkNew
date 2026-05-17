namespace HomeWorkNew
{
    class Program
    {
        static void Main()
        {
            MiniCalcApp();
            GetAgeStatus();
            SalaryBYHours();
            SalaryByKpi();
            IShop();
        }
        public static void MiniCalcApp()
        {

        vvod1:

            Console.Write("Введите первое число: ");
            string inputFirstValue = Console.ReadLine() ?? string.Empty;
            bool resultFirstInput = decimal.TryParse(inputFirstValue, out decimal firstValue);

            if (resultFirstInput == false)
            {
                Console.WriteLine("Введено не число");
                goto vvod1;
            }

        vvod2:

            Console.Write("Введите второе число: ");
            string inputSecondValue = Console.ReadLine() ?? string.Empty;
            bool resultSecondInput = decimal.TryParse(inputSecondValue, out decimal secondValue);

            if (resultSecondInput == false)
            {
                Console.WriteLine("Введено не число");
                goto vvod2;
            }

            Console.Write("Выберите операцию (+, -, *, /): ");
            string operationType = Console.ReadLine() ?? string.Empty;

            switch (operationType)
            {
                case "+":
                    Console.WriteLine($"Результат: {firstValue + secondValue}");
                    break;
                case "-":
                    Console.WriteLine($"Результат: {firstValue - secondValue}");
                    break;
                case "*":
                    Console.WriteLine($"Результат: {firstValue * secondValue}");
                    break;
                case "/":
                    if (secondValue == 0)
                        Console.WriteLine("Ошибка: деление на 0");
                    else
                        Console.WriteLine($"Результат: {firstValue / secondValue}");
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }
        }

        public static void GetAgeStatus()
        {

            int parsedAge = 0;
            bool notValidAge = true;

            do
            {
                Console.WriteLine("Введите возраст");
                string ageInputValue = Console.ReadLine() ?? string.Empty;
                bool parseResult = int.TryParse(ageInputValue, out int age);

                if (parseResult == false || age > 100 || age < 1)
                {
                    Console.WriteLine("Неверно, введите цифры от 1 до 100");
                }
                else
                {
                    notValidAge = false;
                    parsedAge = age;
                }
            } while (notValidAge);

            if (parsedAge >= 18)
            {
                Console.WriteLine("Человек совершеннолетний.");
            }
            else
            {
                Console.WriteLine("Человек несовершеннолетний.");
            }

        }

        public static void SalaryBYHours()
        {

            decimal dayHours = 100;
            decimal nightHours = 50;
            decimal dayRate = 50;
            decimal nightRate = 80;
            decimal gross = 0;
            decimal bonus = 0;

            bool weekendShift = true;

            decimal baseSalary = dayHours * dayRate + nightHours * nightRate;
            decimal totalHours = dayHours + nightHours;

            if (totalHours > 160)
            {
                decimal overHours = totalHours - 160;
                gross = baseSalary + overHours * dayRate * 1.5M;
            }
            else
            {
                gross = baseSalary;
            }

            if (weekendShift)
            {
                bonus = baseSalary * 0.5M;
            }

            gross += bonus;
            decimal net = gross * 0.9M;

            Console.WriteLine($"До налога: {gross}.");
            Console.WriteLine($"После налога: {net}.");

            switch (dayHours + nightHours)
            {
                case 160:
                    Console.WriteLine("160 часов.");
                    break;
                case > 160:
                    Console.WriteLine("Более 160 часов.");
                    break;
                default:
                    Console.WriteLine("Менее 160 часов.");
                    break;
            }

        }

        public static void SalaryByKpi()
        {

            const int kpiFirstGrade = 75;
            const int kpiSecondGrade = 90;
            const decimal bonusFirstGrade = 0.1M;
            const int bonusSecondGrade = 20;


        vvod:

            Console.WriteLine("Введите начисленную зарплату");
            string salary = Console.ReadLine() ?? string.Empty;
            bool resultSalaryParse = decimal.TryParse(salary, out decimal salaryParsed);

            if (resultSalaryParse == false)
            {
                Console.WriteLine("Неверное значение");
                goto vvod;
            }

        vvod2:

            Console.WriteLine("Введите KPI");
            string kpi = Console.ReadLine() ?? string.Empty;
            bool resultKpiParse = decimal.TryParse(kpi, out decimal kpiParsed);

            if (resultKpiParse == false)
            {
                Console.WriteLine("Неверное значение KPI");
                goto vvod2;
            }

            if (kpiParsed >= kpiSecondGrade)
            {
                Console.WriteLine($"Бонус: {salaryParsed * bonusSecondGrade / 100}");
            }
            else if (kpiParsed >= kpiFirstGrade && kpiParsed < kpiSecondGrade)
            {
                Console.WriteLine($"Бонус: {salaryParsed * bonusFirstGrade}");
            }
            else
            {
                Console.WriteLine("В этом месяце нет бонуса.");
            }

        }

        public static void IShop()
        {

            decimal amount = 10000; //Сумма заказа
            bool isVip = false;
            bool isFirstOrder = false;
            bool hasPromo = true;
            decimal discount = 0;
            decimal totalAmount = 0;
            int discountCounter = 0;
            decimal delivery = 0;

            if (isVip)
            {
                discount += 7; //Discount 7% for Vip
                discountCounter++;
            }

            if (isFirstOrder)
            {
                discount += 5; //Discount 5% if First Order
                discountCounter++;
            }

            if (hasPromo)
            {
                discount += 10; //Discount 10% if has Promo
                discountCounter++;
            }

            if (discount > 20)
            {
                discount = 20; //Max discount value
            }

            if (amount >= 15000)
            {
                delivery = 0;
            }
            else
            {
                delivery = 1200;
            }

            switch (discountCounter)
            {
                case 0:
                    Console.WriteLine("Без скидок.");
                    break;
                case 1:
                    Console.WriteLine("Только одна скидка.");
                    break;
                case 3:
                    Console.WriteLine("Все скидки.");
                    break;
                default:
                    break;
            }

            totalAmount = amount * (1 - discount / 100) + delivery;

            Console.WriteLine($"Итоговая скидка: {discount}%");
            Console.WriteLine($"Стоимость доставки: {delivery}");
            Console.WriteLine($"Финальная сумма к оплате: {totalAmount}");

            if (amount == 15000)
            {
                Console.WriteLine("Заказ на границе 15000.");
            }
        }
    }
}
