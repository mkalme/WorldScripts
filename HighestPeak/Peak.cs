using System;
using WorldEditor;

namespace HighestPeak {
    public struct Peak {
        public short Y { get; set; }
        public Cords Cords { get; set; }

        public Peak(short y, Cords cords) {
            Y = y;
            Cords = cords;
        }
    }
}
