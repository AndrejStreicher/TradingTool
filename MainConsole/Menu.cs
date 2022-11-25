namespace MainConsole;

public class Menu
{
    private int _selectedItem;
    private string[] _options;
    private string _prompt;

    public Menu(string prompt, string[] options)
    {
        _prompt = prompt;
        _options = options;
        _selectedItem = 0;
    }

    private void DisplayOptions()
    {
        string prefix;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(_prompt);
        for (int i = 0; i < _options.Length; i++)
        {
            if (_selectedItem == i)
            {
                prefix = ">>";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = "  ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            string currentOption = _options[i];
            Console.WriteLine($"{prefix} {currentOption}");
        }

        Console.ResetColor();
    }

    public int CreateMenu()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.UpArrow)
            {
                _selectedItem--;
                if (_selectedItem == -1)
                {
                    _selectedItem = _options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                _selectedItem++;
                if (_selectedItem == _options.Length)
                {
                    _selectedItem = 0;
                }
            }
        } while (keyPressed != ConsoleKey.Enter);

        return _selectedItem;
    }
}