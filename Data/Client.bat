set GEN_CLIENT=dotnet Tools\Luban.ClientServer\Luban.ClientServer.dll

%GEN_CLIENT% -j cfg --^
 -d Defines\__root__.xml ^
 --input_data_dir Excels ^
 --output_data_dir ..\Client\ciga2023\Assets\Resources\datas ^
 --output_code_dir ..\Client\ciga2023\Assets\Scripts\CSVData\codes ^
 --gen_types code_cs_unity_json,data_json ^
 -s all
pause