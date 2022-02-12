using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CamScrshot : MonoBehaviour
{
    public int FileCounter = 0;

    private void LateUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.F9))
        {
            //CamCapture(); that was a try :/
        }
        
    }

    void CamCapture()
    {
        Camera Cam = this.gameObject.GetComponent<Camera>();

        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = Cam.targetTexture;

        Cam.Render();

        Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
        Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
        Image.Apply();
        RenderTexture.active = currentRT;

        var Bytes = Image.EncodeToPNG();
        Destroy(Image);

        File.WriteAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + (Random.Range(0, 999999999).ToString()) + ".png", Bytes);
        FileCounter++;
    }
}
