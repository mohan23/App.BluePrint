ECHO OFF
cls
ECHO "CLEARING ASP.NET TEMP FILES..."
del "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Temporary ASP.NET Files\*.*" /s /q
rmdir /s /q "C:\Windows\Microsoft.NET\Framework\v4.0.30319\Temporary ASP.NET Files"
ECHO "SUCCESSFULLY CLEARED ASP.NET TEMP FILES !!!"
PAUSE