class Demo4
{
    public static void Run()
    {
        Stack<string> actions = new Stack<string>();

        actions.Push("Type A");
        actions.Push("Type B");
        actions.Push("Delete B");
        actions.Push("Type C");

        Console.WriteLine("Undo:");
        for (int i = 0; i < 3; i++)
            Console.WriteLine(actions.Pop());

        Console.WriteLine("Top: " + actions.Peek());

        Stack<string> redo = new Stack<string>();
        redo.Push("Delete B");
    }
}