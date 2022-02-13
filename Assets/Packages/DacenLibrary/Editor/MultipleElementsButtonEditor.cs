using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(MultipleElementsButton))]
[CanEditMultipleObjects]
public class MultipleElementsButtonEditor : Editor
{
    private MultipleElementsButton targetScript;

    private void OnEnable()
    {
        targetScript = target as MultipleElementsButton;
        targetScript.transition = Selectable.Transition.ColorTint;
        targetScript.navigation = new Navigation() { mode = Navigation.Mode.None };
    }

    public override void OnInspectorGUI()
    {
        targetScript.interactable = EditorGUILayout.Toggle("Interactable", targetScript.interactable);
        EditorGUILayout.Space();
        DrawTargetGraphicsProperty();
        EditorGUILayout.Space();
        DrawColorProperties();
        EditorGUILayout.Space();
        DrawOnClickProperty();
    }

    private void DrawTargetGraphicsProperty()
    {
        SerializedProperty targetGraphics = serializedObject.FindProperty("targetGraphics");
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(targetGraphics, true);
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
    }

    private void DrawColorProperties()
    {
        EditorGUI.BeginChangeCheck();
        Color _normalColor = EditorGUILayout.ColorField("Normal color", targetScript.colors.normalColor);
        Color _highlightedColor = EditorGUILayout.ColorField("Highlighted color", targetScript.colors.highlightedColor);
        Color _pressedColor = EditorGUILayout.ColorField("Pressed color", targetScript.colors.pressedColor);
        Color _selectedColor = EditorGUILayout.ColorField("Selected color", targetScript.colors.selectedColor);
        Color _disabledColor = EditorGUILayout.ColorField("Disabled color", targetScript.colors.disabledColor);
        float _colorMultiplier = EditorGUILayout.Slider("Color multiplier", 1, 1, 5);
        float _fadeDuration = EditorGUILayout.FloatField("Fade duration", targetScript.colors.fadeDuration);
        if (EditorGUI.EndChangeCheck())
            targetScript.colors = new ColorBlock()
            {
                normalColor = _normalColor,
                highlightedColor = _highlightedColor,
                pressedColor = _pressedColor,
                selectedColor = _selectedColor,
                disabledColor = _disabledColor,
                colorMultiplier = _colorMultiplier,
                fadeDuration = _fadeDuration
            };
    }

    private void DrawOnClickProperty()
    {
        EditorGUI.BeginChangeCheck();
        SerializedProperty _onClick = serializedObject.FindProperty("_onClick");
        EditorGUILayout.PropertyField(_onClick);
        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();
            targetScript.onClick = targetScript._onClick;
        }
    }
}
