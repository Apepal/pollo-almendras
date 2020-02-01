using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial Object", menuName = "Tutorial Object")]
public class Tutorial: ScriptableObject
{
    public string[] text;
    public Sprite image;
}

[CreateAssetMenu(fileName = "Dialogo", menuName = "Dialogo")]
public class Dialog : ScriptableObject
{
    public Tutorial[] tutorials;
}

