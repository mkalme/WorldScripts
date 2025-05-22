using System;
using WorldEditor;

namespace HighestPeak {
    public class ChunkPeakScanner : IPeakScanner<Chunk> {
        public Peak Scan(Chunk chunk) {
            Cords cords = new Cords(0, 0);
            short output = short.MinValue;

            if (chunk.Heightmaps.TryGetValue("WORLD_SURFACE", out ushort[] heightmap)) {
                for (int i = 0; i < 256; i++) {
                    short floor = (short)(heightmap[i] + chunk.Configuration.MinY);

                    if (floor > output) {
                        output = floor;
                        cords = new Cords(i % 16 + chunk.Cords.X * 16, i / 16 + chunk.Cords.Z * 16);
                    }
                }
            }

            return new Peak(output, cords);
        }
    }
}
