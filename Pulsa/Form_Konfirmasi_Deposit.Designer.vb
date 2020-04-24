<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Konfirmasi_Deposit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Konfirmasi_Deposit))
        Me.LBLNoDeposit = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LBLStatusDeposit = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LBLWaktuPembayaran = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LBLTotalDeposit = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBLNomorS = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LBLNomor = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBLNoDeposit
        '
        Me.LBLNoDeposit.AutoSize = True
        Me.LBLNoDeposit.Font = New System.Drawing.Font("Berlin Sans FB", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNoDeposit.Location = New System.Drawing.Point(233, 270)
        Me.LBLNoDeposit.Name = "LBLNoDeposit"
        Me.LBLNoDeposit.Size = New System.Drawing.Size(117, 19)
        Me.LBLNoDeposit.TabIndex = 3
        Me.LBLNoDeposit.Text = "Nomor Deposit"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(64, 269)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Nomor Deposit            :"
        '
        'LBLStatusDeposit
        '
        Me.LBLStatusDeposit.AutoSize = True
        Me.LBLStatusDeposit.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLStatusDeposit.Location = New System.Drawing.Point(233, 223)
        Me.LBLStatusDeposit.Name = "LBLStatusDeposit"
        Me.LBLStatusDeposit.Size = New System.Drawing.Size(158, 20)
        Me.LBLStatusDeposit.TabIndex = 5
        Me.LBLStatusDeposit.Text = "Menunggu Konfirmasi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(68, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Status Deposit            :"
        '
        'LBLWaktuPembayaran
        '
        Me.LBLWaktuPembayaran.AutoSize = True
        Me.LBLWaktuPembayaran.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLWaktuPembayaran.Location = New System.Drawing.Point(233, 179)
        Me.LBLWaktuPembayaran.Name = "LBLWaktuPembayaran"
        Me.LBLWaktuPembayaran.Size = New System.Drawing.Size(140, 20)
        Me.LBLWaktuPembayaran.TabIndex = 7
        Me.LBLWaktuPembayaran.Text = "Waktu Pembayaran"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(59, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Waktu Pembayaran    :"
        '
        'LBLTotalDeposit
        '
        Me.LBLTotalDeposit.AutoSize = True
        Me.LBLTotalDeposit.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTotalDeposit.Location = New System.Drawing.Point(233, 138)
        Me.LBLTotalDeposit.Name = "LBLTotalDeposit"
        Me.LBLTotalDeposit.Size = New System.Drawing.Size(98, 20)
        Me.LBLTotalDeposit.TabIndex = 9
        Me.LBLTotalDeposit.Text = "Total Deposit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(65, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Total Deposit                :"
        '
        'LBLNomorS
        '
        Me.LBLNomorS.AutoSize = True
        Me.LBLNomorS.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNomorS.Location = New System.Drawing.Point(233, 99)
        Me.LBLNomorS.Name = "LBLNomorS"
        Me.LBLNomorS.Size = New System.Drawing.Size(56, 20)
        Me.LBLNomorS.TabIndex = 11
        Me.LBLNomorS.Text = "Nomor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(125, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(359, 30)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Konfirmasi Transaksi Deposit Anda"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.Location = New System.Drawing.Point(154, 372)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 40)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Batal"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button1.Location = New System.Drawing.Point(308, 372)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 40)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Konfirmasi"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(408, 97)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 191)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'LBLNomor
        '
        Me.LBLNomor.AutoSize = True
        Me.LBLNomor.Font = New System.Drawing.Font("Berlin Sans FB", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNomor.Location = New System.Drawing.Point(149, 102)
        Me.LBLNomor.Name = "LBLNomor"
        Me.LBLNomor.Size = New System.Drawing.Size(0, 17)
        Me.LBLNomor.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(98, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 18)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Nomor               :"
        '
        'Form_Konfirmasi_Deposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(654, 450)
        Me.Controls.Add(Me.LBLNomor)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LBLNoDeposit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LBLStatusDeposit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBLWaktuPembayaran)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LBLTotalDeposit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBLNomorS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Konfirmasi_Deposit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "v"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LBLNoDeposit As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LBLStatusDeposit As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LBLWaktuPembayaran As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LBLTotalDeposit As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LBLNomorS As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LBLNomor As Label
    Friend WithEvents Label10 As Label
End Class
