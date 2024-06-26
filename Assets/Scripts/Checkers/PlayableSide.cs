using System.Collections.Generic;
using UnityEngine;

namespace Checkers
{
    public class PlayableSide : MonoBehaviour
    {
        public ColorType CurrentSide { get; private set; } =  ColorType.Black;

        [SerializeField] private ClickHandler _clickHandler;

        private List<BaseClickComponent> _whiteChips = new();
        private List<BaseClickComponent> _blackChips = new();
        
        private List<BaseClickComponent> _blackQueens = new();   //Дамки черные
        private List<BaseClickComponent> _whiteQueens = new();   //Дамки белые
        
        private void OnEnable()
        {
            _clickHandler.ObjectsMoved += OnObjectsMoved;
            _clickHandler.GameEnded += OnGameEnded;
            _clickHandler.ChipDestroyed += OnChipDestroyed;
        }
        
        private void OnDisable()
        {
            _clickHandler.ObjectsMoved -= OnObjectsMoved;
            _clickHandler.GameEnded -= OnGameEnded;
            _clickHandler.ChipDestroyed -= OnChipDestroyed;
        }

        private void Start()
        {
            foreach (var chip in _clickHandler.Chips)
            {
                if (chip.Color == ColorType.White)
                {
                    _whiteChips.Add(chip);
                }
                else
                {
                    _blackChips.Add(chip);
                }
            }
        }

        private void OnChipDestroyed(BaseClickComponent chip)
        {
            if (_whiteChips.Contains(chip))
            {
                _whiteChips.Remove(chip);
                if (chip.Coordinate.Y == 0) // Белые дамки
                {
                    chip.Color = ColorType.WhiteQueen;
                    _whiteQueens.Add(chip);
                }
            }
            else
            {
                _blackChips.Remove(chip);
                if (chip.Coordinate.Y == 7) // Черные дамки
                {
                    chip.Color = ColorType.BlackQueen;
                    _blackQueens.Add(chip);
                }
            }

            if (_whiteChips.Count == 0)
            {
                OnGameEnded(ColorType.White);  //
            }
            else if (_blackChips.Count == 0)
            {
                OnGameEnded(ColorType.Black);
            }
        }
        
        private void OnObjectsMoved()
        {
            CurrentSide = CurrentSide == ColorType.Black ? ColorType.White : ColorType.Black;
        }
        
        private void OnGameEnded(ColorType side)
        {
            var congrats = side == ColorType.Black ? "черная" : "белая";
            Debug.Log($"Грац,с победой {congrats} команда");
            Time.timeScale = 0f;
        }
    }
}