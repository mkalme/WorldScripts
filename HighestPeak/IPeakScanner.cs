using System;
using WorldEditor;

namespace HighestPeak {
    public interface IPeakScanner<TInput> {
        Peak Scan(TInput input);
    }
}
