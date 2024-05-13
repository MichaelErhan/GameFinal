using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Checkers
{
    public abstract class BaseClickComponent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [field : SerializeField]
        public Material WhiteMaterial { get; set; }
        
        [field : SerializeField]
        public Material BlackMaterial { get; set; }

        public Coordinate Coordinate;
        
        private Material _defaultMaterial;
        
        private MeshRenderer _meshRenderer;
        
        public ColorType Color { get; set; }
        public BaseClickComponent Pair { get; set; }

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetDefaultMaterial(Material material)
        {
            _defaultMaterial = material;
            SetMaterial(material);
        }
        public void SetMaterial(Material material = null)
        {
            _meshRenderer.sharedMaterial = material ? material : _defaultMaterial;
        }
        public event ClickEventHandler Clicked;      // Событие клика на игровом объекте
        public event FocusEventHandler OnFocusEventHandler;       // Событие наведения и сброса наведения на объект
        public abstract void OnPointerEnter(PointerEventData eventData); //При навадении на объект мышки, вызывается данный метод
        public abstract void OnPointerExit(PointerEventData eventData);    //срабатывает когда мышка перестает указывать на объект, соответственно нужно снимать подсветку с клетки
        
        public abstract IEnumerator Move(BaseClickComponent cell);      //При нажатии мышкой по объекту, вызывается данный метод
        public void OnPointerClick(PointerEventData eventData)
		{
            Clicked?.Invoke(this);
        }
        protected void CallBackEvent(CellComponent target, bool isSelect)
        {
            OnFocusEventHandler?.Invoke(target, isSelect);
		}
    }
    public enum ColorType
    {
        White,
        Black,
        WhiteQueen,
        BlackQueen
    }
    public delegate void ClickEventHandler(BaseClickComponent component);
    public delegate void FocusEventHandler(CellComponent component, bool isSelect);
    
    public struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Y = {Y} || Y = {X}";
        }
    }
}