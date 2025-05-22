using System;
using WorldEditor;

namespace HighestPeak {
    public class RegionPeakScanner : IPeakScanner<Region> {
        public IPeakScanner<Chunk> ChunkScanner { get; set; }

        public RegionPeakScanner() {
            ChunkScanner = new ChunkPeakScanner();
        }

        public Peak Scan(Region region) {
            Peak output = new Peak(short.MinValue, new Cords(0, 0));

            foreach (var chunk in region.Chunks) {
                Peak peak = ChunkScanner.Scan(chunk);

                if (peak.Y > output.Y) output = peak;
            }

            return output;
        }
    }
}
