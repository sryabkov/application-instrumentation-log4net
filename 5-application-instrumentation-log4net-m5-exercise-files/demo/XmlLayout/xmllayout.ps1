$logs = [xml]( get-content .\LookAtMyLog.xml )
$logs.events.logdata.event | where {$_.level -eq 'error' }

