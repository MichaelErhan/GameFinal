/*using System;
using System.Collections.Generic;
using  Netologia.Necro.Units;
using UnityEngine;

namespace Netologia.Necro.Manager
{
    public class CellManager : MonoBehaviour
    {
        private Dictionary<CellNeighbour, Cell> _neighbours;
        
        private Cell[] _cells;

        public event Action<Cell> OnCellClicked;

        private void Awake()
        {
            _cells = FindObjectsOfType<Cell>();
            _neighbours = new Dictionary<CellNeighbour, Cell>(_cells.Length * 8);
            var positions = Array.ConvertAll(_cells, t => t.transform.position);
            var distance = 0f;
            for (int i = 0, iMax = _cells.Length; i < iMax; i++)
            {
                _cells[i].OnPointerClickEvent += OnCellClicked;
#if UNITY_EDITOR
                _cells[i].OnPointerClickEvent += DebugOnPointerClick;
#endif
                for (int j = 0, jMax = _cells.Length; j < jMax; j++)
                {
                    if (i == j) continue;
                    var source = positions[i];
                    var destination = positions[j];

                    var forward = destination.z.CompareTo(source.z);
                    var right = destination.x.CompareTo(source.x);
                    var type = (forward, right) switch
                    {
                        (1, 1) => Primitives.NeighbourType.ForwardRight,
                        (1, 0) => Primitives.NeighbourType.Forward,
                        (1, -1) => Primitives.NeighbourType.ForwardLeft,
                        (0, 1) => Primitives.NeighbourType.Right,
                        (0, -1) => Primitives.NeighbourType.Left,
                        (-1, 1) => Primitives.NeighbourType.BackwardRight,
                        (-1, 0) => Primitives.NeighbourType.Backward,
                        (-1, -1) => Primitives.NeighbourType.BackwardLeft,
                        _ => default
                    };
                    var key = new CellNeighbour(type, _cells[i]);
                    var check = _neighbours.TryGetValue(key, out var cell);
                    if (!check || Vector3.Distance(source, cell.transform.position) >
                        Vector3.Distance(source, destination))
                    {
                        _neighbours[key] = _cells[j];
                    }

                }

            }

        }
        private void DebugOnPointerClick(Cell cell)
        {
            Debug.Log("Cell clicked: " + cell.name);
        }

    }
} */
