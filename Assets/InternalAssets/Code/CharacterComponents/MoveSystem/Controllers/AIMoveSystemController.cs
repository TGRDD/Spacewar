using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class AIMoveSystemController : IMoveSystemController
{
    private IMoveSystemModel _model;
    private JobHandle _jobHandle;

    private Transform moveObject => _model.MoveObject.transform;
    private float moveSpeed => _model.MoveSpeed * Time.deltaTime;

    private Vector3 MovedPosition;

    public TransformAccessArray _transformAccessArray { get; private set; } = new TransformAccessArray();

    public AIMoveSystemController(IMoveSystemModel model)
    {
        _model = model;

        if (_transformAccessArray.isCreated)
        {
            _transformAccessArray.Dispose();
        }
        _transformAccessArray = new TransformAccessArray(1);
        _transformAccessArray.Add(_model.MoveObject);
    }

    public void Execute()
    {
        if (_model == null) return;
        _jobHandle.Complete();

        MoveObjectJob job = new MoveObjectJob()
        {
            DeltaTime = Time.deltaTime,
            MoveSpeed = moveSpeed
        };

        _jobHandle = job.Schedule(_transformAccessArray);
        JobHandle.ScheduleBatchedJobs();
        
    }

    
}
