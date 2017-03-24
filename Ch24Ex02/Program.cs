using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Ch24Ex02
{
    internal class Program
    {
        private static void Main()
        {
            WriteLine("Основной поток выполнения запущен.");

            var mc = new MyClass();

            var task = new Task(mc.MyTask);

            task.Start();

            for (int i = 0; i < 60; i++)
            {
                Write(".");
                Thread.Sleep(100);
            }

            WriteLine("Основной поток выполнения завершён.");
        }
    }

    internal class MyClass
    {
        // Метод выполняющийся в качестве задачи.
        public void MyTask()
        {
            WriteLine("MyTask запущен.");

            for (var count = 0; count < 10; count++)
            {
                Thread.Sleep(500);
                WriteLine($"В методе MyTask(), подсчёт равен {count}");
            }

            WriteLine("MyTask pзавершён.");
        }
    }
}
