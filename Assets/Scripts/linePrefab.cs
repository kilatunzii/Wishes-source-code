using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class linePrefab : MonoBehaviour
{
    public GameObject lineprefab;
    private GameObject currentLine;
    private LineRenderer currentLineRenderer;
    private List<Vector3> currentPositions;
    public float drawTime = 60f;
    private float timer;
    private bool isDrawingTimeOver = false;
    //public RenderTexture RDrawing;    
    private bool hasSaved = false;

    void Start()
    {
        timer = drawTime;
    }

    void Update()
    {
        // Drawing timer countdown
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                StartNewLine();
            }
            else if (Input.GetMouseButton(0) && currentLine != null)
            {
                AddPointToLine();
            }
        }
        else if (!isDrawingTimeOver)
        {
            // Once drawing time is over, you can implement logic to stop drawing or erase lines
            isDrawingTimeOver = true;
        }
    }

    void StartNewLine()
    {
        currentLine = Instantiate(lineprefab);
        currentLineRenderer = currentLine.GetComponent<LineRenderer>();
        currentPositions = new List<Vector3>();
        AddPointToLine(); // Start the line at the current mouse position
    }

    void AddPointToLine()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Only add the point if it's sufficiently far from the last one to avoid clutter
            if (currentPositions.Count == 0 || (currentPositions.Count > 0 && Vector3.Distance(currentPositions[currentPositions.Count - 1], hit.point) > 0.1f))
            {
                currentPositions.Add(hit.point);
                currentLineRenderer.positionCount = currentPositions.Count;
                currentLineRenderer.SetPositions(currentPositions.ToArray());
            }
        }
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "returnShop")
        {
            // Disable UI elements
            ToggleUICanvas(false);

            // Disable unnecessary lights
            ToggleDirectionalLight(false);
        }
    }

    //toggle canvas by tag when new scene is loaded
    public void ToggleUICanvas(bool isActive)
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            canvas.gameObject.SetActive(isActive);
        }
    }

    //toggle directional light by tag when new scene is loaded
    public void ToggleDirectionalLight(bool isActive)
    {
        GameObject lightGameObject = GameObject.FindGameObjectWithTag("darkLight"); 
        if (lightGameObject != null)
        {
            Light light = lightGameObject.GetComponent<Light>();
            if (light != null && light.type == LightType.Directional)
            {
                light.gameObject.SetActive(isActive);
            }
        }
    }

    public void Clear()
    {
        SceneManager.LoadScene("darkRoom");
      
    }
    public void Save()
    {
        StartCoroutine(CoSave());
        hasSaved = true;

    }

    private IEnumerator CoSave()
    {
        //wait for rendering
        yield return new WaitForEndOfFrame();
        Debug.Log(Application.dataPath + "/savedImage.png");

        //set active texture
        RenderTexture.active = renderTextureManager.Instance.RDrawing;
       

        //convert rendering texture to texture2D
        var texture2D = new Texture2D(renderTextureManager.Instance.RDrawing.width, renderTextureManager.Instance.RDrawing.height);
        texture2D.ReadPixels(new Rect(0, 0, renderTextureManager.Instance.RDrawing.width,renderTextureManager.Instance.RDrawing.height), 0, 0);
        texture2D.Apply();

        //write data to file
        var data = texture2D.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);
    }
    
    public void returnToShop()
    {
        if (hasSaved == true)
        {
            SceneManager.LoadSceneAsync("returnShop", LoadSceneMode.Additive);
           // SceneManager.LoadScene("returnShop");

        }
        else
        {
            SceneManager.LoadScene("darkRoom");
        }
        
    }
}
