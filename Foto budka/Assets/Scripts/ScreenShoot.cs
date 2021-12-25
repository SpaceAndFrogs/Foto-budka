using System;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShoot : MonoBehaviour
{
    [SerializeField] GameObject Ui;

    IEnumerator IEScreenShoot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();

        string nameOfScreenShoot = DateTime.Now.ToString();

        nameOfScreenShoot = String.Concat(nameOfScreenShoot.Where(c => !Char.IsWhiteSpace(c)));

        nameOfScreenShoot = String.Concat(nameOfScreenShoot.Where(c => !Char.IsPunctuation(c)));

        nameOfScreenShoot = String.Concat(nameOfScreenShoot.Where(c => !Char.IsSeparator(c)));

        nameOfScreenShoot += ".png";

        if (!Directory.Exists(Application.dataPath + "/StreamingAssets/Output"))
        {
            
            Directory.CreateDirectory(Application.dataPath + "/StreamingAssets/Output");

        }

        File.WriteAllBytes(Application.dataPath + "/StreamingAssets/Output/" + nameOfScreenShoot, bytes);
        

        Destroy(texture);
        Ui.SetActive(true);
    }

    public void TakeScreenShoot()
    {
        Ui.SetActive(false);
        StartCoroutine(IEScreenShoot());
    }
}
