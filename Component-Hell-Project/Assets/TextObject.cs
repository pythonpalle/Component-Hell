using UnityEngine;

public class TextObject : MonoBehaviour
{
    [SerializeField] private TextMesh textMesh;

    public void SetText(string setText)
    {
        textMesh.text = setText;
    }
}