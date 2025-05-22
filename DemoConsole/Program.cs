using System;
using HighestPeak;

namespace DemoConsole {
    class Program {
        private static readonly string WorldName = "PreGen_8192r_nr3";
        private static readonly string RegionFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\.minecraft\\saves\\{WorldName}\\region";

        static void Main(string[] args) {
            FindHighestPeak();

            Console.ReadLine();
        }

        private static void FindHighestPeak() {
            WorldPeakScanner peakScanner = new WorldPeakScanner();
            Peak peak = peakScanner.Scan(RegionFolder);

            Console.WriteLine($"Highest peak: Y {peak.Y}, {peak.Cords.X}; {peak.Cords.Z}");
        }
    }
}
