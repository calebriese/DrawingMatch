using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class PlayerBrush : NetworkBehaviour
{
    #region Initialization
    [Server]
    private void Start()
    {
        var data = PaintCanvas.GetAllTextureData();
        var zippeddata = data.Compress();
 
        RpcSendFullTexture(zippeddata);
    }

    [ClientRpc]
    private void RpcSendFullTexture(byte[] textureData)
    {
        PaintCanvas.SetAllTextureData(textureData.Decompress());
    }
    #endregion

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var pallet = hit.collider.GetComponent<PaintCanvas>();
                if (pallet != null)
                {
                    Debug.Log(hit.textureCoord);
                    Debug.Log(hit.point);

                    Renderer rend = hit.transform.GetComponent<Renderer>();
                    MeshCollider meshCollider = hit.collider as MeshCollider;

                    if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                        return;

                    Texture2D tex = rend.material.mainTexture as Texture2D;
                    Vector2 pixelUV = hit.textureCoord;
                    pixelUV.x *= tex.width;
                    pixelUV.y *= tex.height;

                    CmdBrushAreaWithColorOnServer(pixelUV, ColorPicker.SelectedColor, BrushSizeSlider.BrushSize);
                    BrushAreaWithColor(pixelUV, ColorPicker.SelectedColor, BrushSizeSlider.BrushSize);
                }
            }
        }
        UpdateText(textHolder);
    }
    
    [Command]
    private void CmdBrushAreaWithColorOnServer(Vector2 pixelUV, Color color, int size)
    {
        RpcBrushAreaWithColorOnClients(pixelUV, color, size);
        BrushAreaWithColor(pixelUV, color, size);
    }

    [ClientRpc]
    private void RpcBrushAreaWithColorOnClients(Vector2 pixelUV, Color color, int size)
    {
        BrushAreaWithColor(pixelUV, color, size);
    }

    private void BrushAreaWithColor(Vector2 pixelUV, Color color, int size)
    {
        for (int x = -size; x < size; x++)
        {
            for (int y = -size; y < size; y++)
            {
                PaintCanvas.Texture.SetPixel((int)pixelUV.x + x, (int)pixelUV.y + y, color);
            }
        }

        PaintCanvas.Texture.Apply();
    }





    public string theText;
    public GameObject inputfield;
    public Text UIText;
    public string textHolder;

    public void TextEnter()
    {
        const int MAX_Len = 21;
        string theText = string.Empty;
        theText = inputfield.GetComponent<Text>().text;
        if (theText.Length > MAX_Len)
            theText = theText.Substring(0, MAX_Len - 1);

        textHolder = theText;
        CmdTextOnServer(theText);
        UpdateText(theText);
    }


    [Command]
    public void CmdTextOnServer(string text)
    {
        textHolder = text;
        RpcTextOnClients(text);
        UpdateText(text);
    }

    [ClientRpc]
    private void RpcTextOnClients(string text)
    {
        textHolder = text;
        UpdateText(text);
    }

    private void UpdateText(string text)
    {
        UIText.text = "Player 2 said: " + text;
    }
}