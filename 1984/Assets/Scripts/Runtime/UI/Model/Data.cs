using System;

public class Data<T>
{
    private T value;

    public T Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
            this.onChange?.Invoke(value);
        }
    }
    public Action<T> onChange;
}