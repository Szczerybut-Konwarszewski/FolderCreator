' folder_creator application
'
' Project title: folder_creator
' Author: Szczerybut Konwarszewski
' Description: Simple application which allows users to create empty folders within folder, may be used as a cipher locker game
' Date: 17-05-2017
' 

Public Class folder_creator

    ''''''''''''''' PUBLIC VARIABLES DECLARATION '''''''''''''''
    Dim tBox_folders_per_level_text As String
    Dim tBox_folders_per_lvl_number As Integer

    Dim tBox_lvls_of_list_text As String
    Dim tBox_lvls_of_list_number As Integer

    Dim counter As Integer = tBox_lvls_of_list_number
    Dim i As Integer
    Dim final_number_of_lvls = tBox_lvls_of_list_number
    Dim gCounter As Integer = 1

    Dim alert_Buttons = MessageBoxButtons.YesNo
    Dim strFileName As String



    ''''''''''''''' PUBLIC FUNCTIONS DECLARATION '''''''''''''''

    ' 2. Checking for input mistakes
    Function is_tBox_correct(dec_tBox_list_lvl_text)

        ' declare values
        Dim logResult
        Dim castInput = dec_tBox_list_lvl_text

        ' check what boolean value should be returned
        If IsNothing(castInput) Then
            logResult = True
            MsgBox("Your query can't be empty")
        ElseIf Not IsNumeric(castInput) Then
            logResult = True
            MsgBox("Your query can't contain string value")
        ElseIf IsNumeric(castInput) Then
            logResult = False
        Else
            MsgBox("An unknown error has occured. Please, try again")
        End If

        Return logResult
    End Function


    ' 3. Parsing values
    Sub parse_folders_per_lvl_values(dec_tBox_list_lvl_text)
        'Parsing values to numbers
        tBox_folders_per_lvl_number = Integer.Parse(dec_tBox_list_lvl_text)
    End Sub

    Sub parse_lvls_of_list_values(dec_tBox_list_lvl_text)
        'Parsing values to numbers
        tBox_lvls_of_list_number = Integer.Parse(dec_tBox_list_lvl_text)
    End Sub

    ' 5. Background for creating directories
    Public Sub open_Directories(dec_tBox_folders_per_lvl)

        'opening file dialog to specify the path

        Dim fd As FolderBrowserDialog = New FolderBrowserDialog()

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.SelectedPath
        End If
        fd.ShowNewFolderButton = True

        MsgBox("File path directory you selected is " & strFileName)

        'all directories and its subdirectories are about to be created

        nestedLooping(dec_tBox_folders_per_lvl)

        MsgBox("You succesfully managed to create " & counter & " folders. ",, "Folders HAVE been created")
    End Sub

    ' 6 Here loops are generated
    Sub nestedLooping(dec_tBox_folders_per_lvl)

        For i1 As Integer = 1 To dec_tBox_folders_per_lvl
            For i2 As Integer = 1 To dec_tBox_folders_per_lvl
                For i3 As Integer = 1 To dec_tBox_folders_per_lvl
                    For i4 As Integer = 1 To dec_tBox_folders_per_lvl
                        For i5 As Integer = 1 To dec_tBox_folders_per_lvl
                            IO.Directory.CreateDirectory(strFileName & "\" & i1 & "\" & i2 & "\" & i3 & "\" & i4 & "\" & i5)
                            counter += 1
                        Next i5
                        IO.Directory.CreateDirectory(strFileName & "\" & i1 & "\" & i2 & "\" & i3 & "\" & i4)
                        counter += 1
                    Next i4
                    IO.Directory.CreateDirectory(strFileName & "\" & i1 & "\" & i2 & "\" & i3)
                    counter += 1
                Next i3
                IO.Directory.CreateDirectory(strFileName & "\" & i1 & "\" & i2)
                counter += 1
            Next i2
            IO.Directory.CreateDirectory(strFileName & "\" & i1)
            counter += 1
        Next i1
    End Sub

    ' 4. Opening file prompt to ensure user that he's/she's aware of what may happen if app is misused
    Sub when_Tbox_values_are_correct()
        ' This part of code is going to be executed when above forms are fulfilled
        Dim alertMsg = "This activity is going to make irrevertible changes in your system (new set of folder is about to be created). Anyway, would you like to continue? If you're sure, click OK. If not, click cancel to avoid unwanted changes"

        Dim response = MsgBox(alertMsg, alert_Buttons, "Would you like to continue?")

        If response = MsgBoxResult.Yes Then
            ' creating folders stuff
            open_Directories(tBox_folders_per_lvl_number)
        Else
            MsgBox("Unfortunately, folders could not be created",, "Folders HAVE NOT been created")
        End If
    End Sub

    ' 1. Submitting entered values
    Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ' PRIVATE SUB VARIABLES DECLARATION
        Dim Tbox1BoolResult = is_tBox_correct(tBox_folders_per_level_text)
        Dim Tbox2BoolResult = is_tBox_correct(tBox_lvls_of_list_text)
        ' is_tBox_empty. This one checks
        If Tbox1BoolResult = True Or Tbox2BoolResult = True Then
            ' Do-nothing
        Else
            parse_folders_per_lvl_values(tBox_folders_per_level_text)
            parse_lvls_of_list_values(tBox_lvls_of_list_text)
            when_Tbox_values_are_correct()
        End If

    End Sub

    ' A. Here you insert folders per level
    Function tBox_list_levels_TextChanged(sender As Object, e As EventArgs) Handles tBox_folders_per_level.TextChanged
        ' Grabbing value from a textBox
        tBox_folders_per_level_text = tBox_folders_per_level.Text
        Return tBox_folders_per_level_text
    End Function

    ' B. Here you insert number of levels
    Function TextBox1_TextChanged(sender As Object, e As EventArgs) Handles tBox_lvls_of_list.TextChanged
        ' Grabbing value from a textBox
        tBox_lvls_of_list_text = tBox_lvls_of_list.Text
        Return tBox_lvls_of_list_text
    End Function


    ''''''''''''''' MAIN FUNCTION '''''''''''''''
    Public Sub Main()

    End Sub

End Class

