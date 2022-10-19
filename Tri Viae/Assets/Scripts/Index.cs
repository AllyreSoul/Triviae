using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Index{
    public static void Shuffle<T> (this System.Random random, T[] array)
    {
        int length = array.Length;
        while (length > 1) 
        {
            int rand = random.Next(length--);
            T temp = array[length];
            array[length] = array[rand];
            array[rand] = temp;
        }
    }
    public static Buff GenerateBuff(){
        int rand = UnityEngine.Random.Range(0, 3);
        Buff end = new Buff();
        switch(rand){
            case 0:
                end.type = Sel.Atk;
                end.amount = (int)UnityEngine.Random.Range(1, 3);
                break;
            case 1:
                end.type = Sel.Def;
                end.amount = (int)UnityEngine.Random.Range(1, 3);
                break;
            case 2:
                end.type = Sel.HP;
                end.amount = (int)UnityEngine.Random.Range(1, 4) * 10;
                break;
        }
        return end;
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

public interface Enemy{
    void TakeDamage(float dmg);
}
[System.Serializable] public enum Sel{
    Atk,
    Def,
    HP
}

[System.Serializable] 
public class Buff{
    public Sel type;
    public float amount;
}

[System.Serializable]
public class enemyData{
    public int id = 0;
    public int amount = 0;
}

[System.Serializable]
public class PlayerData{
    public float MaxHP, Hp, Atk, Def;
}