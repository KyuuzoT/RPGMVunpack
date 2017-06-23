using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace RPGMVunpack
{
    class Unpacker
    {
        private static string jsonToSerialize; //Для записи JSON-файла, который нужно сериализовать.
        private int iBytes = 0; //Для записи байтов шифрованного файла. Сам в шоке, что тип инт.
        //Первые два (по порядку) массива - для побайтовой записи зашифрованных файлов
        private byte[] bImgByteArray = null;
        private byte[] bAudioByteArray = null;
        private byte[] bDecodedArray = null; //Третий массив - для побайтовой записи расшифрованного файла и сохранения его на диск.
        private Int16 iHeaderSize = 16; //Реально в файле зашифрованы только 16 бит оригинального заголовка начиная с 16 (если считать с нуля.). До этого идет заголовок зашифрованного файла. 

        //Конструктор по умолчанию... Да-да, шарпы и конструкторы классов. Будто вернулся в плюсы.
        public Unpacker()
        {

        }

        /// <summary>
        /// Открываем json-файл, в котором содержится информация о ключе для криптования.
        /// </summary>
        /// <param name="path">Путь к json-файлу.</param>
        public void OpenSystemJson(string path)
        {
            //Открываем файл System.json выбраный пользователем.
            FileStream sjFile = new FileStream(GlobalVars.jsPath, FileMode.Open, FileAccess.Read);
            StreamReader sjFileReader = new StreamReader(sjFile);
           
            //Получаем строку JSON и сразу закрываем более не нужный ридер.
            jsonToSerialize = sjFileReader.ReadToEnd();
            sjFileReader.Close();

            //Используем десериализатор из библиотеки НьютонСофт.
            JSONSerializer systemJSON = JsonConvert.DeserializeObject<JSONSerializer>(jsonToSerialize);

            GlobalVars._hasImg = systemJSON.hasEncryptedImages;
            GlobalVars._hasAudio = systemJSON.hasEncryptedAudio;
            GlobalVars.encryptionKey = systemJSON.encryptionKey;
            
            for (int i = 0; i < systemJSON.encryptionKey.Length; i++)
            {
                GlobalVars.bEncryptionKey[i] = (byte)systemJSON.encryptionKey[i];
            }
                  
        }

        /// <summary>
        /// Создаем новый каталог по адресу программы.
        /// </summary>
        /// <param name="_filePath">Путь к папке программы</param>
        /// <returns>Возвращает путь к новой папке для сохранения дешифрованных файлов.</returns>
        public string createDir(string _filePath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_filePath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            return dirInfo.FullName;
        }

        /// <summary>
        /// Подготовка к расшифровке зашифрованной картинки, ее получение в расшифрованном виде и запись в файл в папке по пути _folder
        /// </summary>
        /// <param name="_filePath">Путь к зашифрованному файлу</param>
        /// <param name="_folder">Путь к папке для сохранения расшифрованного файла</param>
        public void decryptImg(string _filePath, string _folder)
        {
            FileStream imgFile = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            _folder = string.Concat(_folder, @"\Images");

            FileInfo fiImg = new FileInfo(_filePath); //Две строки - для получения имени файла без расширения
            string imgFileName = string.Concat(_folder, fiImg.Name, @".png");


            for (int i = 0; i < imgFile.Length; i++)
            {
                iBytes = imgFile.ReadByte(); //Вот почему бы методу ReadByte() не возвращать значение byte?
                                             //Так нет же, возвращает в инт. Логика? Не, не слышал.
                if (iBytes != -1) //-1 - всегда конец байт-строки
                {
                    bImgByteArray[i] = (byte)iBytes;
                }
            }
            imgFile.Close();
            iBytes = 0;
            File.WriteAllBytes(imgFileName, decryptData(bAudioByteArray));
        }


        /// <summary>
        /// Подготовка к расшифровке зашифрованного аудио-файла в формате *.ogg, его получение в расшифрованном виде и запись в
        /// файл в папке по пути, задаваемом переменной _folder
        /// </summary>
        /// <param name="_filePath">Путь к зашифрованному файлу, включая его имя и расширение</param>
        /// <param name="_folder">Путь к папке для сохранения расшифрованного аудио</param>
        public void decryptAudio(string _filePath, string _folder)
        {
            FileStream audioFile = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            _folder = string.Concat(_folder, @"\Audio");

            FileInfo fiAudio = new FileInfo(_filePath); //Извлекаем имя файла без расширения
            string audioFileName = string.Concat(_folder, fiAudio.Name, @".ogg");


            for (int i = 0; i < audioFile.Length; i++)
            {
                iBytes = audioFile.ReadByte(); //ReadByte считывает байт и перемещает положение чтения на 1 байт вперед.

                if (iBytes != -1)
                {
                    bAudioByteArray[i] = (byte)iBytes;
                }
            }
            audioFile.Close();
            iBytes = 0;
            File.WriteAllBytes(audioFileName, decryptData(bAudioByteArray));
        }

        public byte[] decryptData(byte [] _byteArray)
        {
            for (int i = 0; (i + iHeaderSize) <= _byteArray.Length; i++)
            {
                if (i < iHeaderSize)
                {
                    bDecodedArray[i] = (byte)(_byteArray[iHeaderSize + i] ^ GlobalVars.bEncryptionKey[i]);
                }
                else 
                {
                    bDecodedArray[i] = _byteArray[i + iHeaderSize];
                }
            }

            return bDecodedArray;
        }
    }
}
