::NotePad++֮����ı��༭������ʹ�á������滻��������\r\n���滻�ɡ�\n����ע��Ҫ��notepad++��Ѳ���ģʽ����Ϊ��չģʽ������ʶ��ת���ַ�\r\n��
@echo off

for /f "delims=" %%i in ( 'where adb') do set ADB=%%i
if not defined ADB (
	echo path��δ�ҵ�adb.exe
	goto end
)
cd %~dp0
:: ��׿ģ�����İ�װ·��
set ADB=C:\Program Files (x86)\Droid4X\adb.exe

set src_path=%~dp0/hosts

::��ȡrootȨ��
"%ADB%" root 
::���¹���ģ����
"%ADB%" remount

::�����豸�ϵ�host������
"%ADB%"  pull /system/etc/hosts %~dp0\hosts.bak

::���ͱ������ļ����豸��
"%ADB%" push %src_path% /system/etc/hosts


echo �ѽ�%relativePath%���͵�android�豸��

pause