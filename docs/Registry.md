# WinCertes - Registry Settings

Advanced configuration of WinCertes can be perfomed using Registry settings. These settings are located in `HKLM\SOFTWARE\WinCertes`. It is possible to set these options using the --setopt=key:value option in the command line, for instance: `WinCertes.exe ... --setopt=keysize:3072`

General Settings
-------------
Some settings are configured automatically using the command line, and thus won't be detailed here. Only additional settings are mentioned

- renewalDays: DWORD, decimal, number of days before certificate expiration when WinCertes should trigger the renewal
- keySize: DWORD, decimal, size of the RSA keys to be used (e.g. 2048, 3072, 4096)


DNS "acme-dns" validation plugin
-------------

See https://github.com/joohoi/acme-dns for more information on acme-dns. All the paramaters are "String" parameters.

- DNSValidatorType: acme-dns
- DNSServerURL: The acme-dns server "update" URL, e.g. http://acme-dns.host/update
- DNSServerUser: The acme-dns username, e.g. eabcdb41-d89f-4580-826f-3e62e9755ef2 
- DNSServerKey: The acme-dns password, e.g. pbAXVjlIOE01xbut7YnAbkhMQIkcwoHO0ek2j4Q0
- DNSServerSubDomain: The acme-dns subdomain, e.g. d420c923-bbd7-4056-ab64-c3ca54c9b3cf


DNS "Windows DNS" validation plugin
-------------

This plugin allows to update Windows DNS server records. All the parameters are "String" parameters.

- DNSValidatorType: win-dns
- DNSServerHost: The Windows DNS Server Hostname/IP, e.g. dns.example.corp
- DNSServerUser:  The Windows DNS Server User, with enough rights on the server to update DNS contents, e.g. Administrator
- DNSServerPassword: The password of the aformentioned Windows DNS Server User
- DNSServerZone: The DNS Zone in which are the hosts to be validated, and as declared in the Windows DNS Server, e.g. example.corp


DNS "PowerShell" validation plugin
-------------

This plugin allows to launch a PowerShell script to update remote DNS record. All the parameter are "String" parameters.

- DNSValidatorType: ps
- DNSScriptFile: The full path to the PowerShell script that will be launched. The script will get dnsKeyName and dnsKeyValue as its parameters.
