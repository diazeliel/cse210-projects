using System.IO;

/// The Journal Class is responsible for managing all the journal entry.
/// It saves and loads these entries in a txt file. It saves the name of the 
/// file as well. Also, it stores the date of the entry.
public class Journal
{
    /// Initial the dateTime and fileName attributes 
    public string _date = "";
    public string _fileName = "";
    private string _filePath = $"journal/";
    private string txtName;

    public string fileAccessName (string fileName)
    {
        /// <summary>
        /// This method takes filename as an input from the user,
        /// removes all whitespace and replace it with an '_' underscore.
        /// </summary>
        /// <param name="fileName">the fileName to store the entry</param>
        /// <returns> A string with an underscore '_'</returns>


        _fileName = fileName;
        txtName = _fileName.Replace(" ", "_").ToLower();
        _filePath += txtName;
        return _filePath;
    }

    
    // Creating the methods for the journal class.
    public string Entry ( string prompt, string fileN = "")
    {
        /// <summary>
        /// The Entry method saves the prompt, date, and the user response in a file.
        /// It displays the prompt recieved from Display class in the main Program,
        /// and stores the users response and saves it.
        /// </summary>
        /// <param name="fileN">the fileName or directory to save the journal in <typeparam name="String">a String</typeparam></param>
        /// <param name="prompt">the prompt/questioned to display to the user <typeparam name="String">a String</typeparam></param>
        /// <returns> It returns the file path to be used by other methods. <typeparam name="String">a String</typeparam> </returns>
        
        using(StreamWriter outputFile = new StreamWriter($"{fileN}.txt"))
        {
            Console.WriteLine(prompt);
            string output = Console.ReadLine();
            outputFile.WriteLine($"--------- File Name: {_fileName}--------------\n-----------Date of Entry: {_date}---------\nQues: {prompt}\n>> ans: {output}\n");
            Console.WriteLine("");
            Console.WriteLine("Your New Journal has been saved");
        }
        return fileN;
    }

    private void Save (string content, string [] file, int option)
    {
        /// <summary>
        /// This private method, saves the journal content and gives the user
        /// a choice to save or not save the entry.
        /// </summary>
        /// <param name="content">the content to save. <typeparam name="String">a String</typeparam></param>
        /// <param name="file"> a list of strings - the list of files in the journal folder <typeparam name="string[]">a list of string</typeparam></param>
        /// <param name="option"> the option from the user on which file to save the content <typeparam name="int"> an integer</typeparam></param>
        /// <returns> returns none </returns>
        
        string choice = "q";
        do
        {
            Console.Write("Save Entry 'y' | Continue Entry'n' | QUIT entry 'q': ");
            choice = Console.ReadLine().ToLower();
        
            if (choice == "y")
            {
                File.AppendAllText(file[option - 1], $"{content}");
                Console.WriteLine("\nYour entry has been saved 📥");
                break;
            } 
            else if (choice == "n")
            {  
                File.AppendAllText(file[option - 1], $"\n{content}");
                Console.WriteLine("\nLet's go 🚵🏼‍♀️:\n");
                content = Console.ReadLine();
            }
        } while (choice != "q");
        
    }
    public void Continue (string prompt)
    {
        // <summary>
        /// This method takes care of the user's choice to continue journaling.
        /// Makes use of the display class to display current files saved for the 
        /// user to choice from.
        /// </summary>
        /// <param name="prompt">the prompt to display to the user <typeparam name="String">a String</typeparam></param>
        /// <returns> returns none </returns>

        string thePrompt = prompt;

        Display display = new();
        string [] files = display.CurrentFiles();

        Console.Write("\nChoose from the files above you would like to continue with: ");
        int option = int.Parse(Console.ReadLine());

        Console.WriteLine(thePrompt);
        string newEntry = Console.ReadLine();
        string content = $"Ques: {thePrompt}\n>> ans: {newEntry}\n";
        Console.WriteLine("");

        Save(content, files, option);

    }

}