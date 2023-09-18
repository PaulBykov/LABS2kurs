using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

public class TestClass 
{
    public static void uncheckedFunction()
    {
        unchecked
        {
            int a = Int32.MaxValue;
            Console.WriteLine(a + 1);
        }
    }

    public static void checkedFunction()
    {
        checked
        {
            int a = Int32.MaxValue;
            Console.WriteLine(a + 1);
        }
    }

    public static void createInputRequest() 
    {
        Console.WriteLine("Enter a value: ");
    }

    public static void enterResult<T>(T value)
    {
        Console.WriteLine("You entered this value: " + value);
    }


    public static void Main(string[] args)
    {
        bool bStatus = true;
        Console.WriteLine(bStatus);

        createInputRequest();
        byte btFirstNumber = Convert.ToByte(Console.ReadLine());
        enterResult(btFirstNumber);

        createInputRequest();
        char cSymbol = Convert.ToChar(Console.ReadLine());
        enterResult(cSymbol);

        createInputRequest();
        decimal decNumber = Convert.ToDecimal(Console.ReadLine());
        enterResult(decNumber);

        createInputRequest();
        double dNumber = Convert.ToDouble(Console.ReadLine());
        enterResult(dNumber);

        createInputRequest();
        float fNumber = Convert.ToSingle(Console.ReadLine());
        enterResult(fNumber);

        createInputRequest();
        int iNumber = Convert.ToInt32(Console.ReadLine());
        enterResult(iNumber);

        createInputRequest();
        long lNumber = Convert.ToInt64(Console.ReadLine());
        enterResult(lNumber);

        createInputRequest();
        short shNumber = Convert.ToInt16(Console.ReadLine());
        enterResult(shNumber);


        //Неявные преобразования
        byte number_0 = 12;
        short number_1 = number_0;
        int number_2 = number_1;
        long number_3 = number_2;
        float number_4 = number_2;


        //Явные преобразования
        double number_6 = 12.1231312432412;
        float number_7 = (float)number_6;

        short number_8 = (short)number_6;
        int number_9 = (int)number_8;
        byte number_10 = (byte)number_8;
        long number_11 = number_9;


        // Упаковка и распаковка значимых типов

        int firstVariableBoxed = 0;
        object firstObject = firstVariableBoxed;

        long secondVariableBoxed = 1;
        object secondObject = secondVariableBoxed;

        float thirdVariableBoxed = 1.1f;
        object thirdObject = thirdVariableBoxed;


        int firstVariableUnboxed = (int)firstObject;
        long secondVariableUnboxed = (long)secondObject;
        float thirdVariableUnboxed = (float)thirdObject;


        //Неявно типизированная переменная

        var implicitlyTyped = 512;
        Console.WriteLine("Your implicitly typed variable: " + implicitlyTyped);


        //Nullable переменная
        int? nullableVariable = null;
        Console.WriteLine("\nYour nullable variable is holding " + nullableVariable);
        nullableVariable = 123;
        Console.WriteLine("\nNow its holding " + nullableVariable);


        /*
         * Определите переменную  типа  var и присвойте ей любое значение. 
         * Затем следующей инструкцией присвойте ей значение другого типа. 
         * Объясните причину ошибки.
         */

        var someVariable = 12;
        //someVariable = "No";


        //Объявите строковые литералы. Сравните их
        string firstName = "Pavel";
        string secondName = "Stas";

        int result = String.Compare(firstName, secondName);

        if (result == 0)
        {
            Console.WriteLine("The same!");
        }
        else
        {
            Console.WriteLine(result > 0 ? firstName : secondName);
        }

        // -----------------------------------------------------------------------------------

        string firstString = "First string ";
        string secondString = "Second string ";
        string thirdString = "Third string";
        string stringForConcat = String.Concat(firstString, secondString, thirdString);
        Console.WriteLine("\nConnected strings: " + stringForConcat);

        string stringForCopy = String.Copy(firstString);
        Console.WriteLine("\nCopied first string: " + stringForCopy);

        string stringForSubString = firstString.Substring(0, firstString.Length - 5);
        Console.WriteLine("\nSubstring from first string: " + stringForSubString);

        string[] words = thirdString.Split(' ');
        foreach (var word in words)
        {
            Console.WriteLine($"{word}");
        }

        string stringForPaste = firstString.Insert(2, stringForSubString);
        Console.WriteLine("\nFirst string with inserted substring from the 2nd position: " + stringForPaste);
        Console.WriteLine("\nFirst string with deleted substring from 2nd position to 7th: " + stringForPaste.Remove(2, 5));
        Console.WriteLine($"\nInterpolation of strings: {firstString}, {secondString}, {thirdString}");

        //Пустая и null строка

        string emptyString = "";
        string nullString = null;
        Console.WriteLine("Result of method IsNullOrEmpty for emptyString: " + String.IsNullOrEmpty(emptyString));
        Console.WriteLine("Result of method IsNullOrEmpty for nullString: " + String.IsNullOrEmpty(nullString));
        Console.WriteLine("We can unite them: " + emptyString + nullString);
        Console.WriteLine("We can compare them with method Compare: " + String.Compare(emptyString, nullString));

        //Создайте строку на основе StringBuilder

        StringBuilder newString = new StringBuilder("String made up by StringBuilder", 50);
        newString.Remove(0, 6);
        newString.Append("A");
        newString.Insert(0, "B");
        Console.WriteLine("\n" + newString);

        //Создайте целый двумерный массив и выведите его на консоль в отформатированном виде (матрица)

        int[,] matrix = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        string[] daysaWeak = new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        for (int i = 0; i < daysaWeak.Length; i++)
        {
            Console.Write(daysaWeak[i] + " ");
        }

        Console.WriteLine("The length of your array is " + daysaWeak.Length);

        Console.WriteLine("Enter which element you want to replace: ");
        int index = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter your string: ");
        daysaWeak[index] = Console.ReadLine();

        for (int i = 0; i < daysaWeak.Length; i++)
        {
            Console.Write(daysaWeak[i] + " ");
        }
        Console.WriteLine();

        double[][] stair_array = new double[3][];
        stair_array[0] = new double[2];
        stair_array[1] = new double[3];
        stair_array[2] = new double[4];

        for (int i = 0; i < 2; i++)
        {
            stair_array[0][i] = Convert.ToDouble(Console.ReadLine());
        }
        for (int i = 0; i < 3; i++)
        {
            stair_array[1][i] = Convert.ToDouble(Console.ReadLine());
        }
        for (int i = 0; i < 4; i++)
        {
            stair_array[2][i] = Convert.ToDouble(Console.ReadLine());
        }

        var someNames = new[] { "Alice", "Jane", "John", "Jack" };
        var implicitString = "There is nothing to read";

        //Кортежи
        (int tupleInt, string tupleString, char, string, ulong) tuple = (5, "Pavel", 'A', "Bykov", 1234567890);
        Console.WriteLine(tuple);

        Console.WriteLine($"Element 1: {tuple.Item1}, Element3: {tuple.Item3}, Element5: {tuple.Item5}");

        int tmpIntVariable = tuple.tupleInt;
        string tmpStringVariable = tuple.tupleString;

        Console.WriteLine("We're using variable from unpacked tuple: " + tmpStringVariable);
        (int tupleInt, string tupleString, char tupleChar, string tupleString2, ulong tupleUlong) tuple2 = (-2, "Paul Bukov", 'K', "nice guy", 542151252);

        Console.WriteLine((tuple == tuple2) ? ("Tuples are the same") : ("Tuples are not the same"));


        //Локальная функция

        (int maxValue, int minValue, int sumOfElements, char firstSymbol) LocalFunction(int[] arrayForFunction,
            string stringForFunction)
        {
            int sum = arrayForFunction.Sum();
            int max = arrayForFunction.Max();
            int min = arrayForFunction.Min();

            return (max, min, sum, stringForFunction[0]);
        };

        Console.WriteLine(LocalFunction(new[] { 1244, 124, -1244, 2144 }, "Kirill"));

        //Checked и unchecked

        checkedFunction();
        uncheckedFunction();




    }


};