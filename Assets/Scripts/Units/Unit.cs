/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Netologia.Necro.Settings;
using Netologia.Necro.Manager;
using Netologia.Necro;

namespace Netologia.Necro.Units
{
    public class Unit : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        public event Action<Cell> OnMoveEndCallback;

        private Cell currentCell;
        private float moveSpeed = 1f; // Скорость перемещения юнита

        public void Move(Cell targetCell)
        {
            StartCoroutine(MoveToCellCoroutine(targetCell));
        }

        private IEnumerator MoveToCellCoroutine(Cell targetCell)
        {
            if (currentCell != null)
            {
              currentCell.OnPointerExitEvent?.Invoke(currentCell);
            }

            float step = 0;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = targetCell.transform.position;
            float journeyLength = Vector3.Distance(startPosition, endPosition);

            while (step < journeyLength)
            {
                float distanceCovered = step / journeyLength;
                transform.position = Vector3.Lerp(startPosition, endPosition, distanceCovered);
                step += moveSpeed * Time.deltaTime;
                yield return null;
            }

            transform.position = endPosition;
            currentCell = targetCell;
            currentCell.OnPointerEnterEvent?.Invoke(currentCell);

            OnMoveEndCallback?.Invoke(currentCell);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
           currentCell.OnPointerEnterEvent?.Invoke(currentCell);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
           currentCell?.OnPointerClickEvent?.Invoke(currentCell);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            currentCell?.OnPointerExitEvent?.Invoke(currentCell);
        }
    }
} */

