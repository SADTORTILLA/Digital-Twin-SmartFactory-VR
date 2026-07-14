using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

/// <summary>
/// Stores scenario completion times in PlayerPrefs.
/// </summary>
public static class RunHistory
{
    private const string RunTimesKey = "runs.times";
    private const char Separator = '|';
    private const int MaxStoredRuns = 20;

    public static void AddRun(float seconds)
    {
        List<float> times = GetRuns();
        times.Insert(0, Mathf.Max(0f, seconds));

        if (times.Count > MaxStoredRuns)
            times.RemoveRange(MaxStoredRuns, times.Count - MaxStoredRuns);

        SaveRuns(times);
    }

    public static List<float> GetRuns()
    {
        var output = new List<float>();
        string raw = PlayerPrefs.GetString(RunTimesKey, string.Empty);

        if (string.IsNullOrWhiteSpace(raw))
            return output;

        string[] chunks = raw.Split(Separator);
        foreach (string chunk in chunks)
        {
            if (float.TryParse(chunk, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
                output.Add(value);
        }

        return output;
    }

    public static void ClearRuns()
    {
        PlayerPrefs.DeleteKey(RunTimesKey);
        PlayerPrefs.Save();
    }

    private static void SaveRuns(List<float> times)
    {
        string[] raw = new string[times.Count];

        for (int i = 0; i < times.Count; i++)
            raw[i] = times[i].ToString("0.###", CultureInfo.InvariantCulture);

        PlayerPrefs.SetString(RunTimesKey, string.Join(Separator.ToString(), raw));
        PlayerPrefs.Save();
    }
}
