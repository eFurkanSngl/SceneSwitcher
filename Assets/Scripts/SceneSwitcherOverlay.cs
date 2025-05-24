#if UNITY_2022_2_OR_NEWER  // => Bu kodun sadece 2022.2 sürüm ve üstünde çalýþmasýný saðlar - Eski sürüm de hata almamak için.
using UnityEditor;  //=> Temel Kütüphane
using UnityEditor.Overlays; //=> OverLays API kullanmak için
using UnityEngine; //=> Unity 
using UnityEditor.SceneManagement;  //=> Sahne yönetimi açma ve kapama için
using System.Linq;
using UnityEngine.UIElements;
using UnityEditor.Build.Content;
using UnityEngine.SceneManagement;  //=> Dizi yönetimi.


[Overlay(typeof(SceneView),"Scene Switcher",true)] // => Hareketli Panel - sadece SceneView de gözükmesi - Panel ismi - varsayýlan Aktif olsun mu ? 
// Scene View de sahne aralarýnda hýzlý geçiþ yapmak için
public class SceneSwitcherOverlay : Overlay  // => Overlaydan türüyor. 
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
