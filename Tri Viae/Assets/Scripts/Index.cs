using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Index{
    public static void Shuffle<T> (this System.Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
[System.Serializable]
public class question
{
    public string theme;
    public int themeID;
    public string title;
    public int correct;
    public bool fourPick;
    public answers[] answers;
}
[System.Serializable]
public class answers
{
    public string text;
    public int id;
}

[System.Serializable]
public struct randomizedList{
    public int listOrder;
    public List<int> id;
    public int internalIndex;
}