
.code

ColorChange PROC x:DWORD, y:DWORD, Z:DWORD


mov rax, r8
add rax, rcx
add rax, rdx


sar rax, 2



ret
ColorChange endp

end