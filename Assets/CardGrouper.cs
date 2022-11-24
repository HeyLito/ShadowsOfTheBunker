using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPText = TMPro.TextMeshProUGUI;

public class CardGrouper : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private TMPText text = null;

    private string _textString = "";
    private List<GameObject> _groupElements = new List<GameObject>();
    private GameObject _ungroupedElement = null;

    void Start()
    {
        _textString = text.text;
    }

    private void AddObjectToGroup(GameObject gObj)
    {
        _groupElements.Add(gObj);
        if (text)
            text.text = $"{_textString} \n({_groupElements.Count})";
        gObj.SetActive(false);
    }

    private GameObject PullFirstObjectFromGroup()
    {
        if (_groupElements.Count > 0)
        {
            var first = _groupElements[0];
            _groupElements.RemoveAt(0);

            if (text)
            {
                if (_groupElements.Count > 0)
                    text.text = $"{_textString} \n({_groupElements.Count})";
                else text.text = _textString;
            }
            return first;
        }
        return null;
    }

    public void ShuffleCards()
    {
        List<GameObject> reorderedGroup = new List<GameObject>();
        while (_groupElements.Count > 0)
        {
            int randomIndex = Random.Range(0, _groupElements.Count - 1);
            reorderedGroup.Add(_groupElements[randomIndex]);
            _groupElements.RemoveAt(randomIndex);
        }

        //foreach (var item in reorderedGroup)
        //    _groupElements.Add(item);
        _groupElements = reorderedGroup;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        var component = collision.GetComponentInParent<DraggableElement>();
        if (component != null)
        {
            if (!component.isDragging)
                AddObjectToGroup(component.gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right)
            return;

        ExternalOnPointerDown(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Right)
            return;

        ExternalOnPointerUp(eventData);
    }

    public void ExternalOnPointerDown(PointerEventData eventData)
    {
        _ungroupedElement = PullFirstObjectFromGroup();
        if (_ungroupedElement == null)
            return;

        var component = _ungroupedElement.GetComponent<DraggableElement>();
        component.gameObject.SetActive(true);
        component.ExternalOnPointerDown(eventData);
    }
    public void ExternalOnPointerUp(PointerEventData eventData)
    {
        if (_ungroupedElement)
        {
            var component = _ungroupedElement.GetComponent<DraggableElement>();
            component.ExternalOnPointerUp(eventData);
        }
    }
}
