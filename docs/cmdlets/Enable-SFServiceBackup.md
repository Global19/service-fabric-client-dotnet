# Enable-SFServiceBackup
Enables periodic backup of stateful partitions under this Service Fabric service.
## Description

Enables periodic backup of stateful partitions which are part of this Service Fabric service. Each partition is backed 
up individually as per the specified backup policy description. In case the application, which the service is part of, 
is already enabled for backup then this operation would override the policy being used to take the periodic backup for 
this service and its partitions (unless explicitly overridden at the partition level).
                Note only C# based Reliable Actor and Reliable Stateful services are currently supported for periodic 
backup.



## Required Parameters
#### -ServiceId

The identity of the service. This ID is typically the full name of the service without the 'fabric:' URI scheme.
                    Starting from version 6.0, hierarchical names are delimited with the "~" character.
                    For example, if the service name is "fabric:/myapp/app1/svc1", the service identity would be 
"myapp~app1~svc1" in 6.0+ and "myapp/app1/svc1" in previous versions.



#### -BackupPolicyName

Name of the backup policy to be used for enabling periodic backups.



