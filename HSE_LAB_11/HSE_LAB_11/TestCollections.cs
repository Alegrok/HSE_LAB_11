using System;
using System.Collections.Generic;
using System.Text;

namespace HSE_LAB_11
{
    class TestCollections
    {
        public Queue<Animals> AnimalsQueue;
        public Queue<string> StringQueue;
        public Dictionary<Animals, Mammals> DictionaryAnimals;
        public Dictionary<string, Mammals> DictionaryString;

        public Mammals firstObject;
        public Mammals middleObject;
        public Mammals lastObject;

        public TestCollections()
        {
            AnimalsQueue = new Queue<Animals>();
            StringQueue = new Queue<string>();
            DictionaryAnimals = new Dictionary<Animals, Mammals>();
            DictionaryString = new Dictionary<string, Mammals>();
        }

        public TestCollections(int count)
        {
            AnimalsQueue = new Queue<Animals>();
            StringQueue = new Queue<string>();
            DictionaryAnimals = new Dictionary<Animals, Mammals>();
            DictionaryString = new Dictionary<string, Mammals>();

            for (int i = 0; i < count; i++)
            {
                Mammals mammal = new Mammals();
                mammal = mammal.CreateObjectAnimalsRandom();
                Animals animal = (Animals) mammal.BaseAnimals.Clone();

                AnimalsQueue.Enqueue(animal);
                StringQueue.Enqueue(animal.ToString());
                DictionaryAnimals.Add(animal, mammal);
                DictionaryString.Add(animal.ToString(), mammal);

                if (i == 0) firstObject = (Mammals)mammal.Clone();
                if (i == count / 2) middleObject = (Mammals)mammal.Clone();
                if (i == count - 1) lastObject = (Mammals)mammal.Clone();
            }
        }

        public void Add(Mammals mammal)
        {
            if (AnimalsQueue.Count >= 100)
            {
                return;
            }

            Animals animal = (Animals)mammal.BaseAnimals.Clone();

            AnimalsQueue.Enqueue(animal);
            StringQueue.Enqueue(animal.ToString());
            DictionaryAnimals.Add(animal, mammal);
            DictionaryString.Add(animal.ToString(), mammal);

            RefactorObjects();
        }

        public void Remove()
        {
            if (AnimalsQueue.Count == 0)
            {
                return;
            }

            Animals deleteAnimal = AnimalsQueue.Dequeue();
            string deleteString = StringQueue.Dequeue();
            DictionaryAnimals.Remove(deleteAnimal);
            DictionaryString.Remove(deleteString);

            RefactorObjects();
        }

        public void RefactorObjects()
        {
            int i = 0;

            foreach(Animals animal in AnimalsQueue)
            {
                Mammals mammal = (Mammals)DictionaryAnimals[animal].Clone();

                if (i == 0) firstObject = (Mammals)mammal.Clone();
                if (i == AnimalsQueue.Count / 2) middleObject = (Mammals)mammal.Clone();
                if (i == AnimalsQueue.Count - 1) lastObject = (Mammals)mammal.Clone();
                i++;
            }
        }
    }
}
