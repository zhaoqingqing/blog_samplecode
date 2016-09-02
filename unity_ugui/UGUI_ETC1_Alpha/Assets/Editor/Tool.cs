using System.IO;
using UnityEditor;
using UnityEngine;
public class Encoder {
    static bool MakeTextureAnAtlas(string path, bool force, bool alphaTransparency)
    {
        if (string.IsNullOrEmpty(path)) return false;
        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null) return false;

        TextureImporterSettings settings = new TextureImporterSettings();
        ti.ReadTextureSettings(settings);

        if (force ||
            settings.readable ||
            settings.maxTextureSize < 4096 ||
            settings.wrapMode != TextureWrapMode.Clamp ||
            settings.npotScale != TextureImporterNPOTScale.ToNearest)
        {
            settings.readable = false;
            settings.maxTextureSize = 4096;
            settings.wrapMode = TextureWrapMode.Clamp;
            settings.npotScale = TextureImporterNPOTScale.None;

            settings.textureFormat = TextureImporterFormat.ARGB32;
            settings.filterMode = FilterMode.Trilinear;

            settings.aniso = 4;
            settings.alphaIsTransparency = alphaTransparency;
            ti.SetTextureSettings(settings);
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
        }
        return true;
    }

    static public bool MakeTextureReadable(string path, bool force)
    {
        if (string.IsNullOrEmpty(path)) return false;
        TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
        if (ti == null) return false;

        TextureImporterSettings settings = new TextureImporterSettings();
        ti.ReadTextureSettings(settings);

        if (force || !settings.readable || settings.npotScale != TextureImporterNPOTScale.None || settings.alphaIsTransparency)
        {
            settings.readable = true;
            settings.textureFormat = TextureImporterFormat.AutomaticTruecolor;
            settings.npotScale = TextureImporterNPOTScale.None;
            settings.alphaIsTransparency = false;
            ti.SetTextureSettings(settings);
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
        }
        return true;
    }

    static public Texture2D ImportTexture(string path, bool forInput, bool force, bool alphaTransparency)
    {
        if (!string.IsNullOrEmpty(path))
        {
            if (forInput) { if (!MakeTextureReadable(path, force)) return null; }
            else if (!MakeTextureAnAtlas(path, force, alphaTransparency)) return null;
            //return AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;

            Texture2D tex = AssetDatabase.LoadAssetAtPath(path, typeof(Texture2D)) as Texture2D;
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
            return tex;
        }
        return null;
    }

    static void CreateAlphaMask(Texture2D tex)
    {
        string oldPath = AssetDatabase.GetAssetPath(tex.GetInstanceID());
        tex = ImportTexture(oldPath, true, false, true);

        //Texture2D rgbTex = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
        Texture2D aTex = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);

        Color newColor = new Color(0f, 0f, 0f);
        for (int i = 0; i < tex.width; ++i) {
            for (int j = 0; j < tex.height; ++j) {
                newColor = tex.GetPixel(i, j);
                //rgbTex.SetPixel(i, j, newColor);

                newColor.r = newColor.a;
                newColor.g = 0;
                newColor.b = 0;
                aTex.SetPixel(i, j, newColor);
            }
        }
        string path = oldPath.Substring(0, oldPath.LastIndexOf("."));

        byte[] bytes = aTex.EncodeToPNG();
        File.WriteAllBytes(path + "_ETC1_A.png", bytes);

        bytes = null;
        aTex = null;

        AssetDatabase.Refresh();
        tex = ImportTexture(oldPath, false, false, true);
    }

    static void CreateMaterial(string materialPath) {
        string pngPath = materialPath.Replace(AppPath, "Assets");
        Texture2D pngSprite = AssetDatabase.LoadAssetAtPath<Texture2D>(pngPath);

        string apngPath = pngPath.Replace(".png", "_ETC1_A.png");
        Texture2D maskSprite = AssetDatabase.LoadAssetAtPath<Texture2D>(apngPath);

        materialPath = materialPath.Replace(".png", ".mat");

        string path = Application.dataPath + "/Material/SpriteMaterial.mat";
        string name = Path.GetFileNameWithoutExtension(materialPath);
        File.Copy(path, materialPath, true);
        AssetDatabase.Refresh();

        string matPath = materialPath.Replace(AppPath, "Assets");
        Material material = AssetDatabase.LoadAssetAtPath<Material>(matPath);

        material.SetTexture("_MainTex", pngSprite);
        material.SetTexture("_AlphaTex", maskSprite);
    }

    /// <summary>
    /// —πÀıŒ∆¿Ì
    /// </summary>
    static void CompressTexture(string path) {
        string aPath = path.Replace(".png", "_ETC1_A.png");
        string[] paths = { path, aPath };
        foreach (var newPath in paths) {
            TextureImporter ti = AssetImporter.GetAtPath(newPath) as TextureImporter;
            if (ti == null) return;

            bool isMask = newPath.Contains("_ETC1_A");

            TextureImporterSettings settings = new TextureImporterSettings();
            ti.ReadTextureSettings(settings);

            settings.readable = false;
            settings.mipmapEnabled = false;
            settings.maxTextureSize = 1024;
            settings.wrapMode = TextureWrapMode.Clamp;
            settings.npotScale = TextureImporterNPOTScale.None;

            settings.textureFormat = TextureImporterFormat.ETC_RGB4;
            settings.filterMode = FilterMode.Trilinear;
            settings.spriteMode = (int)(isMask ? SpriteImportMode.None : SpriteImportMode.Multiple);

            settings.aniso = 4;
            settings.alphaIsTransparency = true;
            ti.SetTextureSettings(settings);
            AssetDatabase.ImportAsset(newPath, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
        }
    }

    /// <summary>
    /// ¥¥Ω®
    /// </summary>
    [MenuItem("Assets/Create ETC1 Mask")]
    static void CreateEtc1Mask() {
        Texture2D tex = Selection.activeObject as Texture2D;
        if (null == tex) return;

        UnityEngine.Object obj = Selection.activeObject;
        var file = AssetDatabase.GetAssetPath(obj);
        if (!file.EndsWith(".png")) return;

        CreateAlphaMask(tex);
        CreateMaterial(AppPath.Replace("Assets", "") + file);
        CompressTexture(file);
        AssetDatabase.Refresh();
    }

    static string AppPath {
        get { return Application.dataPath; }
    }
}