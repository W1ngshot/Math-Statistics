namespace Statistics;

public static class Formatting
{
    public static double ToRound(this double number, int accuracy) =>
        Math.Round(number, accuracy);

    public static (double a, double b) ToRound(this (double a, double b) numbers, int accuracy) =>
        (Math.Round(numbers.a, accuracy), Math.Round(numbers.b, accuracy));
}