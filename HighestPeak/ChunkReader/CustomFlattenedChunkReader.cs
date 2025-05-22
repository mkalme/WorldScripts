using System;
using System.Collections.Generic;
using NbtEditor;
using WorldEditor;

namespace HighestPeak {
    public class CustomFlattenedChunkReader : ChunkReaderBase {
        public IHeightmapReader<(Chunk, ArrayTag)> HeightmapReader { get; set; }

        public CustomFlattenedChunkReader() {
            HeightmapReader =  new HeightmapReader();
        }

        protected override void LoadSections(Chunk chunk, CompoundTag nbtData, CompoundTag level, ChunkLoadSettings settings) {

        }
        protected override void LoadHeightmaps(Chunk chunk, CompoundTag level, HeightmapLoadSettings settings) {
            if (!level.TryGetValue("Heightmaps", out Tag heightmapTag)) return;

            CompoundTag heightmap = heightmapTag as CompoundTag;

            IList<string> heightmaps = settings.Types;
            for (int i = 0; i < heightmaps.Count; i++) {
                if (heightmap.TryGetValue(heightmaps[i], out Tag worldSurface)) {
                    if (!HeightmapReader.TryRead((chunk, worldSurface as ArrayTag), out ushort[] map)) continue;

                    chunk.Heightmaps.Add(heightmaps[i], map);
                }
            }
        }
    }
}
