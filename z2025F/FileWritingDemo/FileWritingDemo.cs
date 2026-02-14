namespace CompSci.zClasswork.FileWritingDemo
{
    public static class IO
    {
        private static void FileWritingDemo()
        {
            string path = @"test.txt";

            if (File.Exists(path))
            {
                Console.WriteLine("File exists.");
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
            
            try
            {
                using StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine("Nyah~");
                sw.WriteLine("Thx fren :3");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        private static void FileReadingDemo()
        {
            string path = @"test.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            try
            {
                using StreamReader sr = new StreamReader(path);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void Main()
        {
            FileReadingDemo();
        }
    }
}