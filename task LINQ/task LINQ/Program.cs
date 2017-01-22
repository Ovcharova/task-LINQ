using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_LINQ
{
    class Program
    {
        class Book
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book { Name = "b LINQ" , Author = "Shildt", Year = 2016 },
                new Book { Name = "LINQ" , Author = "jdhlj", Year = 1996 },
                new Book { Name = "dfgsj" , Author = "Shildt", Year = 2000 },
                new Book { Name = "wqret" , Author = "jdhlj", Year = 2016 },
                new Book { Name = "hlfkhfl" , Author = "Fineas", Year = 1989 },
                new Book { Name = "fhhhLINQ" , Author = "Fineas", Year = 2016 },
            };
            var sortedBooks = books.Where(y => DateTime.IsLeapYear(y.Year)
                && y.Name.Contains("LINQ"));
            Console.Write("Books that have in the names 'LINQ' and leap-year:" + "\n");
            if (!sortedBooks.Any())
            {
                Console.WriteLine("None");
            }
            foreach (var book in sortedBooks)
            {
                Console.WriteLine(String.Format("{0} {1}", book.Name, book.Year));
            }

            string russianWords = "аист свил гнездо на крыше";

            var selectByChar = russianWords
                .Where(ch => (int)ch > 1039 && (int)ch < 1104)
                .GroupBy(c => c)
                .Count();
            Console.WriteLine(string.Format("The sequence is composed by :" + selectByChar + " russians letters"));


            int[] twodigits = { 12, 44, 66, 67, 45, 85, 98, 11, 24, 32, 53, 74, 73, 84, 36 };
            int[] twodigits1 = { 12, 44, 66, 67, 45, 85, 98, 11, 24, 32, 53, 74, 73, 12, 84, 36 };
            Console.WriteLine("Array in two-digits nubmers sorted by increasing upper-digit, than by decreasing lower - digit: ");

            var sortByDigits = twodigits
                .OrderBy(a => a / 10)
                .ThenByDescending(a => a % 10);
            foreach (var array in sortByDigits)
            {
                Console.WriteLine(array);
            }

            var sortedByAuthor = books.GroupBy(b => b.Author);

            Console.Write("Books that have the same Author:" + "\n");
            foreach (var group in sortedByAuthor)
            {
                Console.WriteLine(string.Format("{0} {1}", group.Key, group.Count()));
            }

            var sum = twodigits.Aggregate(0, (result, next) => result + next);
            Console.WriteLine("Sum: "+sum);

            var count = twodigits.Aggregate(0, (result, next) => result + 1);
            Console.WriteLine("Count: "+count);

            var max = twodigits.Aggregate(0, (result, next) => result < next? next:result);
            Console.WriteLine("Max: "+max);

            var average = twodigits
                .Select(integ => (double)integ)
                .Aggregate((result, current) => (result + current))
                / twodigits.Count();
            Console.WriteLine("Average: "+average);


            var test = twodigits1.SelectMany((dig, cou) => twodigits1.Select((subdig, subcount)=>
            {
                if (cou != subcount)
                {
                    return new Tuple<int, int>(dig, subdig);
                }
                return null;
            })).Where(pair => pair != null);

            Console.WriteLine("All combinations: "+"\n");
            foreach (var item in test)
            {
                Console.WriteLine(+item.Item1+ " "+ item.Item2);
            }

            var test1 = test.Where(a =>a.Item1 != a.Item2);
            Console.WriteLine("Combinations with not equal numbers: " + "\n");
            foreach (var i in test1)
            {
                Console.WriteLine(i.Item1 + " " + i.Item2);
            }

            var test2 = test.Where((pair,cnt) => !test.Take(cnt).Any(tuple => (pair.Item1 == tuple.Item2 && pair.Item2 == tuple.Item1)));
            Console.WriteLine("Combinations that exclude a,b if b,a is included: "+"\n");
            foreach (var l in test2)
            {
                Console.WriteLine(l.Item1 + " " + l.Item2);
            }
        }
    }
}
  
