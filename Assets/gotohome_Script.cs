using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotohome_Script : MonoBehaviour
{
	public void SceneChange()
	{
		SceneManager.LoadScene("MainPlayScene");
	}
}
