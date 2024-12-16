using System;
using System.Collections;
using AdventOfCode_2024;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Day03 : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text resultText;
    public ScrollRect scrollRect;
    public float velocity = 1;
    private readonly string greenColor = "#009900";
    private readonly string redColor = "#ff0000";
    private readonly string yellow = "#ffff66";
    private Day03Events events;
    private int indexOffset;
    private string input;

    private void Awake()
    {
        events = new Day03Events();
        var textAsset = Resources.Load<TextAsset>("AdventOfCode/2024/03");
        input = textAsset.text;
        string b = AdventOfCode_2024.Day03.PuzzleB(textAsset.text, events);
        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        scrollRect.velocity = new Vector2(0, velocity);
        foreach (var entry in events.Entries)
        {
            yield return null;
            resultText.SetText(entry.Result.ToString());
            input = HighlightByIndex(input, entry.StartIndex, entry.Length, GetColor(entry));
            text.SetText(input);
            //   ScrollToCharacter(entry.StartIndex + indexOffset);
        }

        EditorApplication.ExitPlaymode();
    }

    private string GetColor(Day03Events.Day03Event day03Event)
    {
        return day03Event.Type switch
        {
            Day03Events.EntryType.Mul => day03Event.Enabled ? yellow : "#CCCCCC",
            Day03Events.EntryType.Dont => redColor,
            Day03Events.EntryType.Do => greenColor,

            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private string HighlightByIndex(string text, int startIndex, int length, string color)
    {
        string before = text.Substring(0, startIndex + indexOffset);
        string toHighlight = text.Substring(startIndex + indexOffset, length);
        string after = text.Substring(startIndex + indexOffset + length);
        indexOffset += 16 + color.Length;
        return $"{before}<color={color}>{toHighlight}</color>{after}";
    }
}