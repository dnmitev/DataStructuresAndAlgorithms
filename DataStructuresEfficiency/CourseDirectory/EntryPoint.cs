// 01. A text file students.txt holds information about students and their courses Using SortedDictionary<K,T> print the 
// courses in alphabetical order and for each of them prints the students ordered by family and then by name

namespace CourseDirectory
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class EntryPoint
    {
        private static void Main()
        {
            var indexerByCourse = new SortedDictionary<string, SortedDictionary<string, string>>();

            var reader = new StreamReader(@"..\..\input.txt", Encoding.UTF8);
            using (reader)
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var firstName = data[0];
                    var lastName = data[1];
                    var course = data[2];

                    SortedDictionary<string, string> entry;
                    if (!indexerByCourse.TryGetValue(course, out entry))
                    {
                        entry = new SortedDictionary<string, string>();
                        indexerByCourse.Add(course, entry);
                    }

                    entry.Add(firstName, lastName);

                    line = reader.ReadLine();
                }
            }

            var result = new StringBuilder();
            foreach (var entry in indexerByCourse.Keys)
            {
                result.AppendLine(entry);

                var fullName = indexerByCourse[entry];
                foreach (var name in fullName)
                {
                    result.AppendLine(string.Format("\t{0} {1}", name.Key, name.Value));
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}