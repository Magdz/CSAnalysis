using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenesNavigation : MonoBehaviour {

	public void Goto_SignalFlow()
    {
        SceneManager.LoadScene("Build Signal Flow Graph");
    }

    public void Goto_BlockDiagram()
    {

    }
}
