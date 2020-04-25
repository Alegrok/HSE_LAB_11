using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HSE_LAB_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Animals> AnimalsQueue = new Queue<Animals>();
            Stack<Animals> AnimalsStack = new Stack<Animals>();
            TestCollections collections = new TestCollections();
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("Добро пожаловать в приложение по работе с коллекциями");

            while (true)
            {
                int numberMenu = 3;

                Console.WriteLine("\nМеню приложения:");
                Console.WriteLine("1 - Меню работы с очередью");
                Console.WriteLine("2 - Меню работы со стэком");
                Console.WriteLine("3 - Меню работы с коллекциями");
                Console.WriteLine("0 - Выйти из приложения");

                int numberChoiceMenu = InputInt(0, numberMenu);

                if (numberChoiceMenu == 0)
                {
                    Console.WriteLine("\n0 - Выход из приложения");
                    break;
                }

                switch (numberChoiceMenu)
                {
                    case 1:
                        while (true) {

                            int numberUnits = 10;

                            Console.WriteLine("\nМеню по работе с очередью:");
                            Console.WriteLine("1 - Добавление объекта в коллекцию");
                            Console.WriteLine("2 - Удаление объекта из коллекции");
                            Console.WriteLine("3 - Запрос. Количество животных определенного вида");
                            Console.WriteLine("4 - Запрос. Печать животных определенного вида");
                            Console.WriteLine("5 - Запрос. Средний вес животных определенного вида в зоопарке");
                            Console.WriteLine("6 - Перебор элементов коллекции с помощью метода foreach");
                            Console.WriteLine("7 - Клонирование коллекции элементов и ее отображение");
                            Console.WriteLine("8 - Сортировка коллекции");
                            Console.WriteLine("9 - Поиск заданного элемента в коллекции");
                            Console.WriteLine("10 - Очистка истории");
                            Console.WriteLine("0 - Выход из меню");

                            int numberChoice = InputInt(0, numberUnits);

                            if (numberChoice == 0)
                            {
                                Console.WriteLine("\n0 - Выход из меню");
                                break;
                            }

                            switch (numberChoice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("\n1 - Добавление объекта в коллекцию");

                                        if (AnimalsQueue.Count >= 100)
                                        {
                                            Console.WriteLine("\nОбъектов в коллекции не меньше 100, больше добавить нельзя");
                                            break;
                                        }

                                        Console.WriteLine("\nВыберите тип объекта:");
                                        Console.WriteLine("1 - Животные");
                                        Console.WriteLine("2 - Птицы");
                                        Console.WriteLine("3 - Млекопитающие");
                                        Console.WriteLine("4 - Парнокопытные");
                                        Console.WriteLine("5 - Животные (рандомный объект)");
                                        Console.WriteLine("6 - Птицы (рандомный объект)");
                                        Console.WriteLine("7 - Млекопитающие (рандомный объект)");
                                        Console.WriteLine("8 - Парнокопытные (рандомный объект)");

                                        int point = InputInt(1, 8);

                                        switch (point)
                                        {
                                            case 1:
                                                {
                                                    Animals animal = new Animals();
                                                    AnimalsQueue.Enqueue(animal.CreateObjectAnimals());
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Birds bird = new Birds();
                                                    AnimalsQueue.Enqueue(bird.CreateObjectAnimals());
                                                }
                                                break;
                                            case 3:
                                                {
                                                    Mammals mammal = new Mammals();
                                                    AnimalsQueue.Enqueue(mammal.CreateObjectAnimals());
                                                }
                                                break;
                                            case 4:
                                                {
                                                    Artiodactyls artiodactyl = new Artiodactyls();
                                                    AnimalsQueue.Enqueue(artiodactyl.CreateObjectAnimals());
                                                }
                                                break;
                                            case 5:
                                                {
                                                    Animals animal = new Animals();
                                                    animal = animal.CreateObjectAnimalsRandom();
                                                    animal.Show();
                                                    AnimalsQueue.Enqueue(animal);
                                                }
                                                break;
                                            case 6:
                                                {
                                                    Birds bird = new Birds();
                                                    bird = bird.CreateObjectAnimalsRandom();
                                                    bird.Show();
                                                    AnimalsQueue.Enqueue(bird);
                                                }
                                                break;
                                            case 7:
                                                {
                                                    Mammals mammal = new Mammals();
                                                    mammal = mammal.CreateObjectAnimalsRandom();
                                                    mammal.Show();
                                                    AnimalsQueue.Enqueue(mammal);
                                                }
                                                break;
                                            case 8:
                                                {
                                                    Artiodactyls artiodactyl = new Artiodactyls();
                                                    artiodactyl = artiodactyl.CreateObjectAnimalsRandom();
                                                    artiodactyl.Show();
                                                    AnimalsQueue.Enqueue(artiodactyl);
                                                }
                                                break;
                                        }
                                        Console.WriteLine("\nДобавление объекта в коллекцию завершено");
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("\n2 - Удаление объекта из коллекции");
                                        if (AnimalsQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nУдаление не может быть завершено, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nУдаленный объект:");
                                        Animals animal = AnimalsQueue.Dequeue();
                                        animal.Show();
                                        Console.WriteLine("\nУдаление объекта из коллекции завершено");
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("\n3 - Запрос. Количество животных определенного вида");
                                        if (AnimalsQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nКоличество животных определенного вида не может быть получено, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nВведите вид животного:");
                                        int numberAnimals = GetCountAnimals(AnimalsQueue, InputString());
                                        if (numberAnimals == 0)
                                        {
                                            Console.WriteLine("\nЗапрос. Количество животных данного вида не может быть получено, так как животных данного вида нет");
                                            break;
                                        }
                                        Console.WriteLine("\nКоличество животных выбранного вида равно " + numberAnimals);
                                        Console.WriteLine("\nЗапрос. Количество животных определенного вида получено");
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.WriteLine("\n4 - Запрос. Печать животных определенного вида");
                                        if (AnimalsQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nПечать животных определенного вида не может быть получена, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nВведите вид животного");
                                        List<Animals> animals = GetObjectsAnimals(AnimalsQueue, InputString());
                                        if (animals.Count == 0)
                                        {
                                            Console.WriteLine("\nПечать животных данного вида не может быть завершена, так как животных данного вида нет");
                                            break;
                                        }
                                        Console.WriteLine("\nПолученные животные:");
                                        foreach (Animals animal in animals)
                                        {
                                            Console.WriteLine();
                                            animal.Show();
                                        }
                                        Console.WriteLine("\nЗапрос. Печать животных определенного вида завершена");
                                    }
                                    break;
                                case 5:
                                    {
                                        Console.WriteLine("\n5 - Запрос. Средний вес животных определенного вида в зоопарке");
                                        if (AnimalsQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nСредний вес животных определенного вида в зоопарке не может быть получен, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nВведите вид животного:");
                                        string kind = InputString();
                                        int numberAnimals = GetCountAnimals(AnimalsQueue, kind);
                                        if (numberAnimals == 0)
                                        {
                                            Console.WriteLine("\nСредний вес животных данного вида в зоопарке не может быть получен, так как животных данного вида нет");
                                            break;
                                        }
                                        double averageWeight = GetAverageWeight(AnimalsQueue, kind);
                                        Console.WriteLine("\nСредний вес выбранного вида животных равен " + averageWeight);
                                        Console.WriteLine("\nЗапрос. Средний вес животных заданного вида в зоопарке получен");
                                    }
                                    break;
                                case 6:
                                    {
                                        Console.WriteLine("\n6 - Перебор элементов коллекции с помощью метода foreach");
                                        if (AnimalsQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nПеребор элементов коллекции с помощью метода foreach не может быть завершен, так как объектов в коллекции нет");
                                            break;
                                        }
                                        foreach (Animals animal in AnimalsQueue)
                                        {
                                            Console.WriteLine();
                                            animal.Show();
                                        }
                                        Console.WriteLine("\nПеребор элементов коллекции с помощью метода foreach завершен");
                                    }
                                    break;
                                case 7:
                                    {
                                        Console.WriteLine("\n7 - Клонирование коллекции элементов и ее отображение");
                                        if (AnimalsQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nКлонирование коллекции элементов и ее отображение не может быть завершено, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Queue<Animals> CloneAnimalsGroup = new Queue<Animals>();
                                        foreach (Animals animal in AnimalsQueue)
                                        {
                                            Console.WriteLine();
                                            CloneAnimalsGroup.Enqueue((Animals)animal.Clone());
                                            animal.Show();
                                        }
                                        Console.WriteLine("\nКлонирование коллекции элементов и ее отображение завершено");
                                    }
                                    break;
                                case 8:
                                    {
                                        Console.WriteLine("\n8 - Сортировка коллекции");
                                        if (AnimalsQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nСортировка коллекции не может быть завершена, так как объектов в коллекции нет");
                                            break;
                                        }

                                        Animals[] sortedAnimalsGroup = new Animals[AnimalsQueue.Count];
                                        Animals[] nonSortedAnimalsGroup = new Animals[AnimalsQueue.Count];

                                        for (int i = 0; i < sortedAnimalsGroup.Length; i++)
                                        {
                                            Animals animal = AnimalsQueue.Dequeue();
                                            sortedAnimalsGroup[i] = animal;
                                            nonSortedAnimalsGroup[i] = animal;
                                        }

                                        Array.Sort(sortedAnimalsGroup);

                                        foreach (Animals animal in sortedAnimalsGroup)
                                        {
                                            AnimalsQueue.Enqueue(animal);
                                        }

                                        bool sorted = true;
                                        for (int i = 0; i < AnimalsQueue.Count; i++)
                                        {
                                            if (!sortedAnimalsGroup[i].Equals(nonSortedAnimalsGroup[i]))
                                            {
                                                sorted = false;
                                                break;
                                            }
                                        }

                                        if (sorted) { Console.WriteLine("\nОчередь уже отсортирована"); }
                                        else { Console.WriteLine("\nСортировка коллекции и поиск заданного элемента в коллекции завершены"); }
                                    }
                                    break;
                                case 9:
                                    {
                                        Console.WriteLine("\n9 - Поиск заданного элемента в коллекции");
                                        if (AnimalsQueue.Count == 0)
                                        {
                                            Console.WriteLine("\nПоиск заданного элемента в коллекции не может быть завершен");
                                            Console.WriteLine("Элементов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nВведите параметры поиска объекта");
                                        Animals animal = new Animals();
                                        animal = animal.CreateObjectAnimals();
                                        if(AnimalsQueue.Contains(animal))
                                        {
                                            Console.WriteLine("\nЗаданный элемент был найден в коллекции");
                                        } 
                                        else
                                        {
                                            Console.WriteLine("\nЗаданные элемент не был найден в коллекции");
                                        }
                                        Console.WriteLine("\nПоиск заданного элемента в коллекции завершен");
                                    }
                                    break;
                                case 10:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("История была очищена");
                                    }
                                    break;
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            int numberUnits = 10;

                            Console.WriteLine("\nМеню по работе со стэком:");
                            Console.WriteLine("1 - Добавление объекта в коллекцию");
                            Console.WriteLine("2 - Удаление объекта из коллекции");
                            Console.WriteLine("3 - Запрос. Количество животных определенного вида");
                            Console.WriteLine("4 - Запрос. Печать животных определенного вида");
                            Console.WriteLine("5 - Запрос. Средний вес животных заданного вида в зоопарке");
                            Console.WriteLine("6 - Перебор элементов коллекции с помощью метода foreach");
                            Console.WriteLine("7 - Клонирование коллекции элементов и ее отображение");
                            Console.WriteLine("8 - Сортировка коллекции");
                            Console.WriteLine("9 - Поиск заданного элемента в коллекции");
                            Console.WriteLine("10 - Очистка истории");
                            Console.WriteLine("0 - Выход из меню");

                            int numberChoice = InputInt(0, numberUnits);

                            if (numberChoice == 0)
                            {
                                Console.WriteLine("\n0 - Выход из меню");
                                break;
                            }

                            switch (numberChoice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("\n1 - Добавление объекта в коллекцию");

                                        if (AnimalsQueue.Count >= 100)
                                        {
                                            Console.WriteLine("\nОбъектов в коллекции не меньше 100, больше добавить нельзя");
                                            break;
                                        }

                                        Console.WriteLine("\nВыберите тип объекта:");
                                        Console.WriteLine("1 - Животные");
                                        Console.WriteLine("2 - Птицы");
                                        Console.WriteLine("3 - Млекопитающие");
                                        Console.WriteLine("4 - Парнокопытные");
                                        Console.WriteLine("5 - Животные (рандомный объект)");
                                        Console.WriteLine("6 - Птицы (рандомный объект)");
                                        Console.WriteLine("7 - Млекопитающие (рандомный объект)");
                                        Console.WriteLine("8 - Парнокопытные (рандомный объект)");
                                        int point = InputInt(1, 8);

                                        switch (point)
                                        {
                                            case 1:
                                                {
                                                    Animals animal = new Animals();
                                                    AnimalsStack.Push(animal.CreateObjectAnimals());
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Birds bird = new Birds();
                                                    AnimalsStack.Push(bird.CreateObjectAnimals());
                                                }
                                                break;
                                            case 3:
                                                {
                                                    Mammals mammal = new Mammals();
                                                    AnimalsStack.Push(mammal.CreateObjectAnimals());
                                                }
                                                break;
                                            case 4:
                                                {
                                                    Artiodactyls artiodactyl = new Artiodactyls();
                                                    AnimalsStack.Push(artiodactyl.CreateObjectAnimals());
                                                }
                                                break;
                                            case 5:
                                                {
                                                    Animals animal = new Animals();
                                                    animal = animal.CreateObjectAnimalsRandom();
                                                    animal.Show();
                                                    AnimalsStack.Push(animal);
                                                }
                                                break;
                                            case 6:
                                                {
                                                    Birds bird = new Birds();
                                                    bird = bird.CreateObjectAnimalsRandom();
                                                    bird.Show();
                                                    AnimalsStack.Push(bird);
                                                }
                                                break;
                                            case 7:
                                                {
                                                    Mammals mammal = new Mammals();
                                                    mammal = mammal.CreateObjectAnimalsRandom();
                                                    mammal.Show();
                                                    AnimalsStack.Push(mammal);
                                                }
                                                break;
                                            case 8:
                                                {
                                                    Artiodactyls artiodactyl = new Artiodactyls();
                                                    artiodactyl = artiodactyl.CreateObjectAnimalsRandom();
                                                    artiodactyl.Show();
                                                    AnimalsStack.Push(artiodactyl);
                                                }
                                                break;
                                        }
                                        Console.WriteLine("\nДобавление объекта в коллекцию завершено");
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("\n2 - Удаление объекта из коллекции");
                                        if (AnimalsStack.Count == 0)
                                        {
                                            Console.WriteLine("\nУдаление не может быть завершено, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nУдаленный объект:");
                                        Animals animal = AnimalsStack.Pop();
                                        animal.Show();
                                        Console.WriteLine("\nУдаление объекта из коллекции завершено");
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("\n3 - Запрос. Количество животных определенного вида");
                                        if (AnimalsStack.Count == 0)
                                        {
                                            Console.WriteLine("\nКоличество животных определенного вида не может быть получено, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nВведите вид животного:");
                                        int numberAnimals = GetCountAnimals(AnimalsStack, InputString());
                                        if (numberAnimals == 0)
                                        {
                                            Console.WriteLine("\nЗапрос. Количество животных данного вида не может быть получено, так как животных данного вида нет");
                                            break;
                                        }
                                        Console.WriteLine("\nКоличество животных выбранного вида равно " + numberAnimals);
                                        Console.WriteLine("\nЗапрос. Количество животных определенного вида получено");
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.WriteLine("\n4 - Запрос. Печать животных определенного вида");
                                        if (AnimalsStack.Count == 0)
                                        {
                                            Console.WriteLine("\nПечать животных определенного вида не может быть получена, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nВведите вид животного");
                                        List<Animals> animals = GetObjectsAnimals(AnimalsStack, InputString());
                                        if (animals.Count == 0)
                                        {
                                            Console.WriteLine("\nПечать животных данного вида не может быть завершена, так как животных данного вида нет");
                                            break;
                                        }
                                        Console.WriteLine("\nПолученные животные:");
                                        foreach (Animals animal in animals)
                                        {
                                            Console.WriteLine();
                                            animal.Show();
                                        }
                                        Console.WriteLine("\nЗапрос. Печать животных определенного вида завершена");
                                    }
                                    break;
                                case 5:
                                    {
                                        Console.WriteLine("\n5 - Запрос. Средний вес животных определенного вида в зоопарке");
                                        if (AnimalsStack.Count == 0)
                                        {
                                            Console.WriteLine("\nСредний вес животных определенного вида в зоопарке не может быть получен, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nВведите вид животного:");
                                        string kind = InputString();
                                        int numberAnimals = GetCountAnimals(AnimalsStack, kind);
                                        if (numberAnimals == 0)
                                        {
                                            Console.WriteLine("\nСредний вес животных данного вида в зоопарке не может быть получен, так как животных данного вида нет");
                                            break;
                                        }
                                        double averageWeight = GetAverageWeight(AnimalsStack, kind);
                                        Console.WriteLine("\nСредний вес выбранного вида животных равен " + averageWeight);
                                        Console.WriteLine("\nЗапрос. Средний вес животных заданного вида в зоопарке получен");
                                    }
                                    break;
                                case 6:
                                    {
                                        Console.WriteLine("\n6 - Перебор элементов коллекции с помощью метода foreach");
                                        if (AnimalsStack.Count == 0)
                                        {
                                            Console.WriteLine("\nПеребор элементов коллекции с помощью метода foreach не может быть завершен, так как объектов в коллекции нет");
                                            break;
                                        }
                                        foreach (Animals animal in AnimalsStack)
                                        {
                                            Console.WriteLine();
                                            animal.Show();
                                        }
                                        Console.WriteLine("\nПеребор элементов коллекции с помощью метода foreach завершен");
                                    }
                                    break;
                                case 7:
                                    {
                                        Console.WriteLine("\n7 - Клонирование коллекции элементов и ее отображение");
                                        if (AnimalsStack.Count == 0)
                                        {
                                            Console.WriteLine("\nКлонирование коллекции элементов и ее отображение не может быть завершено, так как объектов в коллекции нет");
                                            break;
                                        }
                                        Stack<Animals> CloneAnimalsGroup = new Stack<Animals>();
                                        foreach (Animals animal in AnimalsStack)
                                        {
                                            Console.WriteLine();
                                            CloneAnimalsGroup.Push((Animals)animal.Clone());
                                            animal.Show();
                                        }
                                        Console.WriteLine("\nКлонирование коллекции элементов и ее отображение завершено");
                                    }
                                    break;
                                case 8:
                                    {
                                        Console.WriteLine("\n8 - Сортировка коллекции");
                                        
                                        if (AnimalsStack.Count == 0)
                                        {
                                            Console.WriteLine("\nСортировка коллекции не может быть завершена, так как объектов в коллекции нет");
                                            break;
                                        }

                                        Animals[] sortedAnimalsGroup = new Animals[AnimalsStack.Count];
                                        Animals[] nonSortedAnimalsGroup = new Animals[AnimalsStack.Count];

                                        for (int i = 0; i < sortedAnimalsGroup.Length; i++)
                                        {
                                            Animals animal = AnimalsStack.Pop();
                                            sortedAnimalsGroup[i] = animal;
                                            nonSortedAnimalsGroup[i] = animal;
                                        }

                                        Array.Sort(sortedAnimalsGroup);

                                        for (int i = sortedAnimalsGroup.Length - 1; i >= 0; i--)
                                        {
                                            AnimalsStack.Push(sortedAnimalsGroup[i]);
                                        }

                                        bool sorted = true;
                                        for (int i = 0; i < AnimalsStack.Count; i++)
                                        {
                                            if (!sortedAnimalsGroup[i].Equals(nonSortedAnimalsGroup[i]))
                                            {
                                                sorted = false;
                                                break;
                                            }
                                        }

                                        if (sorted) { Console.WriteLine("\nОчередь уже отсортирована"); }
                                        else { Console.WriteLine("\nСортировка коллекции завершена"); }
                                        
                                    }
                                    break;
                                case 9:
                                    {
                                        Console.WriteLine("\n9 - Поиск заданного элемента в коллекции");
                                        if (AnimalsStack.Count == 0)
                                        {
                                            Console.WriteLine("\nПоиск заданного элемента в коллекции не может быть завершен");
                                            Console.WriteLine("Элементов в коллекции нет");
                                            break;
                                        }
                                        Console.WriteLine("\nВведите параметры поиска объекта");
                                        Animals animal = new Animals();
                                        animal = animal.CreateObjectAnimals();
                                        if (AnimalsStack.Contains(animal))
                                        {
                                            Console.WriteLine("\nЗаданный элемент был найден в коллекции");
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nЗаданные элемент не был найден в коллекции");
                                        }
                                        Console.WriteLine("\nПоиск заданного элемента в коллекции завершен");
                                    }
                                    break;
                                case 10:
                                    {
                                        Console.Clear();
                                        Console.WriteLine("История была очищена");
                                    }
                                    break;
                            }
                        }
                        break;
                    case 3:
                        while (true) 
                        {
                            int numberUnits = 10;

                            Console.WriteLine("\nМеню по работе с коллекциями:");
                            Console.WriteLine("1 - Создание коллекции объектов");
                            Console.WriteLine("2 - Добавление объекта в коллекцию");
                            Console.WriteLine("3 - Удаление объекта из коллекции");
                            Console.WriteLine("4 - Время поиска первого объекта в коллекции");
                            Console.WriteLine("5 - Время поиска центрального объекта в коллекции");
                            Console.WriteLine("6 - Время поиска последнего объекта в коллекции");
                            Console.WriteLine("7 - Время поиска инородного объекта в коллекции");
                            int numberChoice = InputInt(0, numberUnits);

                            if (numberChoice == 0)
                            {
                                Console.WriteLine("\n0 - Выход из меню");
                                break;
                            }

                            switch (numberChoice)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("\n1 - Создание коллекции объектов");
                                        Console.WriteLine("\nВведите размер коллекции");
                                        int size = InputInt(1, 100);
                                        collections = new TestCollections(size);
                                        Console.WriteLine("\nСоздание коллекции объектов завершено");
                                    }
                                    break;
                                case 2:
                                    {
                                        Console.WriteLine("\n2 - Добавление объекта в коллекцию");
                                        Console.WriteLine("\nСоздайте объект типа Mammals");
                                        Mammals mammal = new Mammals();
                                        mammal = mammal.CreateObjectAnimals();
                                        collections.Add(mammal);
                                        Console.WriteLine("\nДобавление объекта в коллекцию завершено");
                                    }
                                    break;
                                case 3:
                                    {
                                        Console.WriteLine("\n3 - Удаление объекта из коллекции");
                                        Console.WriteLine("\nОбъект удален из коллекции");
                                        Console.WriteLine("\nУдаление объекта из коллекции завершено");
                                    }
                                    break;
                                case 4:
                                    {
                                        Console.WriteLine("\n4 - Время поиска первого объекта в коллекции");
                                        stopWatch.Start();
                                        Console.WriteLine(collections.AnimalsQueue.Contains(collections.firstObject.BaseAnimals) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в AnimalsQueue = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.StringQueue.Contains(collections.firstObject.BaseAnimals.ToString()) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в StringQueue = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.DictionaryAnimals.ContainsKey(collections.firstObject.BaseAnimals) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в DictionaryAnimals = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.DictionaryString.ContainsKey(collections.firstObject.BaseAnimals.ToString()) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в DictionaryString = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        Console.WriteLine("\nВремя поиска первого объекта в коллекции показано");
                                    }
                                    break;
                                case 5:
                                    {
                                        Console.WriteLine("\n5 - Время поиска центрального объекта в коллекции");
                                        stopWatch.Start();
                                        Console.WriteLine(collections.AnimalsQueue.Contains(collections.middleObject.BaseAnimals) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в AnimalsQueue = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.StringQueue.Contains(collections.middleObject.BaseAnimals.ToString()) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в StringQueue = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.DictionaryAnimals.ContainsKey(collections.middleObject.BaseAnimals) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в DictionaryAnimals = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.DictionaryString.ContainsKey(collections.middleObject.BaseAnimals.ToString()) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в DictionaryString = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        Console.WriteLine("\nВремя поиска центрального объекта в коллекции показано");
                                    }
                                    break;
                                case 6:
                                    {
                                        Console.WriteLine("\n6 - Время поиска последнего объекта в коллекции");
                                        stopWatch.Start();
                                        Console.WriteLine(collections.AnimalsQueue.Contains(collections.lastObject.BaseAnimals) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в AnimalsQueue = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.StringQueue.Contains(collections.lastObject.BaseAnimals.ToString()) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в StringQueue = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.DictionaryAnimals.ContainsKey(collections.lastObject.BaseAnimals) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в DictionaryAnimals = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.DictionaryString.ContainsKey(collections.lastObject.BaseAnimals.ToString()) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в DictionaryString = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        Console.WriteLine("\nВремя поиска последнего объекта в коллекции показано");
                                    }
                                    break;
                                case 7:
                                    {
                                        Console.WriteLine("\n7 - Время поиска инородного объекта в коллекции");
                                        Mammals unknownObject = new Mammals("Name", "Kind", 1, 1);
                                        stopWatch.Start();
                                        Console.WriteLine(collections.AnimalsQueue.Contains(unknownObject.BaseAnimals) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в AnimalsQueue = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.StringQueue.Contains(unknownObject.BaseAnimals.ToString()) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в StringQueue = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.DictionaryAnimals.ContainsKey(unknownObject.BaseAnimals) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в DictionaryAnimals = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        stopWatch.Start();
                                        Console.WriteLine(collections.DictionaryString.ContainsKey(unknownObject.BaseAnimals.ToString()) ? "Объект найден" : "Объект не найден");
                                        stopWatch.Stop();
                                        Console.WriteLine("Время поиска в DictionaryString = " + stopWatch.Elapsed);
                                        stopWatch.Reset();
                                        Console.WriteLine("\nВремя поиска инородного объекта в коллекции показано");
                                    }
                                    break;
                            }
                        }
                        break;
                }               
            }
        }

        public static List<Animals> GetObjectsAnimals(Queue<Animals> animals, string kind)
        {
            List<Animals> array =  new List<Animals>();
            foreach (Animals animal in animals)
            {
                if (animal != null && animal.Kind == kind) array.Add(animal);
            }
            return array;
        }

        public static List<Animals> GetObjectsAnimals(Stack<Animals> animals, string kind)
        {
            List<Animals> array = new List<Animals>();
            foreach (Animals animal in animals)
            {
                if (animal != null && animal.Kind == kind) array.Add(animal);
            }
            return array;
        }

        public static int GetCountAnimals(Queue<Animals> animals, string kind)
        {
            int countAnimals = 0;
            foreach (Animals animal in animals)
            {
                if (animal != null && animal.Kind == kind) countAnimals++;
            }
            return countAnimals;
        }

        public static int GetWeightAnimals(Queue<Animals> animals, string kind)
        {
            int countWeightAnimals = 0;
            foreach (Animals animal in animals)
            {
                if (animal != null && animal.Kind == kind) countWeightAnimals += animal.Weight;
            }
            return countWeightAnimals;
        }

        public static double GetAverageWeight(Queue<Animals> animals, string kind)
        {
            return GetWeightAnimals(animals, kind) / GetCountAnimals(animals, kind);
        }

        public static int GetCountAnimals(Stack<Animals> animals, string kind)
        {
            int countAnimals = 0;
            foreach (Animals animal in animals)
            {
                if (animal != null && animal.Kind == kind) countAnimals++;
            }
            return countAnimals;
        }

        public static int GetWeightAnimals(Stack<Animals> animals, string kind)
        {
            int countWeightAnimals = 0;
            foreach (Animals animal in animals)
            {
                if (animal != null && animal.Kind == kind) countWeightAnimals += animal.Weight;
            }
            return countWeightAnimals;
        }

        public static double GetAverageWeight(Stack<Animals> animals, string kind)
        {
            return GetWeightAnimals(animals, kind) / GetCountAnimals(animals, kind);
        }

        public static string InputString()
        {
            string str;
            bool inputCheck;
            do
            {
                Console.Write("\nВвод: ");
                str = Console.ReadLine();
                inputCheck = str != "";
                if (!inputCheck) Console.WriteLine("Ошибка ввода! Введите не пустые данные");
            } while (!inputCheck);
            return str;
        }

        public static int InputInt()
        {
            int number;
            bool inputCheck;
            do
            {
                Console.Write("\nВвод: ");
                inputCheck = int.TryParse(Console.ReadLine(), out number);
                if (!inputCheck) Console.WriteLine("Ошибка ввода! Введите целое число");
            } while (!inputCheck);
            return number;
        }

        public static int InputInt(int min, int max)
        {
            int number;
            bool inputCheck;
            do
            {
                Console.Write("\nВвод: ");
                inputCheck = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
                if (!inputCheck) Console.WriteLine("Ошибка ввода! Введите целое число в пределах от {0} до {1} (включительно)", min, max);
            } while (!inputCheck);
            return number;
        }
    }
}