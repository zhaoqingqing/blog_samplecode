set file="main.proto"
protoc --descriptor_set_out=main.protobin --include_imports %file%
::protogen -output_directory=client main.protobin
protogen -output_directory=./../taiji_code/tcgame/Assets/Scritps/NetTest main.protobin

del main.protobin
pause