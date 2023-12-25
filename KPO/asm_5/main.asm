.586P
.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO: DWORD
GetStdHandle    PROTO: DWORD
WriteConsoleA   PROTO   :DWORD,:DWORD,:DWORD,:DWORD,:DWORD,

includelib msvcrt.lib
system  PROTO C:DWORD



.STACK 4096

.CONST 
Arr sdword 12, 14, -12, 7, 13, 18, 1, 8, -24, 69
consoletitle db 'SMW Consol', 0

.DATA
consolehandle dd 0h
min sdword ?
max sdword ?
result1 byte    40 dup(0)
        byte    10
result2 byte    40 dup(0)


.CODE

main PROC
START:
    push -11
    call GetStdHandle
    mov consolehandle, eax


    push lengthof Arr
    push offset Arr
    call getmin
    mov min, eax
    

    push lengthof Arr
    push offset Arr
    call getmax
    mov max, eax


   


    push 0
    call ExitProcess
main ENDP


int_to_char PROC uses eax ebx ecx edi esi, 
                                pstr: dword,
                                intfield: dword
    mov edi, pstr
    mov esi, 0
    mov eax, intfield
    cdq
    mov ebx, 10
    idiv ebx
    test eax, 8000000h
    js plus
    neg eax
    neg edx
    mov cl, '-'
    mov [edi], cl
    inc edi
plus:
    push dx
    inc esi
    test eax, eax
    jz fin
    cdq
    idiv ebx
    jmp plus
fin:
    mov ecx, esi
write:
    pop bx
    add bl, '0'
    mov [edi], bl
    inc edi
    loop write

    ret
int_to_char ENDP


getmin PROC uses ecx esi ebx, parr: dword, elem: dword

      mov   ecx, elem
      mov   esi, parr
      mov   ebx, [esi]
CYCLE: 
      lodsd
      cmp   eax, ebx
      jge   FALSE
      xchg  ebx, eax 
FALSE: 
      loop  CYCLE
      xchg eax, ebx
	ret
getmin ENDP


getmax PROC uses ecx esi ebx, parr: dword, elem: dword

      mov   ecx, elem
      mov   esi, parr
      mov   ebx, [esi]
CYCLE: 
      lodsd
      cmp   eax, ebx
      jle   FALSE
      xchg  ebx, eax 
FALSE: 
      loop  CYCLE
      xchg ebx, eax
	ret
getmax ENDP




END main