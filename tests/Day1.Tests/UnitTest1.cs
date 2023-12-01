using Xunit;

namespace Day1.Tests
{
	public class UnitTest1
	{
		[Theory]
		[InlineData("1abc2", 12)]
		[InlineData("pqr3stu8vwx", 38)]
		[InlineData("a1b2c3d4e5f", 15)]
		[InlineData("treb7uchet", 77)]
		public void Solve_should_return_calibration_value(string text, int expectedCalibrationValue)
		{
			// Act
			var calibrationValue = Result.Solve(text);

			// Assert
			Assert.Equal(expectedCalibrationValue, calibrationValue);
		}
	}
}