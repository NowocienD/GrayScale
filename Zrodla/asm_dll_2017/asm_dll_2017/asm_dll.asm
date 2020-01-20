
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

;--------------------------------------------------------------------------------

Decomposition_max_ASM PROC 
movdqu xmm1, [rcx] ; przes³anie wartoœci umieszczonej w pamiêci wskazywanej przez adres zawarty w rcx to xmm1
movdqu xmm2, [rdx]
movdqu xmm3, [r8]

pmaxub xmm1, xmm2 ; porównanie ka¿dego z 16 pakietów 8-bitów z xmm1 i xmm2, i zapisanie wyniku wiêkszego do rejestru xmm1
pmaxub xmm1, xmm3

movdqu [rcx], xmm1 ; przeniesienie adresu z xmm1 do rejestru rcx
movdqu [rdx], xmm1
movdqu [r8], xmm1
; przenoszona jest identyczna wartoœæ do ka¿dego rejestru poniewa¿ taka jest charakterystyka mojego zadania (kolor -> skala szarosci)

ret
Decomposition_max_ASM endp

;--------------------------------------------------------------------------------

Decomposition_min_ASM PROC 
movdqu xmm1, [rcx]
movdqu xmm2, [rdx]
movdqu xmm3, [r8]

pminub xmm1, xmm2
pminub xmm1, xmm3

movdqu [rcx], xmm1
movdqu [rdx], xmm1
movdqu [r8], xmm1
ret
Decomposition_min_ASM endp

;--------------------------------------------------------------------------------

Desaturation_ASM PROC 
movdqu xmm1, [rcx]
movdqu xmm2, [rdx]
movdqu xmm3, [r8]
movdqu xmm4, [rcx]

;wartosc minimalna zapisywana do xmm1
pminub xmm1, xmm2
pminub xmm1, xmm3

;wartosc maxymalna zapisywana do xmm4
pmaxub xmm4, xmm2
pmaxub xmm4, xmm3

;wyciaganie sredniej z min i max
psrlw xmm1, 1			;dzielenie przez 2
psrlw xmm4, 1			;dzielenie przez 2
paddusb xmm1, xmm4		;dodawwanie

;propagowanie
movdqu [rcx], xmm1
movdqu [rdx], xmm1
movdqu [r8], xmm1
ret
Desaturation_ASM endp

end