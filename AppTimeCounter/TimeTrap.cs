using System;


namespace AppTimeCounter {
    class TimeTrap {
        public TimeTrap() {
            StartTime = DateTime.Now;
        }
        public DateTime StartTime { get; set; }
        public TimeSpan TotalTime { get; set; }
    }
}
