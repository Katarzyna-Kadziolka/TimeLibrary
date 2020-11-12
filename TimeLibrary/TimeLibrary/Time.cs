using System;

namespace TimeLibrary {
    public class Time {
        public int Hours => Seconds / 60 * 60;
        public int Minutes => Seconds / 60;

        public int Seconds { get; private set; }
        //tworzy mi automatycznie pole dla tej wlasciwosci, nie musze sie tym martwic

        public Time(int hours = 0, int minutes = 0, int seconds = 0) {
            Seconds = seconds + minutes * 60 + hours * 60 * 60;
        }

        public Time(Time time) : this(time.Hours, time.Minutes, time.Seconds) { }

        public Time AddSeconds(int seconds) {
            Seconds += seconds;
            return this;
        }
    }
}