using Fsi.Ui.Spacers;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fsi.Grid.Settings
{
    public static class GridSettingsProvider
    {
        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            SettingsProvider provider = new("Falling Snow Interactive/Grid", SettingsScope.Project)
                                        {
                                            label = "Grid",
                                            activateHandler = OnActivate,
                                        };
            return provider;
        }

        private static void OnActivate(string searchContext, VisualElement root)
        {
            root.style.marginTop = 5;
            root.style.marginRight = 5;
            root.style.marginLeft = 5;
            root.style.marginBottom = 5;
    
            SerializedObject settingsProp = GridSettings.GetSerializedSettings();
        
            Label title = new("Grid Settings");
            root.Add(title);
        
            root.Add(new Spacer());
        
            root.Add(new InspectorElement(settingsProp));
        
            root.Bind(settingsProp);
        }
    }
}