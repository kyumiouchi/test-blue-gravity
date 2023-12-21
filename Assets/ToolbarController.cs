using System;
using UnityEngine;

public class ToolbarController : MonoBehaviour
{
    [SerializeField] private int _toolbarSize = 9;
    private int selectedTool;

    public Action<int> onChange;

    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                selectedTool++;
                selectedTool = (selectedTool >= _toolbarSize ? 0 : selectedTool);
            }
            else
            {
                selectedTool--;
                selectedTool = (selectedTool <= 0 ? _toolbarSize - 1 : selectedTool);
            }
        }
        onChange?.Invoke(selectedTool);
    }

    public void Set(int index)
    {
        selectedTool = index;
    }
}
