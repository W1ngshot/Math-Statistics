namespace Statistics;

public static class Formatting
{
    public static double ToRound(this double number, int accuracy) =>
        Math.Round(number, accuracy);
}