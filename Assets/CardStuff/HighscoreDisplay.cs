using UnityEngine;
using TMPro;
//using Dacen.Utility;

public class HighscoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI dateTextMesh;
    public TextMeshProUGUI playTimeTextMesh;
    public TextMeshProUGUI numberOfMovesTextMesh;

    public void Fill(Highscore highscore)
    {
        //dateTextMesh.text = highscore.date;
        //playTimeTextMesh.text = DacenUtility.ConvertToMinutesAndSeconds(highscore.playTime);
        //numberOfMovesTextMesh.text = highscore.numberOfMoves.ToString();
    }

    public void ResetValues()
    {
        //dateTextMesh.text = numberOfMovesTextMesh.text = playTimeTextMesh.text = "-";
    }
}
