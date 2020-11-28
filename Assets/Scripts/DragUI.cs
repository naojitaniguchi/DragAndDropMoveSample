using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	RectTransform objRect;
	public string dropTargetTopTag = "DropTargetTop";
	GameObject dropTargetTop;
	public string dropTargetTag = "DropTarget";
	GameObject[] dropTargets;

	private void Start()
    {
		dropTargetTop = GameObject.FindGameObjectWithTag(dropTargetTopTag);
		dropTargets = GameObject.FindGameObjectsWithTag(dropTargetTag);
	}

    public void OnBeginDrag(PointerEventData e)
	{
		objRect = gameObject.GetComponent<RectTransform>();
		objRect.SetAsFirstSibling();
		transform.parent = dropTargetTop.transform;
	}
	public void OnDrag(PointerEventData e)
	{
		objRect.position = e.position;
	}
	public void OnEndDrag(PointerEventData e)
	{
		for ( int i = 0; i <  dropTargets.Length; i ++)
        {
			RectTransform dropObjRect = dropTargets[i].GetComponent<RectTransform>();
			if (dropObjRect.position.x - dropObjRect.sizeDelta.x < objRect.position.x && objRect.position.x < dropObjRect.position.x + dropObjRect.sizeDelta.x)
            {
				if (dropObjRect.position.y - dropObjRect.sizeDelta.y < objRect.position.y && objRect.position.y < dropObjRect.position.y + dropObjRect.sizeDelta.y)
                {
					gameObject.transform.parent = dropTargets[i].transform;
					objRect.SetAsLastSibling();
					break;
                }
			}
        }
	}
}
