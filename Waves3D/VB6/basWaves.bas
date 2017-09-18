Attribute VB_Name = "basWaves"
Option Explicit
Declare Function GetTickCount Lib "kernel32" () As Long

Global Const PI = 3.14159265358979
Global Const INFINITY = 2147483647

Global Const m3Parallel = 0
Global Const m3Perspective = 1

Type Point3D
    coord(1 To 4) As Single
    trans(1 To 4) As Single
End Type

Type Segment3D
    pt1 As Integer
    pt2 As Integer
End Type

' Convert the spherical coordinates into Cartesian coordinates.

Sub m3SphericalToCartesian(r As Single, theta As Single, phi As Single, x As Single, y As Single, z As Single)
Dim R2 As Single
    
    ' Create a line to the center of projection.
    y = r * Sin(phi)
    R2 = r * Cos(phi)
    x = R2 * Cos(theta)
    z = R2 * Sin(theta)
End Sub
' Create a transformation matrix for an oblique
' projection onto the X-Y plane.
Sub m3ObliqueXY(M() As Single, S As Single, theta As Single)
    m3Identity M
    M(3, 1) = -S * Cos(theta)
    M(3, 2) = -S * Sin(theta)
    M(3, 3) = 0
End Sub


' Create a transformation matrix for orthographic
' projection along the X axis.
Sub m3OrthoSide(M() As Single)
    m3Identity M
    M(1, 1) = 0
    M(3, 1) = -1
    M(3, 3) = 0
End Sub
' Create a transformation matrix for orthographic
' projection along the Y axis.
Sub m3OrthoTop(M() As Single)
    m3Identity M
    M(2, 2) = 0
    M(3, 2) = -1
    M(3, 3) = 0
End Sub

' Create a transformation matrix for orthographic
' projection along the Z axis.
Sub m3OrthoFront(M() As Single)
    m3Identity M
    M(3, 3) = 0
End Sub

' Create an identity matrix.
Public Sub m3Identity(M() As Single)
Dim i As Integer
Dim j As Integer

    For i = 1 To 4
        For j = 1 To 4
            If i = j Then
                M(i, j) = 1
            Else
                M(i, j) = 0
            End If
        Next j
    Next i
End Sub

' Normalize a 3-D point vector.
Public Sub m3NormalizeCoords(x As Single, y As Single, z As Single, S As Single)
    x = x / S
    y = y / S
    z = z / S
    S = 1
End Sub

' Normalize a 3-D point vector.
Public Sub m3NormalizePoint(P() As Single)
Dim i As Integer
Dim value As Single

    value = P(4)
    For i = 1 To 3
        P(i) = P(i) / value
    Next i
    P(4) = 1
End Sub


' Normalize a 3-D transformation matrix.
Public Sub m3NormalizeMatrix(M() As Single)
Dim i As Integer
Dim j As Integer
Dim value As Single

    value = M(4, 4)
    For i = 1 To 4
        For j = 1 To 4
            M(i, j) = M(i, j) / value
        Next j
    Next i
End Sub




' Create a 3-D transformation matrix for a
' perspective projection along the Z axis onto
' the X-Y plane with focus at the origin and the
' center of projection at distance (0, 0, D).
Public Sub m3PerspectiveXZ(M() As Single, D As Single)
    m3Identity M
    If D <> 0 Then M(3, 4) = -1 / D
End Sub

' Create a 3-D transformation matrix
Public Sub m3Project(M() As Single, ptype As Integer, Cx As Single, Cy As Single, Cz As Single, Fx As Single, Fy As Single, Fz As Single, ux As Single, uy As Single, uz As Single)
Static M1(1 To 4, 1 To 4) As Single
Static M2(1 To 4, 1 To 4) As Single
Static M3(1 To 4, 1 To 4) As Single
Static M4(1 To 4, 1 To 4) As Single
Static M5(1 To 4, 1 To 4) As Single
Static M12(1 To 4, 1 To 4) As Single
Static M34(1 To 4, 1 To 4) As Single
Static M1234(1 To 4, 1 To 4) As Single
Dim sin1 As Single
Dim cos1 As Single
Dim sin2 As Single
Dim cos2 As Single
Dim sin3 As Single
Dim cos3 As Single
Dim A As Single
Dim b As Single
Dim C As Single
Dim d1 As Single
Dim d2 As Single
Dim d3 As Single
Dim up1(1 To 4) As Single
Dim up2(1 To 4) As Single

    ' Translate the focus to the origin.
    m3Translate M1, -Fx, -Fy, -Fz

    A = Cx - Fx
    b = Cy - Fy
    C = Cz - Fz
    d1 = Sqr(A * A + C * C)
    If d1 <> 0 Then
        sin1 = -A / d1
        cos1 = C / d1
    End If
    d2 = Sqr(A * A + b * b + C * C)
    If d2 <> 0 Then
        sin2 = b / d2
        cos2 = d1 / d2
    End If
    
    ' Rotate around the Y axis to place the
    ' center of projection in the Y-Z plane.
    m3Identity M2
    
    ' If d1 = 0 then the center of projection
    ' already lies in the Y axis and thus the Y-Z plane.
    If d1 <> 0 Then
        M2(1, 1) = cos1
        M2(1, 3) = -sin1
        M2(3, 1) = sin1
        M2(3, 3) = cos1
    End If
    
    ' Rotate around the X axis to place the
    ' center of projection in the Z axis.
    m3Identity M3
    
    ' If d2 = 0 then the center of projection
    ' lies at the origin. This makes projection
    ' impossible.
    If d2 <> 0 Then
        M3(2, 2) = cos2
        M3(2, 3) = sin2
        M3(3, 2) = -sin2
        M3(3, 3) = cos2
    End If
    
    ' Apply the rotations to the UP vector.
    up1(1) = ux
    up1(2) = uy
    up1(3) = uz
    up1(4) = 1
    m3Apply up1, M2, up2
    m3Apply up2, M3, up1

    ' Rotate around the Z axis to put the UP
    ' vector in the Y-Z plane.
    d3 = Sqr(up1(1) * up1(1) + up1(2) * up1(2))
    m3Identity M4
    
    ' If d3 = 0 then the UP vector is a zero
    ' vector so do nothing.
    If d3 <> 0 Then
        sin3 = up1(1) / d3
        cos3 = up1(2) / d3
        M4(1, 1) = cos3
        M4(1, 2) = sin3
        M4(2, 1) = -sin3
        M4(2, 2) = cos3
    End If
    
    ' Project.
    If ptype = m3Perspective And d2 <> 0 Then
        m3PerspectiveXZ M5, d2
    Else
        m3Identity M5
    End If

    ' Combine the transformations.
    m3MatMultiply M12, M1, M2
    m3MatMultiply M34, M3, M4
    m3MatMultiply M1234, M12, M34
    If ptype = m3Perspective Then
        m3MatMultiplyFull M, M1234, M5
     Else
        m3MatMultiply M, M1234, M5
    End If
End Sub



' Create a 3-D transformation matrix for a
' perspective projection with:
'       center of projection    (r, phi, theta)
'       focus                   (fx, fy, fx)
'       up vector               <ux, uy, uz>
' ptype should be m3Perspective or m3Parallel.
Sub m3PProject(M() As Single, ptype As Integer, r As Single, phi As Single, theta As Single, Fx As Single, Fy As Single, Fz As Single, ux As Single, uy As Single, uz As Single)
Dim Cx As Single
Dim Cy As Single
Dim Cz As Single
Dim R2 As Single

    ' Convert to Cartesian coordinates.
    Cy = r * Sin(phi)
    R2 = r * Cos(phi)
    Cx = R2 * Cos(theta)
    Cz = R2 * Sin(theta)
    m3Project M, ptype, Cx, Cy, Cz, Fx, Fy, Fz, ux, uy, uz
End Sub

' Create a transformation matrix for reflecting
' across the plane passing through (p1, p2, p3)
' with normal vector <n1, n2, n3>.
Sub m3Reflect(M() As Single, p1 As Single, p2 As Single, p3 As Single, n1 As Single, n2 As Single, n3 As Single)
Dim t(1 To 4, 1 To 4) As Single     ' Translate.
Dim R1(1 To 4, 1 To 4) As Single    ' Rotate 1.
Dim R2(1 To 4, 1 To 4) As Single    ' Rotate 2.
Dim S(1 To 4, 1 To 4) As Single     ' Reflect.
Dim R2i(1 To 4, 1 To 4) As Single   ' Unrotate 2.
Dim R1i(1 To 4, 1 To 4) As Single   ' Unrotate 1.
Dim Ti(1 To 4, 1 To 4) As Single    ' Untranslate.
Dim D As Single
Dim L As Single
Dim M12(1 To 4, 1 To 4) As Single
Dim M34(1 To 4, 1 To 4) As Single
Dim M1234(1 To 4, 1 To 4) As Single
Dim M56(1 To 4, 1 To 4) As Single
Dim M567(1 To 4, 1 To 4) As Single

    ' Translate the plane to the origin.
    m3Translate t, -p1, -p2, -p3
    m3Translate Ti, p1, p2, p3

    ' Rotate around Z-axis until the normal is in
    ' the Y-Z plane.
    m3Identity R1
    D = Sqr(n1 * n1 + n2 * n2)
    R1(1, 1) = n2 / D
    R1(1, 2) = n1 / D
    R1(2, 1) = -R1(1, 2)
    R1(2, 2) = R1(1, 1)
    
    m3Identity R1i
    R1i(1, 1) = R1(1, 1)
    R1i(1, 2) = -R1(1, 2)
    R1i(2, 1) = -R1(2, 1)
    R1i(2, 2) = R1(2, 2)
    
    ' Rotate around the X-axis until the normal
    ' lies along the Y axis.
    m3Identity R2
    L = Sqr(n1 * n1 + n2 * n2 + n3 * n3)
    R2(2, 2) = D / L
    R2(2, 3) = -n3 / L
    R2(3, 2) = -R2(2, 3)
    R2(3, 3) = R2(2, 2)
    
    m3Identity R2i
    R2i(2, 2) = R2(2, 2)
    R2i(2, 3) = -R2(2, 3)
    R2i(3, 2) = -R2(3, 2)
    R2i(3, 3) = R2(3, 3)

    ' Reflect across the X-Z plane.
    m3Identity S
    S(2, 2) = -1

    ' Combine the matrices.
    m3MatMultiply M12, t, R1
    m3MatMultiply M34, R2, S
    m3MatMultiply M1234, M12, M34
    m3MatMultiply M56, R2i, R1i
    m3MatMultiply M567, M56, Ti
    m3MatMultiply M, M1234, M567
End Sub


' Create a transformation matrix for rotating
' through angle theta around a line passing
' through (p1, p2, p3) in direction <d1, d2, d3>.
' Theta is measured counterclockwise as you look
' down the line opposite the line's direction.
Sub m3LineRotate(M() As Single, p1 As Single, p2 As Single, p3 As Single, d1 As Single, d2 As Single, d3 As Single, theta As Single)
Dim t(1 To 4, 1 To 4) As Single     ' Translate.
Dim R1(1 To 4, 1 To 4) As Single    ' Rotate 1.
Dim R2(1 To 4, 1 To 4) As Single    ' Rotate 2.
Dim Rot3(1 To 4, 1 To 4) As Single  ' Rotate.
Dim R2i(1 To 4, 1 To 4) As Single   ' Unrotate 2.
Dim R1i(1 To 4, 1 To 4) As Single   ' Unrotate 1.
Dim Ti(1 To 4, 1 To 4) As Single    ' Untranslate.
Dim D As Single
Dim L As Single
Dim M12(1 To 4, 1 To 4) As Single
Dim M34(1 To 4, 1 To 4) As Single
Dim M1234(1 To 4, 1 To 4) As Single
Dim M56(1 To 4, 1 To 4) As Single
Dim M567(1 To 4, 1 To 4) As Single

    ' Translate the plane to the origin.
    m3Translate t, -p1, -p2, -p3
    m3Translate Ti, p1, p2, p3

    ' Rotate around Z-axis until the line is in
    ' the Y-Z plane.
    m3Identity R1
    D = Sqr(d1 * d1 + d2 * d2)
    R1(1, 1) = d2 / D
    R1(1, 2) = d1 / D
    R1(2, 1) = -R1(1, 2)
    R1(2, 2) = R1(1, 1)
    
    m3Identity R1i
    R1i(1, 1) = R1(1, 1)
    R1i(1, 2) = -R1(1, 2)
    R1i(2, 1) = -R1(2, 1)
    R1i(2, 2) = R1(2, 2)
    
    ' Rotate around the X-axis until the line
    ' lies along the Y axis.
    m3Identity R2
    L = Sqr(d1 * d1 + d2 * d2 + d3 * d3)
    R2(2, 2) = D / L
    R2(2, 3) = -d3 / L
    R2(3, 2) = -R2(2, 3)
    R2(3, 3) = R2(2, 2)
    
    m3Identity R2i
    R2i(2, 2) = R2(2, 2)
    R2i(2, 3) = -R2(2, 3)
    R2i(3, 2) = -R2(3, 2)
    R2i(3, 3) = R2(3, 3)

    ' Rotate around the line (Y axis).
    m3YRotate Rot3, theta

    ' Combine the matrices.
    m3MatMultiply M12, t, R1
    m3MatMultiply M34, R2, Rot3
    m3MatMultiply M1234, M12, M34
    m3MatMultiply M56, R2i, R1i
    m3MatMultiply M567, M56, Ti
    m3MatMultiply M, M1234, M567
End Sub

' Create a 3-D transformation matrix for scaling
' by scale factors Sx, Sy, and Sz.
Public Sub m3Scale(M() As Single, Sx As Single, Sy As Single, Sz As Single)
    m3Identity M
    M(1, 1) = Sx
    M(2, 2) = Sy
    M(3, 3) = Sz
End Sub

' Create a 3-D transformation matrix for
' translation by Tx, Ty, and Tz.
Public Sub m3Translate(M() As Single, Tx As Single, Ty As Single, Tz As Single)
    m3Identity M
    M(4, 1) = Tx
    M(4, 2) = Ty
    M(4, 3) = Tz
End Sub

' Create a 3-D transformation matrix for rotation
' around the X axis (angle measured in radians).
Public Sub m3XRotate(M() As Single, theta As Single)
    m3Identity M
    M(2, 2) = Cos(theta)
    M(3, 3) = M(2, 2)
    M(2, 3) = Sin(theta)
    M(3, 2) = -M(2, 3)
End Sub

' Create a 3-D transformation matrix for rotation
' around the Y axis (angle measured in radians).
Public Sub m3YRotate(M() As Single, theta As Single)
    m3Identity M
    M(1, 1) = Cos(theta)
    M(3, 3) = M(1, 1)
    M(3, 1) = Sin(theta)
    M(1, 3) = -M(3, 1)
End Sub

' Create a 3-D transformation matrix for rotation
' around the Z axis (angle measured in radians).
Public Sub m3ZRotate(M() As Single, theta As Single)
    m3Identity M
    M(1, 1) = Cos(theta)
    M(2, 2) = M(1, 1)
    M(1, 2) = Sin(theta)
    M(2, 1) = -M(1, 2)
End Sub

' Create a matrix that rotates around the Y axis
' so the point (x, y, z) lies in the X-Z plane.
Sub m3YRotateIntoXZ(Result() As Single, x As Single, y As Single, z As Single)
Dim D As Single

    m3Identity Result
    D = Sqr(x * x + y * y)
    Result(1, 1) = x / D
    Result(1, 2) = -y / D
    Result(2, 1) = -Result(1, 2)
    Result(2, 2) = Result(1, 1)
End Sub

' Set copy = orig.
Public Sub m3MatCopy(copy() As Single, orig() As Single)
Dim i As Integer
Dim j As Integer

    For i = 1 To 4
        For j = 1 To 4
            copy(i, j) = orig(i, j)
        Next j
    Next i
End Sub

' Apply a transformation matrix to a point where
' the transformation may not have 0, 0, 0, 1 in
' its final column. Normalize only the X and Y
' components of the result to preserve the Z
' information.
Public Sub m3ApplyFull(V() As Single, M() As Single, Result() As Single)
Dim i As Integer
Dim j As Integer
Dim value As Single

    For i = 1 To 4
        value = 0#
        For j = 1 To 4
            value = value + V(j) * M(j, i)
        Next j
        Result(i) = value
    Next i
    
    ' Renormalize the point.
    ' Note that value still holds Result(4).
    If value <> 0 Then
        Result(1) = Result(1) / value
        Result(2) = Result(2) / value
        ' Do not transform the Z component.
    Else
        ' Make the Z value greater than that of
        ' the center of projection so the point
        ' will be clipped.
        Result(3) = INFINITY
    End If
    Result(4) = 1#
End Sub




' Apply a transformation matrix to a point.
Public Sub m3Apply(V() As Single, M() As Single, Result() As Single)
    Result(1) = V(1) * M(1, 1) + _
                V(2) * M(2, 1) + _
                V(3) * M(3, 1) + M(4, 1)
    Result(2) = V(1) * M(1, 2) + _
                V(2) * M(2, 2) + _
                V(3) * M(3, 2) + M(4, 2)
    Result(3) = V(1) * M(1, 3) + _
                V(2) * M(2, 3) + _
                V(3) * M(3, 3) + M(4, 3)
    Result(4) = 1#
End Sub

' Multiply two matrices together. The matrices
' may not contain 0, 0, 0, 1 in their last
' columns.
Public Sub m3MatMultiplyFull(Result() As Single, A() As Single, b() As Single)
Dim i As Integer
Dim j As Integer
Dim k As Integer
Dim value As Single

    For i = 1 To 4
        For j = 1 To 4
            value = 0#
            For k = 1 To 4
                value = value + A(i, k) * b(k, j)
            Next k
            Result(i, j) = value
        Next j
    Next i
End Sub
' Multiply two matrices together.
Public Sub m3MatMultiply(Result() As Single, A() As Single, b() As Single)
    Result(1, 1) = A(1, 1) * b(1, 1) + A(1, 2) * b(2, 1) + A(1, 3) * b(3, 1)
    Result(1, 2) = A(1, 1) * b(1, 2) + A(1, 2) * b(2, 2) + A(1, 3) * b(3, 2)
    Result(1, 3) = A(1, 1) * b(1, 3) + A(1, 2) * b(2, 3) + A(1, 3) * b(3, 3)
    Result(1, 4) = 0#
    Result(2, 1) = A(2, 1) * b(1, 1) + A(2, 2) * b(2, 1) + A(2, 3) * b(3, 1)
    Result(2, 2) = A(2, 1) * b(1, 2) + A(2, 2) * b(2, 2) + A(2, 3) * b(3, 2)
    Result(2, 3) = A(2, 1) * b(1, 3) + A(2, 2) * b(2, 3) + A(2, 3) * b(3, 3)
    Result(2, 4) = 0#
    Result(3, 1) = A(3, 1) * b(1, 1) + A(3, 2) * b(2, 1) + A(3, 3) * b(3, 1)
    Result(3, 2) = A(3, 1) * b(1, 2) + A(3, 2) * b(2, 2) + A(3, 3) * b(3, 2)
    Result(3, 3) = A(3, 1) * b(1, 3) + A(3, 2) * b(2, 3) + A(3, 3) * b(3, 3)
    Result(3, 4) = 0#
    Result(4, 1) = A(4, 1) * b(1, 1) + A(4, 2) * b(2, 1) + A(4, 3) * b(3, 1) + b(4, 1)
    Result(4, 2) = A(4, 1) * b(1, 2) + A(4, 2) * b(2, 2) + A(4, 3) * b(3, 2) + b(4, 2)
    Result(4, 3) = A(4, 1) * b(1, 3) + A(4, 2) * b(2, 3) + A(4, 3) * b(3, 3) + b(4, 3)
    Result(4, 4) = 1#
End Sub

' Compute the cross product of two vectors.
 'Set <x, y, z> = <x1, y1, z1> X <x2, y2, z2>.
Sub m3Cross(x As Single, y As Single, z As Single, x1 As Single, y1 As Single, z1 As Single, x2 As Single, y2 As Single, z2 As Single)
    x = y1 * z2 - z1 * y2
    y = z1 * x2 - x1 * z2
    z = x1 * y2 - y1 * x2
End Sub

' Give the vector the indicated length.
Sub m3SizeVector(ByVal L As Single, x As Single, y As Single, z As Single)
    L = L / Sqr(x * x + y * y + z * z)
    x = x * L
    y = y * L
    z = z * L
End Sub

Sub WaitTill(next_time As Long)
    Do
        DoEvents
    Loop While GetTickCount() < next_time
End Sub


