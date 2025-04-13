namespace PracticalWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShopManager shopManager = new ShopManager();

            Console.WriteLine("\t\t\tДобро пожаловать в магический магазин!\n\n");

            // доделать меню со всеми вызовами методов
            while (true)
            {
                Console.WriteLine("\nМеню магазина\n");

                Console.WriteLine("1. Загрузить данные");
                Console.WriteLine("2. Создать отчет");
                Console.WriteLine("3. Найти проклятые артефакты");
                Console.WriteLine("4. Группировка артефактов по редкости");
                Console.WriteLine("5. Топ артефактов по силе");
                Console.WriteLine("0. Выход");


                Console.Write("Выберите действие: ");
                int choose = Convert.ToInt32(Console.ReadLine());


                if (choose == 0)
                {
                    break;
                }
                else if (choose == 1)
                {
                    shopManager.LoadAllData();
                    Console.WriteLine($"Загружено {shopManager.Artifacts.Count} артефактов");
                }
                else if (choose == 2)
                {
                    shopManager.GenerateReport();
                    Console.WriteLine("Отчет сохранен в файле - report.txt");
                }
                else if (choose == 3)
                {
                    var sorted = shopManager.FindCursedArtifacts();
                    Console.WriteLine($"Найдено {sorted.Count} проклятых артефактов:");

                    foreach (var item in sorted)
                    {
                        Console.WriteLine($"Название: {item.Name}, Сила: {item.PowerLevel}, Проклятие: {item.CurseDescription}");
                    }
                }
                else if (choose == 4)
                {
                    var groupped = shopManager.GroupByRarity();

                    foreach (var item in groupped)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value} шт.");
                    }
                }
                else if (choose == 5)
                {
                    Console.Write("Введите кол-во искомых артефактов по силе: ");
                    int chooseCount = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"Топ {chooseCount} артефактов по силе");

                    var range = shopManager.TopByPower(chooseCount);

                    foreach (var item in range)
                    {
                        Console.WriteLine($"Название: {item.Name}, Сила: {item.PowerLevel}");
                    }
                }
                else
                {
                    Console.WriteLine("\nОшибка!! \nНекорректный ввод!!");
                    break;
                }
            }
        }
    }
}
