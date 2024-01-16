using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;

namespace Szachy_Projekt
{
    public class ChessMoveDB
    {
        private string filePath;

        public ChessMoveDB(string filePath)
        {
            this.filePath = filePath;
        }

        public List<string[]> ReadAllRecords()
        {
            var records = new List<string[]>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var fields = line.Split(',');
                    records.Add(fields);
                }
            }

            return records;
        }

        public void AddRecord(string[] record)
        {
            var line = string.Join(",", record);
            File.AppendAllLines(filePath, new[] { line });
        }
    }
}
