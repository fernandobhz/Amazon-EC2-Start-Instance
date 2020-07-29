
Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Me.Cursor = Cursors.WaitCursor


            'Amazon end point (url) services by region
            'http://docs.aws.amazon.com/general/latest/gr/rande.
            'N. Virginia = ec2.us-east-1.amazonaws.com
            'São paulo = ec2.sa-east-1.amazonaws.com

            Dim EC2Config As New Amazon.EC2.AmazonEC2Config()
            EC2Config.WithServiceURL("http://ec2.sa-east-1.amazonaws.com")

            Dim Desenv1 As String = "xxx"
            Dim IP As String = "xxx"


            Dim EC2 As New Amazon.EC2.AmazonEC2Client("xxx", "xxx/AYmw2MOe", EC2Config)
            EC2.StartInstances(New Amazon.EC2.Model.StartInstancesRequest().WithInstanceId(Desenv1))

            'Da um tempinho para máquina iniciar
            System.Threading.Thread.Sleep(5000)

            Dim OK As Boolean = False

            While Not OK

                Try
                    EC2.AssociateAddress(New Amazon.EC2.Model.AssociateAddressRequest().WithPublicIp(IP).WithInstanceId(Desenv1))
                    OK = True
                Catch ex As Exception
                    System.Threading.Thread.Sleep(2000)
                End Try
            End While

            MsgBox("OK")

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Amazon end point (url) services by region
            'http://docs.aws.amazon.com/general/latest/gr/rande.
            'N. Virginia = ec2.us-east-1.amazonaws.com
            'São paulo = ec2.sa-east-1.amazonaws.com

            Dim EC2Config As New Amazon.EC2.AmazonEC2Config()
            EC2Config.WithServiceURL("http://ec2.sa-east-1.amazonaws.com")

            Dim Desenv1 As String = "xxx"

            Dim EC2 As New Amazon.EC2.AmazonEC2Client("xxx", "xxx/AYmw2MOe", EC2Config)



            If MsgBox("Forced?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                EC2.StopInstances(New Amazon.EC2.Model.StopInstancesRequest().WithInstanceId(Desenv1).WithForce(True))
            Else
                EC2.StopInstances(New Amazon.EC2.Model.StopInstancesRequest().WithInstanceId(Desenv1))
            End If

            'EC2.StartInstances(New Amazon.EC2.Model.StartInstancesRequest().WithInstanceId(Desenv1))

            MsgBox("OK")

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Amazon end point (url) services by region
            'http://docs.aws.amazon.com/general/latest/gr/rande.
            'N. Virginia = ec2.us-east-1.amazonaws.com
            'São paulo = ec2.sa-east-1.amazonaws.com

            Dim EC2Config As New Amazon.EC2.AmazonEC2Config()
            EC2Config.WithServiceURL("http://ec2.sa-east-1.amazonaws.com")

            Dim EC2 As New Amazon.EC2.AmazonEC2Client("xxx", "xxx", EC2Config)
            MsgBox(EC2.DescribeInstances(New Amazon.EC2.Model.DescribeInstancesRequest()).ToXML)

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class
