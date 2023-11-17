using System;
//z1
class Spell
{
    public string Effect { get; private set; }
    public int Mana { get; private set; }
    public Spell(int mana, string effect)
    {
        Mana = mana;
        Effect = effect;
    }
    public string Use()
    {
        return Effect;
    }
}

class Magican
{
    public int Mana { get; private set; }
    public string Name { get; private set; }
    public Magican(int mana, string name)
    {
        Mana = mana;
        Name = name;
    }
    public void castSpell(Spell spell)
    {
        if (Mana >= spell.Mana)
        {
            Console.WriteLine($"{Name} использует способность: '{spell.Use()}'");
            Mana -= spell.Mana;
            Console.WriteLine($"У {Name} осталось {Mana} маны\n");
        }
        else
        {
            Console.WriteLine($"Не хватает {spell.Mana - Mana} для использования заклинания: '{spell.Use()}'");
            Console.WriteLine($"{Name} советую выпить зелье восстановления маны!");
        }
    }
}
// z2
class Delivery
{
    private string DiscriptionOrder { get; set; }
    public int WeightOrder { get; private set; }

    public Delivery(string discriptionOrder, int weightOrder)
    {
        DiscriptionOrder = discriptionOrder;
        WeightOrder = weightOrder;
    }
    public string order()
    {
        return DiscriptionOrder;
    }
}

class DeliveryService
{
    private int limitWeight = 5;

    public void sendOrders(Delivery delivery)
    {
        if (limitWeight >= delivery.WeightOrder)
        {
            limitWeight -= delivery.WeightOrder;
            Console.WriteLine($"'{delivery.order()}': отправлено");
        }
        else
        {
            Console.WriteLine($"'{delivery.order()}': отправить не удалось,  превышена допустимый вес на {delivery.WeightOrder - limitWeight} кг");
        }
    }
}
//z3
class Ork
{
    private int _count = 1;
    private int gold;
    private int farming = 2;
    public int Count { get; private set; }
    public int Gold
    {
        get { return gold; }
        set { gold = Maining(); }
    }
    public int BuyOrk()
    {
        Console.WriteLine($"Купить орка - 5 монет");
        string a;
        a = Console.ReadLine();
        if (a == "Купить")
        {
            if (gold - 5 < 0)
            {
                Console.WriteLine("Недостаточно золота");
            }
            else
            {
                Console.WriteLine("Орк успешно куплен");
                gold -= 5;
                _count++;
                Count = _count;
                return gold;
            }
        }
        if (_count >= 5)
        {
            farming -= 2;
        }
        return gold;
    }
    public int Maining()
    {
        while (true)
        {
            Console.WriteLine("Введите: Магазин, Баланс, Заработать, Выйти, чтобы выполнить действие");
            var key = Console.ReadLine();
            if (key == "Магазин")
            {
                Console.WriteLine("Введите: Купить, чтобы купить орка");
                BuyOrk();
            }
            if (key == "Баланс")
            {
                Console.WriteLine($"Ваш баланс == {gold}");
                Console.WriteLine("Напишите exit, чтобы выйти");
            }
            else if (key == "Заработать")
            {
                Console.WriteLine($"Ваш орк успешно добыл {farming * _count} монет");
                gold += farming * _count;
            }
            else if (key == "Выйти")
            {
                break;
            }
            else
            {
                continue;
            }
        }
        return gold;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание: 1,2,3");
        int choose = Convert.ToInt32(Console.ReadLine());
        switch (choose) {

            case 1:
                Spell alohomora = new Spell(100, "Замок открывается");
                Spell vinigardiumLeviosa = new Spell(60, "Предмет поднимается в воздух");

                Magican GarryPotter = new Magican(100, "Гарри Поттер");


                GarryPotter.castSpell(alohomora);
                GarryPotter.castSpell(vinigardiumLeviosa);
                break;
            case 2:
                Console.WriteLine("Введите название посылки и ее вес: ");
                string name = Convert.ToString(Console.ReadLine());
                int weight = Convert.ToInt32(Console.ReadLine());
                Delivery dv = new Delivery(name, weight);

                DeliveryService delivery = new DeliveryService();
                delivery.sendOrders(dv);
                break;
            case 3:
                Ork ork = new Ork();
                int gold;

                ork.Maining();

                Console.WriteLine($"Вы заработали == {ork.Gold} монет и наняли {ork.Count} орка");
                break;
        }
    }
}
