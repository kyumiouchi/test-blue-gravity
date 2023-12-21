using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] private GameObject _highlighter;
    private GameObject _objectToHighlight;

    public void Highlight(GameObject target)
    {
        if (target == _objectToHighlight) return;
        _highlighter.SetActive(true);
        _highlighter.transform.position = target.transform.position;
    }

    public void HideHighlight()
    {
        _objectToHighlight = null;
        _highlighter.SetActive(false);
    }
}
