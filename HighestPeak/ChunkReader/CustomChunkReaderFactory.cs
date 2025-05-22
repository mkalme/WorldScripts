using System;
using WorldEditor;
using NbtEditor;

namespace HighestPeak {
    public class CustomChunkReaderFactory : ChunkReaderFactory {
        protected override IChunkReader<(CompoundTag, ChunkLoadSettings)> CreateFlattenedReader((CompoundTag, ChunkLoadSettings) parameter) {
            return new CustomFlattenedChunkReader();
        }
    }
}
