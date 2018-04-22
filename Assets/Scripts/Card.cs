using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject {

    public enum Type { Monster, Spell, Environment }

    [Header("General")]
    new public string name;

    public Type type;

    public Sprite overlay;

    public int power;

    public Sprite image;

}
