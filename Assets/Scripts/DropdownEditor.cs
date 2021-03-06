using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(DropDown))]
public class DropdownEditor : Editor {

    public DropDown currDropdown;

    void OnEnable()
    {
        currDropdown = target as DropDown;
    }

    public override void OnInspectorGUI()
    {
        VerifyValid();
        currDropdown.isOpen = EditorGUILayout.Toggle("Is Open?", currDropdown.isOpen);

        GUILayout.Space(5);
        currDropdown.mainText.text = EditorGUILayout.TextField("Main Text", currDropdown.mainText.text);
        currDropdown.mainText.fontSize = EditorGUILayout.IntField("Font Size", currDropdown.mainText.fontSize);

        GUILayout.Space(5);
        currDropdown.mainText.font = (Font)EditorGUILayout.ObjectField("Font", currDropdown.mainText.font, typeof(Font), false);
        currDropdown.mainText.color = EditorGUILayout.ColorField("Font Color", currDropdown.mainText.color);

        GUILayout.Space(5);
        currDropdown.image.sprite = (Sprite)EditorGUILayout.ObjectField("Button Sprite", currDropdown.image.sprite, typeof(Sprite), false, GUILayout.Height(16));
        currDropdown.image.type = (Image.Type)EditorGUILayout.EnumPopup("Type", currDropdown.image.type);
        currDropdown.image.color = EditorGUILayout.ColorField("Main Color", currDropdown.image.color);

        currDropdown.Update();
        EditorUtility.SetDirty(currDropdown);
        Repaint();
    }

    void VerifyValid()
    {
        if (currDropdown.image == null)
        {
            currDropdown.gameObject.AddComponent<Image>();
        }

        if (currDropdown.container == null)
        {
            if (currDropdown.transform.Find("Container") == null)
            {
                currDropdown.container = UIUtility.NewUIElement("Container", currDropdown.transform);
                currDropdown.container.gameObject.AddComponent<VerticalLayoutGroup>();
                UIUtility.ScaleRect(currDropdown.container, 0, 0);
                currDropdown.container.anchorMin = new Vector2(0, 0);
                currDropdown.container.anchorMax = new Vector2(1, 0);
            }
            else
                currDropdown.container = currDropdown.transform.Find("Container").GetComponent<RectTransform>();
        }

        if (currDropdown.mainText == null)
        {
            if (currDropdown.transform.Find("Text") == null)
            {
                currDropdown.mainText = UIUtility.NewText("MyDropdown", currDropdown.transform);
            }
            else
                currDropdown.mainText = currDropdown.transform.Find("Text").GetComponent<Text>();
        }
    }
}