using Fsi.Grid.Settings;
using UnityEditor;
using UnityEngine;

namespace Fsi.Grid
{
    [CustomEditor(typeof(GridController))]
    public class GridControllerEditor : UnityEditor.Editor
    {
        private GridController gridController;
        
        public void OnSceneGUI()
        {
            gridController = target as GridController;
            if (!gridController)
            {
                return;
            }

            // for(int x = 0; x < gridController.Size.x; x++)
            // for (int y = 0; y < gridController.Size.y; y++)
            // {
            //     DrawCell(new Vector3Int(x,y));
            // }

            // Draw Cells
        }

        private void DrawCell(Vector3Int gridPosition)
        {
            Vector3 origin = gridController.Layout.CellToWorld(gridPosition);
            Handles.color = GridSettings.HandlesCellColor;

            Vector3 c0 = origin;
            Vector3 c1 = origin + Vector3.right * gridController.Layout.cellSize.x;
            Vector3 c2 = origin + Vector3.forward * gridController.Layout.cellSize.y;
            Vector3 c3 = origin + Vector3.right * gridController.Layout.cellSize.x + Vector3.forward * gridController.Layout.cellSize.y;
            
            float size = HandleUtility.GetHandleSize(origin);
            float scaledThickness = Mathf.Clamp(GridSettings.HandlesLineThickness * size, 
                                                GridSettings.HandlesMinLineThickness, 
                                                GridSettings.HandlesMaxLineThickness); // adjust multiplier as needed
            Handles.DrawLine(c0, c1, scaledThickness);
            
            Handles.DrawLine(c0, c1, scaledThickness);
            Handles.DrawLine(c1, c3, scaledThickness);
            Handles.DrawLine(c3, c2, scaledThickness);
            Handles.DrawLine(c2, c0, scaledThickness);
        }
    }
}