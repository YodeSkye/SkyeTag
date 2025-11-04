[Setup]
AppName=SkyeTag
AppVersion=2.3
AppVerName=SkyeTag v2.3
DefaultDirName={commonpf64}\Skye\SkyeTag
ArchitecturesInstallIn64BitMode=x64compatible
DisableProgramGroupPage=yes
OutputDir=.
OutputBaseFilename=SkyeTagSetup

[Files]
Source: "bin\Release\net9.0-windows\*"; DestDir: "{app}"; Flags: recursesubdirs

[Icons]
; Start Menu shortcut (root, no subfolder)
Name: "{commonprograms}\SkyeTag"; Filename: "{app}\SkyeTag.exe"

; Optional desktop shortcut
Name: "{commondesktop}\SkyeTag"; Filename: "{app}\SkyeTag.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"