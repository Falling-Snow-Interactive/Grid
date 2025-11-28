using Fsi.Grid.Cells;
using UnityEditor;
using UnityEngine;

namespace Fsi.Grid.Settings
{
    public class GridSettings : ScriptableObject
    {
        private const string ResourcePath = "Settings/GridSettings";
        private const string FullPath = "Assets/Resources/" + ResourcePath + ".asset";

        private static GridSettings settings;
        public static GridSettings Settings => settings ??= GetOrCreateSettings();

        [Header("Handles")]

        [SerializeField]
        private float handlesLineThickness = 2;
        public static float HandlesLineThickness => Settings.handlesLineThickness;

        [SerializeField]
        private float handlesMinLineThickness = 1;
        public static float HandlesMinLineThickness => Settings.handlesMinLineThickness;

        [SerializeField]
        private float handlesMaxLineThickness = 3f;
        public static float HandlesMaxLineThickness => Settings.handlesMaxLineThickness;
        
        [SerializeField]
        private Color handlesCellColor = Color.green;
        public static Color HandlesCellColor => Settings.handlesCellColor;
        
        #region Settings

        private static GridSettings GetOrCreateSettings()
        {
            GridSettings s = Resources.Load<GridSettings>(ResourcePath);

            #if UNITY_EDITOR
            if (!s)
            {
                if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }

                if (!AssetDatabase.IsValidFolder("Assets/Resources/Settings"))
                {
                    AssetDatabase.CreateFolder("Assets/Resources", "Settings");
                }

                s = CreateInstance<GridSettings>();
                AssetDatabase.CreateAsset(s, FullPath);
                AssetDatabase.SaveAssets();
            }
            #endif

            return s;
        }

        #if UNITY_EDITOR
        public static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
        #endif

        #endregion
    }
}