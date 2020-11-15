using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic.CompilerServices;

namespace TimeLibrary {
    public class Time : IComparable, IEquatable<Time> {
        private long _totalSecond;
        public int Hours => (int) (_totalSecond / (60 * 60));
        public int Minutes => (int) (_totalSecond % (60 * 60) / 60);

        public int Seconds => (int) (_totalSecond % (60 * 60) % 60);

        public Time(int hours = 0, int minutes = 0, int seconds = 0) {
            if (minutes > 59) {
                throw new ArgumentOutOfRangeException(nameof(minutes),
                    $"Number of minutes is more than 59. Was {minutes}.");
            }

            if (minutes < -59) {
                throw new ArgumentOutOfRangeException(nameof(minutes),
                    $"Number of minutes is less than -59. Was {minutes}.");
            }

            if (seconds > 59) {
                throw new ArgumentOutOfRangeException(nameof(seconds),
                    $"Number of seconds is more than 59. Was {seconds}.");
            }

            if (seconds < -59) {
                throw new ArgumentOutOfRangeException(nameof(seconds),
                    $"Number of seconds is less than -59. Was {seconds}.");
            }

            _totalSecond = seconds + minutes * 60 + hours * 60 * 60;
        }

        public Time(Time time) : this(time.Hours, time.Minutes, time.Seconds) { }

        public Time AddSeconds(long seconds) {
            _totalSecond += seconds;
            return this;
        }

        public Time AddMinutes(int minutes) {
            _totalSecond += minutes * 60;
            return this;
        }

        public Time AddHours(int hours) {
            _totalSecond += hours * 60 * 60;
            return this;
        }

        public int CompareTo(object? obj) {
            if (obj is null) {
                throw new ArgumentNullException(nameof(obj));
            }

            Time time = obj as Time;
            if (time is null) {
                throw new ArgumentException("Object is not Time");
            }

            return this._totalSecond.CompareTo(time._totalSecond);
        }

        bool IEquatable<Time>.Equals(Time other) {
            return this._totalSecond.Equals(other?._totalSecond);
        }

        public override bool Equals(object? obj) {
            if (obj is null) {
                return false;
            }

            Time time = obj as Time;
            if (time is null) {
                return false;
            }

            return this._totalSecond.Equals(time._totalSecond);
        }


        public static Time operator +(Time a, Time b) => a.AddSeconds(b._totalSecond);
        public static Time operator -(Time a, Time b) => a.AddSeconds(-b._totalSecond);
        public static bool operator >(Time a, Time b) => a.CompareTo(b) > 0;
        public static bool operator <(Time a, Time b) => a.CompareTo(b) < 0;
        public static bool operator >=(Time a, Time b) => a.CompareTo(b) >= 0;
        public static bool operator <=(Time a, Time b) => a.CompareTo(b) <= 0;
        public static bool operator ==(Time a, Time b) => a.Equals(b);
        public static bool operator !=(Time a, Time b) => !a.Equals(b);
    }
}