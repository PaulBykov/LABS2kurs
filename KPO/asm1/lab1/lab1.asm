.586P
.model flat, stdcall
includelib kernel32.lib

ExitProcess PROTO :DWORD
MessageBoxA PROTO : DWORD, : DWORD, : DWORD, : DWORD

.STACK 4096

.CONST

.DATA

Arr BYTE 1, 2, 3, 4, 5, 6, 0
myBytes BYTE 10h, 20h, 30h, 40h
MB_OK	EQU 0
STR1 DB "1 ", 0
STR2 DB "2 ", 0
STR3 DB "3 ", 0
HW		DD ?


.CODE

main PROC

START:
	
	xor eax,eax
    xor ebx,ebx
    mov ecx,5
    lea esi,[mass]
    mov al,byte ptr[mass]
l1:    
    mov bl,[esi+1]
    add ax,bx
    inc esi
    loop l1 

	push 0
	CALL ExitProcess

main ENDP
end main

		ret
printconsole endp
;----------------------------------

end main