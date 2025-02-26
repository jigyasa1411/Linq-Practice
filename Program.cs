using System;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)


        {
            // AGGREGATION METHODS

            int[] numbers = { 1, 2, 3, 4 };

            // Aggregate 
            Console.WriteLine("------------- Aggregate -------------");
            int aggResult = numbers.Aggregate((a, b) => a * b);
            Console.WriteLine("aggResult " + aggResult);

            // Average - Computes the average of a sequence of numeric values.
            Console.WriteLine("----------- Average --------------");
            double avg = numbers.Average(); // (1 + 2 + 3 + 4) / 4 = 2.5
            Console.WriteLine("avg : " + avg);

            // Count - Returns the number of elements in a sequence.
            Console.WriteLine("-------- Count -------");
            int count = numbers.Count(); // 4
            Console.WriteLine("count : " + count);

            // Max - Returns the maximum value in a sequence.
            Console.WriteLine("--------- Max ---------");
            int max = numbers.Max(); // 4
            Console.WriteLine("max : " + max);

            // Sum - Computes the sum of a sequence of numeric values.
            Console.WriteLine("--------- Sum ----------");
            int sum = numbers.Sum(); // 1 + 2 + 3 + 4 = 10
            Console.WriteLine("sum : " + sum);


            // ELEMENTS OPERATORS

            // ElementAt - Returns the element at a specified index.
            Console.WriteLine("---------- ElementAt ----------");

            int element = numbers.ElementAt(2); // 3 (0-based index)
            Console.WriteLine("elementAt : " + element);

            // ElementAtOrDefault - Returns the element at a specified index or default if out of range.
            Console.WriteLine("------- ElementAtOrDefault --------");
            int elementOrDefault = numbers.ElementAtOrDefault(10); // 0 (default for int)
            Console.WriteLine("elementOrDefault : " + elementOrDefault);

            // First - Returns the first element; throws if the sequence is empty.
            Console.WriteLine("--------- First ----------");
            int first = numbers.First(); // 1
            Console.WriteLine("first : " + first);

            // FirstOrDefault - Returns the first element or default if empty.
            Console.WriteLine("--------- FirstOrDefault ----------");
            int firstOrDefault = numbers.FirstOrDefault(); // 1 (or default if empty)
            Console.WriteLine("firstOrDefault : " + firstOrDefault);

            // Last - Returns the last element; throws if empty.
            Console.WriteLine("--------- Last ---------");
            int last = numbers.Last(); // 4
            Console.WriteLine("last : " + last);

            // LastOrDefault - Returns the last element or default if empty.
            Console.WriteLine("--------- LastOrDefault ----------");
            int lastOrDefault = numbers.LastOrDefault(); // 4 (or default if empty)
            Console.WriteLine("lastOrDefault : " + lastOrDefault);

            // Single - Returns a single element; throws if there is more than one or none.
            Console.WriteLine("---------- Single ----------");
            int[] singleArray = { 42 };
            int single = singleArray.Single(); // 42
            Console.WriteLine("single : " + single);

            // SingleOrDefault - Returns a single element or default if empty; throws if multiple.
            Console.WriteLine("-----------  SingleOrDefault ----------");
            int singleOrDefault = singleArray.SingleOrDefault(); // 42
            Console.WriteLine("singleOrDefault : " + singleOrDefault);


            // SET OPERATORS

            // SequenceEqual - Determines whether two sequences are equal.
            Console.WriteLine("---------- SequenceEqual -----------");
            int[] seq1 = { 1, 2, 3 };
            int[] seq2 = { 1, 2, 3 };
            bool isEqual = seq1.SequenceEqual(seq2); // true
            Console.WriteLine("isEqual : " + isEqual);

            // Concat - Concatenates two sequences.
            Console.WriteLine("--------- Concat -----------");
            var concatenated = seq1.Concat(new int[] { 4, 5 }); // {1, 2, 3, 4, 5}
            Console.WriteLine("concat : " + concatenated);

            // DefaultIfEmpty - Returns the sequence or a default value if empty.
            Console.WriteLine("----------- DefaultIfEmpty -----------");
            int[] emptyArray = { };
            var result = emptyArray.DefaultIfEmpty(100); // {100}
            Console.WriteLine("defaultIfEmpty result : " + result);




            // GENERATION METHODS

            // Empty - Returns an empty sequence.
            Console.WriteLine("----------- Empty ----------");
            var emptySequence = Enumerable.Empty<int>(); // No elements
            Console.WriteLine(emptySequence);


            // Range - Generates a sequence of numbers within a range.
            Console.WriteLine("-------- Range ---------");
            var range = Enumerable.Range(1, 5); // {1, 2, 3, 4, 5}
            Console.WriteLine("range : " + range);

            // Repeat - Repeats an element multiple times.
            Console.WriteLine("---------- Repeat ----------");
            var repeated = Enumerable.Repeat("Hello", 3); // {"Hello", "Hello", "Hello"}
            Console.WriteLine("repeated : " + repeated);


            // SET OPERATIONS

            // Distinct - Removes duplicate values.
            Console.WriteLine("----------- Distinct -----------");
            int[] values = { 1, 2, 2, 3 };
            var distinctValues = values.Distinct(); // {1, 2, 3}
            Console.WriteLine("distinct : " + distinctValues);

            // Except - Returns elements from the first sequence that are not in the second.
            Console.WriteLine("----------- Except ------------");
            var except = new int[] { 1, 2, 3, 4 }.Except(new int[] { 3, 4 }); // {1, 2}
            Console.WriteLine("except : " + except);


            // Intersect - Returns common elements from both sequences.
            Console.WriteLine("---------- intersect ----------");
            var intersect = new int[] { 1, 2, 3 }.Intersect(new int[] { 2, 3, 4 }); // {2, 3}
            Console.WriteLine("intersect : " + intersect);

            // Union - Returns unique elements from both sequences.
            Console.WriteLine("------------- Union ------------");
            var union = new int[] { 1, 2, 3 }.Union(new int[] { 3, 4, 5 }); // {1, 2, 3, 4, 5}
            Console.WriteLine("union : " + union);


            // PARTITIONING METHODS

            // Skip - Skips a specified number of elements.
            Console.WriteLine("-------------- Skip --------------");
            var skipped = numbers.Skip(2); // {3, 4}
            Console.WriteLine("skip : " + skipped);

            // SkipWhile - Skips elements while a condition is met.
            Console.WriteLine("--------------- Skip While ----------------");
            var skipWhile = numbers.SkipWhile(n => n < 3); // {3, 4}
            Console.WriteLine("skip while : " + skipWhile);

            // Take - Takes a specified number of elements.
            Console.WriteLine("------------- Take ----------");
            var taken = numbers.Take(2); // {1, 2}
            Console.WriteLine("take : " + taken);


            // TakeWhile - Takes elements while a condition is met.
            Console.WriteLine("------------- Take While -------------");
            var takeWhile = numbers.TakeWhile(n => n < 3); // {1, 2}
            Console.WriteLine("take while : " + takeWhile);







        }
    }
}