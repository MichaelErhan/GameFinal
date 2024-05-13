using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Checkers
{
    public class CellComponent : BaseClickComponent
    {
        public ClickHandler ClickHandler { get; set; }
        public bool IsFreeCellToMove { get; set; }
        
        [SerializeField] private Material _selectMaterial;
        [SerializeField] private Material _freeCellMaterial;
        
        [SerializeField] private Material _queenWhiteMaterial;
        [SerializeField] private Material _queenBlackMaterial;
        
        private Dictionary<NeighborType, CellComponent> _neighbors;
        public CellComponent GetNeighbors(NeighborType type) => _neighbors[type];

        public void HighLightFreeCellToMove()
        {
            SetMaterial(_freeCellMaterial);
        }
        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (EventSystem.current == null)
            {
                SetMaterial();
                return;
            }
            SetMaterial(_selectMaterial);
            CallBackEvent(this, true);
        }
        public override void OnPointerExit(PointerEventData eventData)
        {
            if (IsFreeCellToMove)
            {
                SetMaterial(_freeCellMaterial);
            }
            else
            {
                SetMaterial();
            }
            
            CallBackEvent(this, false);
        }
        public override IEnumerator Move(BaseClickComponent cell)
        {
            throw new System.NotImplementedException();
        }
        public void Configuration(Dictionary<NeighborType, CellComponent> neighbors)   // Конфигурирование связей клеток
        {
            if (_neighbors != null) return;
            _neighbors = neighbors;
        }
    }
    public enum NeighborType : byte
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}