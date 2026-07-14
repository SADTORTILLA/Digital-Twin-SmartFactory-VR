using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Holds temporary user information from the start scene
/// and handles saving it to a CSV file.
/// </summary>
public static class SessionDataManager
{
    public static string UserName { get; set; } = "Unknown";
    public static string Gender { get; set; } = "Male";
    public static string Age { get; set; } = "0";
    public static string UserClass { get; set; } = "None";
    public static bool IsFirstTime { get; set; } = true;
    public static string SceneName { get; set; } = "Unknown";

    // Change save path to Desktop
    private static readonly string csvFilePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/UserSessionData.csv";

    public static void SaveSessionToCSV(float completionTime, System.Collections.Generic.List<float> stepTimes, System.Collections.Generic.List<int> falseGrabsPerStep = null)
    {
        bool fileExists = File.Exists(csvFilePath);

        SceneName = SceneManager.GetActiveScene().name;

        using (StreamWriter writer = new StreamWriter(csvFilePath, true))
        {
            // If the file doesn't exist, write the header row first
            if (!fileExists)
            {
                string header = "Date,Name,Gender,Age,Class,IsFirstTime,SceneName,TotalTimeSeconds";
                for (int i = 0; i < stepTimes.Count; i++)
                {
                    header += $",Step {i + 1} Time";
                }
                
                if (falseGrabsPerStep != null)
                {
                    for (int i = 0; i < falseGrabsPerStep.Count; i++)
                    {
                        header += $",Step {i + 1} False Grabs";
                    }
                }
                writer.WriteLine(header);
            }

            // Write the actual user data
            string dateStr = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            
            // Format time nicely or just save raw seconds
            string line = $"{dateStr},{EscapeCSV(UserName)},{Gender},{Age},{EscapeCSV(UserClass)},{IsFirstTime},{EscapeCSV(SceneName)},{completionTime.ToString("0.###")}";
            
            for (int i = 0; i < stepTimes.Count; i++)
            {
                line += $",{stepTimes[i].ToString("0.###")}";
            }

            if (falseGrabsPerStep != null)
            {
                for (int i = 0; i < falseGrabsPerStep.Count; i++)
                {
                    line += $",{falseGrabsPerStep[i]}";
                }
            }
            
            writer.WriteLine(line);
        }
        
        Debug.Log($"[SessionDataManager] User session data saved to CSV at: {csvFilePath}");
    }

    private static string EscapeCSV(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";
        if (input.Contains(",") || input.Contains("\""))
        {
            input = input.Replace("\"", "\"\"");
            return $"\"{input}\"";
        }
        return input;
    }
}