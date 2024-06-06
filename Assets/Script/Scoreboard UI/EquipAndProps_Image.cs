using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "new Scoreboard_Image", menuName = "ScriptableObject/Equip And Props Image")]
public class EquipAndProps_Image : ScriptableObject
{
    public EquipImage Equip;
    public PropsImage Props;
}

[System.Serializable]
public class EquipImage
{
    public List<Sprite> equipImage = new List<Sprite>();
}

[System.Serializable]
public class PropsImage
{
    public List<Sprite> propsImage = new List<Sprite>();
}
