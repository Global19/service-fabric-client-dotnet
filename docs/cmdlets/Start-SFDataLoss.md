# Start-SFDataLoss
This API will induce data loss for the specified partition. It will trigger a call to the OnDataLossAsync API of the partition.
## Description

This API will induce data loss for the specified partition. It will trigger a call to the OnDataLoss API of the 
partition.
                Actual data loss will depend on the specified DataLossMode.
                
                - PartialDataLoss - Only a quorum of replicas are removed and OnDataLoss is triggered for the 
partition but actual data loss depends on the presence of in-flight replication.
                - FullDataLoss - All replicas are removed hence all data is lost and OnDataLoss is triggered.
                
                This API should only be called with a stateful service as the target.
                
                Calling this API with a system service as the target is not advised.
                
                Note:  Once this API has been called, it cannot be reversed. Calling CancelOperation will only stop 
execution and clean up internal system state.
                It will not restore data if the command has progressed far enough to cause data loss.
                
                Call the GetDataLossProgress API with the same OperationId to return information on the operation 
started with this API.



## Required Parameters
#### -ServiceId

The identity of the service. This ID is typically the full name of the service without the 'fabric:' URI scheme.
                    Starting from version 6.0, hierarchical names are delimited with the "~" character.
                    For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be 
"myapp~app1~svc1" in 6.0+ and "myapp/app1/svc1" in previous versions.



#### -PartitionId

The identity of the partition.



#### -OperationId

A GUID that identifies a call of this API.  This is passed into the corresponding GetProgress API



#### -DataLossMode

This enum is passed to the StartDataLoss API to indicate what type of data loss to induce. Possible values include: 
'Invalid', 'PartialDataLoss', 'FullDataLoss'



