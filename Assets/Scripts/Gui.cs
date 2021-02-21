using UnityEngine;

public class Gui : MonoBehaviour
{
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), $"{Scoring._aScore} : {Scoring._bScore}");
    }
}
