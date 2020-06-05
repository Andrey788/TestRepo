using System;
using System.Collections.Generic;
using System.Linq;



namespace testConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var t = new Predator(new Grass());
            //t.ShowState();
            //t.SetState(true);
            //t.Eat();
//2222222222
//3333333333333333
            var list = Test();
///44444
            Console.WriteLine(list.Count);

            foreach (var item in list)
            {
                Console.WriteLine(item.Id +" " +item.Name);
            }




        }


    static List<Foo> Test()
    {
        var current = new List<Foo>();
        var newData = new List<Foo>();

            current.Add(new Foo() { Id = "1", Name = "c1" });
            current.Add(new Foo() { Id = "2", Name = "c2" });
            current.Add(new Foo() { Id = "3", Name = "c3" });
            current.Add(new Foo() { Id = "4", Name = "c4" });
            current.Add(new Foo() { Id = "5", Name = "c5" });
            current.Add(new Foo() { Id = "6", Name = "c6" });

            newData.Add(new Foo() { Id = "2", Name = "n2" });
            newData.Add(new Foo() { Id = "4", Name = "n4" });
            newData.Add(new Foo() { Id = "7", Name = "n7" });
            newData.Add(new Foo() { Id = "8", Name = "n8" });




            for (int i = 0; i < 10000; i++)
            {
                string id = Guid.NewGuid().ToString();

                current.Add(new Foo
                {
                    Id = id,
                    Name = i.ToString()
                });

                if (i % 2 == 0)
                {
                    newData.Add(new Foo
                    {
                        Id = id,
                        Name = i.ToString()
                    });
                }
            }

            for (int i = 10001; i < 10500; i++)
            {
                newData.Add(new Foo
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = i.ToString()
                });
            }

            UpdateList2(current, newData);

        return current;
    }

        static void UpdateList2(List<Foo> current, IEnumerable<Foo> newData)
        {

            Dictionary<string, Foo> currentD = current.ToDictionary(x => x.Name, x => x);
            Dictionary<string, Foo> newDataD = newData.ToDictionary(x => x.Name, x => x);
            for (int i = current.Count - 1; i >= 0; i--)
            {

                if (newDataD.ContainsKey(current[i].Id)) {
                    current[i].Id = newDataD[current[i].Id].Name;
                }
                else
                {
                    current.RemoveAt(i);
                }
            }

            foreach (var newItem in newData)
            {
                if (!currentD.ContainsKey(newItem.Id))
                {
                    current.Add(newItem);
                }
            }

        }

        static void UpdateList(List<Foo> current, IEnumerable<Foo> newData)
    {



        for (int i = current.Count - 1; i >= 0; i--)
        {

            bool isFound = false;
            foreach (var newItem in newData)
            {

                //UPDTE
                if (current[i].Id == newItem.Id)
                {
                    current[i].Name = newItem.Name;
                    isFound = true;
                    break;
                }

            }

            //Delete
            if (!isFound)
            {
                current.RemoveAt(i);
            }

        }



        foreach (var newItem in newData)
        {
            bool isFoundNew = true;
            for (int i = current.Count - 1; i >= 0; i--)
            {
                if (newItem.Id == current[i].Id)
                {

                    isFoundNew = false;
                    break;
                }

            }

            //Insert
            if (isFoundNew)
            {
                current.Add(newItem);
            }

        }



    }

    public class Foo
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    }


    //public class Meal
    //{
    //    public virtual void GetFood()
    //    {
    //        Console.WriteLine("Get food");
    //    }
    //}

    //public class Meat : Meal
    //{
    //    public override void GetFood()
    //    {
    //        Console.WriteLine("Get food from meat");
    //    }
    //}


    //public class Grass : Meal
    //{
    //    public override void GetFood()
    //    {
    //        Console.WriteLine("Get food from grass");
    //    }
    //}

    //public class Animal
    //{
    //    public Animal(Meal meal)
    //    {
    //        this.Meal = meal;
    //    }
    //    private Meal Meal;
    //    protected bool IsHungry { get; set; }
    //    public void ShowState()
    //    {
    //        if (IsHungry)
    //        {
    //            Console.WriteLine("I am  hungry");
    //        }
    //        else
    //        {
    //            Console.WriteLine("I am not hungry");
    //        }
    //    }

    //    public void SetState(bool isHungry)
    //    {
    //        IsHungry = isHungry;
    //    }

    //    public void Eat()
    //    {
    //        if (IsHungry)
    //        {
    //            Meal.GetFood();
    //        }
    //    }

    //}

    //public class Predator : Animal
    //{
    //    public Predator(Meal meal) : base(meal)
    //    {
    //    }
    //}

    //public class Herbivorous : Animal
    //{
    //    public Herbivorous(Meal meal) : base(meal)
    //    {
    //    }
    //}


}
