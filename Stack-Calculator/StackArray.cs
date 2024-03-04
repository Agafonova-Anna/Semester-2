/// <summary>
/// Stack, a last-in-first-out container implemented using an array.
/// </summary>
public class StackArray : IStack
{
    private static int size = 20;
    private int top = -1;
    private float[] stack = new float[size];

    /// <summary>
    /// Adds elements to a top of the stack.
    /// </summary>
    /// <param name="element">Element to add.</param>
    /// <exception cref="InvalidOperationException">it is thrown out when the stack is full and no more items can be added.</exception>
    public void Push(float element)
    {
        if (this.top > size)
        {
            throw new InvalidOperationException("Stack Overflow");
        }

        this.top++;
        this.stack[this.top] = element;
    }

    /// <summary>
    /// Gets elements from the top of the stack and removes it.
    /// </summary>
    /// <returns>Element that was on the top.</returns>
    /// <exception cref="InvalidOperationException">is thrown when the stack is empty.</exception>
    public float Pop()
    {
        if (this.top < 0)
        {
            throw new InvalidOperationException("The Stack is empty");
        }

        return this.stack[this.top--];
    }
}