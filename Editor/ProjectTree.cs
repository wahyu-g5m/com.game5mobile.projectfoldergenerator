using UnityEngine;
using UnityEditor;
using System.IO;

namespace Tools.ProjectTreeGenerator.Editor
{
    public class ProjectTree
    {
        [MenuItem("Five/Project Folder/Generate")]
        public static void Execute()
        {
            var assets = GenerateFolderStructure();

            if (assets == null)
            {
                return;
            }

            CreateFolders(assets);
        }

        private static void CreateFolders(Folder rootFolder)
        {
            if (!AssetDatabase.IsValidFolder(rootFolder.DirPath))
            {
                Debug.Log("Creating: <b>" + rootFolder.DirPath + "</b>");
                AssetDatabase.CreateFolder(rootFolder.ParentPath, rootFolder.Name);
                File.Create(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + rootFolder.DirPath + Path.DirectorySeparatorChar + ".keep");
            }
            else
            {
                if (Directory.GetFiles(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + rootFolder.DirPath).Length < 1)
                {
                    File.Create(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + rootFolder.DirPath + Path.DirectorySeparatorChar + ".keep");
                    Debug.Log("Creating '.keep' file in: <b>" + rootFolder.DirPath + "</b>");
                }
                else
                {
                    Debug.Log("Directory <b>" + rootFolder.DirPath + "</b> already exists");
                }
            }

            foreach (var folder in rootFolder.Subfolders)
            {
                CreateFolders(folder);
            }
        }

        private static Folder GenerateFolderStructure()
        {
            Folder rootFolder = new Folder("Assets", "");
            var projectName = Application.productName;

            var project = rootFolder.Add($"{projectName}");

            var assets = project.Add("Assets");
            assets.Add("Meshes");
            assets.Add("Particles");
            assets.Add("Prefabs");
            assets.Add("Rewards");
            var sound = assets.Add("Sounds");
            var bgm = sound.Add("Bgm");
            bgm.Add("Demo");
            bgm.Add("Final");
            var sfx = sound.Add("Sfx");
            sfx.Add("Demo");
            sfx.Add("Final");
            var sprites = assets.Add("Sprites");
            sprites.Add("AppIcon");
            sprites.Add("PushNotificationAppIcon");
            var ui = sprites.Add("UI");
            ui.Add("Mockup");
            ui.Add("Simple");
            ui.Add("Sliced");
            ui.Add("Tiled");
            assets.Add("Textures");

            var fonts = project.Add("Fonts");
            var fontName = fonts.Add("FontName");
            var sdf = fontName.Add("SDF");
            sdf.Add("Materials");
            fontName.Add("Source");

            var materials = project.Add("Materials");

            var prefabs = project.Add("Prefabs");
            prefabs.Add("Ads");
            var prefabCore = prefabs.Add("Core");
            prefabCore.Add("Boosters");
            prefabs.Add("Flow");
            prefabs.Add("Haptic");
            prefabs.Add("Loading");
            prefabs.Add("Meta");
            prefabs.Add("Sound");
            prefabs.Add("Tracking");
            var prefabTutorial = prefabs.Add("Tutorial");
            prefabTutorial.Add("Core");
            prefabTutorial.Add("Meta");
            var prefabUI = prefabs.Add("UI");
            prefabUI.Add("_Tools");
            prefabUI.Add("Elements");
            prefabUI.Add("Loading");
            prefabUI.Add("Overlays");
            prefabUI.Add("PopUps");
            prefabUI.Add("Screens");

            var resources = project.Add("Resources");
            var scenes = project.Add("Scenes");
            var scriptableObjects = project.Add("ScriptableObjects");

            var scripts = project.Add("Scripts");
            var scriptTool = scripts.Add("_Tools");
            var scriptEditor = scripts.Add("Editor");
            var scriptRuntime = scripts.Add("Runtime");
            scriptRuntime.Add("Ads");
            scriptRuntime.Add("Constants");
            scriptRuntime.Add("Controllers");
            var scriptRuntimeCore = scriptRuntime.Add("Core");
            scriptRuntimeCore.Add("Boosters");
            scriptRuntimeCore.Add("Rewards");
            scriptRuntime.Add("Data");
            scriptRuntime.Add("Flow");
            scriptRuntime.Add("Haptic");
            scriptRuntime.Add("Loading");
            scriptRuntime.Add("Meta");
            scriptRuntime.Add("PushNotification");
            scriptRuntime.Add("Sound");
            scriptRuntime.Add("Tracking");
            scriptRuntime.Add("Transition");
            var scriptRuntimeTutorial = scriptRuntime.Add("Tutorial");
            scriptRuntimeTutorial.Add("Core");
            scriptRuntimeTutorial.Add("Meta");
            var scriptRuntimeUI = scriptRuntime.Add("UI");
            scriptRuntimeUI.Add("Elements");
            scriptRuntimeUI.Add("Loading");
            scriptRuntimeUI.Add("Overlays");
            scriptRuntimeUI.Add("PopUps");
            scriptRuntimeUI.Add("Screens");

            var shader = project.Add("Shaders");

            return rootFolder;
        }
    }
}
