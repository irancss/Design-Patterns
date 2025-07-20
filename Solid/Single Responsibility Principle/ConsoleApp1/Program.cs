using System.Diagnostics;

public class Journal
{
    public List<string> entries { get; set; } = new List<string>();
    private static int count = 0;

    public int AddEntry(string text)
    {
        entries.Add($"{++count} : {text}");
        return count;
    }

    public void RemoveEntry(int index)
    {
        if (index < 0 || index >= entries.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
        }
        entries.RemoveAt(index);
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }



    public static Journal LoadFromFile(string filename)
    {
        Debug.Assert(filename != null, nameof(filename) + " != null");
        if (filename != null && File.GetAttributes("name").Equals(obj: filename))
        {
            throw new Exception();
        }
        var journal = new Journal();
        journal.Load(filename);
        return journal;
    }

    public void Load(string filename)
    {
        //if (!filename.Length.ToString() > 0 && File.Exists(filename))
        //{
        //    entries = File.ReadAllLines(filename).ToList();
        //    count = entries.Count;
        //    Console.WriteLine($"Loading journal from {filename}");
        //}
        //else
        //{
        //    throw new FileNotFoundException("File not found.", filename);
        //}
    }
    public class Persistence
    {
        public void SaveToFile<T>(T j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }
    public class Demo
    {

        static void Main(string[] args)
        {
            var j = new Journal();
            var p = new Persistence();

            var fileName = "journal.txt";
            p.SaveToFile<Journal>(j , fileName, true);
            Process.Start(fileName);

            Console.WriteLine(j);
        }

    }
}
