<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Konfirmasi_Transaksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Konfirmasi_Transaksi))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LBLNoTujuan = New System.Windows.Forms.Label()
        Me.LBLTotalPembayaran = New System.Windows.Forms.Label()
        Me.LBLWaktuPembayaran = New System.Windows.Forms.Label()
        Me.LBLStatusPembayaran = New System.Windows.Forms.Label()
        Me.LBLNoPembayaran = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Source Sans Pro", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(165, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(277, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Konfirmasi Transaksi Anda"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nomor Tujuan :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(80, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Total Pembayaran :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(70, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(147, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Waktu Pembayaran :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(70, 209)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Status Pembayaran :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(66, 257)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(151, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Nomor Pembayaran :"
        '
        'LBLNoTujuan
        '
        Me.LBLNoTujuan.AutoSize = True
        Me.LBLNoTujuan.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNoTujuan.Location = New System.Drawing.Point(235, 85)
        Me.LBLNoTujuan.Name = "LBLNoTujuan"
        Me.LBLNoTujuan.Size = New System.Drawing.Size(106, 20)
        Me.LBLNoTujuan.TabIndex = 0
        Me.LBLNoTujuan.Text = "Nomor Tujuan"
        '
        'LBLTotalPembayaran
        '
        Me.LBLTotalPembayaran.AutoSize = True
        Me.LBLTotalPembayaran.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTotalPembayaran.Location = New System.Drawing.Point(235, 124)
        Me.LBLTotalPembayaran.Name = "LBLTotalPembayaran"
        Me.LBLTotalPembayaran.Size = New System.Drawing.Size(131, 20)
        Me.LBLTotalPembayaran.TabIndex = 0
        Me.LBLTotalPembayaran.Text = "Total Pembayaran"
        '
        'LBLWaktuPembayaran
        '
        Me.LBLWaktuPembayaran.AutoSize = True
        Me.LBLWaktuPembayaran.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLWaktuPembayaran.Location = New System.Drawing.Point(235, 165)
        Me.LBLWaktuPembayaran.Name = "LBLWaktuPembayaran"
        Me.LBLWaktuPembayaran.Size = New System.Drawing.Size(140, 20)
        Me.LBLWaktuPembayaran.TabIndex = 0
        Me.LBLWaktuPembayaran.Text = "Waktu Pembayaran"
        '
        'LBLStatusPembayaran
        '
        Me.LBLStatusPembayaran.AutoSize = True
        Me.LBLStatusPembayaran.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLStatusPembayaran.Location = New System.Drawing.Point(235, 209)
        Me.LBLStatusPembayaran.Name = "LBLStatusPembayaran"
        Me.LBLStatusPembayaran.Size = New System.Drawing.Size(158, 20)
        Me.LBLStatusPembayaran.TabIndex = 0
        Me.LBLStatusPembayaran.Text = "Menunggu Konfirmasi"
        '
        'LBLNoPembayaran
        '
        Me.LBLNoPembayaran.AutoSize = True
        Me.LBLNoPembayaran.Font = New System.Drawing.Font("Source Sans Pro", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNoPembayaran.Location = New System.Drawing.Point(235, 257)
        Me.LBLNoPembayaran.Name = "LBLNoPembayaran"
        Me.LBLNoPembayaran.Size = New System.Drawing.Size(144, 20)
        Me.LBLNoPembayaran.TabIndex = 0
        Me.LBLNoPembayaran.Text = "Nomor Pembayaran"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button1.Location = New System.Drawing.Point(310, 360)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 40)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Konfirmasi"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.Location = New System.Drawing.Point(156, 360)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 40)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Batal"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(410, 85)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(182, 191)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Form_Konfirmasi_Transaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(654, 450)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LBLNoPembayaran)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LBLStatusPembayaran)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LBLWaktuPembayaran)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LBLTotalPembayaran)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBLNoTujuan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Konfirmasi_Transaksi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anjay Reload"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LBLNoTujuan As Label
    Friend WithEvents LBLTotalPembayaran As Label
    Friend WithEvents LBLWaktuPembayaran As Label
    Friend WithEvents LBLStatusPembayaran As Label
    Friend WithEvents LBLNoPembayaran As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
