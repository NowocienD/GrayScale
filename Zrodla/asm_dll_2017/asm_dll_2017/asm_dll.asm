
.code

SingleColorChannel_Red_ASM PROC 
movdqu xmm1, [rcx]
movdqu xmm2, [rdx]
movdqu xmm3, [r8]
movdqu [rcx], xmm1
movdqu [rdx], xmm1
movdqu [r8], xmm1
ret
SingleColorChannel_Red_ASM endp

;--------------------------------------------------------------------------------

SingleColorChannel_Green_ASM PROC 
movdqu xmm1, [rcx]
movdqu xmm2, [rdx]
movdqu xmm3, [r8]
movdqu [rcx], xmm2
movdqu [rdx], xmm2
movdqu [r8], xmm2
ret
SingleColorChannel_Green_ASM endp

;--------------------------------------------------------------------------------

SingleColorChannel_Blue_ASM PROC 
movdqu xmm1, [rcx]
movdqu xmm2, [rdx]
movdqu xmm3, [r8]
movdqu [rcx], xmm3
movdqu [rdx], xmm3
movdqu [r8], xmm3
ret
SingleColorChannel_Blue_ASM endp


Decomposition_max_ASM PROC 
movdqu xmm1, [rcx]
movdqu xmm2, [rdx]
movdqu xmm3, [r8]

PMAXsw xmm1, xmm2
PMAXsw xmm1, xmm3

movdqu [rcx], xmm1
movdqu [rdx], xmm1
movdqu [r8], xmm1
ret
Decomposition_max_ASM endp

Decomposition_min_ASM PROC 
movdqu xmm1, [rcx]
movdqu xmm2, [rdx]
movdqu xmm3, [r8]

PMINsw xmm1, xmm2
PMINsw xmm1, xmm3

movdqu [rcx], xmm1
movdqu [rdx], xmm1
movdqu [r8], xmm1
ret
Decomposition_min_ASM endp

;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;

Desaturation_ASM PROC 
movdqu xmm1, [rcx]
movdqu xmm2, [rdx]
movdqu xmm3, [r8]
movdqu xmm4, [rcx]

;wartosc minimalna zapisywana do xmm1
PMINuw xmm1, xmm2
PMINuw xmm1, xmm3

;wartosc maxymalna zapisywana do xmm4
PMAXuw xmm4, xmm2
PMAXuw xmm4, xmm3

;dzielenie przez 2
PSRLW xmm1, 1
PSRLW xmm4, 1

;dodawwanie
PADDusB xmm1, xmm4

;propagowanie
movdqu [rcx], xmm1
movdqu [rdx], xmm1
movdqu [r8], xmm1
ret
Desaturation_ASM endp

end