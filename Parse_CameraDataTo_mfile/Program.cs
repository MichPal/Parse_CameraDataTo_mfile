using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parse_CameraDataTo_mfile
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = "data2";

            using (StreamReader inputFile = new StreamReader($"C:/Users/Michal/Desktop/Skola/Diplomovka/parametre_kamery/{fileName}.txt"))
            using (StreamWriter outputFile = new StreamWriter(String.Format($"C:/Users/Michal/Desktop/Skola/Diplomovka/parametre_kamery/{fileName}_parsed.m")))
            {
                List<string> lines = new List<string>();
                while(true)
                {
                    var line = inputFile.ReadLine();
                    if (line == null)
                        break;
                    if (line != string.Empty)
                        lines.Add(line.Replace(" NEWLINE",""));
                }

                StringBuilder x_cm = new StringBuilder();
                StringBuilder y_cm = new StringBuilder();
                StringBuilder x_px = new StringBuilder();
                StringBuilder priemer_kruhu = new StringBuilder();

                foreach (var line in lines)
                {
                    var rawData = line.Split(' ');

                    x_px.Append(int.Parse(rawData[0]) + " ");
                    priemer_kruhu.Append(int.Parse(rawData[2]) + " ");
                    x_cm.Append(int.Parse(rawData[4]) + " ");
                    y_cm.Append(int.Parse(rawData[3]) + " ");

                }


                outputFile.WriteLine("x_cm=[" + x_cm.ToString() + "];");
                outputFile.WriteLine("y_cm=[" + y_cm.ToString() + "];");
                outputFile.WriteLine("x_px=[" + x_px.ToString() + "];");
                outputFile.WriteLine("priemer_kruhu=[" + priemer_kruhu.ToString() + "];");
            }
        }
    }
}
