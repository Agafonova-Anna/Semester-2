/// <summary>
/// This interface describes the methods in the stack data type.
/// </summary>
public interface IStack
{
    /// <summary>
    /// Adds elements to a top of the stack.
    /// </summary>
    /// <param name="element">Element to add.</param>
    void Push(float element);

    /// <summary>
    /// Gets elements from the top of the stack and removes it.
    /// </summary>
    /// <returns>Element that was on the top.</returns>
    float Pop();
}