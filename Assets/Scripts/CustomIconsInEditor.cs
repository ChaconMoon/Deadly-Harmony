using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InfoSpritesPersonajes))]
public class CharacterSpritesInEditor : Editor
{
    public override Texture2D RenderStaticPreview(
        string assetPath, Object[] subAssets, int width, int height)
    {
        InfoSpritesPersonajes spriteInfo = (InfoSpritesPersonajes)target;
        if (spriteInfo == null || spriteInfo.sprite == null)
        {
            return null;
        }
        Color[] pixels = spriteInfo.sprite.texture.GetPixels(
            (int)spriteInfo.sprite.textureRect.x,
            (int)spriteInfo.sprite.textureRect.y,
            (int)spriteInfo.sprite.textureRect.width,
            (int)spriteInfo.sprite.textureRect.height);
        Texture2D texture = new Texture2D((int)spriteInfo.sprite.textureRect.width, (int)spriteInfo.sprite.textureRect.height);
        texture.SetPixels(pixels);
        texture.Apply();
        EditorUtility.CopySerialized(spriteInfo.sprite.texture, texture);
        return texture;
    }
}
