﻿#region Using directives

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Celeste_Launcher_Gui.Helpers;
using Celeste_Launcher_Gui.Properties;

#endregion

namespace Celeste_Launcher_Gui.Controls
{
    // [Designer(typeof(MyCustomControlDesigner1))]
    public partial class MainContainer : UserControl
    {
        public bool MinimizeBox { get; set; }

        public MainContainer()
        {
            InitializeComponent();

            ////Set Skin
            //TopLeftFixed.BackgroundImage = CustomSkinMainContainer.TopLeftFixed;
            //TopRigthFixed.BackgroundImage = CustomSkinMainContainer.TopRigthFixed;
            //TopMiddleFluid.BackgroundImage = CustomSkinMainContainer.TopMiddleFluid;

            //Configure Fonts
            SkinHelper.SetFont(Controls);
        }

        // ReSharper disable once ConvertToAutoProperty
        //public Panel ContainerPanel => panel9;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ParentForm?.Close();
        }

        private void MoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            SkinHelper.ReleaseCapture();
            var findForm = ((Control) sender).FindForm();
            if (findForm != null)
                SkinHelper.SendMessage(findForm.Handle, SkinHelper.WM_NCLBUTTONDOWN, SkinHelper.HT_CAPTION, 0);
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_Close.Image = Resources.XButton_Hover;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.Image = Resources.XButton_Normal;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if(ParentForm != null)
                ParentForm.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.MinimizeButtonHover;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.MinimizeButtonNormal;
        }

        private void MainContainer_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = MinimizeBox;
        }
    }

    public static class CustomSkinMainContainer
    {
        private static Image _topLeftFixed;

        private static Image _topRigthFixed;

        private static Image _topMiddleFluid;

        public static Image TopLeftFixed
        {
            get
            {
                if (_topLeftFixed != null)
                    return _topLeftFixed;

                _topLeftFixed = File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}Skin\\TopLeftFixed.png")
                    ? Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}Skin\\TopLeftFixed.png")
                    : Resources.TopLeftFixed;
                return _topLeftFixed;
            }
            set => _topLeftFixed = value;
        }

        public static Image TopRigthFixed
        {
            get
            {
                if (_topRigthFixed != null)
                    return _topRigthFixed;

                _topRigthFixed = File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}Skin\\TopRigthFixed.png")
                    ? Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}Skin\\TopRigthFixed.png")
                    : Resources.TopRigthFixed;
                return _topRigthFixed;
            }
            set => _topRigthFixed = value;
        }

        public static Image TopMiddleFluid
        {
            get
            {
                if (_topMiddleFluid != null)
                    return _topMiddleFluid;

                _topMiddleFluid = File.Exists($"{AppDomain.CurrentDomain.BaseDirectory}Skin\\TopMiddleFluid.png")
                    ? Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}Skin\\TopMiddleFluid.png")
                    : Resources.TopMiddleFluid;
                return _topMiddleFluid;
            }
            set => _topMiddleFluid = value;
        }
    }

    //public class MyCustomControlDesigner1 : ParentControlDesigner
    //{
    //    public override void Initialize(IComponent component)
    //    {
    //        base.Initialize(component);

    //        var control = Control as MainContainer;
    //        if (control != null)
    //            EnableDesignMode(control.ContainerPanel, "WorkingArea");
    //    }
    //}
}