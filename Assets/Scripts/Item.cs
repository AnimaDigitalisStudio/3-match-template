using UnityEngine;

[CreateAssetMenu(menuName = "Match-3/Item")]
public sealed class Item : ScriptableObject
{
    public Sprite sprite;
    public int value;
}
