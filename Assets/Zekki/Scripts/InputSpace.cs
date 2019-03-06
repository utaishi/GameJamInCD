using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Zekki
{ 
    public class InputSpace : MonoBehaviour {
        [SerializeField] private ChangeSceneUeta cs;
        [SerializeField] private string nextScene;
	// Use this for initialization
	void Start () {
            this.UpdateAsObservable()
                    .Subscribe(_ =>
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            cs.ChangeAnyScene(nextScene);
                        }


                    }).AddTo(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
}
