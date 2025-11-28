using System;
using UnityEngine;

namespace Fsi.Grid.Cells
{
    public class GridCellVisuals : MonoBehaviour
    {
        [SerializeField]
        private GridCellState cellState;
        public GridCellState CellState => cellState;
        
        [Header("State Groups")]
        
        [SerializeField]
        private GameObject regularGroup;

        [SerializeField]
        private GameObject highlightGroup;

        public void SetState(GridCellState cellState)
        {
            HideGroups();
            this.cellState = cellState;
            switch (cellState)
            {
                case GridCellState.None:
                    HideGroups();
                    break;
                case GridCellState.Regular:
                    regularGroup.SetActive(true);
                    break;
                case GridCellState.Highlight:
                    highlightGroup.SetActive(true);
                    break;
                case GridCellState.Select:
                default:
                    throw new ArgumentOutOfRangeException(nameof(cellState), cellState, null);
            }
        }

        private void HideGroups()
        {
            regularGroup.SetActive(false);
            highlightGroup.SetActive(false);
        }
    }
}
