using System.Collections;
using System.Collections.Generic;
using UniProject.Demo;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{

    private IApplicationService _applicationService;

    [Inject]
    private void Bind(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
