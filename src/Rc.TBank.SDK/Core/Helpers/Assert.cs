namespace Rc.TBank.SDK.Core.Helpers;

internal abstract class Assert
{
    #region Private Members

    private static void That<T>(Func<T, bool> func, T value, string field)
    {
        if (!func(value))
            throw new ArgumentException($"Unable to build request: field '{field}' is not valid");
    }

    #endregion

    #region Public Members

    public static void IsNonNegative(int value, string field)
    {
        That(arg => arg >= 0, value, field);
    }

    public static void IsNonNegative(decimal value, string field)
    {
        That(arg => arg >= decimal.Zero, value, field);
    }

    public static void IsNonNullOrEmpty(string value, string field)
    {
        That(arg => !string.IsNullOrEmpty(arg), value, field);
    }

    #endregion
}