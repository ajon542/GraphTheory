using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    class MapReader
    {
        List<List<bool>> grid = new List<List<bool>>();

        IGraph graph;

        public IGraph ReadMapFile(string path)
        {
            graph = new SimpleGraph();
            int row = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    grid.Add(new List<bool>());

                    string line = sr.ReadLine();
                    for (int col = 0; col < line.Length; ++col)
                    {
                        char c = line[col];
                        if(c == '.')
                        {
                            grid[row].Add(true);
                        }
                        else
                        {
                            grid[row].Add(false);
                        }
                    }

                    row++;
                }
            }

            return graph;
        }
    }
}
