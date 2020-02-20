using System;
using UnityEditor;
using UnityEngine;

namespace NaughtyAttributes.Editor
{
    [CustomPropertyDrawer(typeof(QuadraticSliderAttribute))]
    public class NonLinearSliderDrawer : PropertyDrawerBase
    {
        const float SLIDER_NUMBER_FIELD_WIDTH = 50;
        const float SLIDER_MARGIN_SIZE = 5;

        #region Public Drawing API
        public static void Draw_Layout(SerializedProperty serializedProperty, float leftValue, float rightValue, Function function)
        {
            Draw_Layout(serializedProperty, leftValue, rightValue, function,
                new GUIContent(serializedProperty.displayName, serializedProperty.tooltip));
        }

        public static void Draw_Layout(SerializedProperty serializedProperty, float leftValue, float rightValue, Function function, GUIContent guiContent)
        {
            Rect rect = GetLayoutRect();
            EditorGUI.BeginProperty(rect, GUIContent.none, serializedProperty);

            serializedProperty.floatValue = Draw(rect, guiContent, serializedProperty.floatValue, leftValue, rightValue, function);

            EditorGUI.EndProperty();
        }

        public static float Draw_Layout(GUIContent guiContent, float value, float leftValue, float rightValue, Function function)
        {
            Rect rect = GetLayoutRect();

            return Draw(rect, guiContent, value, leftValue, rightValue, function);
        }


        public static void Draw(Rect rect, SerializedProperty serializedProperty, float leftValue, float rightValue, Function function)
        {
            Draw(rect, serializedProperty, leftValue, rightValue, function, new GUIContent(serializedProperty.displayName, serializedProperty.tooltip));
        }

        public static void Draw(Rect rect, SerializedProperty serializedProperty, float leftValue, float rightValue, Function function, GUIContent guiContent)
        {
            EditorGUI.BeginProperty(rect, GUIContent.none, serializedProperty);

            serializedProperty.floatValue = Draw(rect, guiContent, serializedProperty.floatValue, leftValue, rightValue, function);

            EditorGUI.EndProperty();
        }

        public static float Draw(Rect rect, GUIContent guiContent, float value, float leftValue, float rightValue, Function function)
        {
            Rect controlRect;
            if (guiContent != null) controlRect = EditorGUI.PrefixLabel(rect, guiContent);
            else controlRect = rect;

            Rect sliderRect = new Rect(controlRect.x, controlRect.y, controlRect.width - SLIDER_NUMBER_FIELD_WIDTH - SLIDER_MARGIN_SIZE, controlRect.height);

            float sliderValue = GUI.HorizontalSlider(sliderRect, function.backwardsFunction(value), leftValue, rightValue);
            float convertedValue = function.function(sliderValue);

            EditorGUI.BeginChangeCheck();
            Rect numberRect = new Rect(controlRect.xMax - SLIDER_NUMBER_FIELD_WIDTH, controlRect.y, SLIDER_NUMBER_FIELD_WIDTH, controlRect.height);
            float floatFieldValue = EditorGUI.FloatField(numberRect, convertedValue);
            if (EditorGUI.EndChangeCheck())
            {
                convertedValue = Mathf.Clamp(leftValue, rightValue, floatFieldValue);
            }

            return convertedValue;
        }
        #endregion

        static Rect GetLayoutRect()
        {
            return EditorGUILayout.GetControlRect();
        }


        protected override void OnGUI_Internal(Rect rect, SerializedProperty property, GUIContent label)
        {
            QuadraticSliderAttribute quadraticAttribute = PropertyUtility.GetAttribute<QuadraticSliderAttribute>(property);
            if (quadraticAttribute != null)
            {
                Draw(rect, property, quadraticAttribute.Min, quadraticAttribute.Max, Function.Quadratic(quadraticAttribute.Power), label);
            }
        }


        public struct Function
        {
            public Func<float, float> function;
            public Func<float, float> backwardsFunction;

            public static Function Quadratic(int power)
            {
                return new Function
                {
                    function = (x) => Mathf.Pow(x, power),
                    backwardsFunction = (x) => Mathf.Pow(x, 1f / power)
                };
            }
        }
    }

}
