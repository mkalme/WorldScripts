using System;
using System.IO;
using System.Threading.Tasks;
using WorldEditor;

namespace HighestPeak {
    public class WorldPeakScanner : IPeakScanner<string> {
        public IPeakScanner<Region> RegionScanner { get; set; }
        public int Buffer { get; set; } = 10;

        public WorldPeakScanner() {
            RegionScanner = new RegionPeakScanner();
        }

        public Peak Scan(string regionDirectory) {
            string[] regionFiles = Directory.GetFiles(regionDirectory);

            Peak[] outputs = new Peak[regionFiles.Length];

            for (int i = 0; i < regionFiles.Length; i += Buffer) {
                int end = i + Buffer > regionFiles.Length ? regionFiles.Length : i + Buffer;

                Parallel.For(i, end, j => {
                    CustomRegionReader regionReader = new CustomRegionReader();
                    regionReader.TryRead((regionFiles[j], ChunkLoadSettings.Default), out Region region);

                    outputs[j] = RegionScanner.Scan(region);
                });

                Console.WriteLine($"{end}/{regionFiles.Length} ({((float)end / regionFiles.Length * 100).ToString("N2").Replace(",", ".")}%)");
            }

            Peak output = new Peak(short.MinValue, new Cords(0, 0));

            for (int i = 0; i < regionFiles.Length; i++) {
                if (outputs[i].Y > output.Y) output = outputs[i];
            }

            return output;
        }
    }
}
