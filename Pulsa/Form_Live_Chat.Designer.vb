<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Live_Chat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Live_Chat))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NoLive = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LBLUser1 = New System.Windows.Forms.Label()
        Me.LBLUser2 = New System.Windows.Forms.Label()
        Me.LBLAdmin1 = New System.Windows.Forms.Label()
        Me.LBLAdmin2 = New System.Windows.Forms.Label()
        Me.LBLAdmin3 = New System.Windows.Forms.Label()
        Me.LBLUser3 = New System.Windows.Forms.Label()
        Me.MsgUser3 = New System.Windows.Forms.RichTextBox()
        Me.MsgAdmin1 = New System.Windows.Forms.RichTextBox()
        Me.MsgUser1 = New System.Windows.Forms.RichTextBox()
        Me.MsgAdmin2 = New System.Windows.Forms.RichTextBox()
        Me.MsgAdmin3 = New System.Windows.Forms.RichTextBox()
        Me.MsgUser2 = New System.Windows.Forms.RichTextBox()
        Me.MessageBox = New System.Windows.Forms.RichTextBox()
        Me.TombolKirim = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.NoLive)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 46)
        Me.Panel1.TabIndex = 1
        '
        'NoLive
        '
        Me.NoLive.AutoSize = True
        Me.NoLive.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoLive.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.NoLive.Location = New System.Drawing.Point(646, 25)
        Me.NoLive.Name = "NoLive"
        Me.NoLive.Size = New System.Drawing.Size(53, 18)
        Me.NoLive.TabIndex = 4
        Me.NoLive.Text = "NoLive"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Location = New System.Drawing.Point(607, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label3.Location = New System.Drawing.Point(7, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(239, 18)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "AnjayUI Costumer Service Live Chat"
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.Pulsa.My.Resources.Resources.icon_close_putih
        Me.PictureBox1.Location = New System.Drawing.Point(772, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.LBLUser1)
        Me.Panel2.Controls.Add(Me.LBLUser2)
        Me.Panel2.Controls.Add(Me.LBLAdmin1)
        Me.Panel2.Controls.Add(Me.LBLAdmin2)
        Me.Panel2.Controls.Add(Me.LBLAdmin3)
        Me.Panel2.Controls.Add(Me.LBLUser3)
        Me.Panel2.Controls.Add(Me.MsgUser3)
        Me.Panel2.Controls.Add(Me.MsgAdmin1)
        Me.Panel2.Controls.Add(Me.MsgUser1)
        Me.Panel2.Controls.Add(Me.MsgAdmin2)
        Me.Panel2.Controls.Add(Me.MsgAdmin3)
        Me.Panel2.Controls.Add(Me.MsgUser2)
        Me.Panel2.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(12, 62)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(776, 376)
        Me.Panel2.TabIndex = 2
        '
        'LBLUser1
        '
        Me.LBLUser1.AutoSize = True
        Me.LBLUser1.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUser1.Location = New System.Drawing.Point(689, 63)
        Me.LBLUser1.Name = "LBLUser1"
        Me.LBLUser1.Size = New System.Drawing.Size(75, 18)
        Me.LBLUser1.TabIndex = 4
        Me.LBLUser1.Text = "Username"
        Me.LBLUser1.Visible = False
        '
        'LBLUser2
        '
        Me.LBLUser2.AutoSize = True
        Me.LBLUser2.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUser2.Location = New System.Drawing.Point(689, 173)
        Me.LBLUser2.Name = "LBLUser2"
        Me.LBLUser2.Size = New System.Drawing.Size(75, 18)
        Me.LBLUser2.TabIndex = 4
        Me.LBLUser2.Text = "Username"
        Me.LBLUser2.Visible = False
        '
        'LBLAdmin1
        '
        Me.LBLAdmin1.AutoSize = True
        Me.LBLAdmin1.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAdmin1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBLAdmin1.Location = New System.Drawing.Point(12, 7)
        Me.LBLAdmin1.Name = "LBLAdmin1"
        Me.LBLAdmin1.Size = New System.Drawing.Size(109, 18)
        Me.LBLAdmin1.TabIndex = 4
        Me.LBLAdmin1.Text = "Admin AnjayUI"
        '
        'LBLAdmin2
        '
        Me.LBLAdmin2.AutoSize = True
        Me.LBLAdmin2.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAdmin2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBLAdmin2.Location = New System.Drawing.Point(11, 117)
        Me.LBLAdmin2.Name = "LBLAdmin2"
        Me.LBLAdmin2.Size = New System.Drawing.Size(109, 18)
        Me.LBLAdmin2.TabIndex = 4
        Me.LBLAdmin2.Text = "Admin AnjayUI"
        Me.LBLAdmin2.Visible = False
        '
        'LBLAdmin3
        '
        Me.LBLAdmin3.AutoSize = True
        Me.LBLAdmin3.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAdmin3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBLAdmin3.Location = New System.Drawing.Point(11, 227)
        Me.LBLAdmin3.Name = "LBLAdmin3"
        Me.LBLAdmin3.Size = New System.Drawing.Size(109, 18)
        Me.LBLAdmin3.TabIndex = 4
        Me.LBLAdmin3.Text = "Admin AnjayUI"
        Me.LBLAdmin3.Visible = False
        '
        'LBLUser3
        '
        Me.LBLUser3.AutoSize = True
        Me.LBLUser3.Font = New System.Drawing.Font("Berlin Sans FB", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUser3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBLUser3.Location = New System.Drawing.Point(689, 283)
        Me.LBLUser3.Name = "LBLUser3"
        Me.LBLUser3.Size = New System.Drawing.Size(75, 18)
        Me.LBLUser3.TabIndex = 4
        Me.LBLUser3.Text = "Username"
        Me.LBLUser3.Visible = False
        '
        'MsgUser3
        '
        Me.MsgUser3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MsgUser3.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgUser3.Location = New System.Drawing.Point(417, 301)
        Me.MsgUser3.Name = "MsgUser3"
        Me.MsgUser3.ReadOnly = True
        Me.MsgUser3.Size = New System.Drawing.Size(347, 55)
        Me.MsgUser3.TabIndex = 1
        Me.MsgUser3.Text = ""
        Me.MsgUser3.Visible = False
        '
        'MsgAdmin1
        '
        Me.MsgAdmin1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MsgAdmin1.Enabled = False
        Me.MsgAdmin1.Location = New System.Drawing.Point(12, 26)
        Me.MsgAdmin1.Name = "MsgAdmin1"
        Me.MsgAdmin1.ReadOnly = True
        Me.MsgAdmin1.Size = New System.Drawing.Size(336, 55)
        Me.MsgAdmin1.TabIndex = 0
        Me.MsgAdmin1.Text = "Halo apakah ada yang bisa saya bantu?"
        '
        'MsgUser1
        '
        Me.MsgUser1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MsgUser1.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgUser1.Location = New System.Drawing.Point(417, 81)
        Me.MsgUser1.Name = "MsgUser1"
        Me.MsgUser1.ReadOnly = True
        Me.MsgUser1.Size = New System.Drawing.Size(347, 55)
        Me.MsgUser1.TabIndex = 0
        Me.MsgUser1.Text = ""
        Me.MsgUser1.Visible = False
        '
        'MsgAdmin2
        '
        Me.MsgAdmin2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MsgAdmin2.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgAdmin2.Location = New System.Drawing.Point(12, 136)
        Me.MsgAdmin2.Name = "MsgAdmin2"
        Me.MsgAdmin2.ReadOnly = True
        Me.MsgAdmin2.Size = New System.Drawing.Size(336, 55)
        Me.MsgAdmin2.TabIndex = 0
        Me.MsgAdmin2.Text = ""
        Me.MsgAdmin2.Visible = False
        '
        'MsgAdmin3
        '
        Me.MsgAdmin3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MsgAdmin3.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgAdmin3.Location = New System.Drawing.Point(12, 246)
        Me.MsgAdmin3.Name = "MsgAdmin3"
        Me.MsgAdmin3.ReadOnly = True
        Me.MsgAdmin3.Size = New System.Drawing.Size(336, 55)
        Me.MsgAdmin3.TabIndex = 0
        Me.MsgAdmin3.Text = ""
        Me.MsgAdmin3.Visible = False
        '
        'MsgUser2
        '
        Me.MsgUser2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MsgUser2.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgUser2.Location = New System.Drawing.Point(417, 191)
        Me.MsgUser2.Name = "MsgUser2"
        Me.MsgUser2.ReadOnly = True
        Me.MsgUser2.Size = New System.Drawing.Size(347, 55)
        Me.MsgUser2.TabIndex = 0
        Me.MsgUser2.Text = ""
        Me.MsgUser2.Visible = False
        '
        'MessageBox
        '
        Me.MessageBox.Font = New System.Drawing.Font("Open Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageBox.Location = New System.Drawing.Point(12, 457)
        Me.MessageBox.Name = "MessageBox"
        Me.MessageBox.Size = New System.Drawing.Size(659, 43)
        Me.MessageBox.TabIndex = 1
        Me.MessageBox.Text = ""
        '
        'TombolKirim
        '
        Me.TombolKirim.BackColor = System.Drawing.Color.AliceBlue
        Me.TombolKirim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TombolKirim.Location = New System.Drawing.Point(677, 457)
        Me.TombolKirim.Name = "TombolKirim"
        Me.TombolKirim.Size = New System.Drawing.Size(108, 43)
        Me.TombolKirim.TabIndex = 4
        Me.TombolKirim.Text = "Kirim"
        Me.TombolKirim.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Form_Live_Chat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(800, 525)
        Me.Controls.Add(Me.TombolKirim)
        Me.Controls.Add(Me.MessageBox)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Live_Chat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anjay UI"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents MsgUser3 As RichTextBox
    Friend WithEvents MsgAdmin1 As RichTextBox
    Friend WithEvents MsgUser1 As RichTextBox
    Friend WithEvents MsgAdmin2 As RichTextBox
    Friend WithEvents MsgAdmin3 As RichTextBox
    Friend WithEvents MsgUser2 As RichTextBox
    Friend WithEvents MessageBox As RichTextBox
    Friend WithEvents TombolKirim As Button
    Friend WithEvents LBLUser1 As Label
    Friend WithEvents LBLUser2 As Label
    Friend WithEvents LBLAdmin1 As Label
    Friend WithEvents LBLAdmin2 As Label
    Friend WithEvents LBLAdmin3 As Label
    Friend WithEvents LBLUser3 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents NoLive As Label
    Friend WithEvents Label1 As Label
End Class
