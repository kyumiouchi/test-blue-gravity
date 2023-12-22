using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemInventorySo))]
public class ItemInventorySoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawClearInventoryButton();

        DrawDefaultInspector();
    }

    private void DrawClearInventoryButton()
    {
        ItemInventorySo inventorySo = target as ItemInventorySo;
        if (GUILayout.Button("Clear inventory"))
        {
            if (inventorySo != null) inventorySo.ClearInventory();
        }
    }
}
