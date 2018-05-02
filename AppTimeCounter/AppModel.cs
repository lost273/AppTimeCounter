using System;

namespace AppTimeCounter {
    class AppModel {
        public AppModel() {
            startTime = DateTime.Now;
        }
        public DateTime startTime { get; set; }
        public TimeSpan totalTime { get; set; }
    }
}
