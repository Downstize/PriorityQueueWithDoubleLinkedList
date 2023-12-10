using static System.Console;

namespace PriorityQueueWithDoubleLinkedList;

public class Program
{
    static void Main()
    {
        Queue<string> priorityQueue = new Queue<string>();

        priorityQueue.Add("Привет, Андрей", 10);
        priorityQueue.Add("Как дела?", 7);
        priorityQueue.Add("Что делаешь?", 4);
        priorityQueue.Add("Ничего не спрашивайте по лабе пж", 3);
        priorityQueue.Add("Можно просто поставить зачёт?", 1);

        WriteLine($"Размер очереди = {priorityQueue.Size()}");
        WriteLine("-----------------");

        foreach (var item in priorityQueue)
        {
            Thread.Sleep(1000);
            WriteLine($"Значение элемента (узла) = {item} ");
        }
        WriteLine("-----------------");
        Thread.Sleep(1000);
        WriteLine($"Максимальный элемент без удаления: {priorityQueue.Peek()}");
        WriteLine("-----------------");
        Thread.Sleep(1000);
        WriteLine($"Максимальный элемент с удалением: {priorityQueue.Poll()}");
        WriteLine("-----------------");
        Thread.Sleep(1000);
        WriteLine($"Размер очереди = {priorityQueue.Size()}");
        WriteLine("-----------------");
        foreach (var item in priorityQueue)
        {
            Thread.Sleep(1000);
            WriteLine($"Значение элемента (узла) = {item} ");
        }
    }
}
