using System;

namespace TimeLibrary {
    public class Time {
        private int _totalSecond;
        public int Hours => _totalSecond / (60 * 60);
        public int Minutes => _totalSecond % (60 * 60) / 60;

        public int Seconds => _totalSecond % (60 * 60) % 60;

        public Time(int hours = 0, int minutes = 0, int seconds = 0) {
            _totalSecond = seconds + minutes * 60 + hours * 60 * 60;
        }

        public Time(Time time) : this(time.Hours, time.Minutes, time.Seconds) { }

        public Time AddSeconds(int seconds) {
            _totalSecond += seconds;
            return this;
        }
    }
}