/// <summary>
/// Stack, a last-in-first-out container implemented using a list.
/// </summary>
public class StackList : IStack
{
    private LinkedList<float> Stack = new LinkedList<float>();

    /// <summary>
    /// Adds elements to a top of the stack.
    /// </summary>
    /// <param name="element">Element to add.</param>
    public void Push(float element)
    {
        Stack.AddFirst(element);
    }

    /// <summary>
    /// Gets elements from the top of the stack and removes it.
    /// </summary>
    /// <returns>Element that was on the top.</returns>
    /// <exception cref="InvalidOperationException">is thrown when the stack is empty.</exception>
    public float Pop()
    {
        if (!Stack.Any())
        {
            throw new InvalidOperationException("The Stack is empty");
        }

        float element = Stack.First.Value;
        Stack.RemoveFirst();

        return element;
    }
}