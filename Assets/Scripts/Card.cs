using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : ScriptableObject {

    public enum Type { Monster, Spell, Environment }

    [Header("General")]
    public Type type;

    public Sprite overlay;

}
