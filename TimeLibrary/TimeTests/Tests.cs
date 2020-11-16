using System;
using FluentAssertions;
using NUnit.Framework;
using TimeLibrary;

namespace TimeTests {
    public class Tests {
        [Test]
        public void Constructor_CorrectArguments_ShouldCreateTime() {
            // Arrange
            // Act
            Time _ = new Time(12, 48, 53);
            // Assert
        }

        [Test]
        public void Constructor_DefaultArguments_ShouldCreateTime() {
            // Arrange
            // Act
            Time time = new Time();
            // Assert
            time.Seconds.Should().Be(0);
            time.Minutes.Should().Be(0);
            time.Hours.Should().Be(0);
        }

        [Test]
        public void Constructor_MinutesMoreThan59_ShouldThrowArgumentOutOfRangeException() {
            // Arrange
            const int minutes = 60;
            // Act
            Action act = () => {
                Time _ = new Time(minutes: minutes);
            };
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage($"Number of minutes is more than 59. Was {minutes}. (Parameter 'minutes')");
        }

        [Test]
        public void Constructor_MinutesLessThanMinus59_ShouldThrowArgumentOutOfRangeException() {
            // Arrange
            const int minutes = -60;
            // Act
            Action act = () => {
                Time _ = new Time(minutes: minutes);
            };
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage($"Number of minutes is less than -59. Was {minutes}. (Parameter 'minutes')");
        }

        [Test]
        public void Constructor_SecondsMoreThan59_ShouldThrowArgumentOutOfRangeException() {
            // Arrange
            const int seconds = 60;
            // Act
            Action act = () => {
                Time _ = new Time(seconds: seconds);
            };
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage($"Number of seconds is more than 59. Was {seconds}. (Parameter 'seconds')");
        }

        [Test]
        public void Constructor_SecondsLessThanMinus59_ShouldThrowArgumentOutOfRangeException() {
            // Arrange
            const int seconds = -60;
            // Act
            Action act = () => {
                Time _ = new Time(seconds: seconds);
            };
            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage($"Number of seconds is less than -59. Was {seconds}. (Parameter 'seconds')");
        }

        [Test]
        public void Constructor_TwoSeconds_ShouldTimeHaveSecondsTwo() {
            // Arrange
            const int seconds = 2;
            // Act
            Time time = new Time(seconds: seconds);
            // Assert
            time.Seconds.Should().Be(seconds);
        }

        [Test]
        public void Constructor_MinusTwoSeconds_ShouldTimeHaveSecondsMinusTwo() {
            // Arrange
            const int seconds = -2;
            // Act
            Time time = new Time(seconds: seconds);
            // Assert
            time.Seconds.Should().Be(seconds);
        }

        [Test]
        public void Constructor_TwoMinutes_ShouldTimeHaveTwo() {
            // Arrange
            const int minutes = 2;
            // Act
            Time time = new Time(minutes: minutes);
            // Assert
            time.Minutes.Should().Be(minutes);
        }

        [Test]
        public void Constructor_MinusTwoMinutes_ShouldTimeHaveMinusTwo() {
            // Arrange
            const int minutes = -2;
            // Act
            Time time = new Time(minutes: minutes);
            // Assert
            time.Minutes.Should().Be(minutes);
        }

        [Test]
        public void Constructor_TwoHours_ShouldTimeHaveTwo() {
            // Arrange
            const int hours = 2;
            // Act
            Time time = new Time(hours: hours);
            // Assert
            time.Hours.Should().Be(hours);
        }

        [Test]
        public void Constructor_MinusTwoHours_ShouldTimeHaveMinusTwo() {
            // Arrange
            const int hours = -2;
            // Act
            Time time = new Time(hours: hours);
            // Assert
            time.Hours.Should().Be(hours);
        }

        [Test]
        public void Constructor_TimeArgument_ShouldCreateTime() {
            // Arrange
            const int hours = 5;
            const int minutes = 15;
            const int seconds = 30;
            Time time = new Time(hours, minutes, seconds);

            // Act 
            Time cloneTime = new Time(time);

            // Assert
            cloneTime.Hours.Should().Be(hours);
            cloneTime.Minutes.Should().Be(minutes);
            cloneTime.Seconds.Should().Be(seconds);
        }

        [Test]
        public void Constructor_MinusTimeArgument_ShouldCreateTime() {
            // Arrange
            const int hours = -5;
            const int minutes = -15;
            const int seconds = -30;
            Time time = new Time(hours, minutes, seconds);

            // Act 
            Time cloneTime = new Time(time);

            // Assert
            cloneTime.Hours.Should().Be(hours);
            cloneTime.Minutes.Should().Be(minutes);
            cloneTime.Seconds.Should().Be(seconds);
        }

        [Test]
        public void Constructor_DefaultTimeArgument_ShouldCreateTime() {
            // Arrange
            Time time = new Time();

            // Act 
            Time cloneTime = new Time(time);

            // Assert
            cloneTime.Hours.Should().Be(0);
            cloneTime.Minutes.Should().Be(0);
            cloneTime.Seconds.Should().Be(0);
        }

        [Test]
        public void AddSeconds_PositiveNumberArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddSeconds(3661);
            // Assert
            time.Hours.Should().Be(1);
            time.Minutes.Should().Be(1);
            time.Seconds.Should().Be(1);
        }

        [Test]
        public void AddSeconds_NegativeNumberArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddSeconds(-3661);
            // Assert
            time.Hours.Should().Be(-1);
            time.Minutes.Should().Be(-1);
            time.Seconds.Should().Be(-1);
        }

        [Test]
        public void AddSeconds_ZeroSecondsArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddSeconds(0);
            // Assert
            time.Hours.Should().Be(0);
            time.Minutes.Should().Be(0);
            time.Seconds.Should().Be(0);
        }

        [Test]
        public void AddMinutes_PositiveNumberArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddMinutes(61);
            // Assert
            time.Hours.Should().Be(1);
            time.Minutes.Should().Be(1);
            time.Seconds.Should().Be(0);
        }

        [Test]
        public void AddMinutes_NegativeNumberArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddMinutes(-61);
            // Assert
            time.Hours.Should().Be(-1);
            time.Minutes.Should().Be(-1);
            time.Seconds.Should().Be(0);
        }

        [Test]
        public void AddMinutes_ZeroMinutesArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddMinutes(0);
            // Assert
            time.Hours.Should().Be(0);
            time.Minutes.Should().Be(0);
            time.Seconds.Should().Be(0);
        }

        [Test]
        public void AddHours_PositiveNumberArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddHours(1);
            // Assert
            time.Hours.Should().Be(1);
            time.Minutes.Should().Be(0);
            time.Seconds.Should().Be(0);
        }

        [Test]
        public void AddHours_NegativeNumberArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddHours(-1);
            // Assert
            time.Hours.Should().Be(-1);
            time.Minutes.Should().Be(0);
            time.Seconds.Should().Be(0);
        }

        [Test]
        public void AddHours_ZeroHoursArgument_ShouldReturnCorrectTime() {
            // Arrange 
            Time time = new Time();
            // Act
            time.AddHours(0);
            // Assert
            time.Hours.Should().Be(0);
            time.Minutes.Should().Be(0);
            time.Seconds.Should().Be(0);
        }

        [Test]
        public void CompareTo_OtherTimeLess_ShouldReturnOne() {
            // Arrange
            Time a = new Time(10, 10, 10);
            Time b = new Time(5, 5, 5);

            // Act
            int result = a.CompareTo(b);

            // Assert
            result.Should().Be(1);
        }

        [Test]
        public void CompareTo_OtherTimeGreater_ShouldReturnMinusOne() {
            // Arrange
            Time a = new Time(5, 5, 5);
            Time b = new Time(10, 10, 10);

            // Act
            int result = a.CompareTo(b);

            // Assert
            result.Should().Be(-1);
        }

        [Test]
        public void CompareTo_OtherTimeEquals_ShouldReturnZero() {
            // Arrange
            Time a = new Time(5, 5, 5);
            Time b = new Time(5, 5, 5);

            // Act
            int result = a.CompareTo(b);

            // Assert
            result.Should().Be(0);
        }

        [Test]
        public void Equals_OtherTimesSame_ShouldReturnTrue() {
            // Arrange
            Time a = new Time(1, 1, 1);
            Time b = new Time(1, 1, 1);

            // Act
            bool result = a.Equals(b);

            // Assert
            result.Should().Be(true);
        }

        [Test]
        public void Equals_OtherTimeDifferent_ShouldReturnFalse() {
            // Arrange
            Time a = new Time(1, 1, 1);
            Time b = new Time(2, 2, 2);

            // Act
            bool result = a.Equals(b);

            // Assert
            result.Should().Be(false);
        }

        [Test]
        public void Plus_OtherTimePositive_ShouldResultBeSum() {
            // Arrange
            Time a = new Time(1, 1, 1);
            Time b = new Time(2, 2, 2);

            // Act
            Time result = a + b;

            // Assert
            result.Hours.Should().Be(3);
            result.Minutes.Should().Be(3);
            result.Seconds.Should().Be(3);
        }

        [Test]
        public void Plus_OtherTimeNegative_ShouldResultBeSum() {
            // Arrange
            Time a = new Time(-1, -1, -1);
            Time b = new Time(-2, -2, -2);

            // Act
            Time result = a + b;

            // Assert
            result.Hours.Should().Be(-3);
            result.Minutes.Should().Be(-3);
            result.Seconds.Should().Be(-3);
        }

        [Test]
        public void Plus_OtherTimeDefault_ShouldResultBeSum() {
            // Arrange
            Time a = new Time();
            Time b = new Time();

            // Act
            Time result = a + b;

            // Assert
            result.Hours.Should().Be(0);
            result.Minutes.Should().Be(0);
            result.Seconds.Should().Be(0);
        }

        [Test]
        public void Minus_OtherTimePositive_ShouldResultBeDifference() {
            // Arrange
            Time a = new Time(1, 1, 1);
            Time b = new Time(2, 2, 2);

            // Act
            Time result = a - b;

            // Assert
            result.Hours.Should().Be(-1);
            result.Minutes.Should().Be(-1);
            result.Seconds.Should().Be(-1);
        }

        [Test]
        public void Minus_OtherTimeNegative_ShouldResultBeDifference() {
            // Arrange
            Time a = new Time(-1, -1, -1);
            Time b = new Time(-2, -2, -2);

            // Act
            Time result = a - b;

            // Assert
            result.Hours.Should().Be(1);
            result.Minutes.Should().Be(1);
            result.Seconds.Should().Be(1);
        }

        [Test]
        public void Minus_OtherTimeDefault_ShouldResultBeDifference() {
            // Arrange
            Time a = new Time();
            Time b = new Time();

            // Act
            Time result = a - b;

            // Assert
            result.Hours.Should().Be(0);
            result.Minutes.Should().Be(0);
            result.Seconds.Should().Be(0);
        }

        [Test]
        public void GreaterThan_OtherTimeLessThan_ShouldResultBeTrue() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(1, 1, 1);

            // Act
            bool result = a > b;

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void GreaterThan_OtherTimeGreaterThan_ShouldResultBeFalse() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(3, 3, 3);

            // Act
            bool result = a > b;

            //Assert
            result.Should().Be(false);
        }

        [Test]
        public void GreaterThan_OtherTimeEquals_ShouldResultBeFalse() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(2, 2, 2);

            // Act
            bool result = a > b;

            //Assert
            result.Should().Be(false);
        }

        [Test]
        public void LessThan_OtherTimeGreaterThan_ShouldResultBeTrue() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(3, 3, 3);

            // Act
            bool result = a < b;

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void LessThan_OtherTimeLessThan_ShouldResultBeFale() {
            // Arrange
            Time a = new Time(4, 4, 4);
            Time b = new Time(3, 3, 3);

            // Act
            bool result = a < b;

            //Assert
            result.Should().Be(false);
        }

        [Test]
        public void LessThan_OtherTimeEquals_ShouldResultBeFalse() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(2, 2, 2);

            // Act
            bool result = a < b;

            //Assert
            result.Should().Be(false);
        }

        [Test]
        public void GreaterThanOrEqualTo_OtherTimeLessThan_ShouldResultBeTrue() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(1, 1, 1);

            // Act
            bool result = a >= b;

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void GreaterThanOrEqualTo_OtherTimeGreaterThan_ShouldResultBeFalse() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(3, 3, 3);

            // Act
            bool result = a >= b;

            //Assert
            result.Should().Be(false);
        }

        [Test]
        public void GreaterThanOrEqualTo_OtherTimeEquals_ShouldResultBeTrue() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(2, 2, 2);

            // Act
            bool result = a >= b;

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void LessThanOrEqualTo_OtherTimeGreaterThan_ShouldResultBeTrue() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(3, 3, 3);

            // Act
            bool result = a <= b;

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void LessThanOrEqualTo_OtherTimeLessThan_ShouldResultBeFalse() {
            // Arrange
            Time a = new Time(4, 4, 4);
            Time b = new Time(3, 3, 3);

            // Act
            bool result = a <= b;

            //Assert
            result.Should().Be(false);
        }

        [Test]
        public void LessThanOrEqualTo_OtherTimeEquals_ShouldResultBeTrue() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(2, 2, 2);

            // Act
            bool result = a <= b;

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void IsEquals_OtherTimeEquals_ShouldResultBeTrue() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(2, 2, 2);

            // Act
            bool result = a == b;

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void IsEquals_OtherTimeNotEquals_ShouldResultBeFalse() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(3, 2, 2);

            // Act
            bool result = a == b;

            //Assert
            result.Should().Be(false);
        }

        [Test]
        public void IsNotEquals_OtherTimeEquals_ShouldResultBeFalse() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(2, 2, 2);

            // Act
            bool result = a != b;

            //Assert
            result.Should().Be(false);
        }

        [Test]
        public void IsNotEquals_OtherTimeNotEquals_ShouldResultBeTrue() {
            // Arrange
            Time a = new Time(2, 2, 2);
            Time b = new Time(3, 2, 2);

            // Act
            bool result = a != b;

            //Assert
            result.Should().Be(true);
        }

        [Test]
        public void ToString_ShouldReturnFormattedString() {
            // Arrange
            Time time = new Time(1, 1, 1);
            
            // Act
            string s = time.ToString();

            // Assert
            s.Should().Be("01:01:01");
        }
    }
}