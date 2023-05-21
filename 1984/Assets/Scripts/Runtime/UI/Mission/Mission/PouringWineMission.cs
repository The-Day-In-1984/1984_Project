using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class PouringWineMission : DragMission
{
   private Vector3 _startPosition;
   public override void OnMissionStart()
   {
      base.OnMissionStart();

      _startPosition = transform.position;
   }
   
   public override void OnMissionComplete()
   {
      base.OnMissionComplete();
   }

   public override void OnDrag(PointerEventData eventData)
   {
      base.OnDrag(eventData);
   }

   public void SetStartPosition()
   {
      transform.position = _startPosition;
   }
}
