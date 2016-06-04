Imports System.IO
Public Class Form1
    'declaratii variabile + liste + vectori 
    Dim nrst As New ArrayList()
    Dim clasa_random As New Random()
    Dim sunet As Integer = 1
    Dim st As Double = 0
    Dim este_inceput As Integer = 0
    Dim numar_perechi As Integer = 0
    Dim numeecran As Integer = 0
    Dim carte1 As Integer = 0
    Dim carte2 As Integer = 0
    Dim carte1pic As Integer = 0
    Dim carte2pic As Integer = 0
    Dim scor As Integer = 0
    Dim lista_itemi As New ArrayList()
    Dim values(,) As String = New String(,) {
        {"Numar_cutie", "Numar_pereche"},
        {"1", "1"}, {"2", "10"}, {"3", "11"}, {"4", "2"}, {"5", "18"}, {"6", "7"}, {"7", "19"}, {"8", "20"}, {"9", "5"}, {"10", "20"},
        {"11", "6"}, {"12", "19"}, {"13", "1"}, {"14", "13"}, {"15", "18"}, {"16", "12"}, {"17", "17"}, {"18", "4"}, {"19", "8"},
        {"20", "16"}, {"21", "9"}, {"22", "16"}, {"23", "11"}, {"24", "3"}, {"25", "15"}, {"26", "15"}, {"27", "14"}, {"28", "2"},
        {"29", "14"}, {"30", "13"}, {"31", "4"}, {"32", "6"}, {"33", "5"}, {"34", "3"}, {"35", "12"}, {"36", "10"}, {"37", "17"},
        {"38", "7"}, {"39", "9"}, {"40", "8"}
        }
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Verificam daca exista itemi in fisierele care contin imagini si sunete
        If Pict_fisier_verificat() = 1 And Sunet_fisier_verificat() = 1 Then
            Dim bgpic As Integer = My.Settings.Background

            'Selectie imagini de background ( din Resources )
            Select Case bgpic
                Case 1
                    Panel1.BackgroundImage = My.Resources.bc1
                Case 2
                    Panel1.BackgroundImage = My.Resources.bc2
                Case 3
                    Panel1.BackgroundImage = My.Resources.bc3
                Case 4
                    Panel1.BackgroundImage = My.Resources.bc4
                Case 5
                    Panel1.BackgroundImage = My.Resources.bc5
                Case 6
                    Panel1.BackgroundImage = My.Resources.bc6
                Case 7
                    Panel1.BackgroundImage = My.Resources.bc7
                Case 8
                    Panel1.BackgroundImage = My.Resources.bc8
                Case 9
                    Panel1.BackgroundImage = My.Resources.bc9
                Case 10
                    Panel1.BackgroundImage = My.Resources.bc10
            End Select
            'Ascundem Panel-ul cu culorile de background
            Panel2.Hide()
            'Scriem valorile default pentru caseta de scor si cea de timp 
            Label2.Text = "Score : 0"
            Label3.Text = "Time : 0 seconds"
            c0.Hide()
            dtp.Hide()
            'Afisare Panel pentru autentificare utilizator
            Panel3.Show()
            numeecran = 1
            Panel4.Hide()
        Else
            MsgBox("Lipsesc fisiere, nu putem incepe !")
            End
        End If
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        'Apasare buton de CLOSE
        My.Settings.Save()
        End
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        'Apasare buton de minimizare
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Daca este apasat butonul de JOC NOU , iar numele a fost introdus de utilizator, afisam urmatoarea interfata
        If numeecran = 0 Then
            Label2.Text = "Score : 0"
            scor = 0
            Label3.Text = "Time : 0 seconds"
            numar_perechi = 0
            'Afisaj imagini pentru carti 
            For i As Int32 = 1 To 40
                If My.Settings.Deck = 1 Then
                    CType(Me.Controls.Find("c" + CStr(i), True)(0), PictureBox).Image = My.Resources.cardbg
                ElseIf My.Settings.Deck = 2 Then
                    CType(Me.Controls.Find("c" + CStr(i), True)(0), PictureBox).Image = My.Resources.deck2
                ElseIf My.Settings.Deck = 3 Then
                    CType(Me.Controls.Find("c" + CStr(i), True)(0), PictureBox).Image = My.Resources.deck3
                ElseIf My.Settings.Deck = 4 Then
                    CType(Me.Controls.Find("c" + CStr(i), True)(0), PictureBox).Image = My.Resources.deck4
                End If
            Next
            st = 0
            'Stergere fundal carti
            sterge_locuri()
            'Inlocuire fundal carti
            schimba_locuri()
            'Pornire timer
            Timer1.Start()
            este_inceput = 1
            talk("Joc nou ! ")
        Else
            MsgBox("Introdu mai intai numele")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Buton pentru selectarea funcdalului 
        If numeecran = 0 Then
            'Afisare panel cu texturile pentru fundal
            Panel2.Show()
            PictureBox7.Show()
            PictureBox8.Show()
            PictureBox10.Show()
            PictureBox16.Show()
            PictureBox14.Show()
            PictureBox12.Show()
            PictureBox9.Show()
            PictureBox13.Show()
            PictureBox15.Show()
            PictureBox11.Show()
            deck1.Hide()
            deck2.Hide()
            deck3.Hide()
            deck4.Hide()
        Else
            MsgBox("Introdu numele mai intai !")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Apasare buton close de la panel-ul pentru imagini de fundal
        Panel2.Hide()
    End Sub
#Region "bgcolors"
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        Panel1.BackgroundImage = My.Resources.bc1
        My.Settings.Background = 1
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        Panel1.BackgroundImage = My.Resources.bc2
        My.Settings.Background = 2
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        Panel1.BackgroundImage = My.Resources.bc3
        My.Settings.Background = 3
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        Panel1.BackgroundImage = My.Resources.bc4
        My.Settings.Background = 4
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        Panel1.BackgroundImage = My.Resources.bc5
        My.Settings.Background = 5
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        Panel1.BackgroundImage = My.Resources.bc6
        My.Settings.Background = 6
    End Sub
    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        Panel1.BackgroundImage = My.Resources.bc7
        My.Settings.Background = 7
    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        Panel1.BackgroundImage = My.Resources.bc8
        My.Settings.Background = 8
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        Panel1.BackgroundImage = My.Resources.bc9
        My.Settings.Background = 9
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        Panel1.BackgroundImage = My.Resources.bc10
        My.Settings.Background = 10
    End Sub
#End Region
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        st = st + 1
        Label3.Text = "Timp : " & st & " secunde"
        Label7.Text = "Perechi : " & numar_perechi
        If numar_perechi = 19 And carte1 <> 0 And carte2 <> 0 Then
            numar_perechi = numar_perechi + 1
            victorie()
        End If
    End Sub
#Region "pictureboxes"
    Private Sub c1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c1.Click
        cb(1)
    End Sub

    Private Sub c2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c2.Click
        cb(2)
    End Sub

    Private Sub c3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c3.Click
        cb(3)
    End Sub

    Private Sub c4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c4.Click
        cb(4)
    End Sub

    Private Sub c5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c5.Click
        cb(5)
    End Sub

    Private Sub c6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c6.Click
        cb(6)
    End Sub

    Private Sub c7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c7.Click
        cb(7)
    End Sub

    Private Sub c8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c8.Click
        cb(8)
    End Sub

    Private Sub c9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c9.Click
        cb(9)
    End Sub

    Private Sub c10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c10.Click
        cb(10)
    End Sub

    Private Sub c11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c11.Click
        cb(11)
    End Sub

    Private Sub c12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c12.Click
        cb(12)
    End Sub

    Private Sub c13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c13.Click
        cb(13)
    End Sub

    Private Sub c14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c14.Click
        cb(14)
    End Sub

    Private Sub c15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c15.Click
        cb(15)
    End Sub

    Private Sub c16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c16.Click
        cb(16)
    End Sub

    Private Sub c17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c17.Click
        cb(17)
    End Sub

    Private Sub c18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c18.Click
        cb(18)
    End Sub

    Private Sub c19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c19.Click
        cb(19)
    End Sub

    Private Sub c20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c20.Click
        cb(20)
    End Sub

    Private Sub c21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c21.Click
        cb(21)
    End Sub

    Private Sub c22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c22.Click
        cb(22)
    End Sub

    Private Sub c23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c23.Click
        cb(23)
    End Sub

    Private Sub c24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c24.Click
        cb(24)
    End Sub

    Private Sub c25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c25.Click
        cb(25)
    End Sub

    Private Sub c26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c26.Click
        cb(26)
    End Sub

    Private Sub c27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c27.Click
        cb(27)
    End Sub

    Private Sub c28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c28.Click
        cb(28)
    End Sub

    Private Sub c29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c29.Click
        cb(29)
    End Sub

    Private Sub c30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c30.Click
        cb(30)
    End Sub

    Private Sub c31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c31.Click
        cb(31)
    End Sub

    Private Sub c32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c32.Click
        cb(32)
    End Sub

    Private Sub c33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c33.Click
        cb(33)
    End Sub

    Private Sub c34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c34.Click
        cb(34)
    End Sub

    Private Sub c35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c35.Click
        cb(35)
    End Sub

    Private Sub c36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c36.Click
        cb(36)
    End Sub

    Private Sub c37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c37.Click
        cb(37)
    End Sub

    Private Sub c38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c38.Click
        cb(38)
    End Sub

    Private Sub c39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c39.Click
        cb(39)
    End Sub

    Private Sub c40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c40.Click
        cb(40)
    End Sub
#End Region

    Public Function cb(ByVal value As Integer)
        'Daca jocul este inceput
        If este_inceput = 1 Then
            'Sunet pentru click pe carte
            soundPlay("Sounds\card_click.wav")
            If este_clicked(value) = 0 Then
                If carte1pic = carte2pic Then
                    If carte1pic <> 0 Then
                        scor = scor + 100
                        lista_itemi.Add(carte1)
                        lista_itemi.Add(carte2)
                        carte1 = 0
                        carte2 = 0
                        carte1pic = 0
                        carte2pic = 0
                        Label2.Text = "Scor : " & scor
                        numar_perechi = numar_perechi + 1
                        soundPlay("Sounds\pair.wav")
                    End If
                Else
                    If carte1pic = 0 Then
                    Else
                        If carte2pic = 0 Then
                        Else
                            If My.Settings.Deck = 1 Then
                                CType(Me.Controls.Find("c" + CStr(carte1), True)(0), PictureBox).Image = My.Resources.cardbg
                                CType(Me.Controls.Find("c" + CStr(carte2), True)(0), PictureBox).Image = My.Resources.cardbg
                            ElseIf My.Settings.Deck = 2 Then
                                CType(Me.Controls.Find("c" + CStr(carte1), True)(0), PictureBox).Image = My.Resources.deck2
                                CType(Me.Controls.Find("c" + CStr(carte2), True)(0), PictureBox).Image = My.Resources.deck2
                            ElseIf My.Settings.Deck = 3 Then
                                CType(Me.Controls.Find("c" + CStr(carte1), True)(0), PictureBox).Image = My.Resources.deck3
                                CType(Me.Controls.Find("c" + CStr(carte2), True)(0), PictureBox).Image = My.Resources.deck3
                            ElseIf My.Settings.Deck = 4 Then
                                CType(Me.Controls.Find("c" + CStr(carte1), True)(0), PictureBox).Image = My.Resources.deck4
                                CType(Me.Controls.Find("c" + CStr(carte2), True)(0), PictureBox).Image = My.Resources.deck4
                            End If
                            carte1 = 0
                            carte2 = 0
                            carte1pic = 0
                            carte2pic = 0
                            scor = scor - 10
                            Label2.Text = "Scor : " & scor
                            soundPlay("Sounds\no_pair.wav")
                        End If
                    End If
                End If
                If carte1 = 0 Then
                    carte1 = value
                    carte1pic = values(carte1, 1)
                    CType(Me.Controls.Find("c" + CStr(carte1), True)(0), PictureBox).Image = Image.FromFile("Cards/p" & carte1pic & ".jpeg")
                ElseIf carte1 > 0 Then
                    If carte2 = 0 Then
                        carte2 = value
                        carte2pic = values(carte2, 1)
                        CType(Me.Controls.Find("c" + CStr(carte2), True)(0), PictureBox).Image = Image.FromFile("Cards/p" & carte2pic & ".jpeg")
                    ElseIf carte2 > 0 Then
                        MsgBox("EROARE")
                    End If
                End If
            Else
                soundPlay("Sounds\clicked.wav")
            End If
        Else
            MsgBox("Apasa JOC NOU pentru a incepe ! ")
        End If

        Return 0
    End Function
    Public Function victorie()
        Timer1.Stop()
        talk("Victorie !")
        soundPlay("Sounds\victory.wav")
        MsgBox("Victory !" & Chr(10) & "Scor : " & scor & Chr(10) & "Timp : " & st & " Secunde")
        If scor > My.Settings.top1 Then
            My.Settings.top1 = scor
            My.Settings.top1name = My.Settings.Pname
            My.Settings.top1time = st
            My.Settings.top1date = dtp.Text
            MsgBox("Felicitari, sunteti top 1 !")
        ElseIf scor > My.Settings.top2 Then
            My.Settings.top2 = scor
            My.Settings.top2name = My.Settings.Pname
            My.Settings.top2time = st
            My.Settings.top2date = dtp.Text
            MsgBox("Felicitari, sunteti top 2 !")
        ElseIf scor > My.Settings.top3 Then
            My.Settings.top2 = scor
            My.Settings.top3name = My.Settings.Pname
            My.Settings.top3time = st
            My.Settings.top3date = dtp.Text
            MsgBox("Felicitari, sunteti top 3 !")
        ElseIf scor > My.Settings.top4 Then
            My.Settings.top4 = scor
            My.Settings.top4name = My.Settings.Pname
            My.Settings.top4time = st
            My.Settings.top4date = dtp.Text
            MsgBox("Felicitari, sunteti top 4 !")
        ElseIf scor > My.Settings.top5 Then
            My.Settings.top5 = scor
            My.Settings.top5name = My.Settings.Pname
            My.Settings.top5time = st
            My.Settings.top5date = dtp.Text
            MsgBox("Sunteti top 5 !")
        Else
            MsgBox("Scor prea mic pentru a fi inregistrat !")
        End If
        My.Settings.Save()
        numar_perechi = 0
        este_inceput = 0
        carte1 = 0
        carte2 = 0
        'timp = st 
        st = 0
        lista_itemi.Clear()
        Return 0
    End Function
    'Functie care verifica daca o carte este sau nu aleasa
    Public Function este_clicked(ByVal value As Integer)
        Dim i As Integer
        For i = 0 To lista_itemi.Count - 1
            If lista_itemi.Item(i) = value Then
                Return 1
                Exit For
            End If
        Next i
        Return 0
    End Function
    Public Function verifica_valori()
        Dim x As Integer = 0
        For i As Integer = 1 To 40
            If values(i, 1) = "" Then
                x = x + 1
            End If
        Next
        Return x
    End Function
    Public Function schimba_locuri()
        Dim nrlist As New ArrayList()
        For i As Integer = 1 To 20
            nrlist.Add(i)
            nrlist.Add(i)
        Next
        For a As Integer = 1 To 40
            Dim rnd = clasa_random.Next(0, nrlist.Count)
            values(a, 1) = nrlist(rnd)
            nrlist.RemoveAt(rnd)
        Next
        Return 0
    End Function
    Public Function sterge_locuri()
        For i As Integer = 1 To 40
            values(i, 1) = ""
        Next
        Return 0
    End Function
    Public Function update_scoruri()
        If My.Settings.top1time <> "" Then
            Label12.Text = My.Settings.top1name
            Label13.Text = "Scor : " & My.Settings.top1
            Label14.Text = "Timp : " & My.Settings.top1time & " Secunde"
            Label15.Text = My.Settings.top1date
        Else
            Label12.Hide()
            Label13.Hide()
            Label14.Hide()
            Label15.Hide()
        End If
        If My.Settings.top2time <> "" Then
            Label20.Text = My.Settings.top2name
            Label19.Text = "Scor : " & My.Settings.top2
            Label18.Text = "Timp : " & My.Settings.top2time & " Secunde"
            Label17.Text = My.Settings.top2date
        Else
            Label17.Hide()
            Label18.Hide()
            Label19.Hide()
            Label20.Hide()
        End If
        If My.Settings.top3time <> "" Then
            Label24.Text = My.Settings.top3name
            Label23.Text = "Scor : " & My.Settings.top3
            Label22.Text = "Timp : " & My.Settings.top3time & " Secunde"
            Label21.Text = My.Settings.top3date
        Else
            Label21.Hide()
            Label22.Hide()
            Label23.Hide()
            Label24.Hide()
        End If
        If My.Settings.top4time <> "" Then
            Label28.Text = My.Settings.top4name
            Label27.Text = "Scor : " & My.Settings.top4
            Label26.Text = "Timp : " & My.Settings.top4time & " Secunde"
            Label25.Text = My.Settings.top4date
        Else
            Label25.Hide()
            Label26.Hide()
            Label27.Hide()
            Label28.Hide()
        End If
        If My.Settings.top5time <> "" Then
            Label32.Text = My.Settings.top5name
            Label30.Text = "Scor : " & My.Settings.top5
            Label31.Text = "Timp : " & My.Settings.top5time & " Secunde"
            Label29.Text = My.Settings.top5date
        Else
            Label29.Hide()
            Label30.Hide()
            Label31.Hide()
            Label32.Hide()
        End If
        Return 0
    End Function
    'Buton CARTE
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If numeecran = 0 Then
            If este_inceput = 0 Then
                Panel2.Show()
                PictureBox7.Hide()
                PictureBox8.Hide()
                PictureBox10.Hide()
                PictureBox16.Hide()
                PictureBox14.Hide()
                PictureBox12.Hide()
                PictureBox9.Hide()
                PictureBox13.Hide()
                PictureBox15.Hide()
                PictureBox11.Hide()
                deck1.Show()
                deck2.Show()
                deck3.Show()
                deck4.Show()
            Else
                MsgBox("Jocul este deja inceput ! ")
            End If
        Else
            MsgBox("Introdu mai intai numele !")
        End If
    End Sub

    Private Sub deck1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deck1.Click
        My.Settings.Deck = 1
        Panel2.Hide()
    End Sub

    Private Sub deck2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deck2.Click
        My.Settings.Deck = 2
        Panel2.Hide()
    End Sub

    Private Sub deck3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deck3.Click
        My.Settings.Deck = 3
        Panel2.Hide()
    End Sub

    Private Sub deck4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deck4.Click
        My.Settings.Deck = 4
        Panel2.Hide()
    End Sub
    ' Buton ok, de introducere nume utilizator
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If pname.Text = "" Then
            MsgBox("Introdu numele !")
        Else
            My.Settings.Pname = pname.Text
            Panel3.Hide()
            numeecran = 0
        End If
    End Sub
    ' Buton SCOR
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        update_scoruri()
        Panel4.Show()
    End Sub
    ' Eticheta pentru CLOSE panel pt scor ( EXIT )
    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        Panel4.Hide()
    End Sub
    ' Eticheta pentru stergere scoruri
    Private Sub Label33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label33.Click
        If MessageBox.Show("Sigur doriti sa stergeti scorul ?", "Atentie !", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            My.Settings.top1 = 0
            My.Settings.top2 = 0
            My.Settings.top3 = 0
            My.Settings.top4 = 0
            My.Settings.top5 = 0

            My.Settings.top1name = ""
            My.Settings.top2name = ""
            My.Settings.top3name = ""
            My.Settings.top4name = ""
            My.Settings.top5name = ""

            My.Settings.top1time = ""
            My.Settings.top2time = ""
            My.Settings.top3time = ""
            My.Settings.top4time = ""
            My.Settings.top5time = ""

            My.Settings.top1date = ""
            My.Settings.top2date = ""
            My.Settings.top3date = ""
            My.Settings.top4date = ""
            My.Settings.top5date = ""
            My.Settings.Save()
            Button6.PerformClick()
        End If
    End Sub
    ' Buton de mute (fara sunet)
    Private Sub mute_b_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mute_b.Click
        If sunet = 0 Then
            sunet += 1
        End If
        mute_b.Hide()
        unmute_b.Show()
        talk("Revenire SUNET !")
    End Sub

    Private Sub unmute_b_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unmute_b.Click
        If sunet = 1 Then
            sunet = 0
        End If
        unmute_b.Hide()
        mute_b.Show()
        talk("Fara sunet !")
    End Sub
    Function talk(ByVal text)
        If sunet = 1 Then
            Dim SAPI
            SAPI = CreateObject("SAPI.spvoice")
            SAPI.Speak(text)
        End If
        Return 0
    End Function
    Private PlaySound As New System.Media.SoundPlayer

    Public Sub PlaySoundFile(ByVal SoundPath As String)
        PlaySound.SoundLocation = SoundPath
        PlaySound.Load()
        PlaySound.Play()
    End Sub
    Function soundPlay(ByVal sounda)
        If sunet = 1 Then
            PlaySoundFile(sounda)
        End If
        Return 0
    End Function
    Function Sunet_fisier_verificat()
        Try
            Dim dir As New IO.DirectoryInfo(Application.StartupPath() & "\Sounds")
            Dim finf As IO.FileInfo() = dir.GetFiles()
            Dim fc As Integer = 0
            For Each dra In finf
                fc += 1
            Next
            If fc >= 5 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Function Pict_fisier_verificat()
        Try
            Dim dir As New IO.DirectoryInfo(Application.StartupPath() & "\Cards")
            Dim finf As IO.FileInfo() = dir.GetFiles()
            Dim fc As Integer = 0
            For Each dra In finf
                fc += 1
            Next
            If fc >= 20 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Private mouseOffset As Point
    Private isMouseDown As Boolean = False
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, _
    ByVal e As MouseEventArgs) Handles MyBase.MouseDown, PictureBox1.MouseDown
        Dim xOffset As Integer
        Dim yOffset As Integer
        If e.Button = MouseButtons.Left Then
            xOffset = -e.X - SystemInformation.FrameBorderSize.Width
            yOffset = -e.Y - SystemInformation.CaptionHeight - _
            SystemInformation.FrameBorderSize.Height
            mouseOffset = New Point(xOffset, yOffset)
            isMouseDown = True
        End If
    End Sub
    Private Sub PictureBox1_MouseMove(ByVal sender As Object, _
    ByVal e As MouseEventArgs) Handles MyBase.MouseMove, PictureBox1.MouseMove
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Location = mousePos
        End If
    End Sub
    Private Sub PictureBox1_MouseUp(ByVal sender As Object, _
    ByVal e As MouseEventArgs) Handles MyBase.MouseUp, PictureBox1.MouseUp
        ' Changes the isMouseDown field so that the form does
        ' not move unless the user is pressing the left mouse button.
        If e.Button = MouseButtons.Left Then
            isMouseDown = False
        End If
    End Sub

    
End Class
