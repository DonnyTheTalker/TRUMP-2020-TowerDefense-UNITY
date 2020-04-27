using UnityEngine;
using UnityEngine.UI;

public class TrumpFace : MonoBehaviour
{

    private static Sprite[] _images;
    private static Image Trump;
    private static Color[] _colors;

    public Sprite[] Images;
    public Image TrumpMain;
    public Color[] Colors;

    void Start()
    {
        Trump = TrumpMain;
        _images = Images;
        _colors = Colors;

        Trump.sprite = _images[0];
        Trump.color = _colors[0];

    }

    public static void ChangeImage(float percentage)
    {
        Trump.sprite = _images[Mathf.Min(_images.Length - (int) (percentage / (1f / (float)_images.Length)), _images.Length - 1)];
        Trump.color = _colors[Mathf.Min(_colors.Length - (int) (percentage / (1f / (float)_colors.Length)), _colors.Length - 1)];
    }

    
}
