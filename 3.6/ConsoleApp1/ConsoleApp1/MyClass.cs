namespace ConsoleApp1;

public class MyClass
{
    private static MyClass _inctence;

    private MyClass() { }

    public static MyClass GetInstane()
    {
        _inctence = _inctence == null ? _inctence = new MyClass() : _inctence;
        return _inctence;
    }
}
