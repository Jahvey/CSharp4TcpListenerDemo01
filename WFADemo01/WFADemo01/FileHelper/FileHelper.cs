﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WFADemo01.FileHelper
{
    class FileHelper
    {

        private static readonly int _blockLength = 500 * 1024;


        /// <summary>
        /// 计算文件的hash值 
        /// </summary>
        internal string CalcFileHash(string FilePath)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash;


            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096))
            {
                hash = md5.ComputeHash(fs);
            }
            return BitConverter.ToString(hash);
        }
        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public bool SendFile(string filePath, NetworkStream stream)
        {
            //FileStream fs = File.Open(filePath, FileMode.Open);
            //int readLength = 0;
            //byte[] data = new byte[_blockLength];

            ////发送大小
            //byte[] length = new byte[8];
            //BitConverter.GetBytes(new FileInfo(filePath).Length).CopyTo(length, 0);
            //stream.Write(length, 0, 8);

            ////发送文件
            //while ((readLength = fs.Read(data, 0, _blockLength)) > 0)
            //{
            //    stream.Write(data, 0, readLength);
            //}
            //fs.Close();

            string FileName = System.IO.Path.GetFileName(filePath);

            byte[] fileNameByte = Encoding.Unicode.GetBytes(FileName);

            byte[] fileNameLengthForValueByte = Encoding.Unicode.GetBytes(fileNameByte.Length.ToString("D11"));
            byte[] fileAttributeByte = new byte[fileNameByte.Length + fileNameLengthForValueByte.Length];

            fileNameLengthForValueByte.CopyTo(fileAttributeByte, 0);  //文件名字符流的长度的字符流排在前面。

            fileNameByte.CopyTo(fileAttributeByte, fileNameLengthForValueByte.Length);  //紧接着文件名的字符流

            stream.Write(fileAttributeByte, 0, fileAttributeByte.Length);
            //TxtAddContent(filePathText.Text);
            FileStream fileStrem = new FileStream(filePath, FileMode.Open);

            int fileReadSize = 0;
            long fileLength = 0;
            while (fileLength < fileStrem.Length)
            {
                byte[] buffer = new byte[204800];
                fileReadSize = fileStrem.Read(buffer, 0, buffer.Length);
                stream.Write(buffer, 0, fileReadSize);
                fileLength += fileReadSize;

            }
            fileStrem.Flush();
            stream.Flush();
            fileStrem.Close();
            stream.Close();
            return true;
        }


        /// <summary>
        /// 接收文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public bool ReceiveFile(string filePath, NetworkStream stream)
        {


            //try
            //{
            //    long count = GetSize(stream);
            //    if (count == 0)
            //    {
            //        return false;
            //    }

            //    long index = 0;
            //    byte[] clientData = new byte[_blockLength];
            //    if (File.Exists(filePath))
            //    {
            //        File.Delete(filePath);
            //    }
            //    string path = new FileInfo(filePath).Directory.FullName;
            //    if (!Directory.Exists(path))
            //    {
            //        Directory.CreateDirectory(path);
            //    }

            //    FileStream fs = File.Open(filePath, FileMode.OpenOrCreate);
            //    try
            //    {
            //        //计算当前要读取的块的大小
            //        int currentBlockLength = 0;
            //        if (_blockLength < count - index)
            //        {
            //            currentBlockLength = _blockLength;
            //        }
            //        else
            //        {
            //            currentBlockLength = (int)(count - index);
            //        }

            //        int receivedBytesLen = stream.Read(clientData, 0, currentBlockLength);
            //        index += receivedBytesLen;
            //        fs.Write(clientData, 0, receivedBytesLen);

            //        while (receivedBytesLen > 0 && index < count)
            //        {
            //            clientData = new byte[_blockLength];
            //            receivedBytesLen =0;

            //            if (_blockLength < count - index)
            //            {
            //                currentBlockLength = _blockLength;
            //            }
            //            else
            //            {
            //                currentBlockLength = (int)(count - index);
            //            }
            //            receivedBytesLen = stream.Read(clientData, 0, currentBlockLength);
            //            index += receivedBytesLen;
            //            fs.Write(clientData, 0, receivedBytesLen);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        return false;
            //    }
            //    finally
            //    {
            //        fs.Close();
            //    }
            //}
            //catch (Exception ex)
            //{

            //    return false;
            //}


            byte[] fileNameLengthForValueByte = Encoding.Unicode.GetBytes((256).ToString("D11"));
            byte[] fileNameLengByte = new byte[102400];
            int fileNameLengthSize = stream.Read(fileNameLengByte, 0, fileNameLengthForValueByte.Length);
            string fileNameLength = Encoding.Unicode.GetString(fileNameLengByte, 0, fileNameLengthSize);
           // TxtReceiveAddContent("文件名字符流的长度为：" + fileNameLength);

            int fileNameLengthNum = Convert.ToInt32(fileNameLength);
            byte[] fileNameByte = new byte[fileNameLengthNum];

            int fileNameSize = stream.Read(fileNameByte, 0, fileNameLengthNum);
            string fileName = Encoding.Unicode.GetString(fileNameByte, 0, fileNameSize);
            
            //TxtReceiveAddContent("文件名为：" + fileName);

            // string dirPath = Application.StartupPath + "\\WebFile";
           // string dirPath = "C:\\WebFile";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            FileStream fileStream = new FileStream(filePath + "\\" + fileName, FileMode.Create, FileAccess.Write);
            try
            {
                int fileReadSize = 0;
                byte[] buffer = new byte[204800];
                while ((fileReadSize = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, fileReadSize);

                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                fileStream.Close();
            }
            return true;
        }



        /// <summary>
        /// 获取要读取的数据的大小
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private int GetSize(NetworkStream stream)
        {
            int count = 0;
            byte[] countBytes = new byte[8];
            try
            {
                if (stream.Read(countBytes, 0, 8) ==

8)
                {
                    count = BitConverter.ToInt32(countBytes, 0);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

            }
            return count;
        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public bool SendMessage(string message, NetworkStream stream)
        {

            byte[] data = Encoding.UTF8.GetBytes(message);
            byte[] resultData = new byte[8 + data.Length];
            BitConverter.GetBytes(data.Length).CopyTo(resultData,

0);
            data.CopyTo(resultData, 8);

            stream.Write(resultData, 0, resultData.Length);
            return true;
        }

        /// <summary>
        /// 读取消息
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public string ReadMessage(NetworkStream stream)
        {
            string result = "";
            int messageLength = 0;

            byte[] resultbyte = new byte[500 * 1024];
            //读取数据大小
            int index = 0;
            int count = GetSize(stream);

            byte[] data = new byte[count];
            while (index < count && (messageLength = stream.Read(data, 0, count - index)) != 0)
            {
                data.CopyTo(resultbyte, index);
                index += messageLength;
            }
            result = Encoding.UTF8.GetString(resultbyte, 0, index);
            return result;
        }
    }

}
