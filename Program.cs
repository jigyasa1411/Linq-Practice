using System;
using System.Linq;
using System.Collections;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)


        {
            // CONVERSION OPEARTORS

            // 1. AsEnumerable - Converts a list to IEnumerable<T> to enable LINQ queries.
            List<int> list = new List<int> { 1, 2, 3 };
            IEnumerable<int> enumerable = list.AsEnumerable();


            // 2. ToList - Converts a sequence to a List<T>.
            var numbers = Enumerable.Range(1, 5);
            List<int> listNumbers = numbers.ToList(); // {1, 2, 3, 4, 5}

            for (int i = 0; i < listNumbers.Count; i++)
            {
                Console.Write(" " + listNumbers[i]);
            }

            // 3. ToArray - Converts a sequence to an array.
            int[] arrayNumbers = numbers.ToArray(); // {1, 2, 3, 4, 5}

            // 4. ToDictionary - Converts a sequence to a dictionary.
            var people = new[]
                {
                    new { Id = 1, Name = "Alice" },
                    new { Id = 2, Name = "Bob" }
                };
            var dictionary = people.ToDictionary(p => p.Id, p => p.Name);
            for (int i = 1; i < dictionary.Count + 1; i++)
            {
                Console.WriteLine(dictionary[i]);
            }

            // 5. Cast - Converts elements to a specific type.
            ArrayList arrayList = new ArrayList { 1, 2, 3 };
            var casted = arrayList.Cast<int>().ToList(); // {1, 2, 3}
            for (int i = 0; i < casted.Count; i++)
            {
                Console.WriteLine(casted[i]);
            }

            // 6. OfType - Filters elements by type.
            object[] mixed = { 1, "hello", 2, "world" };
            var numbersOnly = mixed.OfType<int>(); // {1, 2}
            var stringsOnly = mixed.OfType<string>(); // {"hello", "world"}
            for (int i = 0; i < mixed.ToList().Count; i++)
            {
                Console.WriteLine(mixed.ToList()[i]);
            }
            for (int i = 0; i < numbersOnly.ToList().Count; i++)
            {
                Console.WriteLine(numbersOnly.ToList()[i]);
            }
            for (
                int i = 0; i < stringsOnly.ToList().Count; i++
            )
            {
                Console.WriteLine(stringsOnly.ToList()[i]);
            }



            // The let keyword is used in LINQ to store intermediate calculations within a query.
            var words = new[] { "apple", "banana", "cherry" };

            var query = from word in words
                        let upper = word.ToUpper() // Store uppercase version
                        where upper.StartsWith("C")
                        select upper;

            foreach (var item in query)
            {
                Console.WriteLine(item); // Output: BANANA
            }


            // The into keyword is used to continue a query after a grouping or join.
            // Example 1: Using into with Grouping
            var numbers1 = new[] { 1, 2, 3, 4, 5, 6 };

            var query1 = from n in numbers1
                         group n by n % 2 into grouped
                         select new { Key = grouped.Key, Count = grouped.Count() };

            foreach (var group in query1)
            {
                Console.WriteLine($"Key: {group.Key}, Count: {group.Count}");
            }

            // Example 2: Using into with join
            var students = new[]
            {
                new { Id = 1, Name = "Alice" },
                new { Id = 2, Name = "Bob" }
            };
            var scores = new[]
            {
                new { StudentId = 1, Score = 90 },
                new { StudentId = 2, Score = 85 }
            };

            var result = from s in students
                         join sc in scores on s.Id equals sc.StudentId into studentScores
                         select new { s.Name, Scores = studentScores };

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name}: {string.Join(", ", student.Scores.Select(s => s.Score))}");
            }


            // Immediate Execution
            // Query runs and stores results immediately.
            // Examples: ToList(), ToArray(), Count(), Sum()
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var result = numbers.Where(n => n > 2).ToList(); // Executed immediately

            numbers.Add(6); // Modifying source does NOT affect `result`

            foreach (var num in result)
            {
                Console.WriteLine(num);
            }

            // Deferred Execution
            // Query is not executed immediately; it runs when iterated.
            // Examples: Select, Where, OrderBy, GroupBy
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var query = numbers.Where(n => n > 2); // Query not executed yet

            numbers.Add(6); // Modifying source

            foreach (var num in query)
            {
                Console.WriteLine(num);
            }

        }
    }
}