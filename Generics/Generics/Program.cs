using System.Runtime.CompilerServices;

namespace Generics
{
    public class GenericClass<T>
    {
        public static int count = 0;

        public static void Increment() => count++;
        public static void Display() { Console.WriteLine($"Generic Type --> {typeof(T)}\nCounter: {count}"); }
    }

    internal class Program
    {
        static void Assembly_Info_of_Generic_Type_Objects()
        {
            foreach (var item in typeof(Tuple<int, float, double, string, long>).GenericTypeArguments)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void Method<T>()
        {
            Console.WriteLine(typeof(T).Name + " -->--> " + typeof(List<T>).FullName);

            Console.WriteLine("------------------------------------------------------");

            Console.WriteLine(typeof(Dictionary<,>).FullName);
            Console.WriteLine(typeof(List<>).FullName);
        }

        static void How_Each_Genericly_Typed_Object_Differ()
        {
            GenericClass<int>.Increment();
            GenericClass<int>.Increment();
            GenericClass<int>.Increment();
            GenericClass<int>.Display();

            Console.WriteLine();

            GenericClass<string>.Increment();
            GenericClass<string>.Display();
        }

        static void Main(string[] args)
        {
            How_Each_Genericly_Typed_Object_Differ();
        }
    }
}