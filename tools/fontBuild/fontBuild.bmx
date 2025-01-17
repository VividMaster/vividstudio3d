'Font Build.
SuperStrict 

SetGraphicsDriver GLMax2DDriver()

Graphics 640,480


Local font_name$ = ""
Local font_size:Int = 12

If AppArgs.length>1
	font_name$ = AppArgs[1]
EndIf

If AppArgs.length>2

 	font_size = Int(AppArgs[2])

End If

Local tf:TImageFont  

If font_name.length > 1

 	tf = LoadImageFont(font_name,font_size)
	If tf = Null
	
		Print "failed to load font."
		End 
	
	End If 
	SetImageFont tf
	

End If

Print "Parsing Font:"+font_name
Print "FontSize:"+font_size

Local fo:TStream = WriteFile(font_name+".vf")

For Local c:Int = 0 Until 255

	Cls
	
	DrawText Chr(c),2,2
	
	Local cw:Int = TextWidth(Chr(c))
	Local ch:Int = TextHeight(Chr(c))
	
	cw:+4
	ch:+4
	
	WriteShort fo,cw
	WriteShort fo,ch
	
	Local np:TPixmap = CreatePixmap(cw,ch,PF_RGBA8888)
	
	
	Local cp:TPixmap = GrabPixmap(0,0,cw,ch)
	Rem
	For Local y:Int =0 Until ch
	For Local x:Int =0 Until cw
		
		Local col:Int = 0
		Local ic:Int =0
		
		For Local sy:Int = y-2 To y+2
		For Local sx:Int = x-2 To x+2
		
			If sx>=0 And sx<cw And sy>=0 And sy<ch	
			
				Local p1:Byte Ptr = cp.pixelptr(sx,sy)
				col:+p1[0]
				ic:+1
			
			EndIf
			
		
		Next
		Next
		
		col = col / ic
		
		Local p2:Byte Ptr = np.pixelptr(x,y)
		
		Local p3:Byte Ptr = cp.pixelptr(x,y)
		
		If p3[0] > 128
			p2[0] = 255
			p2[1] = 255
			p2[2] = 255
		EndIf
		
		p2[3] = col
		
	Next
	Next
	
	End Rem
	
	For Local y:Int = 0 Until ch
	For Local x:Int = 0 Until cw
	
		Local pp:Byte Ptr = cp.pixelptr(x,y)
	
		WriteByte fo,pp[0]
		WriteByte fo,pp[1]
		WriteByte fo,pp[2]
		
		If (pp[0]+pp[1]+pp[2])>0
		
			WriteByte fo,255
		
		Else
		 
			WriteByte fo,0
		
		EndIf
		
	
	Next
	Next
	Print "Parsed Index:"+c+"/255"
	
	
Next

fo.flush()

fo.close()

fo = Null

Delay 1000

End 

