using System;
using WorldEditor;

namespace HighestPeak {
    public class CustomRegionReader : RegionReader {
        public CustomRegionReader() : base() {
            ChunkReaderFactory = new CustomChunkReaderFactory();
        }
    }
}
