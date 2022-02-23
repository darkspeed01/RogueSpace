using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropDown : MonoBehaviour, IPointerClickHandler {

    public RectTransform container;
    public bool isOpen;
    public Text mainText;
    public Image image { get { return GetComponent<Image>(); } }

    	
    void Start()
    {
        container = transform.Find("Container").GetComponent<RectTransform>();
        isOpen = false;
    }

	// Update is called once per frame
	public void Update ()
    {
        Vector3 scale = container.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        container.localScale = scale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isOpen = !isOpen;
    }
}


[System.Serializable]
public class DropdownChild
{
    public GameObject childObj;
    public Text childText;
    public Button.ButtonClickedEvent childEvents;

    private LayoutElement element {  get { return childObj.GetComponent<LayoutElement>(); } }
    private Button button { get { return childObj.GetComponent<Button>(); } }
    private Image image { get { return childObj.GetComponent<Image>(); } }

    public DropdownChild (DropDown parent)
    {
        childObj = UIUtility.NewButton("Child", "Button", parent.container).gameObject;
        childObj.AddComponent<LayoutElement>();

        childText = childObj.GetComponentInChildren<Text>();

        childEvents = button.onClick;
    }

}