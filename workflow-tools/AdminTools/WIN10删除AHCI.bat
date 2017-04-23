rem WIN10删除AHCI
reg delete "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\storahci\" /v StartOverride /f