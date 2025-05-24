#if UNITY_2022_2_OR_NEWER  // => Bu kodun sadece 2022.2 s�r�m ve �st�nde �al��mas�n� sa�lar - Eski s�r�m de hata almamak i�in.
using UnityEditor;  //=> Temel K�t�phane
using UnityEditor.Overlays; //=> OverLays API kullanmak i�in
using UnityEngine; //=> Unity 
using UnityEditor.SceneManagement;  //=> Sahne y�netimi a�ma ve kapama i�in
using System.Linq;
using UnityEngine.UIElements;
using UnityEditor.Build.Content;
using UnityEngine.SceneManagement;  //=> Dizi y�netimi.


[Overlay(typeof(SceneView),"Scene Switcher",true)] // => Hareketli Panel - sadece SceneView de g�z�kmesi - Panel ismi - varsay�lan Aktif olsun mu ? 
// Scene View de sahne aralar�nda h�zl� ge�i� yapmak i�in
public class SceneSwitcherOverlay : Overlay  // => Overlaydan t�r�yor. 
{
   private VisualElement sceneList;
    public override VisualElement CreatePanelContent()
    {
        var root = new VisualElement();

        var refreshBtn = new Button(() =>
        {
            UpdateSceneList();

        })
        {
            text = "Refresh"
        };
       root.Add(refreshBtn);

        sceneList = new VisualElement();
        root.Add(sceneList);

        UpdateSceneList();

        return root;

    }

    private void UpdateSceneList()
    {
        sceneList.Clear();  // Listeyi temizledik 


        var scenes = AssetDatabase.FindAssets("t:scene").Select(AssetDatabase.GUIDToAssetPath).ToArray();

        foreach (var scenePath in scenes)
        {
            var btn = new Button(() =>
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(scenePath);
                }
            })
            {
                text = System.IO.Path.GetFileNameWithoutExtension(scenePath)
            };
            sceneList.Add(btn);

        }
    }
}

#endif
