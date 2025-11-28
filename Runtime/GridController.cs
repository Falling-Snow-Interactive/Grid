using System.Collections.Generic;
using Fsi.General;
using Fsi.General.RunningLock;
using Fsi.Grid.Cells;
using Fsi.Grid.Settings;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fsi.Grid
{
    [RequireComponent(typeof(GridLayout))]
    public class GridController : MbSingleton<GridController>, ISerializationCallbackReceiver
    {
	    // [FormerlySerializedAs("gridCellVisualsPrefab")]
	    // [FormerlySerializedAs("gridCellPrefab")]
	    // [FormerlySerializedAs("cellPrefab")]
	    // [Header("Cells Properties")]
	    //
	    // [RunningLock]
	    // [SerializeField]
	    // private BoardGridCellVisuals boardGridCellVisualsPrefab;

	    [RunningLock]
	    [SerializeField]
	    private Transform cellContainer;

	    // private readonly Dictionary<Vector3Int, BoardGridCellVisuals> cells = new();
	    // public Dictionary<Vector3Int, BoardGridCellVisuals> Cells => cells;

	    [Header("References")]

	    [RunningLock]
	    [SerializeField]
	    private GridLayout layout;
	    public GridLayout Layout => layout;

	    private void Start()
	    {
		    // for(int x = 0; x < size.x; x++)
		    // for (int y = 0; y < size.y; y++)
		    // {
			   //  Vector3Int cellPosition = new(x, y);
			   //  Vector3 worldPosition = layout.CellToWorld(cellPosition);
		    //
			   //  GridCell gridCell = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity, cellContainer);
			   //  cells.Add(cellPosition, gridCell);
		    // }
	    }

	    private void OnDrawGizmos()
	    {
		    // for(int x = 0; x < Size.x; x++)
		    // for (int y = 0; y < Size.y; y++)
		    // {
			   //  DrawGizmoCell(new Vector3Int(x,y));
		    // }
	    }
	    
	    private void DrawGizmoCell(Vector3Int gridPosition)
	    {
		    Vector3 origin = Layout.CellToWorld(gridPosition);
		    Gizmos.color = GridSettings.HandlesCellColor;

		    Vector3 c0 = origin;
		    Vector3 c1 = origin + Vector3.right * layout.cellSize.x;
		    Vector3 c2 = origin + Vector3.forward * layout.cellSize.y;
		    Vector3 c3 = origin + Vector3.right * layout.cellSize.x + Vector3.forward * layout.cellSize.y;
            
		    Gizmos.DrawLine(c0, c1);
		    Gizmos.DrawLine(c1, c3);
		    Gizmos.DrawLine(c3, c2);
		    Gizmos.DrawLine(c2, c0);
	    }
	    
	    public bool CheckPosition(Vector3Int position)
	    {
		    // if (position.x < 0 || position.x > Size.x)
		    // {
			   //  return false;
		    // }
		    //
		    // if (position.y < 0 || position.y > Size.y) 
		    // {
			   //  return false;
		    // }

		    return true;
	    }

	    public void OnBeforeSerialize() { }

	    public void OnAfterDeserialize() { }
    }
}
