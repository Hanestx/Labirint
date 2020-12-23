using UnityEditor;

namespace Labirint
{
    public class MenuItems
    {
        [MenuItem("Labirint/Пункт меню №1 ")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "Labirint");
        }
    }
}
