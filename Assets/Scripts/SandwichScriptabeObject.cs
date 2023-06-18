using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "NewSandwich", menuName = "Sandwich")]
public class SandwichScriptabeObject : ScriptableObject
{
    public string sandwichName;
    public GameObject sandwichIconPrefab;
    public GameObject[] ingredients;
}
