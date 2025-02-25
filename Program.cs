using System;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)


        {

            Console.WriteLine("--------------WHERE-------------------");
            // Data source
            List<string> my_list = new List<string>()
            {
                    "This is my Dog",
                    "Name of my Dog is Robin",
                    "This is my Cat",
                    "Name of the cat is Mewmew"
            };

            // Creating LINQ Query
            IEnumerable<string> res = from l in my_list
                                      where l.Contains("my")
                                      select l;

            // Executing LINQ Query
            foreach (string q in res)
            {
                Console.WriteLine(q);
            }


            // OFTYPE => Used to show records of a particular type.
            Console.WriteLine("--------------OF Type-------------------");
            var fruits = new List<object?>
                {
                "Mango",
                    "Orange",
                    null,
                    "Apple",
                    3.0,
                    "Banana"
                }
            ;

            // Apply OfType() to the ArrayList.
            IEnumerable<string> ofTypeQuery = fruits.OfType<string>();

            Console.WriteLine("Elements of type 'string' are:");
            foreach (string fruit in ofTypeQuery)
            {
                Console.WriteLine(fruit);
            }


            // ORDERBY: Sorts elements in ascending or descending order
            Console.WriteLine("--------------ORDER BY-------------------");

            var names = new List<string> { "John", "Alice", "Bob" };
            var sortedNames = names.OrderBy(n => n);

            foreach (var name in sortedNames)
                Console.WriteLine(name);

            List<int> intList = new List<int>() {
                1, 7, 99, 57, 77, 98
            };

            IEnumerable<int> descendingSortedList = from i in intList where i > 10 orderby i descending select i;
            foreach (var name in descendingSortedList)
                Console.WriteLine(name);


            // THEN BY: Performs secondary sorting.
            Console.WriteLine("--------------THEN BY-------------------");
            List<(string Name, int Age)> people = new List<(string Name, int Age)>()
                    {
                        ("John", 30),
                        ("Alice", 25),
                        ("Bob", 30),
                        ("Charlie", 25)
                    };

            var sortedPeople = people.OrderBy(p => p.Age).ThenBy(p => p.Name);

            foreach (var person in sortedPeople)
                Console.WriteLine($"{person.Name} - {person.Age}");

            // GROUP BY: Groups elements based on a key.

            Console.WriteLine("--------------GROUP BY-------------------");
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var groups = numbers.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");

            foreach (var group in groups)
            {
                Console.WriteLine(group.Key + ": " + string.Join(", ", group));
            }

            // TO LOOKUP: Similar to GroupBy, but returns a Lookup, which allows multiple lookups.

            Console.WriteLine("--------------TO LOOKUP-------------------");

            var words = new List<string> { "apple", "banana", "apricot", "blueberry" };
            var lookup = words.ToLookup(w => w[0]); // Groups by first letter

            foreach (var group in lookup)
            {
                Console.WriteLine(group.Key + ": " + string.Join(", ", group));
            }

            // JOIN: Performs an inner join between two sequences.

            Console.WriteLine("--------------JOIN-------------------");
            var students = new List<(int Id, string Name)>
                {
                    (1, "John"),
                    (2, "Alice"),
                    (3, "Bob")
                };

            var scores = new List<(int StudentId, int Score)>
                {
                    (1, 90),
                    (2, 85),
                    (1, 95)
                };

            var studentScores = students.Join(scores,
                student => student.Id,
                score => score.StudentId,
                (student, score) => new { student.Name, score.Score });

            foreach (var record in studentScores)
                Console.WriteLine($"{record.Name}: {record.Score}");


            // GROUP JOIN: Performs a grouped join, grouping matching elements.

            Console.WriteLine("--------------GROUP JOIN-------------------");

            var categories = new List<(int Id, string Category)>
                {
                    (1, "Fruits"),
                    (2, "Vegetables")
                };

            var products = new List<(string Name, int CategoryId)>
                {
                    ("Apple", 1),
                    ("Carrot", 2),
                    ("Banana", 1),
                    ("Broccoli", 2)
                };

            var grouped = categories.GroupJoin(products,
                category => category.Id,
                product => product.CategoryId,
                (category, products) => new { category.Category, Products = products });

            foreach (var group in grouped)
            {
                Console.WriteLine(group.Category + ": " + string.Join(", ", group.Products.Select(p => p.Name)));
            }

            // SELECT: Projects each element into a new form.

            Console.WriteLine("--------------SELECT-------------------");

            var numList = new List<int> { 1, 2, 3 };
            var squares = numList.Select(n => n * n);

            foreach (var square in squares)
                Console.WriteLine(square);

            // ALL: Checks if all elements satisfies a condition

            Console.WriteLine("--------------ALL-------------------");

            var numList1 = new List<int> { 2, 4, 6 };
            bool areAllEven = numList1.All(n => n % 2 == 0);
            Console.WriteLine(areAllEven);

            // ANY: Checks if any elements satisfies a condition

            Console.WriteLine("--------------ANY-------------------");

            var numList2 = new List<int> { 1, 3, 5 };
            bool hasEven = numList2.Any(n => n % 2 == 0);
            Console.WriteLine(hasEven);

            // CONTAINS: Checks if a sequence contains a specified element.
            Console.WriteLine("--------------CONTAINS-------------------");
            var numList3 = new List<int> { 1, 2, 3, 4, 5 };
            bool containsThree = numList3.Contains(3);
            Console.WriteLine(containsThree);










        }
    }
}