using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGMVunpack
{
    public partial class Form1 : Form
    {
        Unpacker unpack = new Unpacker();
        public static string textToTextField;
        public Form1()
        {
            InitializeComponent();
        }


        #region Menu "File"

        /// <summary>
        /// Диалог открытия json-файла с требуемым ключом для расшифровки файлов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadSystemjsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Диалог открытия файла. По умолчанию каталогом является корень диска C:\
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "System JSON (System.json)|System.json"; //Не даем открыть никакой другой файл, кроме требуемого. А то ошибок дохера будет.
            openFileDialog1.Title = "Open System.JSON file... ";
            openFileDialog1.RestoreDirectory = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                GlobalVars.jsPath = openFileDialog1.FileName;
                unpack.OpenSystemJson(GlobalVars.jsPath);
                KeyField.Text = GlobalVars.encryptionKey;
            }
            else
                return;

            //Меняем надписи для определения зашифрованности файлов.
            audioLabelChange();
            imagesLabelChange();
        }

        /// <summary>
        /// Диалог открытия файлов, которые нужно будет расшифровать. Попутно делает дополнительную проверку поля ключа.
        /// И здесь есть проблема. Хорошо бы добавить возможность Drag&Drop для большего удобства, но, блин, если какой-нибудь
        /// долбаеб перетащит какой-нибудь левый файл, то все крашнется с эксепшеном. Его, конечно, можно обработать, но код итак 
        /// разросся до совершенно неприличных размеров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFilesStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalVars.encryptionKey = KeyField.Text;
            audioLabelChange();
            imagesLabelChange();


            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Диалог открытия файла. По умолчанию каталогом является корень диска C:\
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "Encrypted images (*.rpgmvp)|*.rpgmvp|Encrypted audio (*.rpgmvo)|*.rpgmvo"; //Не даем открыть никакой другой файл, кроме требуемого. А то ошибок дохера будет.
            openFileDialog1.Title = "Open files to encrypt... ";
            openFileDialog1.RestoreDirectory = false;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in openFileDialog1.FileNames)
                {
                    FileList.Items.Add(filename, true);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitFileDialog();
        }


        /// <summary>
        /// Отображает диалог выхода из программы.
        /// </summary>
        private void exitFileDialog()
        {
            DialogResult ExitQuestion = MessageBox.Show("Are you sure you want to exit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (ExitQuestion == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
                return;
        }
        #endregion

        public void KeyField_TextChanged(object sender, EventArgs e)
        {
        }

        #region Labels just for beauty
        private void labelImagesEncrypted_Click(object sender, EventArgs e)
        {
            imagesLabelChange();

        }

        private void imagesLabelChange()
        {
            labelImagesEncrypted.Text = "Unknown";
            labelImagesEncrypted.ForeColor = Color.Black;

            if (GlobalVars._hasImg) //Если изображения зашифрованы
            {
                labelImagesEncrypted.Font = new Font(labelImagesEncrypted.Font, FontStyle.Bold);
                labelImagesEncrypted.Text = "Encrypted";
                labelImagesEncrypted.ForeColor = Color.DarkRed;
            }
            else
            {
                labelImagesEncrypted.Font = new Font(labelImagesEncrypted.Font, FontStyle.Bold);
                labelImagesEncrypted.Text = "Not Encrypted";
                labelImagesEncrypted.ForeColor = Color.DarkGreen;
            }
        }

        private void labelAudioEncrypted_Click(object sender, EventArgs e)
        {
            audioLabelChange();
        }

        private void audioLabelChange()
        {
            labelAudioEncrypted.Text = "Unknown";
            labelAudioEncrypted.ForeColor = Color.Black;
            if (GlobalVars._hasAudio) //Если аудио зашифровано
            {
                labelAudioEncrypted.Font = new Font(labelImagesEncrypted.Font, FontStyle.Bold);
                labelAudioEncrypted.Text = "Encrypted";
                labelAudioEncrypted.ForeColor = Color.DarkRed;
            }
            else
            {
                labelAudioEncrypted.Font = new Font(labelImagesEncrypted.Font, FontStyle.Bold);
                labelAudioEncrypted.Text = "Not Encrypted";
                labelAudioEncrypted.ForeColor = Color.DarkGreen;
            }
        }
        #endregion

        #region Menu "?"
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", GlobalVars.helpPath); //Открываем Хелп из файла в блокноте.
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", GlobalVars.aboutPath); //То же с "о программе"
        }
        #endregion

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            string _folder = unpack.createDir(GlobalVars.path);

            foreach (string fileName in FileList.Items)
            {
                if (GlobalVars.regex1.IsMatch(fileName)) //Если это зашифрованная картинка
                {
                    unpack.decryptImg(fileName, _folder); //Вызываем метод расшифровки картинок
                }
                else if (GlobalVars.regex2.IsMatch(fileName)) //Иначе если это зашифрованное аудио формата *.ogg
                {
                    unpack.decryptAudio(fileName, _folder); //Расшифровываем его
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
