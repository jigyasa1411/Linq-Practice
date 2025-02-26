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




            // Where,OfType, OrderBy, ThenBy, GroupBy, ToLookup, Join, GroupJoin, Select, 
            //All, Any, Contains for tabular data. 

            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, Name = "Alice", Age = 30, DepartmentID = 1, Salary = 50000 },
                new Employee { EmployeeID = 2, Name = "Bob", Age = 25, DepartmentID = 2, Salary = 45000 },
                new Employee { EmployeeID = 3, Name = "Charlie", Age = 35, DepartmentID = 1, Salary = 60000 },
                new Employee { EmployeeID = 4, Name = "David", Age = 28, DepartmentID = 3, Salary = 40000 },
                new Employee { EmployeeID = 5, Name = "Eve", Age = 40, DepartmentID = 2, Salary = 70000 }
            };

            // WHERE : Filtering Employees Above 30
            Console.WriteLine("------- WHERE : Filtering Employees Above 30 ------");
            var seniorEmployees = employees.Where(e => e.Age > 30);

            foreach (var emp in seniorEmployees)
                Console.WriteLine(emp.Name);

            // OfType : Filtering Only Numeric Data from Mixed List
            Console.WriteLine("-------- OfType : Filtering Only Numeric Data from Mixed List ------");
            var mixedData = new List<object> { "Alice", 25, 30, "Bob", 40, 35.5 };
            var numericData = mixedData.OfType<int>();

            foreach (var num in numericData)
                Console.WriteLine(num);

            // OrderBy - Sorting Employees by Salary (Ascending)
            Console.WriteLine("---------- OrderBy - Sorting Employees by Salary (Ascending) ---------");
            var sortedEmployees = employees.OrderBy(e => e.Salary);

            foreach (var emp in sortedEmployees)
                Console.WriteLine($"{emp.Name} - {emp.Salary}");

            // ThenBy - Sorting Employees by Department and Then Salary
            Console.WriteLine("--------- ThenBy - Sorting Employees by Department and Then Salary -------");
            var sortedEmployeesThenBy = employees.OrderBy(e => e.DepartmentID).ThenBy(e => e.Salary);

            foreach (var emp in sortedEmployeesThenBy)
                Console.WriteLine($"{emp.Name} - {emp.DepartmentID} - {emp.Salary}");

            // GroupBy - Group Employees by Department
            Console.WriteLine("------- GroupBy - Group Employees by Department ---------");
            var groupedEmployees = employees.GroupBy(e => e.DepartmentID);

            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"Department {group.Key}:");
                foreach (var emp in group)
                    Console.WriteLine($"  {emp.Name}");
            }

            // ToLookup - Creating Lookup for Quick Access
            Console.WriteLine("----------- ToLookup - Creating Lookup for Quick Access -------");
            var employeeLookup = employees.ToLookup(e => e.DepartmentID);

            Console.WriteLine("Employees in Department 1:");
            foreach (var emp in employeeLookup[1])
                Console.WriteLine(emp.Name);

            // Join - Joining Employees with Departments
            var departments = new List<Department>
            {
                new Department { DepartmentID = 1, DepartmentName = "HR" },
                new Department { DepartmentID = 2, DepartmentName = "IT" },
                new Department { DepartmentID = 3, DepartmentName = "Sales" }
            };

            var employeeDetails = employees.Join(departments,
                e => e.DepartmentID,
                d => d.DepartmentID,
                (e, d) => new { e.Name, e.Age, e.Salary, d.DepartmentName });

            foreach (var emp in employeeDetails)
                Console.WriteLine($"{emp.Name} - {emp.DepartmentName} - {emp.Salary}");


            // GroupJoin - Group Employees Under Departments
            Console.WriteLine("------------ GroupJoin - Group Employees Under Departments ---------");
            var departmentGroups = departments.GroupJoin(employees,
            d => d.DepartmentID,
            e => e.DepartmentID,
            (d, emps) => new { d.DepartmentName, Employees = emps });

            foreach (var group in departmentGroups)
            {
                Console.WriteLine($"{group.DepartmentName}:");
                foreach (var emp in group.Employees)
                    Console.WriteLine($"  {emp.Name}");
            }

            // Select - Projecting Employee Names
            Console.WriteLine("--------- Select - Projecting Employee Names -----------");
            var employeeNames = employees.Select(e => e.Name);

            foreach (var name in employeeNames)
                Console.WriteLine(name);

            // All - Checking if All Employees Earn More Than 30,000
            Console.WriteLine("---------- All - Checking if All Employees Earn More Than 30,000 --------");
            bool allHighEarners = employees.All(e => e.Salary > 30000);
            Console.WriteLine(allHighEarners);


            // Any - Checking If There Are Any Employees in HR
            Console.WriteLine("---------- Any - Checking If There Are Any Employees in HR --------");
            bool hasHREmployees = employees.Any(e => e.DepartmentID == 1);
            Console.WriteLine(hasHREmployees);


            // Contains - Checking If Employee List Contains a Specific Employee
            Console.WriteLine("------------- Contains - Checking If Employee List Contains a Specific Employee ---------");
            var checkEmployee = new Employee { EmployeeID = 3, Name = "Charlie", Age = 35, DepartmentID = 1, Salary = 60000 };
            bool exists = employees.Contains(checkEmployee);
            Console.WriteLine(exists);















        }
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentID { get; set; }
        public decimal Salary { get; set; }
    }

    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

}