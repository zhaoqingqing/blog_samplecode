cd %~dp0
set src_path="%CD%\81-C# Script-NewBehaviourScript.cs.txt"
set unity_path="D:\Program Files\Unity\Editor\Data\Resources\ScriptTemplates\81-C# Script-NewBehaviourScript.cs.txt"
xcopy %src_path% %unity_path% /S /Y


::copy cs to code path
set src_cs="%CD%\CreateScriptEditor.cs"
set code_path="E:\Code\Editor\CreateScriptEditor.cs"
::xcopy %src_cs% %code_path% /S /Y
pause