using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] private GameObject _highlighter;
    private GameObject _objectToHighlight;
    [SerializeField] private float _lenghtUp = 0.5f;

    public void Highlight(GameObject target)
    {
        if (target == _objectToHighlight) return;
        _highlighter.SetActive(true);
        
        var position = target.transform.position;
        position += Vector3.up * _lenghtUp;
        _highlighter.transform.position = position;
    }

    public void HideHighlight()
    {
        _objectToHighlight = null;
        _highlighter.SetActive(false);
    }
}
